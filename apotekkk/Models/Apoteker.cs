using System;
using System.Collections.Generic;

namespace apotekkk.Models
{
    public partial class Apoteker
    {
        public Apoteker()
        {
            Transaksi = new HashSet<Transaksi>();
        }

        public int IdApoteker { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Transaksi> Transaksi { get; set; }
    }
}
