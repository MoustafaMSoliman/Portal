using Portal.Domain.Common.Models;

namespace Portal.Domain.User.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; protected set; } = null!;
    public string City { get; protected set; } = null!;
    public string State { get; protected set; } = null!;
    public string PostalCode { get; protected set; } = null!;
    public string Country { get; protected set; } = null!;

#pragma warning disable CS8618
    private Address() { }

#pragma warning restore CS8618

    private Address(string? street, string? city, string? state, string? postalCode, string? country)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }
    public static Address Create(string? street, string? city, string? state, string? postalCode, string? country)
        => new(street,city, state, postalCode, country);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return PostalCode;
        yield return Country;
    }
}
