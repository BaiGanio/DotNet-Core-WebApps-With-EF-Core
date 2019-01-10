using System;
using System.Collections.Generic;
using System.Linq;

namespace Geography.Db1st.Local
{
    class Program
    {
        static void Main(string[] args)
        {
            var _ctx = new GeographyEntities();

            List<River> rivers = _ctx.Rivers.ToList();

            foreach (var river in rivers)
            {
                Console.WriteLine(river.ToString());
            }
        }
    }
}
