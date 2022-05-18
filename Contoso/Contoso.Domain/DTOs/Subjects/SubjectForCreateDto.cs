namespace Contoso.Domain.DTOs.Subjects
{
    public class SubjectForCreateDto
    {
        public string SubjectName { get; set; }
        public decimal Fee { get; set; }
        public int? TotalHours { get; set; }

        public SubjectForCreateDto(string subjectName, decimal fee, int? totalHours)
        {
            SubjectName = subjectName;
            Fee = fee;
            TotalHours = totalHours;
        }
    }
}
