using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.Domain.ViewModels
{
    public class UnitViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
    }
}
