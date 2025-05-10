using System.Net;

using Polly;

using WebApplication56.Options;

namespace WebApplication56.ServiceCollection_Extensions
{
    public static class PollyHttpClientServiceCollectionExtension
    {
        public static void AddPollyHttpClient(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("pollyHttpClient.json")
                .Build();
            var options = config.GetSection(PollyHttpClientOption.SectionName).Get<List<PollyHttpClientOption>>();
            if (options != null)
            {
                foreach (var item in options)
                {
                    services.AddPollyHttpClient(item);
                }
            }
        }

        public static void AddPollyHttpClient(this IServiceCollection services
            , PollyHttpClientOption option)
        {
            if (option == null)
            {
                throw new Exception("Invalid PollyHttpClientOption");
            }


            if (option.ServiceName == null || option.ServiceName.Count < 1)
            {
                throw new Exception("Invalid PollyHttpClientOption ServiceName");
            }

            foreach (var item in option.ServiceName)
            {
                var builder = services.AddHttpClient(item);
                builder.BuildFallbackAsync(option.HttpResponseMessage, option.HttpResponseStatus);
                builder.BuildCircuitBreakerAsync(option.CircuitBreakerOpenFallCount, option.CircuitBreakerDownTime);
                builder.BuildRetryAsync(option.RetryCount);
                builder.BuildTimeoutAsync(option.TimeoutTime);
            }
        }

        private static void BuildFallbackAsync(this IHttpClientBuilder builder
            , string httpResponseMessage
            , int httpResponseStatus)
        {
            if (httpResponseStatus < 1 || string.IsNullOrEmpty(httpResponseMessage))
            {
                return;
            }

            var fallbackResponse = new HttpResponseMessage
            {
                Content = new StringContent(httpResponseMessage),
                StatusCode = (HttpStatusCode)httpResponseStatus
            };

            builder.AddPolicyHandler(Policy<HttpResponseMessage>.HandleInner<Exception>().FallbackAsync(fallbackResponse, async b =>
            {
                Console.WriteLine($"服务开始降级,异常消息：{b.Exception.Message}");
                Console.WriteLine($"服务降级内容响应：{await fallbackResponse.Content.ReadAsStringAsync()}");
                await Task.CompletedTask;
            }));
        }

        private static void BuildCircuitBreakerAsync(this IHttpClientBuilder builder
            , int circuitBreakerOpenFallCount
            , int circuitBreakerDownTime)
        {
            if (circuitBreakerOpenFallCount < 1 || circuitBreakerDownTime < 1)
            {
                return;
            }

            builder.AddPolicyHandler(
                Policy<HttpResponseMessage>
                .Handle<Exception>()
                .OrResult(res => res.StatusCode == HttpStatusCode.InternalServerError || res.StatusCode == HttpStatusCode.RequestTimeout)
                .CircuitBreakerAsync(
                    circuitBreakerOpenFallCount,
                    TimeSpan.FromSeconds(circuitBreakerDownTime),
                    (res, ts) =>
                    {
                        Console.WriteLine($"服务断路器开启，异常消息：{res.Result}");
                        Console.WriteLine($"服务断路器开启的时间：{ts.TotalSeconds}s");
                    },
                    () => { Console.WriteLine($"服务断路器重置"); },
                    () => { Console.WriteLine($"服务断路器半开启(一会开，一会关)"); }
                )
            );
        }

        private static void BuildRetryAsync(this IHttpClientBuilder builder, int retryCount)
        {
            if (retryCount > 0)
            {
                builder.AddPolicyHandler(Policy<HttpResponseMessage>.Handle<HttpRequestException>().RetryAsync(retryCount));
            }
        }

        private static void BuildTimeoutAsync(this IHttpClientBuilder builder, int timeoutTime)
        {
            if (timeoutTime > 0)
            {
                builder.AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(timeoutTime)));
            }
        }
    }
}
