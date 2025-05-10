namespace WebApplication56.Options
{
    public class PollyHttpClientOption
    {
        public const string SectionName = "Polly";

        public required List<string> ServiceName { set; get; }

        public int TimeoutTime { set; get; }

        public int RetryCount { set; get; }

        public int CircuitBreakerOpenFallCount { set; get; }

        public int CircuitBreakerDownTime { set; get; }

        public string HttpResponseMessage { set; get; } = string.Empty;

        public int HttpResponseStatus { set; get; }
    }
}
