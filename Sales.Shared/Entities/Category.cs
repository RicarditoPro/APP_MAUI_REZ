﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Categorias")]
        [MaxLength(100, ErrorMessage = "El campo {0 debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string Address { get; set; } = null;

    }
}
