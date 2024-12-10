using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using System;
using System.Collections.Generic;

namespace mvc.Controllers;

public class TeacherController : Controller
{
  private readonly ApplicationDbContext _context;

  // Constructeur
  public TeacherController(ApplicationDbContext context)
  {
      _context = context;
  }

  private static List<TeacherModel> teachers = new List<TeacherModel>();

  public ActionResult Index()
  {

    return View(_context.Teachers.ToList());
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

    // Ajouter le teacher
    _context.Teachers.Add(teacher);

    // Sauvegarder les changements
    _context.SaveChanges();
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