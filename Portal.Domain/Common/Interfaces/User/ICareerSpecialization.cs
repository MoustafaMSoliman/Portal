namespace Portal.Domain.Common.Interfaces.User;

public interface ICareerSpecialization
{
    string CareerSpecializationName { get; }
    IList<ICareerTitle> CareerTitles { get; }
}
