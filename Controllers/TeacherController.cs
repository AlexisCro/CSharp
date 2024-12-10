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

  public ActionResult Index()
  {
    return View(_context.Teachers.ToList());
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

    teacher.Email = teacher.Name.Replace(' ', '.').ToLower() + "@school.com";
    // Ajouter le teacher
    _context.Teachers.Add(teacher);

    // Sauvegarder les changements
    _context.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Show(int id)
  {
    var teacher = _context.Teachers.Find(id);
    return View(teacher);
  }

  public ActionResult Edit(int id)
  {
    var teacher = _context.Teachers.Find(id);
    return View(teacher);
  }

  public ActionResult Update(TeacherModel teacher)
  {
    if (!ModelState.IsValid)
    {
      return View("Edit");
    }

    var teacherToUpdate = _context.Teachers.Find(teacher.Id);

    // modifier ici
    teacherToUpdate.Name        = teacher.Name;
    teacherToUpdate.Age         = teacher.Age;
    teacherToUpdate.Subject     = teacher.Subject;
    teacherToUpdate.JoiningDate = teacher.JoiningDate;
    
    // Mettre à jour le teacher
    _context.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Delete(int id)
  {
    _context.Teachers.Remove(_context.Teachers.Find(id));
    _context.SaveChanges();
    return RedirectToAction("Index");
  }
}