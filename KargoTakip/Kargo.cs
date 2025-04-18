using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip
{
    public class Kargo
    {
        public string? LastUpdate { get; set; }
        public string? Firma { get; set; }       
        public string? TakipNo { get; set; }
        public bool TeslimEdildi { get; set; }
        public string? MagazaID { get; set; }
        public string? TalepID { get; set; }
        public bool IsChecked { get; set; }
        public string? OngorulenTeslimat { get; set; }


    }
}
