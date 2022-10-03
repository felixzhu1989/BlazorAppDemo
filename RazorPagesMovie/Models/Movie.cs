using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required]
        [StringLength(60,MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Display(Name= "Release Date")]//属性指定字段的显示名称。 
        [DataType(DataType.Date)]//仅显示日期，而非时间信息。
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]//[DisplayFormat] 特性用于显式指定日期格式
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; } = string.Empty;
        //数据注释使 Entity Framework Core 可以将 Price 正确映射到数据库中的货币。
        [Column(TypeName = "decimal(18, 2)")]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; } = string.Empty;
    }
}