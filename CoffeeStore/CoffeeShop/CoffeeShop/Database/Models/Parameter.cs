﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Database.Models
{
    [Table("Parameter")]
    public class Parameter
    {
        [Key, MaxLength(10)]
        public string Name { get; set; }

        public int Value { get; set; }
    }
}
