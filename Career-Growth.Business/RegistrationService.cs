using Career_Growth.DataAccess;
using Career_Growth_App_2._0.Models;

namespace Career_Growth.Business
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }
        public string Save_Registration(CandidateRegistration candidateRegistration)
        {
            string result=registrationRepository.Save_Registration(candidateRegistration);
            return result;
        }
    }
}
