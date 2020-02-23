using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDL.Models
{
    public class RestaurantFilter
    {
        public string SearchTerm { get; set; }
        public string Location { get; set; }
        public int LocationRadius { get; set; }
        public string Categories { get; set; }
        // TODO: price range

        public string FormatForUrlParameters()
        {
            StringBuilder sb = new StringBuilder();

            string querySeparator = "?";

            // TODO: This is gross. Clean up later
            
            if (SearchTerm != null)
            {
                sb.Append(querySeparator);
                sb.Append($"term={SearchTerm}");
                querySeparator = "&";
            }

            if (Location != null)
            {
                sb.Append(querySeparator);
                sb.Append($"location={Location}");
                querySeparator = "&";
            }

            if (LocationRadius != 0)
            {
                sb.Append(querySeparator);
                sb.Append($"radius={LocationRadius}");
                querySeparator = "&";
            }

            if (Categories != null)
            {
                sb.Append(querySeparator);
                sb.Append($"categories={Categories}");
                querySeparator = "&";
            }

            return sb.ToString();
        }
    }
}
