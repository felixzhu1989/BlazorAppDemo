
using System.ComponentModel.DataAnnotations;

namespace BlazingPizza;

public class Address
{
    public int Id { get; set; }
    [Required,MinLength(3,ErrorMessage = "长度应大于3"),MaxLength(100,ErrorMessage = "长度应小于100")]
    public string Name { get; set; }
    [Required, MinLength(5, ErrorMessage = "长度应大于5"), MaxLength(100, ErrorMessage = "长度应小于100")]
    public string Line1 { get; set; }
    [MaxLength(100, ErrorMessage = "长度应小于100")]
    public string Line2 { get; set; }
    [Required,MinLength(3, ErrorMessage = "长度应大于3"),MaxLength(50, ErrorMessage = "长度应小于50")]
    public string City { get; set; }
    [Required, MinLength(3, ErrorMessage = "长度应大于3"), MaxLength(20, ErrorMessage = "长度应小于20")]
    public string Region { get; set; }
    [Required,RegularExpression(@"^([0-9]{5})$",ErrorMessage = "邮政编码为5位数字")]
    public string PostalCode { get; set; }
}