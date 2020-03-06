using System;
using System.Collections.Generic;
using System.Data;

namespace LabEight
{
    public class Search
    {
        public int[] LinearSearch(String searchFor, List<ListItem> list)
        {

            List<ListItem> results = new List<ListItem>();
            results = list.FindAll(s => s.value.Equals(searchFor));

            if (results.Count == 0)
                throw new Exception();

            List<int> indexes = new List<int>();

            foreach (ListItem li in results)
                indexes.Add(li.index);

            return indexes.ToArray();
        }
    }
}
