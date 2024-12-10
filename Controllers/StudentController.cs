using AspNetCoreGeneratedDocument;
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
      return View(students);
    }

    public ActionResult New()
    {
      return View();
    }

    public ActionResult Create(StudentModel student)
    { 
      if (students.Count == 0)
      {
        student.Id = 1;
      }
      else
      {
        student.Id = students.Max(student => student.Id) + 1;
      }

      student.Email = $"{student.Name.Replace(" ", ".").ToLower()}@gmail.com";
      students.Add(student);
      return RedirectToAction("Index");
    }

    public ActionResult Show(int id)
    {
      var student = students.Find(student => student.Id == id);
      return View(student);
    }

    public ActionResult Edit(int id)
    {
      var student = students.Find(student => student.Id == id);
      return View(student);
    }

    public ActionResult Update(StudentModel student)
    {
      var studentToUpdate = students.Find(student => student.Id == student.Id);
      studentToUpdate.Name = student.Name;
      studentToUpdate.Age = student.Age;
      studentToUpdate.AdmissionDate = student.AdmissionDate;
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var student = students.Find(student => student.Id == id);
      students.Remove(student);
      return RedirectToAction("Index");
    }
}
