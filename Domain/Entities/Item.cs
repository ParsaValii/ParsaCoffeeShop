using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; }


        [Display(Name = "Title")]
        [Required(ErrorMessage = "required")]
        [MaxLength(150)]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "required")]
        [MaxLength(350)]
        public string Description { get; set; }


        [Display(Name = "Price")]
        [Required(ErrorMessage = "required")]
        public decimal Price { get; set; }


        [Display(Name = "Image")]
        public string Image { get; set; }


        [Display(Name = "Category")]
        public virtual Category Category { get; set; }
    }
}