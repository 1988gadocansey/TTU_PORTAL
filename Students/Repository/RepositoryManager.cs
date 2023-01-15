using Students.Contracts;
using Students.Entities;

namespace Students.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository? _companyRepository;
        private IMountedCourseRepository? _mountedCourseRepository;
        private ICourseRepository? _courseRepository;
        private ICalenderRepository _calenderRepository;

        private IDashBoardRepository _dashboardRepository;
        private IEventRepository _eventRepository;


        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

        }

        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_repositoryContext);

                return _companyRepository;
            }
        }
        public ICourseRepository Course
        {
            get
            {
                if (_courseRepository == null)
                    _courseRepository = new CourseRepository(_repositoryContext);

                return _courseRepository;
            }
        }
        public IMountedCourseRepository MountedCourse
        {
            get
            {
                if (_mountedCourseRepository == null)
                    _mountedCourseRepository = new MountedCourseRepository(_repositoryContext);

                return _mountedCourseRepository;
            }
        }


        public ICalenderRepository Calender
        {
            get
            {
                if (_calenderRepository == null)
                    _calenderRepository = new CalenderRepository(_repositoryContext);

                return _calenderRepository;
            }
        }
        public IDashBoardRepository Student
        {
            get
            {
                if (_dashboardRepository == null)
                    _dashboardRepository = new DashboardRepository(_repositoryContext);

                return _dashboardRepository;
            }
        }

        IEventRepository IRepositoryManager.Event
        {
            get
            {
                if (_eventRepository == null)
                    _eventRepository = new EventRepository(_repositoryContext);

                return _eventRepository;
            }
            set
            {

            }
        }


    }
}