using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dietapp.Database.Models
{
    internal class MonAn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaMA { get; set; }

        public string TenMA { get; set; }

        public int SoCalo { get; set; }

        public byte[] HinhAnh { get; set; }
    }
}
