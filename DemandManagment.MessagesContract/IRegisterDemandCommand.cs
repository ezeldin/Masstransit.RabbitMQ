using System;
using System.Collections.Generic;
using System.Text;

namespace DemandManagment.MessagesContract
{
    public interface IRegisterDemandCommand
    {
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
