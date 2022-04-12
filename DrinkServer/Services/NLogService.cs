using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Helpers;
using DrinkServer.ViewModels;
using Newtonsoft.Json;

namespace DrinkServer.Services
{
    public class NLogService : INLogService
    {
        private readonly ILogger<NLogService> _logger;
        private readonly IHttpContextAccessor _accessor;
        public NLogService(ILogger<NLogService> logger, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _accessor = accessor;
        }

        public void NlogStart(string message)
        {

            LoginAuthorizeVM vm = _accessor.HttpContext.Session
                .GetObject<LoginAuthorizeVM>("User");
            _logger.LogError(vm.UserName);

            _logger.LogError($" {message}------------------Start----------------");
        }

        public void NlogEnd(string message)
        {
            LoginAuthorizeVM vm = _accessor.HttpContext.Session
                .GetObject<LoginAuthorizeVM>("User");
            _logger.LogError($" {message}-------------------End-----------------");
        }
        public void NlogObject<T>(T t)
        {
            LoginAuthorizeVM vm = _accessor.HttpContext.Session
                .GetObject<LoginAuthorizeVM>("User");
            string json = JsonConvert.SerializeObject(t);
            _logger.LogError($" {json}");
        }
    }
}
