using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace mvc.Models;

public enum Subject
{
  CS,
  IT,
  MATHS,
  FRENCH,
  ENGLISH
}

public class TeacherModel
{
  public int Id { get; set; }
  
  [Required]
  public string Name { get; set; }
  
  [Required]
  [Range(20, 60)]
  public int Age { get; set; }  
  public string Subject { get; set; }
  public string Email { get; set; } = String.Empty;
  public DateTime JoiningDate { get; set; } = DateTime.Now;
}