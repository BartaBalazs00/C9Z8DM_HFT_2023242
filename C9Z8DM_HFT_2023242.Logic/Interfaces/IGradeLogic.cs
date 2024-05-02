using C9Z8DM_HFT_2023242.Models;
using System.Collections.Generic;
using System.Linq;

namespace C9Z8DM_HFT_2023242.Logic
{
    public interface IGradeLogic
    {
        void Create(Grade item);
        void Delete(int id);
        IEnumerable<GradeInfo> GetAvarageGradesPerStudents();
        double? GetAvarageGradesPerSubject(string subject);
        IEnumerable<GradeInfoPerSubject> GetAvarageGradesPerSubjects();
        double? GetAvarageGradesPerYear(int year);
        int? GetNumbersOfStudentsThatHasFailed();
        Grade Read(int id);
        IQueryable<Grade> ReadAll();
        void Update(Grade item);
    }
}