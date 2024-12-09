using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System;
using System.Collections.Generic;

namespace mvc.Controllers;

public class StudentController : Controller
{
    private static List<StudentModel> students = new List<StudentModel>();

    public ActionResult Index()
    {
      int counter = 0;
      string[] names = ["John Doe", "Jane Doe", "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Heidi"];
      
      while (counter < 10)
      {
        var student = new StudentModel();
        student.Id = counter;
        student.Name = names[counter];
        student.Age = new Random().Next(18, 25);
        student.Email = $"{student.Name.Replace(" ", ".").ToLower()}@gmail.com";
        students.Add(student);
        counter++;
      }

      return View(students);
    }

    public ActionResult Show(int id)
    {
      var student = students.Find(student => student.Id == id);
      return View(student);
    }

    public ActionResult Delete(int id)
    {
      var student = students.Find(student => student.Id == id);
      students.Remove(student);
      return RedirectToAction("Index");
    }
}
