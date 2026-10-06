using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        private double JelenlegiHomerseklet;
        private double CelHomerseklet;

        public double JelenlegiHomerseklet1 { get => JelenlegiHomerseklet; set => JelenlegiHomerseklet = value; }
        public double CelHomerseklet1 { get => CelHomerseklet; set => CelHomerseklet = value; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            this.JelenlegiHomerseklet = 21.0;
            this.CelHomerseklet = celHomerseklet;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            const string elotag = "BEALLIT_HOMERSEKLET:";

            if (string.IsNullOrEmpty(parancs) ||
                !parancs.StartsWith(elotag, StringComparison.Ordinal))
            {
                return;
            }

            string ertek = parancs
                .Substring(elotag.Length)
                .Replace(',', '.');

            if (double.TryParse(
                ertek,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double ujHomerseklet))
            {
                this.CelHomerseklet = ujHomerseklet;
                this.UtolsoFrissites = DateTime.Now;
            }
        }

        public override string AllapotJelentes()
        {
            return $"{this.Nev}: jelenlegi hőmérséklet: " +
                  $"{this.JelenlegiHomerseklet:F1} °C, " +
                  $"célhőmérséklet: {this.CelHomerseklet:F1} °C";
        }

        protected override bool OnTesztFuttatasa()
        {
            return this.CelHomerseklet >= 5.0 &&
            this.CelHomerseklet <= 35.0;
        }

    }
}
