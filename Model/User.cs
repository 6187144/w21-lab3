using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace w21_lab3.Models;

public class User
{
    public int UserId { get; set; }
    [MinLength(3, ErrorMessage = "Too short name"), MaxLength(40, ErrorMessage = "Name limit 40 characters")]
    public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }
    public int? StreetNumber { get; set; }
    public string? StreetName { get; set; }
    [RegularExpression(@"^[A-Za-z][0-9][A-Za-z][ ]*[0-9][A-Za-z][0-9]$")]
    public string? PostalCode { get; set; }
    [Required]
    public string? City { get; set; }
    [MinLength(2, ErrorMessage = "Please use 2 letter abb. for the province"), MaxLength(2, ErrorMessage = "Please use 2 letter abb. for the province")]
    public string? Province { get; set; }
    public string? Phone { get; set; }

}