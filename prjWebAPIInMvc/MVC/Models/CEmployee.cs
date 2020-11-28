using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CEmployee
    {

        public int fEmpId { get; set; }
        [DisplayName("姓名")]
        [Required(ErrorMessage ="輸入姓名")]
        public string fName { get; set; }
        [DisplayName("職稱")]
        public string fPosition { get; set; }
        [DisplayName("年齡")]
        public Nullable<int> fAge { get; set; }
        [DisplayName("薪資")]
        public Nullable<int> fSalary { get; set; }
    }
}