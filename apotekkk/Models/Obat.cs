using System;
using System.Collections.Generic;

namespace apotekkk.Models
{
    public partial class Obat
    {
        public Obat()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int IdObat { get; set; }
        public string NamaObat { get; set; }
        public string JenisObat { get; set; }
        public int? Harga { get; set; }
        public int? Quantity { get; set; }

        public ICollection<Transaksi> Transaksi { get; set; }
    }
}
