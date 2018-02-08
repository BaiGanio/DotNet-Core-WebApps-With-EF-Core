using System;
using System.Collections.Generic;
using System.Text;

namespace ITGigs.DB.Heplers
{
    public static class DBConnections
    {
        public static string GetAzureConnection()
        {
            return
                "Server=tcp:MY-SERVER.database.windows.net,1433; " +
                "Initial Catalog = MY-DB; " +
                "Persist Security Info = False; " +
                "User ID = MY-ADMIN; " +
                "Password = MY-PASS; " +
                "MultipleActiveResultSets = False; " +
                "Encrypt = True; " +
                "TrustServerCertificate = False; " +
                "Connection Timeout = 30; ";
        }

        public static string GetAppHarborConnection()
        {
            return
                "Server=94e7bd52-eefe-4762-a4b5-a86b0087217e.sqlserver.sequelizer.com;" +
                "Database=db94e7bd52eefe4762a4b5a86b0087217e;" +
                "User ID=mvrolnlqbjwehnjl;" +
                "Password=sU7YKg6pzNBGBkiqDg5X3UBD3YjTAv4xRd6hHKyw2BhVc2kZnLNiJFFErA6T6kVe;" +
                "MultipleActiveResultSets=true";
        }
    }
}
