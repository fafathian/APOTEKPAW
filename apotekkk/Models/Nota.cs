using System;
using System.Collections.Generic;

namespace apotekkk.Models
{
    public partial class Nota
    {
        public int IdNota { get; set; }
        public int? IdTransaksi { get; set; }
        public int? TotalHarga { get; set; }

        public Transaksi IdTransaksiNavigation { get; set; }
    }
}
