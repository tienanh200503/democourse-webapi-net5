using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int maLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string tenLoai { get; set; }
        public virtual ICollection<HangHoa> HangHoas { get; set; }
    }
}
