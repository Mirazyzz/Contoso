using Bogus;
using Contoso.Domain.Entities;
using Contoso.Domain.Enums;
using Contoso.Infrastructure;

namespace Contoso.Api.Helpers
{
    public static class SeedData
    {
        private static readonly Random random = new Random();
        private static readonly Faker faker = new Faker("en");

        public static void Initialize(ContosoDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }
            try
            {
                var cities = GetCities();

                context.Cities.AddRange(cities);
                context.SaveChanges();

                var cityEntites = context.Cities.ToList();

                var departments = GetDepartments(cityEntites);

                context.Departments.AddRange(departments);
                context.SaveChanges();

                var departmentEntities = context.Departments.ToList();

                var subjects = GetSubjects();
                var students = GetStudents(departmentEntities);
                var instructors = GetInstructors(departmentEntities);

                context.Subjects.AddRange(subjects);
                context.Students.AddRange(students);
                context.Instructors.AddRange(instructors);

                context.SaveChanges();

                var subjectEntities = context.Subjects.ToList();
                var studentEntities = context.Students.ToList();
                var instructorEntites = context.Instructors.ToList();

                var enrollments = GetEnrollments(subjectEntities, studentEntities);
                var courseAssignments = GetCourseAssignments(subjectEntities, instructorEntites);

                context.Enrollments.AddRange(enrollments);
                context.CourseAssignments.AddRange(courseAssignments);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        private static List<City> GetCities()
        {
            return new List<City>()
            {
                new City("New York"),
                new City("Massachusetts"),
                new City("London"),
                new City("Warsaw"),
                new City("Paris")
            };
        }

        private static List<Department> GetDepartments(List<City> cities)
        {
            List<string> departmentNames = new List<string>()
            {
                "IT",
                "Applied mathematics",
                "Physics",
                "3D Animation",
                "Legal",
                "Architecture",
                "Design"
            };

            List<Department> departments = new List<Department>();

            foreach (var departmentName in departmentNames)
            {
                departments.Add(new Department(departmentName, cities[random.Next(0, cities.Count - 1)].CityId));
            }

            return departments;
        }

        private static List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();

            for (int i = 0; i < 20; i++)
            {
                subjects.Add(new Subject(faker.Lorem.Word(), decimal.Parse(random.Next(150, 500).ToString()), random.Next(20, 80)));
            }

            return subjects;
        }

        private static List<Student> GetStudents(List<Department> departments)
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < 250; i++)
            {
                var randomGender = GetRandomGender();
                var randomDepartment = departments[random.Next(0, departments.Count - 1)];

                students.Add(new Student(faker.Name.FindName(), faker.Name.LastName(), randomDepartment.DepartmentId, GetRandomBirthDate(), randomGender));
            }

            return students;
        }

        private static List<Instructor> GetInstructors(List<Department> departments)
        {
            List<Instructor> instructors = new List<Instructor>();

            for (int i = 0; i < 50; i++)
            {
                var randomDepartment = departments[random.Next(0, departments.Count - 1)];
                instructors.Add(new Instructor(faker.Name.FullName(), GetRandomBirthDate(), GetRandomGender(), randomDepartment.DepartmentId));
            }

            return instructors;
        }

        private static List<Enrollment> GetEnrollments(List<Subject> subjects, List<Student> students)
        {
            var uniqueSubjects = GetRandomUniqueSubjects(subjects);
            List<Enrollment> enrollments = new List<Enrollment>();

            foreach (var student in students)
            {
                foreach (var subject in uniqueSubjects)
                {
                    var randomGrade = GetRandomGrade();
                    enrollments.Add(new Enrollment(student.StudentId, subject.SubjectId, randomGrade));
                }
            }

            return enrollments;
        }

        private static List<CourseAssignment> GetCourseAssignments(List<Subject> subjects, List<Instructor> instructors)
        {
            var uniqueSubjects = GetRandomUniqueSubjects(subjects);
            List<CourseAssignment> courseAssignments = new List<CourseAssignment>();

            foreach (var instructor in instructors)
            {
                foreach (var subject in uniqueSubjects)
                {
                    courseAssignments.Add(new CourseAssignment(instructor.InstructorId, subject.SubjectId));
                }
            }

            return courseAssignments;
        }

        private static Gender GetRandomGender()
        {
            var valuesAsList = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            return valuesAsList[random.Next(0, valuesAsList.Count)];
        }

        private static Grade GetRandomGrade()
        {
            var valuesAsList = Enum.GetValues(typeof(Grade)).Cast<Grade>().ToList();

            return valuesAsList[random.Next(0, valuesAsList.Count)];
        }

        private static DateTime GetRandomBirthDate()
        {
            DateTime minBirthDate = new DateTime().AddYears(1990);
            DateTime maxBirthDate = new DateTime().AddYears(2005);

            return faker.Date.Between(minBirthDate, maxBirthDate);
        }

        private static List<Subject> GetRandomUniqueSubjects(List<Subject> subjects)
        {
            Dictionary<int, Subject> uniqueSubjects = new Dictionary<int, Subject>();

            while (uniqueSubjects.Count < 10)
            {
                var randomSubject = subjects[random.Next(0, subjects.Count - 1)];

                if (!uniqueSubjects.ContainsKey(randomSubject.SubjectId))
                {
                    uniqueSubjects.Add(randomSubject.SubjectId, randomSubject);
                }
            }

            return uniqueSubjects.Values.ToList();
        }
    }
}
