using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);

            var sortedGrades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if (sortedGrades[threshold - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (sortedGrades[(threshold*2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (sortedGrades[(threshold*3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (sortedGrades[(threshold*4) - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            return 'F';
        }
    }
}
