using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dietapp.Database.Models
{
    internal class NauAn
    {
        [Key, Column(Order = 0)]
        public int MaMA { get; set; }

        [Key, Column(Order = 1)]
        public string TenKhachHang { get; set; }
    }
}
