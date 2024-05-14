using C9Z8DM_HFT_2023242.Logic;
using C9Z8DM_HFT_2023242.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace C9Z8DM_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IGradeLogic gradeLogic;
        IStudentLogic studentLogic;

        public StatController(IGradeLogic gradeLogic, IStudentLogic studentLogic)
        {
            this.gradeLogic = gradeLogic;
            this.studentLogic = studentLogic;
        }

        [HttpGet("{year}")]
        public double? AvarageGradesPerYear(int year)
        {
            return this.gradeLogic.GetAvarageGradesPerYear(year);
        }
        [HttpGet("{subject}")]
        public double? AvarageGradesPerSubject(string subject)
        {
            return this.gradeLogic.GetAvarageGradesPerSubject(subject);
        }
        [HttpGet]
        public IEnumerable<GradeInfo> AvarageGradesPerStudents()
        { 
            return this.gradeLogic.GetAvarageGradesPerStudents();
        }
        [HttpGet]
        public IEnumerable<GradeInfoPerSubject> AvarageGradesPerSubjects()
        {
            return this.gradeLogic.GetAvarageGradesPerSubjects();
        }
        [HttpGet]
        public int? NumbersOfStudentsThatHasFailed()
        {
            return this.gradeLogic.GetNumbersOfStudentsThatHasFailed();
        }
        [HttpGet]
        public IEnumerable<ClassInfo> StudentsCountOfEachClass()
        {
            return this.studentLogic.GetStudentsCountOfEachClass();
        }
    }
}
