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
        private IUnitOfWork _unitOfWork;
        private IDashBoardRepository _dashboardRepository;
        private IEventRepository _eventRepository;

        private IPaymentRepository _paymentRepository;

        private ITimeTableRepository _timetableRepository;
        private IAcademicRepository _academicRepository;


        public RepositoryManager(RepositoryContext repositoryContext, IUnitOfWork unitOfWork)
        {
            _repositoryContext = repositoryContext;
            _unitOfWork = unitOfWork;

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
                    _mountedCourseRepository = new MountedCourseRepository(_repositoryContext, _unitOfWork);

                return _mountedCourseRepository;
            }
        }


        public ICalenderRepository Calender
        {
            get
            {
                if (_calenderRepository == null)
                    _calenderRepository = new CalenderRepository(_repositoryContext, _unitOfWork);

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

        //public IPaymentRepository Payment => throw new NotImplementedException();

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

        IPaymentRepository IRepositoryManager.Payment
        {
            get
            {
                if (_paymentRepository == null)
                    _paymentRepository = new PaymentRepository(_repositoryContext);

                return _paymentRepository;
            }

        }
        ITimeTableRepository IRepositoryManager.TeachingTimeTable
        {
            get
            {
                if (_timetableRepository == null)
                    _timetableRepository = new TimeTableRepository(_repositoryContext);

                return _timetableRepository;
            }

        }
        IAcademicRepository IRepositoryManager.AcademicRecords
        {
            get
            {
                if (_academicRepository == null)
                    _academicRepository = new AcademicRecordRepository(_repositoryContext);

                return _academicRepository;
            }

        }



    }
}