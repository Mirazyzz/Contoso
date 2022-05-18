namespace Contoso.Domain.DTOs.Subjects
{
    public class SubjectDto
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public decimal Fee { get; set; }
        public int TotalHours { get; set; }

        public SubjectDto(string subjectName, decimal fee, int totalHours)
        {
            SubjectName = subjectName;
            Fee = fee;
            TotalHours = totalHours;
        }

        public override string ToString()
        {
            return SubjectName;
        }
    }
}