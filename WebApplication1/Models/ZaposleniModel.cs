using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ZaposleniModel
    {
        public int ZaposleniID { get; set; }
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Pozicija { get; set; }

        public int Godine { get; set; }
        public int Plata { get; set; }
    }
}
