using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dietapp.Database.Models
{
    internal class QuanLy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaQL { get; set; }

        public int MaKH { get; set; }

        public DateTime ThoiGian { get; set; }

        public string TenMA { get; set; }

        public int MaHD { get; set; }

        public int MaBT { get; set; }
    }
}
