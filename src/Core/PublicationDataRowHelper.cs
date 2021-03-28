using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using CafeynCatalogTools.Core.CafeynAPI;
using CafeynCatalogTools.Core.CafeynAPI.Data;

namespace CafeynCatalogTools.Core
{
    public class PublicationDataRowHelper
    {
        private static IEnumerable<PublicationDataRow> ToPublicationDataRows(IEnumerable<Store> stores)
        {
            IList<PublicationDataRow> rows = new List<PublicationDataRow>();
            foreach (Store store in stores)
            {
                foreach (Category category in store.Categories)
                {
                    foreach (CategoryItem categoryItem in category.Items)
                    {
                        rows.Add(new PublicationDataRow()
                        {
                            StoreId = store.StoreId,
                            StoreName = store.Name,
                            CategoryId = category.Id,
                            CategoryName = category.Name,
                            PublicationId = categoryItem.PublicationId,
                            PublicationName = categoryItem.Title
                        });
                    }
                }
            }

            return rows;
        }

        public static async Task<IEnumerable<PublicationDataRow>> GetPublicationsAsync()
        {
            IEnumerable<Store> stores = await ApiClientHelper.GetStoresAsync();
            IEnumerable<PublicationDataRow> publicationDataRows = ToPublicationDataRows(stores);
            return publicationDataRows;
        }

        public static void Serialize(IEnumerable<PublicationDataRow> publicationDataRows, string path)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<PublicationDataRow>));
            FileStream fileStream = File.Create(path);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            writer.Serialize(fileStream, publicationDataRows.ToList(), namespaces);
        }
    }
}
