using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dietapp.Database.Models
{
    internal class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKh { get; set; }

        public string TenKhachHang { get; set; }

        public int CanNang { get; set; }

        public int ChieuCao { get; set; }

        public int GioiTinh { get; set; }

        public int TienTrinh { get; set; }

        public int Tuoi { get;set; }
    }
}
