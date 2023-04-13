using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dietapp.Database.Models
{
    internal class DangNhap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string TenNguoiDung { get; set; }

        public string MatKhau { get; set; }

        public string PhanQuyen { get; set; }
    }
}
