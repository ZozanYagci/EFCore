namespace EfCore.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.Debug(Serilog.Events.LogEventLevel.Information)
            //    .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}