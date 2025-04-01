using System.Text;

using log4net.Appender;
using log4net.Core;

namespace WebApplication1.log4net
{
    public class Custom2Appender : BufferingAppenderSkeleton
    {
        public string ServerUrl
        {
            get
            {
                if (_httpClient.BaseAddress != null)
                    return _httpClient.BaseAddress.OriginalString;

                return string.Empty;
            }
            set
            {
                if (!value.EndsWith("/"))
                    value += "/";

                _httpClient.BaseAddress = new Uri(value);
            }
        }
        public string ApiKey { get; set; } = string.Empty;

        readonly HttpClient _httpClient = new HttpClient();
        readonly List<AppenderParameter> _parameters = new List<AppenderParameter>();

        const string BulkUploadResource = "api/events/raw";
        const string ApiKeyHeaderName = "X-Seq-ApiKey";

        protected override void SendBuffer(LoggingEvent[] events)
        {
            //foreach (var item in events)
            //{
            //    System.Diagnostics.Debug.WriteLine(item.RenderedMessage);
            //}

            var payload = new StringWriter();
            LoggingEventFormatter.ToJson(events, payload, _parameters);

            var content = new StringContent(payload.ToString(), Encoding.UTF8, "application/vnd.serilog.clef");
            if (!string.IsNullOrWhiteSpace(ApiKey))
                content.Headers.Add(ApiKeyHeaderName, ApiKey);

            using (var result = _httpClient.PostAsync(BulkUploadResource, content).Result)
            {
                if (!result.IsSuccessStatusCode)
                    ErrorHandler.Error($"Received failed result {result.StatusCode}: {result.Content.ReadAsStringAsync().Result}");
            }
        }
    }
}
