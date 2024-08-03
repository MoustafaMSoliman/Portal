namespace Portal.Domain.Common.Interfaces.User;

public interface ICareerGroup
{
    string CareerGroupName { get; }
    IList<ICareerSpecialization> Specializations { get; }
}
