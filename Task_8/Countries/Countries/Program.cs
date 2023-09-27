using Newtonsoft.Json.Linq;
using System.Globalization;

namespace Countries
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await GenerateCountryDataFiles();
                Console.WriteLine("Files created succesfully!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        static async Task<JArray> FetchData()
        {
            string url = "https://restcountries.com/v3.1/all";
            //fetch the data
            using (var httpClient = new HttpClient())
            {
                var res = await httpClient.GetStringAsync(url);  // HTTP GET request
                return JArray.Parse(res); 
            }
        }

        static async Task GenerateCountryDataFiles()
        {
            JArray data = await FetchData();
            for (int i = 0; i < data.Count; ++i)
            {
                //data to be written into file
                string name = data[i]["name"]["common"] != null ? data[i]["name"]["common"].ToString() : "N/A";
                string reg = data[i]["region"] != null ? data[i]["region"].ToString() : "N/A";
                string subreg = data[i]["subregion"] != null ? data[i]["subregion"].ToString() : "N/A";
                string latLng = data[i]["latlng"] != null ? data[i]["latlng"].ToString() : "N/A";
                string area = data[i]["area"] != null ? data[i]["area"].ToString() : "N/A";
                string ppl = data[i]["population"] != null ? data[i]["population"].ToString() : "N/A";

                String nametxt = name + ".txt";
                Console.WriteLine($" creating file {nametxt}");
                using (StreamWriter wr = File.CreateText(nametxt))
                {
                    wr.WriteLine($"Country: {name}");
                    wr.WriteLine($"Region: {reg}");
                    wr.WriteLine($"Subregion: {subreg}");
                    wr.WriteLine($"LatLng: {latLng}");
                    wr.WriteLine($"Area: {area}");
                    wr.WriteLine($"Population: {ppl}");
                }
            }
        }


    }
}