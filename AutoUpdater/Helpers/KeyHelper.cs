using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoUpdater.Helpers
{
    public class KeyHelper
    {
        private static KeyHelper _instance;
        public static KeyHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KeyHelper();
                    //Плохая практика, но здесь сработает
                    string path = AppContext.BaseDirectory + "/keystore.pfx";
                    _instance.SignKey = File.ReadAllBytes(path);
                    _instance.SecurityKey = new SymmetricSecurityKey(_instance.SignKey);
                }
                return _instance;
            }
        }

        public byte[] SignKey { get; set; }
        public SymmetricSecurityKey SecurityKey { get; set; }
    }
}
