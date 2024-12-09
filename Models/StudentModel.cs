namespace mvc.Models;

public enum Major
{
  CS, IT, MATHS, OTHER
}

public class StudentModel
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int Age { get; set; }
  public string Email { get; set; }
  public Major Major { get; set; }
  public DateTime AdmissionDate { get; set; }
}