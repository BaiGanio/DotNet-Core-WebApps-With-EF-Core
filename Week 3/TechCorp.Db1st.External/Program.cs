using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechCorp.Db1st.External;

namespace TechCorp.Db1st.External
{
    class Program
    {
        static void Main(string[] args)
        {
            TechCorpEntities ctx = new TechCorpEntities();
            var emp = ctx.Employees.ToList();
            foreach (var item in emp)
            {

                Console.Write(item.FirstName);
                Console.WriteLine(" is from department " + item.Department.Name);
            }

        }
    }
}
