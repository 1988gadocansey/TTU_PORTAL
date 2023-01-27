namespace Students.Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        ICourseRepository Course { get; }
        IMountedCourseRepository MountedCourse { get; }

        ICalenderRepository Calender { get; }

        IEventRepository Event { get; set; }

        IDashBoardRepository Student { get; }

        IPaymentRepository Payment { get; }
        ITimeTableRepository TeachingTimeTable { get; }
        IAcademicRepository AcademicRecords { get; }

    }
}
