using System;
using System.Collections.Generic;

namespace apotekkk.Models
{
    public partial class Pembeli
    {
        public Pembeli()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int IdPembeli { get; set; }
        public string UsernamePembeli { get; set; }
        public string PasswordPembeli { get; set; }

        public ICollection<Transaksi> Transaksi { get; set; }
    }
}
