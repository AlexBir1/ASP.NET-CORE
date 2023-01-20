using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Models
{
    public class WirehousesPageViewModel
    {
        public int id { get; set; }
        public string title { get; set; }

        [Required(ErrorMessage = "ПОЛЕ ПУСТЕ")]
        public int quantity { get; set; }

        public int cost { get; set; }
        public string type_name { get; set; }
        public string owner_alias { get; set; }

        public List<WirehousesViewModel> ProductList { get; set; }
        public string GetByType { get; set; }
        public List<SelectListItem> ProdTypes { get; set; }
        public string GetByOwner { get; set; }
        public List<SelectListItem> OwnerList { get; set; }
        public WirehousesViewModel Product { get; set; }
        public int isAllEdit { get; set; }
        public bool IsMobileDevice { get; set; }
    }
}
