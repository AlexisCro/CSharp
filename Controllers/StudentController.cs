using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using System;
using System.Collections.Generic;

namespace mvc.Controllers;

public class StudentController : Controller
{
  private readonly ApplicationDbContext _context;

  public StudentController(ApplicationDbContext context)
  {
    _context = context;
  }

  public ActionResult Index()
  {
    return View(_context.Students.ToList());
  }

  public ActionResult New()
    {
      return View();
    }

    public ActionResult Create(StudentModel student)
    { 
      if (!ModelState.IsValid)
      {
        return View("New");
      }

      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Show(int id)
    {
      var student = _context.Students.Find(id);
      return View(student);
    }

    public ActionResult Edit(int id)
    {
      var student = _context.Students.Find(id);
      return View(student);
    }

    public ActionResult Update(StudentModel student)
    {
      if (!ModelState.IsValid)
      {
        return View("Edit");
      }

      var StudentToUpdate = _context.Students.Find(student.Id);

      StudentToUpdate.Name          = student.Name;
      StudentToUpdate.Age           = student.Age;
      StudentToUpdate.Major         = student.Major;
      StudentToUpdate.AdmissionDate = student.AdmissionDate;

      _context.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      _context.Students.Remove(_context.Students.Find(id));
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
}
