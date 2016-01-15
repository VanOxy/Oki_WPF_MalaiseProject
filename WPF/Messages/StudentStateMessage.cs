using System;
using WPF.UnivercityService;

namespace WPF.Messages
{
    internal class StudentStateMessage
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public SexEnum Sex { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public int CurrentClass { get; set; }

        public StudentStateMessage(int id, string name, string surname, int age, SexEnum sex,
                                   DateTime? enrolementDate, int currentClass)
        {
            StudentId = id;
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
            EnrollmentDate = enrolementDate;
            CurrentClass = currentClass;
        }
    }
}