# Contoso
Test project

## Spec
You are given next tables:  
  CITIES: Id, Name, CreatedDate, LastUpdatedDate, IsDeleted  
  DEPARTMENTS: Id, Name, CreatedDate, LastUpdatedDate, IsDeleted  
  STUDENTS: Id, Name, CityId, BirthDate, Gender, CurrentGradeLevel, DepartmentId, CreatedDate, LastUpdatedDate, IsDeleted  
  TEACHERS: Id, Name, CityId, BirthDate, Gender, CreatedDate, LastUpdatedDate, IsDeleted  
  TEACHERS_SUBJECTS: Id, TeacherId, SubjectId, CreatedDate, LastUpdatedDate, IsDeleted  
  STUDENTS_SUBJECTS: Id, StudentId, SubjectId, Mark, CreatedDate, LastUpdatedDate, IsDeleted  
    
Create WebApi with all the functionality that you think as necessary. At least make following methods:  
- CRUDs  
- Filtering in tables  
- Filtering students by fields including, but not limited to, gender, department, age, zodiac sign, city, grade and studying subjects  
- Filtering teachers by fields including, but not limited to, gender, age and teaching subject  
- Find out 10 students with highest mark by chosen subject, ordered by mark, grade and age  
- Find out 10 teachers, who is teaching TOP-5 students with highest marks or TOP-5 students with lowest marks
