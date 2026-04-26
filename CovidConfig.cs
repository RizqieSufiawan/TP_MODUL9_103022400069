using System;
using System.IO;
using System.Text.Json;

namespace TP_MODUL9_103022400069
{
    public class CovidConfigModel
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public CovidConfigModel() { }

        public CovidConfigModel(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
    }

    internal class CovidConfig
    {
        public CovidConfigModel config;
        private const string filePath = "covid_config.json";

        public CovidConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        private void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<CovidConfigModel>(configJsonData);
        }

        private void SetDefault()
        {
            config = new CovidConfigModel(
                "celcius",
                14,
                "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                "Anda dipersilahkan untuk masuk ke dalam gedung ini"
            );
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void UbahSatuan()
        {
            if (config.satuan_suhu == "celcius")
            {
                config.satuan_suhu = "fahrenheit";
            }
            else if (config.satuan_suhu == "fahrenheit")
            {
                config.satuan_suhu = "celcius";
            }

            WriteNewConfigFile();
        }
    }
}