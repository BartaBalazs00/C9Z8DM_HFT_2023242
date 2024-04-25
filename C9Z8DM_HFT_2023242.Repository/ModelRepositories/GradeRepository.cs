using C9Z8DM_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C9Z8DM_HFT_2023242.Repository
{
    public class GradeRepository : Repository<Grade>, IRepository<Grade>
    {
        public GradeRepository(SchoolDbContext ctx) : base(ctx)
        {
        }

        public override Grade Read(int id)
        {
            return ctx.Grades.FirstOrDefault(t => t.GradeId == id);
        }

        public override void Update(Grade item)
        {
            var old = Read(item.GradeId);
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
