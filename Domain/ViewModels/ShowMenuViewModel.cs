using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ShowMenuViewModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public virtual IList<Item>? Items { get; set; }
    }
}
