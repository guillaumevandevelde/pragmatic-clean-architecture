using Bookify.Domain.Apartments.Entities;
using Bookify.Domain.Bookings.Entities;

namespace Bookify.Domain.Bookings.Services;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(
        Apartment apartment,
        DateRange duration,
        CancellationToken cancellationToken = default);

    void Add(Booking booking);
}