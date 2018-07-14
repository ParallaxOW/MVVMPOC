using Realms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Acosta.Xam.POC.Core;
using Acosta.Xam.POC.IServices;

namespace Acosta.Xam.POC.Services
{
    public class EventService : IEventService
    {
        private Realm _realm;

        public EventService()
        {
            _realm = Realm.GetInstance();
        }

        public List<Event> GetAllEvents() => _realm.All<Event>().ToList();

        public int SaveEvents(List<Event> events)
        {
            events.ForEach(e => {
                _realm.Write(() => _realm.Add(e));
            });

            return events.Count;
        }
    }
}
