using System.Data;

namespace Bookify.Domain.Shared.Entities;

public record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");

    private Currency(string code) => Code = code;

    public string Code { get; init; }

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ??
               throw new DataException("The currency code is invalid");
    }

    private static readonly IReadOnlyCollection<Currency> All =
    [
        Usd,
        Eur
    ];
}