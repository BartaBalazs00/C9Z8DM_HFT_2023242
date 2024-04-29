using C9Z8DM_HFT_2023242.Models;
using System.Linq;

namespace C9Z8DM_HFT_2023242.Logic
{
    public interface ITeacherLogic
    {
        void Create(Teacher item);
        void Delete(int id);
        Teacher Read(int id);
        IQueryable<Teacher> ReadAll();
        void Update(Teacher item);
    }
}