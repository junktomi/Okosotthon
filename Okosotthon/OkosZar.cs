using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar: OkosEszkoz
    {
        public bool ZartE { get; private set; }

        private string pinKod;
        public string PinKod { get => pinKod; set => pinKod = value; }


        public OkosZar(string azonosito, string nev, string pinKod)
        : base(azonosito, nev)
        {
            this.ZartE = true;
            this.pinKod = pinKod;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (string.IsNullOrEmpty(parancs))
            {
                return;
            }

            if (parancs == "ZARAS")
            {
                this.ZartE = true;
                this.UtolsoFrissites = DateTime.Now;
            }
            else if (parancs.StartsWith(
                "NYITAS:",
                StringComparison.Ordinal))
            {
                string megadottPin = parancs.Substring("NYITAS:".Length);

                if (megadottPin == this.pinKod)
                {
                    this.ZartE = false;
                    this.UtolsoFrissites = DateTime.Now;
                }
            }
        }


        public override string AllapotJelentes()
        {
            return $"{this.Nev}: {(this.ZartE ? "ZÁRVA" : "NYITVA")}";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();

            this.pinKod = "0000";
            this.ZartE = true;
        }


    }
}
