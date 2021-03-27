using System;
using System.Collections.Generic;
using System.Text;

namespace CafeynCatalogTools.Core
{
    public class PublicationDataRow
    {
        public Int32 StoreId { get; set; }

        public String StoreName { get; set; }

        public Int32 CategoryId { get; set; }

        public String CategoryName { get; set; }

        public Int32 PublicationId { get; set; }

        public String PublicationName { get; set; }
    }
}
