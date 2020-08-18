using AutoUpdater.Models;
using Jose;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdater.Helpers
{
    public static class EkasutJWTHelper
    {
        private static JsonSerializerSettings JsonSettings { get; set; } = new JsonSerializerSettings()
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Include, // Program.Configuration["includeNullInJson"]=="true"?NullValueHandling.Include:NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            DateFormatString = "yyyy-MM-ddTHH:mm:ss",
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            TypeNameHandling = TypeNameHandling.All
        };

        public static string CreateToken(EkasutUserAcess ua)
        {
            string[] grants = ua.Grants?.ToArray();
            ua.Grants = null;
            string sub = JsonConvert.SerializeObject(ua, Formatting.None, JsonSettings);
            var baseDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var payload = new Dictionary<string, object>()
            {
                { "sub", Convert.ToBase64String(Encoding.UTF8.GetBytes(sub)) },
                { "exp", (int)(DateTime.UtcNow.AddHours(24) - baseDate).TotalSeconds},
                { "iat", (int)(DateTime.UtcNow - baseDate).TotalSeconds },
                { "nbf", (int)(DateTime.UtcNow - baseDate).TotalSeconds },
                { "role", grants}
            };

            string token = JWT.Encode(payload, KeyHelper.Instance.SignKey, JwsAlgorithm.HS512);
            return token;
        }
    }
}
