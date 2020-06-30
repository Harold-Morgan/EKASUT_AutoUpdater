using AutoUpdater.Helpers;
using AutoUpdater.Logic;
using AutoUpdater.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace AutoUpdater.Controllers
{
    [Route("api/build")]
    public class BuildController : Controller
    {
        [HttpPost("ekasut")]
        public async Task<object> EkasutAsync([FromBody] GitlabPushPost gitlabPushPost)
        {
            Log.Information($"User {gitlabPushPost.user_name} pushed something!");

            var result = BuildLogic.BuildEkasut();

            return result;
        }

        [HttpGet("a")]
        public object A()
        {
            Log.Information("aaa");


            return "Hi";
        }

    }
}
