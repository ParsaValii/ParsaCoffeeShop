using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }


        [Display(Name = "Title")]
        [Required(ErrorMessage = "required")]
        [MaxLength(150)]
        public string Title { get; set; }


        [Display(Name = "Image")]
        public string Image { get; set; }


        [Display(Name = "Items")]
        public virtual IList<Item>? Items { get; set; }
        public Category()
        {
            Items = new List<Item>();
        }
    }
}