﻿using C9Z8DM_HFT_2023242.Models;
using System.Collections.Generic;
using System.Linq;

namespace C9Z8DM_HFT_2023242.Logic
{
    public interface IStudentLogic
    {
        void Create(Student item);
        void Delete(int id);
        IEnumerable<ClassInfo> GetStudentsCountOfEachClass();
        Student Read(int id);
        IQueryable<Student> ReadAll();
        void Update(Student item);
    }
}