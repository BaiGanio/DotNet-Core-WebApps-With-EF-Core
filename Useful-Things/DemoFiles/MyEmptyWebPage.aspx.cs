using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmptyWebTemplate.DBClient
{
    public partial class MyEmptyWebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Establish the SQL connection. SSPI means Windows authentication. */
           // SqlConnection con = new SqlConnection("data source = .; database = TechCorpDB; integrated security = SSPI");
            SqlConnection con = new SqlConnection("data source = .; database = Geography; integrated security = SSPI");

            try
            {
                /*  Prepare the command. Execute it with the connection.  */
                //SqlCommand cmd = new SqlCommand("SELECT TOP (5) Name, Description, StartDate, EndDate FROM Projects", con);
                //SqlCommand cmd = new SqlCommand("SELECT ContinentCode, ContinentName FROM Continents", con);
                SqlCommand cmd = new SqlCommand("SELECT [CountryCode], [CountryName], [Population], [Capital], [AreaInSqKm] FROM [Countries] Order by Population desc", con);

                /* Open the connection. Otherwise you get a runtime error. An open connection is required to execute the command */
                con.Open();

                /* !! ExecuteReader() returns SqlDataReader object. */
                SqlDataReader reader = cmd.ExecuteReader();

                /* Set the Gridview data source to the reader. */
                GridView1.DataSource = reader;
                /* Bind the data. */
                GridView1.DataBind();
            }
            catch (Exception)
            {
                Error.Text = "Something get wrong... DB name doesn't exist.";
            }
            finally
            {
                /* 
                 * Don't forget to close the connection. 
                 * The finally block is guarenteed to execute even if there is an exception. 
                 */
                con.Close();
            }

        }
    }
}