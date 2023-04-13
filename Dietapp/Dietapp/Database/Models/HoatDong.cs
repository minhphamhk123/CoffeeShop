using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dietapp.Database.Models
{
    internal class HoatDong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHD { get; set; }

        public string TenHD { get; set; }

        public int ThoiLuong { get; set; } // In minutes

        public int CaloTime { get; set; }
    }
}
