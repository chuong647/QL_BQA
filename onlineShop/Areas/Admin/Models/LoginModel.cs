using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace onlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Vui lòng nhập tên tài khoản")]
        public string tenTK { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string matkhau { set; get; }
    }
}