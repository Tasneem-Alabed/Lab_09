using Newtonsoft.Json;
using System;
using System.IO;

namespace Read_Json
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string File_json_path = "../../../../data.json";

            string data_json = File.ReadAllText(File_json_path);
            var Object = JsonConvert.DeserializeObject<point>(data_json);
            IEnumerable<string> neighborhoods = Object.features.Select(fitter => fitter.properties.neighborhood);

            Console.WriteLine("Neighborhoods:");
            Console.WriteLine(string.Join("\t", neighborhoods));
            Console.WriteLine("Total: " + neighborhoods.Count() + " neighborhoods");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("*****************************************");
            Console.WriteLine("----------------------------------------");
            var namedNeighborhoods = neighborhoods.Where(n => !string.IsNullOrEmpty(n));
            Console.WriteLine("Named neighborhoods:");
            Console.WriteLine(string.Join("\t", namedNeighborhoods));
            Console.WriteLine("Total " + namedNeighborhoods.Count() + " neighborhoods");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("*****************************************");
            Console.WriteLine("----------------------------------------");
            var distinctNeighborhoods = namedNeighborhoods.Distinct();
            Console.WriteLine("Distinct neighborhoods:");
            Console.WriteLine(string.Join("\t", distinctNeighborhoods));
            Console.WriteLine("Total " + distinctNeighborhoods.Count() + " neighborhoods");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("*****************************************");
            Console.WriteLine("----------------------------------------");
            


            var Data_Neighborhoods_Querys = (from f in Object.features
                                           where !string.IsNullOrEmpty(f.properties.neighborhood)
                                           select f.properties.neighborhood).Distinct();

            var datedNeighborhoods = Object.features
                .Select(f => f.properties.neighborhood)
                .Where(n => !string.IsNullOrEmpty(n)).Distinct();

            Console.WriteLine("Consolidated neighborhoods:");
            Console.WriteLine(string.Join("\t ", datedNeighborhoods));
            Console.WriteLine("Total " + datedNeighborhoods.Count() + " neighborhoods");

            Console.WriteLine("Consolidated neighborhoods (using query syntax):");
            Console.WriteLine(string.Join("\t ", Data_Neighborhoods_Querys));

            Console.WriteLine("Total " + Data_Neighborhoods_Querys.Count() + " neighborhoods");


           
        }

    }
    }

    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double> list { get; set; }
    }

    public class Properties
    {
        public string zip { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address { get; set; }
        public string borough { get; set; }
        public string neighborhood { get; set; }
        public string county { get; set; }
    }

    public class point
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }

