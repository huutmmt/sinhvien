using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace database.Models
{
    public class SinhVien
    {
        [Display(Name ="mã sinh viên")]
        [Key]
        public int ma { get; set; }
        [Display(Name = "họ tên")]

        public string ht { get; set; }
        [Display(Name = "Điểm thi")]

        public decimal diem { get; set; }
        
    }
}