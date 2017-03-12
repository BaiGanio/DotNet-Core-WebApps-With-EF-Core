using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SqlConnection con = new SqlConnection("data source = .; database = Geography; integrated security = SSPI");
            SqlCommand cmd = new SqlCommand("SELECT top(3) [CountryCode], [CountryName], [Population], [Capital], [AreaInSqKm] FROM [Countries] Order by Population desc", con);

            /* Open the connection. Otherwise you get a runtime error. An open connection is required to execute the command */
            con.Open();

            /* !! ExecuteReader() returns SqlDataReader object. */
            SqlDataReader reader = cmd.ExecuteReader();

            Dictionary<string, List<string>> countries = new Dictionary<string, List<string>>();
            while (reader.Read())
            {
                Console.WriteLine();

                // get the results of each column
                string countryCode = (string)reader["CountryCode"];
                string countryName = (string)reader["CountryName"];
                int population = (int)reader["Population"];
                string capital = (string)reader["Capital"];
                int areaInSqKm = (int)reader["AreaInSqKm"];

                if (!countries.ContainsKey(countryName))
                {
                    List<string> countryData = new List<string> {countryCode, capital, population.ToString(), areaInSqKm.ToString()};

                    countries.Add(countryName, countryData);
                }
            }

            ViewData["Countries"] = countries;

            return View(countries);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}