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


    }
}
