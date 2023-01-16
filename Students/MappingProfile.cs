﻿using AutoMapper;
using Students.Entities.DataTransferObjects;
using Students.Entities.Models;

namespace Students;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

        CreateMap<UserForRegistrationDto, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

        CreateMap<MountedCourse, MountedCourseDto>()
        .ForMember(c => c.CourseName, opt => opt.MapFrom(x => x.Course.COURSE_NAME))
        .ForMember(b => b.CourseCode, opt => opt.MapFrom(b => b.Course.COURSE_CODE))
        .ForMember(x => x.CourseType, opt => opt.MapFrom(x => x.COURSE_TYPE))
         .ForMember(x => x.CourseCredit, opt => opt.MapFrom(x => x.COURSE_CREDIT))
        .ReverseMap();

        CreateMap<Course, CourseDto>()
         .ForMember(u => u.CourseName, opt => opt.MapFrom(x => x.COURSE_NAME))
         .ForMember(x => x.CourseCode, opt => opt.MapFrom(x => x.COURSE_CODE));

        CreateMap<Calender, CalenderDto>()
           .ForMember(u => u.LiaisonOpen, opt => opt.MapFrom(x => x.LIAISON))
           .ForMember(x => x.RegistrationOpen, opt => opt.MapFrom(x => x.STATUS))
           .ForMember(x => x.ResultOpened, opt => opt.MapFrom(x => x.RESULT_BLOCK))
            .ForMember(x => x.ResitOpen, opt => opt.MapFrom(x => x.RESIT_REG))
           ;

        CreateMap<Student, DashBoardDto>()
           .ForMember(u => u.FullName, opt => opt.MapFrom(x => x.FullName))
             .ForMember(u => u.CurrentClass, opt => opt.MapFrom(x => x.CLASS))
             .ForMember(u => u.Programme, opt => opt.MapFrom(x => x.Programme.SLUG))
             .ForMember(u => u.IndexNumber, opt => opt.MapFrom(x => x.INDEXNO))
             .ForMember(u => u.StudentNumber, opt => opt.MapFrom(x => x.STNO))
              .ForMember(u => u.CurrentLevel, opt => opt.MapFrom(x => x.Level.name))
               .ForMember(u => u.Cgpa, opt => opt.MapFrom(x => x.CGPA))
                .ForMember(u => u.Status, opt => opt.MapFrom(x => x.STATUS))
           .ForMember(u => u.Cgpa, opt => opt.MapFrom(x => x.CGPA))
           .ForMember(u => u.Registered, opt => opt.MapFrom(x => x.REGISTERED))
            .ForMember(u => u.LecturerAssessed, opt => opt.MapFrom(x => x.QUALITY_ASSURANCE))
             .ForMember(u => u.DateOfBirth, opt => opt.MapFrom(x => x.DATEOFBIRTH));


        CreateMap<Event, EventDto>()
     .ForMember(u => u.Activities, opt => opt.MapFrom(x => x.activities))
     .ForMember(u => u.IPaddress, opt => opt.MapFrom(x => x.ipaddress))
     .ForMember(u => u.Hostname, opt => opt.MapFrom(x => x.hostname))
     .ForMember(u => u.LastSeen, opt => opt.MapFrom(x => x.dateTime))
        //.ForMember(u => u.EventType, opt => opt.MapFrom(x => Convert.ToInt64(x.eventType)))

        .ForMember(u => u.UserAGent, opt => opt.MapFrom(x => x.usergent))
     ;





    }
}
