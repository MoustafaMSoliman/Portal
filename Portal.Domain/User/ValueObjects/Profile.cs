using Portal.Domain.Common.Enums;
using Portal.Domain.Common.Models;

namespace Portal.Domain.User.ValueObjects;

public class Profile : ValueObject
{
    public int Id { get; set; }
    public User User { get; set; } = null!;
    public string FirstName { get; private  set; } = null!;
    public string MiddleName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string ArabicName { get; private set; } = null!;
    public int NationalityId {  get; private set; }
    public Nationality Nationality { get; private set; }    
    public long NationalId { get; private set; }
    public Gender Gender { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string ContactNumber { get; private set; } = null!;
    public Address Address { get; private set; } = null!;

#pragma warning disable CS8618
    private Profile() { }
#pragma warning restore CS8618
    private Profile(string firstName,string middleName, string lastName, string arabicName,
        Nationality nationality, long nationalId, Gender gender,
        DateTime dateOfBirth, string contactNumber, Address address)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        ArabicName = arabicName;
        Nationality = nationality;
        NationalId = nationalId;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        ContactNumber = contactNumber;
        Address = address;
    }

    public static Profile Create(
       string firstName, string middleName, string lastName, string arabicName,
        Nationality nationality, long nationalId, Gender gender,
        DateTime dateOfBirth, string contactNumber, Address address)
        =>new(firstName, middleName, lastName, arabicName, nationality, nationalId, gender, dateOfBirth, contactNumber, address);

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
