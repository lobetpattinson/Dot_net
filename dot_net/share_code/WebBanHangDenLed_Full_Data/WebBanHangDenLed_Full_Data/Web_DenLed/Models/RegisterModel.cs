using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Display(Name = "Tên đăng nhập")]
        //[Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập.")]
        public string UserName { set; get; }



        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu tối thiểu từ 6 ký tự trở lên.")]
        //[Required(ErrorMessage = "Yêu cầu nhập mật khẩu.")]
        public string Password { set; get; }




        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        //[Required(ErrorMessage = "Yêu cầu xác nhận mật khẩu.")]
        public string ConfirmPassword { set; get; }



        [Display(Name = "Họ tên")]
        //[Required(ErrorMessage = "Yêu cầu nhập họ tên.")]
        public string Name { set; get; }




        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        public string Address { set; get; }




        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập Email.")]
        public string Email { set; get; }




        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập SĐT")]
        public string Phone { set; get; }
    }
}
