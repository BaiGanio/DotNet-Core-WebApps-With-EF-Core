using System;

namespace Console.DBClient
{
    class SimpleADONET
    {
        static void Main()
        {
            /* 1. Create connection to SQL Server Database */
			/* SSPI stands for Windows authentication. It can be replaced with “true” */
			SqlConnection con = new SqlConnection("data source = .; database = TechCorpDB; integrated security = SSPI");

            /* 2. Why is this try-catch needed? */
            try
            {
                /* 3. Prepare the command & execute it with the connection. */
                /* Pass the connection to the command object, so the command object knows on which connection to execute the command. */
				SqlCommand cmd = new SqlCommand("SELECT TOP (5) Name, Description, StartDate, EndDate FROM Projects", con);				
				
                /* 4. Open the connection. Otherwise you get a runtime error. An open connection is required to execute the command */
                con.Open();

                /* 5. Prepare object who can read the data from DB */
                /* !! ExecuteReader() returns SqlDataReader object. */
                SqlDataReader reader = cmd.ExecuteReader();

                /* 6. Make some while-loop logic here & print the results. */
				 while (reader.Read())
				{
					Console.WriteLine();
					
					// get the results of each column
					string name = (string)reader["Name"];
					string description = (string)reader["Description"];
					DateTime startDate = (DateTime)reader["StartDate"];
					
					Console.WriteLine($"Project: {name}");
					Console.WriteLine($"Decsription: {description}");
					Console.WriteLine($"Start date: {startDate}");
					Console.WriteLine("*************************************************");
				}

            }
            catch (Exception ex)
            {
               //TODO Create some message about the error 
            }

            /* 7. Homework */
            /* Do some SQL queries. Decided wich one? / No */
        }
    }
}
