namespace Microservice.Core.Utilities.Caching.Redis
{
    public class Redis
    {
        public int Port { get; set; }
        public string Host { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public string Configuration => $"{Host}:{Port}";
    }
}