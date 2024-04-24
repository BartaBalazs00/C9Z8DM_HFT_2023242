using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace C9Z8DM_HFT_2023242.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [StringLength(240)]
        public string StudentName { get; set; }
        [Required]
        [StringLength(240)]
        public string StudentClass { get; set; }
        [JsonIgnore]
        public virtual ICollection<Grade> Grades { get; set; }
        public Student() { }
        public Student(string line)
        {
            string[] split = line.Split('#');
            StudentId = int.Parse(split[0]);
            StudentName = split[1];
            StudentClass = split[2];
        }
    }
}
