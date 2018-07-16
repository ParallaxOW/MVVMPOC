using Realms;

namespace Acosta.Xam.POC.Core
{
    public class Product : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; }
        public string product_name { get; set; }
        public string shelf_code { get; set; }
        public string barcode { get; set; }
        public string category { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string client { get; set; }
        public string brand { get; set; }
        public string unit_size { get; set; }
        public string units_case { get; set; }
        public string thumbnail { get; set; }
        public string image_url { get; set; }
    }
}