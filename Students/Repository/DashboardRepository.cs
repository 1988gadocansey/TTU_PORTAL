using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class DashboardRepository : RepositoryBase<Student>, IDashBoardRepository
    {
        public DashboardRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        Student IDashBoardRepository.GetByEmail(User user)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Event> IDashBoardRepository.GetEvents(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Payment> IDashBoardRepository.GetLastPayment(bool trackChanges, Student student)
        {
            throw new NotImplementedException();
        }

        Student? IDashBoardRepository.GetStudentDetails(string email)
        {
            IEnumerable<Student> student = FindByCondition(a => a.EMAIL == email, false).Include("Programme");

            return student?.FirstOrDefault();


        }


        /*  IEnumerable<Student> IDashBoardRepository.GetStudentDetails(User user)
         {
             IQueryable<Student> mountedCourses = Filter(a => a.EMAIL == user.Email);

             return mountedCourses
                         .OrderBy(c => c.COURSE_TYPE)
                         .OrderBy(c => c.Course.COURSE_NAME)
                         .Include(a => a.Course)
                         .ToList();

         } */


        /*  Student GetStudentDetails(User user)
         {


             return Query(a => a.EMAIL == user.Email);
         } */



        DateTime IDashBoardRepository.GetStudentLastSeen(bool trackChanges, User user)
        {
            throw new NotImplementedException();
        }

        decimal IDashBoardRepository.TotalOwing(bool trackChanges, User user)
        {
            throw new NotImplementedException();
        }

        decimal IDashBoardRepository.TotalPaid(bool trackChanges, User user)
        {
            throw new NotImplementedException();
        }
    }
}