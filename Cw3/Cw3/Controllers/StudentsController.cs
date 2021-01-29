using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public string GetStudents(string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowanie={orderBy}";
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id==1)
            {
                return Ok("Kowalski");
            } else if (id==2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //... add to database
            //... generating index number
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id,Student student)
        {
            if (id==1)
            {
                student.FirstName = "Alan";
            }
            return Ok("Aktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id, Student student)
        {
            if (id==1)
            {
                student = null;
            }
            return Ok("Usuwanie zakończone");
        }
       
    }
}