using System;
using System.Collections.Generic;
using System.Text;

namespace DemandManagment.MessagesContract
{
    public interface IDemandRegisteredEvent
    {
        public Guid DemandId { get; set; }
    }
}
