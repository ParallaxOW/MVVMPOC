using System.Collections.Generic;

namespace Acosta.Xam.POC.Core
{
    public class EventsRetrieval
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string version { get; set; }
        public int count { get; set; }
        public List<Event> data { get; set; }
    }
}
