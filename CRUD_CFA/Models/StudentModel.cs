using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_CFA.Models
{
    // StudentDetail Treated as Table name  else StudentModel is a Table name
    [Table("StudentDetail")]
    public class StudentModel
    {
        [Key] // Treated as Primary key
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public int  ClassId { get; set; }
    }
}