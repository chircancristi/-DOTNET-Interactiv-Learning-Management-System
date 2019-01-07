﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        InteractionModel interaction = new InteractionModel();
        CoursesModel courses = new CoursesModel();
        PeopleModel people = new PeopleModel();
        Profesor profesor = new Profesor();
        Course course;
        public IActionResult Professor(Guid id)
        {
            this.generateProfessor(id);
            List<Student> result = new List<Student>();
            //result = courses.GetStudentsByCourse();
            @ViewBag.students = result;
            return View();
        }
        private void generateProfessor(Guid id)
        {
            Guid profesorId = id;
            profesor = people.GetProfesor(profesorId);
            //course = courses.GetCourse(profesor.Course);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
