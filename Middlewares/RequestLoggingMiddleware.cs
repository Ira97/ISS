using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MiddleWares
{
    /// <summary>
    /// MiddleWare для логирования запросов
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// Инициализирует экземпляр <see cref="RequestLoggingMiddleware"/>
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        /// <summary>
        /// Выполнение
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var requestBody = string.Empty;
            var requestQueryString = string.Empty;
            var request = context.Request;
            if (context.Request?.Method == HttpMethods.Post || context.Request?.Method == HttpMethods.Put)
            {
                requestBody = await GetRequestBody(request);
            }
            if (context.Request?.QueryString.HasValue == true)
            {
                requestQueryString = Uri.UnescapeDataString(context.Request?.QueryString.Value);
            }
            _logger.LogInformation(
                $"Request {context.Request?.Method} {context.Request?.Path.Value}{requestQueryString} {requestBody} => {context.Response?.StatusCode}");
            await _next(context);
        }

        private async Task<string> GetRequestBody(HttpRequest request)
        {
            var stream = request.Body;
            var requestBody = await new StreamReader(stream).ReadToEndAsync();
            var requestData = Encoding.UTF8.GetBytes(requestBody);
            stream = new MemoryStream(requestData);
            request.Body = stream;
            return requestBody;
        }
    }
}
