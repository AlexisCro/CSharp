using System.ComponentModel.DataAnnotations;

namespace mvc.Models;

public enum Subjects
{
  CS, IT, MATHS, FRENCH, ENGLISH
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
  
  public DateTime JoiningDate { get; set; }
}