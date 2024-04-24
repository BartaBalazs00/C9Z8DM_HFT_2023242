using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace C9Z8DM_HFT_2023242.Models
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradeId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [StringLength(240)]
        public string Subject { get; set; }
        [Required]
        [Range(1, 5)]
        public int GradeValue { get; set; }
        public int Year { get; set; }
        public virtual Student Student { get; private set; }
        public virtual Teacher Teacher { get; private set; }
        public Grade() { }
        public Grade(string line)
        {
            string[] split = line.Split('#');
            GradeId = int.Parse(split[0]);
            StudentId = int.Parse(split[1]);
            Subject = split[2];
            GradeValue = int.Parse(split[3]);
            Year = int.Parse(split[4]);
        }
    }
}
