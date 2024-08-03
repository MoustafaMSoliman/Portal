using Portal.Domain.Common.Interfaces.User;

namespace Portal.Domain.User.Career;

public class CareerTitle : ICareerTitle
{
    public string Title { get; private set; }

#pragma warning disable CS8618
    private CareerTitle() { }
#pragma warning restore CS8618
    private CareerTitle(string title)
    {
        Title = title;
    }
    public static CareerTitle Create(string title)
        =>new(title);   

}
