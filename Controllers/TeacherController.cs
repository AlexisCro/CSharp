using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System;
using System.Collections.Generic;

namespace mvc.Controllers;

public class TeacherController : Controller
{
  private static List<TeacherModel> teachers = new List<TeacherModel>();

  public ActionResult Index()
  {
    int counter = 0;
    string[] names = ["Albert Einstein", "Isaac Newton", "Galileo Galilei", "Marie Curie", "Nikola Tesla", "Thomas Edison", "Leonardo da Vinci", "Stephen Hawking", "Ada Lovelace", "Alan Turing"];

    while (counter < 10)
    {
      var teacher = new TeacherModel();
      teacher.Id = counter;
      teacher.Name = names[counter];
      teacher.Age = new Random().Next(40, 65);
      teacher.Email = $"{teacher.Name.Replace(" ", ".").ToLower()}@gmail.com";
      teacher.Subject = Enum.GetName(typeof(Subject), new Random().Next(0, 5));
      teachers.Add(teacher);
      counter++;
    }

    return View(teachers);
  }

  public ActionResult Show(int id)
  {
    var teacher = teachers.Find(teacher => teacher.Id == id);
    return View(teacher);
  }
}