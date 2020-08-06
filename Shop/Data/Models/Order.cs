using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name="Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage= "Name length 5+")]
        public string name { get; set; }
        [Display(Name = "Введите фамилию")]
        [StringLength(25)]
        [Required(ErrorMessage = "Sename length 5+")]
        public string sename { get; set; }
        [Display(Name = "Введите адрес")]
        [StringLength(35)]
        [Required(ErrorMessage = "adress length 15+")]
        public string adress { get; set; }
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "phone length 10+")]
        public string phone { get; set; }
        [Display(Name = "email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "email length 15+")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime ordeTime { get; set; }
       
        public List<OrderDetail> orderDetails { get; set; }

    }
}
