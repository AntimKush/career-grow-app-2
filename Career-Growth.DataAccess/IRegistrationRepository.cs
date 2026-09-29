using Career_Growth_App_2._0.Models;

namespace Career_Growth.DataAccess
{
    public interface IRegistrationRepository
    {
        string Save_Registration(CandidateRegistration candidateRegistration);
    }
}
