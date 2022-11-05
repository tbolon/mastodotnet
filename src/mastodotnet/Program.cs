using StackExchange.Redis;
using Npgsql;

namespace mastodotnet
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            // check redis
            using (var redis = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = redis.GetDatabase();
                db.StringSet("warmup", DateTimeOffset.UtcNow.ToString());
                var value = db.StringGet("warmup");
            }

            // check database
            using (var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=postgres"))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select * from pg_catalog.pg_tables;";

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                }
            }

            app.MapGet("/", () => "Hello World!");

            app.Run();

        }
    }
}