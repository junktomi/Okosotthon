namespace Okosotthon
{
    public class Program
    {
        static void Main(string[] args)
        {
            Termosztat termosztat =
            new Termosztat("T001", "Nappali termosztát", 22.0);

            OkosZar zar =
                new OkosZar("Z001", "Bejárati ajtó", "1234");

            OkosotthonKozpont kozpont = new OkosotthonKozpont();

            kozpont.EszkozHozzaadasa(termosztat);
            kozpont.EszkozHozzaadasa(zar);

            Console.WriteLine(
                "Sikeres tesztek csatlakozás előtt: " +
                kozpont.RendszerDiagnosztikaFuttatasa());

            kozpont.OsszesCsatlakoztatasa();

            termosztat.ParancsVegrehajtasa("BEALLIT_HOMERSEKLET:24.5");
            zar.ParancsVegrehajtasa("NYITAS:1234");

            Console.WriteLine(termosztat.AllapotJelentes());
            Console.WriteLine(zar.AllapotJelentes());

            Console.WriteLine(
                "Sikeres tesztek csatlakozás után: " +
                kozpont.RendszerDiagnosztikaFuttatasa());

            termosztat.ParancsVegrehajtasa("BEALLIT_HOMERSEKLET:40");

            Console.WriteLine(
                "Sikeres tesztek hibás célhőmérséklettel: " +
                kozpont.RendszerDiagnosztikaFuttatasa());

            zar.GyariBeallitasokVisszaallitasa();
            Console.WriteLine(zar.AllapotJelentes());

            zar.ParancsVegrehajtasa("NYITAS:0000");
            Console.WriteLine(zar.AllapotJelentes());
        }
    }
}
