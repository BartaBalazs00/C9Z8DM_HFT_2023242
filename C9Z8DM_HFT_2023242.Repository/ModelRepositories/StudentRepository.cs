using C9Z8DM_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C9Z8DM_HFT_2023242.Repository
{
    public class StudentRepository : Repository<Student>, IRepository<Student>
    {
        public StudentRepository(SchoolDbContext ctx) : base(ctx)
        {
        }

        public override Student Read(int id)
        {
            return ctx.Students.FirstOrDefault(t => t.StudentId == id);
        }

        public override void Update(Student item)
        {
            var old = Read(item.StudentId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
