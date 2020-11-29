using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace mvcLoginRegistration.Models
{
    public class CUserAccount
    {
        [Key]
        public int fUserId { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage ="輸入姓名")]
        public string fName { get; set; }

        [DisplayName("信箱")]
        [Required(ErrorMessage = "輸入信箱")]
        [RegularExpression(@"^([\w-\.]+)@(([[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage ="格式不符")]
        [DataType(DataType.EmailAddress)]
        public string fEmail { get; set; }

        [DisplayName("使用者名稱")]
        [Required(ErrorMessage = "輸入使用者名稱")]
        public string fUserName { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "輸入密碼")]
        [DataType(DataType.Password)]
        public string fPassword{ get; set; }

        [DisplayName("確認密碼")]
        [Required(ErrorMessage = "輸入確認密碼")]
        [DataType(DataType.Password)]
        [Compare("fPassword",ErrorMessage ="密碼不一致")]
        public string fConfirmPassword { get; set; }
    }
}