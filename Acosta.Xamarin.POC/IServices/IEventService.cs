using System;
using System.Collections.Generic;
using System.Text;

using Acosta.Xam.POC.Core;

namespace Acosta.Xam.POC.IServices
{
    public interface IEventService
    {
        List<Event> GetAllEvents();
        int SaveEvents(List<Event> events);
    }
}
