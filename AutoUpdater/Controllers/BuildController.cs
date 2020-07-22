using AutoUpdater.Helpers;
using AutoUpdater.Logic;
using AutoUpdater.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace AutoUpdater.Controllers
{
    [Route("autoupdater/build")]
    public class BuildController : Controller
    {
        [HttpPost("ekasut")]
        public async Task<object> UpdateEkasutAsync([FromBody] GitlabPushPost gitlabPushPost)
        {
            Log.Information($"User {gitlabPushPost.user_name} pushed something to {gitlabPushPost.repository.name}!");

            var result = await BuildLogic.BuildEkasut();

            return result;
        }

        [HttpPost("dbsync")]
        public async Task<object> UpdateDbsyncAsync([FromBody] GitlabPushPost gitlabPushPost)
        {
            Log.Information($"User {gitlabPushPost.user_name} pushed something to {gitlabPushPost.repository.name}!");

            var result = await BuildLogic.BuildDbsync();

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
