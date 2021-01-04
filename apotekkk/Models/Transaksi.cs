using System;
using System.Collections.Generic;

namespace apotekkk.Models
{
    public partial class Transaksi
    {
        public Transaksi()
        {
            Nota = new HashSet<Nota>();
        }

        public int IdTransaksi { get; set; }
        public int? IdObat { get; set; }
        public int? IdPembeli { get; set; }
        public int? IdApoteker { get; set; }
        public DateTime? TglTransaksi { get; set; }
        public int? TotalHarga { get; set; }

        public Apoteker IdApotekerNavigation { get; set; }
        public Obat IdObatNavigation { get; set; }
        public Pembeli IdPembeliNavigation { get; set; }
        public ICollection<Nota> Nota { get; set; }
    }
}
