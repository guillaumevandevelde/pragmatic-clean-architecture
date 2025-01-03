﻿using Bookify.Domain.Shared;
using Bookify.Domain.Shared.Entities;

namespace Bookify.Domain.Bookings.Entities;

public record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);