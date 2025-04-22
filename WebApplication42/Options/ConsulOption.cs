namespace WebApplication42.Options
{
    public class ConsulOption
    {
        public string Address { get; set; } = string.Empty;

        public required HostAndPort ClientInfo { get; set; }

        public string HealthCheckPath { get; set; } = string.Empty;

        public string ServiceName { get; set; } = string.Empty;

        public string LBStrategy { get; set; } = string.Empty;

        public int Weight { get; set; } = 1;

        public class HostAndPort
        {
            public string Host { get; set; } = string.Empty;

            public int Port { get; set; }
        }
    }
}
