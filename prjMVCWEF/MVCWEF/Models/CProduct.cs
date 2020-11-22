using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWEF.Models
{
    public class CProduct
    {
        public int fProductId { get; set; }
        [Required(ErrorMessage ="輸入品名")]
        [DisplayName("品名")]
        public string fProductName { get; set; }
        [Required(ErrorMessage = "輸入價格")]
        [DisplayName("價格")]
        public decimal fPrice { get; set; }
        [Required(ErrorMessage = "輸入數量")]
        [DisplayName("數量")]
        public int fCount { get; set; }
    }
}