using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dietapp.Database.Models
{
    internal class NguyenLieu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNL { get; set; }

        public string TenNL { get; set; }

        public int SoCalo { get; set; }

        public int Carb { get; set; }

        public int ChatDam { get; set; }

        public int ChatBeo { get; set; }

        public byte[] HinhAnh { get; set;}
    }
}
