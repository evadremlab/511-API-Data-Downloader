using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace APIDataDownloader
{
    class Program
    {
        static string baseAddress;
        static string endPoints;
        static string saveFilePath;

        static void Main(string[] args)
        {
            var now = DateTime.Now;
            baseAddress = ConfigurationManager.AppSettings["BaseAddress"];
            endPoints = ConfigurationManager.AppSettings["EndPoints"];
            saveFilePath = ConfigurationManager.AppSettings["SaveFilePath"];

            if (!Directory.Exists(saveFilePath))
            {
                Directory.CreateDirectory(saveFilePath);
            }

            foreach (string endPoint in endPoints.Split(','))
            {
                Download(endPoint, now);
            }

            Console.WriteLine("-- done --");
            Console.Read();
        }

        static void Download(string endPoint, DateTime now)
        {
            var url = string.Format("{0}/{1}", baseAddress, endPoint);

            Console.WriteLine(url);

            var req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Accept = "application/xml";
   
            using (var stream = req.GetResponse().GetResponseStream())
            {
                using (var reader = new StreamReader(stream, Encoding.ASCII))
                {
                    var filePath = Path.Combine(saveFilePath, string.Format("{0}-{1:yyyy-MM-dd--HH-mm-ss}.xml", endPoint, now));

                    Console.WriteLine(filePath);

                    using (var writer = new StreamWriter(filePath))
                    {
                        writer.Write(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}
