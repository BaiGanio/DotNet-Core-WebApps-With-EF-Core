namespace AuthManager2
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthManagerDBContext ctx = new AuthManagerDBContext();
            ctx.Database.Initialize(true);
            //var countries = ctx.Countries.ToList();

            //foreach (var item in countries)
            //{
            //    Console.WriteLine($"{item.CountryName} => {item.Population}");
            //}

        }
    }
}
