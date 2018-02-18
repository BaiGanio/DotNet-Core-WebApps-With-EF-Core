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
                "Server=GIUD.sqlserver.sequelizer.com;" +
                "Database=SOMEHASH;" +
                "User ID=SOMEHASH;" +
                "Password=SOMEHASH;" +
                "MultipleActiveResultSets=true";
        }
    }
}
