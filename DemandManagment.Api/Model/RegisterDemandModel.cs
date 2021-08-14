using DemandManagment.MessagesContract;

namespace DemandManagment.Api.Model
{
    public class RegisterDemandModel : IRegisterDemandCommand
    {
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}