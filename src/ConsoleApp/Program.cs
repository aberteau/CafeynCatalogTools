using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CafeynCatalogTools.Core;

namespace CafeynCatalogTools.ConsoleApp
{
    class Program
    {
        private const string OutputPath = @""; // Chemin d'export à renseigner

        static async Task Main(string[] args)
        {
            IEnumerable<PublicationDataRow> publicationDataRows = await PublicationDataRowHelper.GetPublicationsAsync();
            string path = GetXmlFilePath();
            PublicationDataRowHelper.Serialize(publicationDataRows, path);
        }

        private static string GetXmlFilePath()
        {
            string chrono = DateTime.Now.ToString("yyMMddHHmm");
            string filename = $"cafeyn-bouygues-publications-{chrono}.xml";
            string path = Path.Combine(OutputPath, filename);
            return path;
        }
    }
}
