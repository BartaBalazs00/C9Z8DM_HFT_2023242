using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace C9Z8DM_HFT_2023242.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }

        [Required]
        [StringLength(240)]
        public string TeacherName { get; set; }
        [Required]
        [StringLength(240)]
        public string Subject { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Grade> Grades { get; set; }
        public Teacher() { }
        public Teacher(string line)
        {
            string[] split = line.Split('#');
            TeacherId = int.Parse(split[0]);
            TeacherName = split[1];
            Subject = split[2];
            Email = split[3];
        }
    }
}
