using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Menu
    {
        public Guid Id { get; set; }


        [Display(Name = "Title")]
        [Required(ErrorMessage = "required")]
        [MaxLength(150)]
        public string Title { get; set; }


        public virtual IList<category>? Categories { get; set; }
        public Menu()
        {
            Categories = new List<category>();
        }
    }
}