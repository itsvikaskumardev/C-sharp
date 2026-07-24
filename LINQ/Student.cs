namespace LINQ
{
    internal partial class LinqTutorial3
    {
        public enum Gender
        {
            Male,
            Female
        }

        public class Student
        {
            public int RollNo { get; set; }
            public string Name { get; set; }
            public int Standard { get; set; }
            public Gender Gender { get; set; }
        }

        public static class StudentDatabase
        {
            public static List<Student> GetStudents()
            {
                return new List<Student>
                {
                    new Student { RollNo = 101, Name = "Vikas",  Gender = Gender.Male,   Standard = 10 },
                    new Student { RollNo = 102, Name = "Rahul",  Gender = Gender.Male,   Standard = 9  },
                    new Student { RollNo = 103, Name = "Priya",  Gender = Gender.Female, Standard = 10 },
                    new Student { RollNo = 104, Name = "Anjali", Gender = Gender.Female, Standard = 8  },
                    new Student { RollNo = 105, Name = "Aman",   Gender = Gender.Male,   Standard = 11 },
                    new Student { RollNo = 106, Name = "Neha",   Gender = Gender.Female, Standard = 2 },
                    new Student { RollNo = 107, Name = "Rohit",  Gender = Gender.Male,   Standard = 9  },
                    new Student { RollNo = 108, Name = "Sneha",  Gender = Gender.Female, Standard = 11 },
                    new Student { RollNo = 109, Name = "Arjun",  Gender = Gender.Male,   Standard = 7 },
                    new Student { RollNo = 110, Name = "Pooja",  Gender = Gender.Female}
                };
            }
        }

        public class Standard
        {
            public int Id { get; set; }
            public string ClassTeacher { get; set; }
            public double Fees { get; set; }
        }

        public static class StandardDatabase
        {
            public static List<Standard> GetClasses()
            {
                return new List<Standard>
                {
                    new Standard { Id = 8,  ClassTeacher = "Mr. Sharma", Fees = 8000 },
                    new Standard { Id = 9,  ClassTeacher = "Mrs. Gupta", Fees = 8500 },
                    new Standard { Id = 10, ClassTeacher = "Mr. Verma",  Fees = 9000 },
                    new Standard { Id = 11, ClassTeacher = "Ms. Kapoor", Fees = 9500 },
                    new Standard { Id = 12, ClassTeacher = "Mr. Singh",  Fees = 10000 }
                };
            }
        }
    }
}