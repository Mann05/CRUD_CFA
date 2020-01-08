using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_CFA.Models
{
    [Table("Class")]
    public class ClassesModel
    {
        [Key]
        public int ClassId { get; set; }

        [Required(ErrorMessage ="Class Name is Required")]
        public string ClassName { get; set; }
        [ForeignKey("ClassId")]
        public ICollection<StudentModel> Student { get; set; }
    }
}