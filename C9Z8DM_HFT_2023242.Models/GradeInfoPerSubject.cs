using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C9Z8DM_HFT_2023242.Models
{
    public class GradeInfoPerSubject
    {
        public string Subject { get; set; }
        public double? AvgGradeValue { get; set; }
        public override bool Equals(object obj)
        {
            GradeInfoPerSubject gradeInfoPerSubject = obj as GradeInfoPerSubject;
            if (gradeInfoPerSubject == null)
            {
                return false;
            }
            else
            {
                return this.Subject == gradeInfoPerSubject.Subject
                    && this.AvgGradeValue == gradeInfoPerSubject.AvgGradeValue;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Subject, this.AvgGradeValue);
        }
    }
}
