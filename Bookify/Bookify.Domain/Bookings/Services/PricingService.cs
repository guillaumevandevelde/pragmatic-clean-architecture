using Bookify.Domain.Apartments.Entities;
using Bookify.Domain.Bookings.Entities;
using Bookify.Domain.Shared.Entities;

namespace Bookify.Domain.Bookings.Services;

public class PricingService
{
    public PricingDetails CalculatePrice(Apartment apartment, DateRange period)
    {
        var currency = apartment.Price.Currency;
        var priceForPeriod = new Money(
            apartment.Price.Amount * period.LengthInDays,
            currency
        );

        var percentUpCharge = apartment.Amenities.Sum(amenity => amenity switch
        {
            Amenity.GardenView or Amenity.MountainView => 0.05m,
            Amenity.AirConditioning => 0.01m,
            Amenity.Parking => 0.01m,
            _ => 0
        });

        var amenitiesUpCharge = Money.Zero();

        if (percentUpCharge > 0)
        {
            amenitiesUpCharge = new Money(
                priceForPeriod.Amount * percentUpCharge,
                currency
            );
        }
        
        var totalPrice = Money.Zero();
        totalPrice += priceForPeriod;
        
        if (!apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }
        
        totalPrice += amenitiesUpCharge;
        
        return new PricingDetails(
            priceForPeriod,
            apartment.CleaningFee,
            amenitiesUpCharge,
            totalPrice
        );
        
    }
    
}