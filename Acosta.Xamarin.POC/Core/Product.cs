using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace Acosta.Xam.POC.Core
{
    public class Product : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
