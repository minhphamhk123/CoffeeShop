using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dietapp.Database.Models
{
    internal class ThamSo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaThamSo { get; set; }

        public int MaKH { get; set; }

        public int LuongNuoc { get; set; }

        public int ThoiGianLuyenTap { get; set; }

        public int LuongNuocCoc { get; set; }
    }
}
