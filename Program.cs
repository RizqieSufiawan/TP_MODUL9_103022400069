namespace TP_MODUL9_103022400069
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CovidConfig covidConfig = new CovidConfig();

            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.config.satuan_suhu}: ");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
            int hari = Convert.ToInt32(Console.ReadLine());

            bool suhuValid = false;

            if (covidConfig.config.satuan_suhu == "celcius")
            {
                if (suhu >= 36.5 && suhu <= 37.5)
                {
                    suhuValid = true;
                }
            }
            else if (covidConfig.config.satuan_suhu == "fahrenheit")
            {
                if (suhu >= 97.7 && suhu <= 99.5)
                {
                    suhuValid = true;
                }
            }

            bool hariValid = hari < covidConfig.config.batas_hari_demam;

            if (suhuValid && hariValid)
            {
                Console.WriteLine(covidConfig.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(covidConfig.config.pesan_ditolak);
            }

            covidConfig.UbahSatuan();
        }
    }
}