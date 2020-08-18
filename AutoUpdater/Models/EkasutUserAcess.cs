using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoUpdater.Models
{
    public class EkasutUserAcess
    {
        public int UserId { get; set; }
        public int? KodFirm { get; set; }
        public int? TabNum { get; set; }
        public List<string> Grants { get; set; }
        public List<int> Roads { get; set; }
        public bool IsSld { get; set; }
        public bool IsTche { get; set; }
        public int PredId { get; set; }
        /// <summary>
        /// Уровень доступа предприятия юзера. 0 - ЦТ, 1 - региональное отделение тяги, 2 и ниже - ТЧЭ, СЛД и прочее.
        /// </summary>
        public int? AccessLevel { get; set; }
    }
}
