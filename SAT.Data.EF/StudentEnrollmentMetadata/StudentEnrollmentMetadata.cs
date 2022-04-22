using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SAT.Data.EF/*.StudentEnrollmentMetadata*/
{
    class StudentEnrollmentMetadata
    {
        public class CourseMetadata
        {
            [Required(ErrorMessage ="Course Name is required")]
            [StringLength(50, ErrorMessage ="Must be 50 characters or less")]
            [Display(Name ="Course Name")]
            public string CourseName { get; set; }

            [Required(ErrorMessage ="Description is required")]
            [UIHint("MultilineText")]
            public string Description { get; set; }

            [Required(ErrorMessage="Credit Hours is required")]
            [Display(Name = "Credit Hour(s)")]
            public int CreditHours { get; set; }

            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string CourseImage { get; set; }
        }

        [MetadataType(typeof(CourseMetadata))]
        public partial class Course { }

        public class EnrollmentMetadata
        {
            [Required(ErrorMessage ="Student ID is required")]
            public int StudentID { get; set; }

            [Required(ErrorMessage ="Scheduled Class ID is required")]
            public int ScheduledClassID { get; set; }

            [Required(ErrorMessage ="Enrollment Date is required")]
            [Display(Name ="Enrollment Date")]
            [DisplayFormat(DataFormatString ="{0:d}")]
            public System.DateTime EnrollmentDate { get; set; }
        }

        [MetadataType(typeof(EnrollmentMetadata))]
        public partial class Enrollment { }
    }

    public class ScheduledClassMetadata
    {
        [Required(ErrorMessage ="Course ID is required")]
        [Display(Name ="Course")]
        public int CourseID { get; set; }

        [Required(ErrorMessage ="Instructor Name is required")]
        [StringLength(50, ErrorMessage = "Must be 50 characters or less")]
        [Display(Name="Instructor")]
        public string InstructorName { get; set; }

        [Required(ErrorMessage ="Start Date is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name ="Start Date")]
        public System.DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required(ErrorMessage ="End Date is required")]
        public System.DateTime EndDate { get; set; }

        [Display(Name ="Day of Week")]
        [Required(ErrorMessage ="Class Day is required")]
        [StringLength(50, ErrorMessage ="Must be 50 characters or less")]
        public string ClassDay { get; set; }

        [Required(ErrorMessage = "Class Time is required")]
        [Display(Name = "Class Time")]
        [DisplayFormat(DataFormatString ="{0:h\\:mm}")]
        public System.TimeSpan ClassTime { get; set; }

        [Required(ErrorMessage ="Scheduled Class Status is Required")]
        [Display(Name = "Scheduled Class Status")]
        public int SCSID { get; set; }
    }

    [MetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass
    {
        public string ClassInfo
        {
            get { return $"Start Date: {StartDate:d} Course: {Cours.CourseName}"; }
        }
    }

    public class ScheduledClassStatusMetadata
    {
        [Required(ErrorMessage ="Scheduled Class Status is required")]
        public string SCSName { get; set; }
    }

    [MetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus { }

    public class StudentMetadata
    {
        [Required(ErrorMessage ="First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage ="Must be 50 characters or less")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is required")]
        [Display(Name ="Last Name")]
        [StringLength(50, ErrorMessage ="Must be 50 characters or less")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [StringLength(100, ErrorMessage ="Must be 100 characters or less")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Student Status is required")]
        public int SSID { get; set; }
    }

    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }

    public class StudentStatusMetadata
    {
        [Required(ErrorMessage = "Student Status is required")]
        [StringLength(50, ErrorMessage="Must be 50 characters or less")]
        [Display(Name = "Student Status")]
        public string SSName { get; set; }

        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText ="---")]
        [Display(Name = "Description")]
        public string SSDecscription { get; set; }
    }

    [MetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus { }


}


