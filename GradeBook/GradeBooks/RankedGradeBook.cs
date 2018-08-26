using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int totalStudents = Students.Count;
            if (totalStudents <5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            int TwentyPCOfTotalStudents = totalStudents / 5;


            List<double> averageGrades = (from Student in Students  select Student.AverageGrade).ToList();

            
            averageGrades.Sort();

            int threshold = (int)Math.Ceiling(Students.Count * 0.2);




            double lastAGrade = averageGrades.ElementAt(Students.Count - threshold);

            double lastBGrade = averageGrades.ElementAt(Students.Count - threshold*2);

            double lastCGrade = averageGrades.ElementAt(index: Students.Count - threshold*3);

            double lastDGrade = averageGrades.ElementAt(index:Students.Count - threshold*4);

            if (averageGrade >= lastAGrade)
            return 'A';
            
            if (averageGrade >= lastBGrade)
                return 'B';
            
            if (averageGrade >= lastCGrade)
                return 'C';
            
            if (averageGrade >= lastDGrade)
                return 'D';
                      
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();

            return;
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
            return;
        }

    }
}
