using Portal.Domain.Common.Interfaces.User;

namespace Portal.Domain.User.Career;

public class CareerSpecialization : ICareerSpecialization
{
    public string CareerSpecializationName { get; private set; } = null!;

    public IList<ICareerTitle> CareerTitles { get; private set; }

#pragma warning disable CS8618
    private CareerSpecialization() { }
#pragma warning restore CS8618

    private CareerSpecialization(string careerSpecializationName, IList<ICareerTitle> careerTitles) 
    {
        CareerSpecializationName = careerSpecializationName;
        CareerTitles = careerTitles;
    }
    public static CareerSpecialization Create(string careerSpecializationName, IList<ICareerTitle> careerTitles)
        => new(careerSpecializationName, careerTitles);
}
