using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C9Z8DM_HFT_2023242.Models
{
    public class GradeInfo
    {
        public string Name { get; set; }
        public double? AvgGradeValue { get; set; }
        public override bool Equals(object obj)
        {
            GradeInfo gradeInfo = obj as GradeInfo;
            if (gradeInfo == null)
            {
                return false;
            }
            else
            {
                return this.Name == gradeInfo.Name
                    && this.AvgGradeValue == gradeInfo.AvgGradeValue;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.AvgGradeValue);
        }
    }
}
