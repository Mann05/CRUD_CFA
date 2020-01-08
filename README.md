# CRUD_CFA
CRUD_CFA ( Create, Read, Update, Delete with Code First Approach Technique with EF 6 and .net Framework 4.7)

# Migration Points
Add Some line of Code in Global.asax file : 
```
Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
```
or through the Console :
```
Enable-Migrations  
add-migration InitialCreate  
update-database
```
<b>Note:</b>Once the migration is finished, you will see a Migrations folder with two files.

# Other Stuff
```
    [Table("StudentDetail")]
    public class StudentModel
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public int  ClassId { get; set; }
    }
```

```
The [Key] attribute is used to denote the property that uniquely identifies an entity (the EntityKey), and which is mapped to the Primary Key field in a database
```
```
The [Table("StudentDetail")] attribute is used to denote the Table name which is mapped to the Table Name in the databse.
```
```
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
```
```
[Required] 
Attribute make the Sql Column Not Null. [More Info Data Annotations](https://www.tutorialspoint.com/asp.net_mvc/asp.net_mvc_data_annotations.htm)
```
```
        [ForeignKey("ClassId")]
        public ICollection<StudentModel> Student { get; set; }
        
        Declare the foreign key and mapped with StudentModal and make the ClassId property as Foreign key
```
```
ViewBag.classes = db.Class.ToList();
ViewBag uses for data transfer from controller to View in MVC. [More Info](https://www.tutorialsteacher.com/mvc/viewbag-in-asp.net-mvc)
```
