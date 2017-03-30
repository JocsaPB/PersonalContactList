using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalContactList.MVC.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Informe um nome para a categoria")]
        [DisplayName("Nome da categoria")]
        public string CategoryName { get; set; }
        [DisplayName("Categoria especial?")]
        public bool EspecialCategory { get; set; }
    }
}