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
    return View(teachers);
  }

  public ActionResult Show(int id)
  {
    var teacher = teachers.Find(teacher => teacher.Id == id);
    return View(teacher);
  }

  public ActionResult New()
  {
    return View();
  }

  public ActionResult Create(TeacherModel teacher)
  {
    if (!ModelState.IsValid)
    {
      return View("New");
    }

    if (teachers.Count == 0)
    {
      teacher.Id = 1;
    }
    else
    {
      teacher.Id = teachers.Max(teacher => teacher.Id) + 1;
    }

    teacher.Subject = teacher.Subject;
    teachers.Add(teacher);
    return RedirectToAction("Index");
  }

  public ActionResult Edit(int id)
  {
    var teacher = teachers.Find(teacher => teacher.Id == id);
    return View(teacher);
  }

  public ActionResult Update(TeacherModel teacher)
  {
    var teacherToUpdate = teachers.Find(teacher => teacher.Id == teacher.Id);
    teacherToUpdate.Name = teacher.Name;
    teacherToUpdate.Age = teacher.Age;
    teacherToUpdate.JoiningDate = teacher.JoiningDate;
    teacherToUpdate.Subject = teacher.Subject;

    return RedirectToAction("Index");
  }

  public ActionResult Delete(int id)
  {
    var teacher = teachers.Find(teacher => teacher.Id == id);
    teachers.Remove(teacher);
    return RedirectToAction("Index");
  }
}