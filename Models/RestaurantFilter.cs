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
            foreach (KeyValuePair<string, string> filter in FiltersAsStringDictionary())
            {
                if (filter.Value != null)
                {
                    sb.Append(querySeparator);
                    sb.Append($"{filter.Key}={filter.Value}");
                    querySeparator = "&";
                }
            }

            return sb.ToString();
        }

        private Dictionary<string, string> FiltersAsStringDictionary()
        {
            Dictionary<string, string> filters = new Dictionary<string, string>();

            filters.Add("term", SearchTerm);
            filters.Add("location", Location);
            filters.Add("radius", LocationRadius != 0 ? LocationRadius.ToString() : null);
            filters.Add("categories", Categories);

            return filters;
        }
    }
}
