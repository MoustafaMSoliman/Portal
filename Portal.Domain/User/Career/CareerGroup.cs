using Portal.Domain.Common.Interfaces.User;

namespace Portal.Domain.User.Career;

public class CareerGroup : ICareerGroup
{
    public string CareerGroupName { get; private set; } = null!;

    public IList<ICareerSpecialization> Specializations { get; private set; }

#pragma warning disable CS8618
    private CareerGroup() { }
#pragma warning restore CS8618
    private CareerGroup(string careerGroupName,IList<ICareerSpecialization> specializations)
    {
        CareerGroupName = careerGroupName;
        Specializations = specializations;  
    }
    public static CareerGroup Create(string careerGroupName, IList<ICareerSpecialization> specializations)
        => new(careerGroupName, specializations);
}
