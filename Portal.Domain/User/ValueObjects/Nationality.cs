namespace Portal.Domain.User.ValueObjects;

public class Nationality
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

#pragma warning disable CS8618
    private Nationality() { }
#pragma warning restore CS8618
    private Nationality(string name) 
    { 
        
        Name = name;
    }
    public static Nationality Create(string name)
        => new(name);

}
