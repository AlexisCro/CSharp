namespace mvc.Models;

public enum Subject
{
  CS, IT, MATHS, FRENCH, ENGLISH
}

public class TeacherModel
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int Age { get; set; }
  public string Email { get; set; }
  public string Subject { get; set; }
  public DateTime JoiningDate { get; set; }
}