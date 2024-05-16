using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string tenLoai { get; set; }
    }
}
