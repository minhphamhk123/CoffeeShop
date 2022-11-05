using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dietapp.Database.Models
{
    internal class LichSu
    {
        [Key]
        public DateTime ThoiGian { get; set; }

        public int LuongNuocUong { get; set; }

        public int LuongCalo { get; set; }

        public int LuongCarb { get; set; }

        public int LuongLipid { get; set; }

        public int LuongDam { get; set; }
    }
}
