using AutoUpdater.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace AutoUpdater.Controllers
{
    [Route("api/build")]
    public class BuildController : Controller
    {
        [HttpPost("ekasut")]
        public object Ekasut([FromBody] GitlabPushPost gitlabPushPost)
        {
            Log.Information("POST RECIEVED");

            Log.Information($"User {gitlabPushPost.user_name} pushed something!");

            return gitlabPushPost;
        }

        [HttpGet("a")]
        public object a()
        {
            Log.Information("aaa");


            return "Hi";
        }

    }
}
