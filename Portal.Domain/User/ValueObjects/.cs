using Portal.Domain.Common.Errors;
using Portal.Domain.Common.Models;
using System.Text.RegularExpressions;

namespace Portal.Domain.User.ValueObjects;

public class Email : ValueObject
{

    private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            /*
            //   ^    -> the string beginning
            // [^@\s]+ -> one/more chars that isn't @ or white space
            //   @     -> @
            // [^@\s]+ -> one/more chars that isn't @ or white space
            //   \.    -> .
            // [^@\s]+ -> one/more chars that isn't @ or white space
            //   $    -> the string ending
            */
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
    /*
     RegexOptions.Compiled -> compile regular exp into assembly
     Regexoptions.IgnoreCase -> UpperCase or LowerCase doesn't matter.
     */
    public int Id { get; set; }
    public string Value { get; set; } = null!;
    public User User { get; set; }

#pragma warning disable CS8618
    private Email() { }
#pragma warning restore CS8618
    private Email(string value)
    {
          Value = value;
    }
    public static Email Create(string value)=>new(value);

    
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
