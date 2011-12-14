using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Stacky;
using Newtonsoft.Json;

namespace CaptureRequest
{
    class Program
    {
        static readonly string Filter = "!Dm8Xl";

        static void Main(string[] args)
        {
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Requests.txt");
            IUrlClient client = new UrlClient();

            foreach (string urlString in File.ReadAllLines(inputPath))
            {
                Uri url = new Uri(urlString);
                url = EnsureFilter(url);
                string fileName = GetFilename(url);
                Console.WriteLine(fileName);

                string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                if (File.Exists(outputPath))
                    continue;

                var response = client.MakeRequest(url);

                StringBuilder s = new StringBuilder();
                s.AppendLine(url.ToString());
                if (response.Error != null)
                {
                    s.AppendLine(response.Error.ToString());
                }
                else
                {
                    object o = JsonConvert.DeserializeObject(response.Body);
                    s.AppendLine(JsonConvert.SerializeObject(o, Formatting.Indented));
                }

                File.WriteAllText(outputPath, s.ToString());
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        private static Uri EnsureFilter(Uri url)
        {
            if (url.Query.Contains(Filter))
                return new Uri(url.ToString() + "&filter=" + Filter);
            return url;
        }

        static string GetFilename(Uri url)
        {
            string method = url.Segments.ElementAt(2).Replace("/", "");
            string subMethod = url.Segments.ElementAtOrDefault(4);

            if (!String.IsNullOrEmpty(subMethod))
                method += "-" + subMethod.Replace("/", "");
            
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            string hash = Convert.ToBase64String(sha.ComputeHash((new UnicodeEncoding()).GetBytes(url.ToString().Trim())));
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                hash = hash.Replace(c.ToString(), "");
            }
            return String.Format("{0}-{1}.txt", method, hash);
        }
    }
}
