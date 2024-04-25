﻿using C9Z8DM_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C9Z8DM_HFT_2023242.Repository
{
    public class TeacherRepository : Repository<Teacher>, IRepository<Teacher>
    {
        public TeacherRepository(SchoolDbContext ctx) : base(ctx)
        {
        }

        public override Teacher Read(int id)
        {
            return ctx.Teachers.FirstOrDefault(t => t.TeacherId == id);
        }

        public override void Update(Teacher item)
        {
            var old = Read(item.TeacherId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
