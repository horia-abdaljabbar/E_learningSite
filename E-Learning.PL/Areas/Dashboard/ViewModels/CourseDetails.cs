﻿namespace E_Learning.PL.Areas.Dashboard.ViewModels
{
    public class CourseDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TeacherName { get; set; }
        public int NumOfHour { get; set; }
        public string ImageName { get; set; }
        public bool IsFinished { get; set; }
        public DateTime CreatedAt { get; set; }
        public int NumOfStudents { get; set; }
    }
}