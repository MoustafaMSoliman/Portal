using Portal.Domain.Common.Models;

namespace Portal.Domain.User.ValueObjects;

public class Profile : ValueObject
{
    public string FirstName { get; private  set; } = null!;
    public string LastName { get; private set; } = null!;
    public DateTime DateOfBirth { get; private set; }
    public string ContactNumber { get; private set; } = null!;
    public Address Address { get; private set; } = null!;

#pragma warning disable CS8618
    private Profile() { }
#pragma warning restore CS8618
    private Profile(string firstName, string lastName, DateTime dateOfBirth, string contactNumber, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        ContactNumber = contactNumber;
        Address = address;
    }

    public static Profile Create(string firstName, string lastName, DateTime dateOfBirth, string contactNumber, Address address)
        =>new(firstName, lastName, dateOfBirth, contactNumber, address);

    public void UpdateContactNumber(string contactNumber)
    {
        ContactNumber = contactNumber;
    }

    public void UpdateAddress(Address newAddress)
    {
        Address = newAddress;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
        yield return DateOfBirth;
        yield return ContactNumber;
        yield return Address;
    }
}
