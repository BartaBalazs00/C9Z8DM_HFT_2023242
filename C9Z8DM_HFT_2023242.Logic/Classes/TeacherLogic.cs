using C9Z8DM_HFT_2023242.Models;
using C9Z8DM_HFT_2023242.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C9Z8DM_HFT_2023242.Logic
{
    public class TeacherLogic : ITeacherLogic
    {
        IRepository<Teacher> repo;

        public TeacherLogic(IRepository<Teacher> repo)
        {
            this.repo = repo;
        }

        public void Create(Teacher item)
        {
            if (item.TeacherName == null || item.Email == null || item.Subject == null)
            {
                throw new ArgumentException("All properties must be given");
            }
            if (item.TeacherName.Length < 5)
            {
                throw new ArgumentException("TeacherName is too short...");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Teacher Read(int id)
        {
            var teacher = this.repo.Read(id);
            if (teacher == null)
            {
                throw new ArgumentException("Teacher not exists");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Teacher> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Teacher item)
        {
            this.repo.Update(item);
        }
    }
}
