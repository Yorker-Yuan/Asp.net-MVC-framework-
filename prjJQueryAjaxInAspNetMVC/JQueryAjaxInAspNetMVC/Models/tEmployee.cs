//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JQueryAjaxInAspNetMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class tEmployee
    {
        public int fEmpId { get; set; }

        [Required(ErrorMessage ="輸入姓名")]
        [DisplayName("姓名")]
        public string fName { get; set; }

        [DisplayName("職稱")]
        public string fPosition { get; set; }

        [DisplayName("部門")]
        public string fOffice { get; set; }

        [DisplayName("薪資")]
        public Nullable<int> fSalary { get; set; }

        [DisplayName("圖檔路徑")]
        public string fImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase fImageUpload { get; set; }

        public tEmployee()
        {
            fImagePath = "~/AppFiles/images/default.png";
        }
    }
}