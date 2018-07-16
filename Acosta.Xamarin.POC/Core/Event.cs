using System;
using Realms;

namespace Acosta.Xam.POC.Core
{
    public class Event : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string company_name { get; set; }
        public string description { get; set; }
        public DateTimeOffset date { get; set; }
        public DateTimeOffset start_time { get; set; }
        public DateTimeOffset end_time { get; set; }
        public int objectives_count { get; set; }
    }
}
