using C9Z8DM_HFT_2023242.Models;
using System.Linq;

namespace C9Z8DM_HFT_2023242.Logic
{
    public interface IGradeLogic
    {
        void Create(Grade item);
        void Delete(int id);
        Grade Read(int id);
        IQueryable<Grade> ReadAll();
        void Update(Grade item);
    }
}