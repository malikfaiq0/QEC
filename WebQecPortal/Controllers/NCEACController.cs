using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQecPortal.Models;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;

namespace WebQecPortal.Controllers
{
    public class NCEACController : Controller
    {
        QecPortalEntities db = new QecPortalEntities();
        // GET: NCEAC
        public ActionResult Index()
        {
            return View();
    
        }



        public ActionResult AdminStructure()
        {
            ViewBag.SharedRoom = db.AvailableRooms.Where(x => x.RoomTypeID == 1).Count();

            ViewBag.Dedicated = db.AvailableRooms.Where(x => x.RoomTypeID == 2).Count();

            ViewBag.AverageRoomSize = (from d in db.RoomTypes select d.AverageSize).FirstOrDefault();

            var lst = (from d in db.AvailableRooms
                       where d.RoomTypeID == 1
                       select d).FirstOrDefault();

           
            var lstins = (from pd in db.HecAdministrations
                          join od in db.InstructionalFacilities on pd.InstructionalFacilitiesID equals od.InstructionalFacilitiesID



                          select new

                          {
                              od.multimedia,
                              od.sound,
                              od.AC,
                              od.wifi,
                              od.advanced,

                          }).ToList();



            ViewBag.ismultimedia = lstins[0].multimedia;
            ViewBag.isair = lstins[0].AC;
            ViewBag.iswifi = lstins[0].wifi;
            ViewBag.issound = lstins[0].sound;
            ViewBag.isadvanced = lstins[0].advanced;
            return View(lst);

        }
        public ActionResult Admission()

        {
            ViewBag.Institution = (from d in db.Institutions select d.InstitutionName).FirstOrDefault();

            var lst = (from d in db.Institutions
                       where d.InstitutionID == 1
                       select d).FirstOrDefault();


            var lstp = (from pd in db.AdmissionForms
                    join od in db.Programs on pd.ProgramID equals od.ProgramID
                        select new
                        {
                            od.Description,

                        }).ToList();

            ViewBag.prog = String.Join(",", lstp);

            var lst1 = (from pd in db.AdmissionForms
                            select new
                        {
                            pd.FrequencyAdmission

                        }).ToList();

            ViewBag.freq = String.Join(",", lst1);
            var lst2 = (from pd in db.AdmissionForms
                        select new
                        {
                            pd.WhenStudentAdmit

                        }).ToList();

            ViewBag.studAdmit = String.Join(",", lst2);

            var lst3 = (from pd in db.AdmissionForms
                        select new
                        {
                            pd.Instrument

                        }).ToList();

            ViewBag.instrument = String.Join(",", lst3);

            var lst4 = (from pd in db.AdmissionForms
                        select new
                        {
                            pd.MiniRequirement

                        }).ToList();

            ViewBag.req = String.Join(",", lst4);

            var lst5 = (from pd in db.AdmissionForms
                        select new
                        {
                            pd.MeritCompiled

                        }).ToList();

            ViewBag.meritCompiled = String.Join(",", lst5);

            var lst6 = (from pd in db.AdmissionForms
                       
                        select new
                        {
                            pd.policies

                        }).ToList();



            ViewBag.policy = String.Join(",", lst6);

            //bscs

            var lst7y = (from pd in db.AdmissionForms
                         join pg in db.Programs on pd.ProgramID equals pg.ProgramID
                         join ia in db.InductionYearsAdmissions on pd.InductionYearsAdmissionID equals ia.InductionYearsAdmissionID
                         join iy in db.InductionYears on ia.InductionYearID equals iy.InductionYearID
                         join ty in db.Terms on iy.TermID equals ty.TermID

                         where ty.Semester== "Spring 19" && pg.Description=="BSCS"
                         select new
                        {
                            iy.Description

                        }).ToList();



            ViewBag.spring19bscs = String.Join(",", lst7y);
            var lst8y = (from pd in db.AdmissionForms
                         join pg in db.Programs on pd.ProgramID equals pg.ProgramID
                         join ia in db.InductionYearsAdmissions on pd.InductionYearsAdmissionID equals ia.InductionYearsAdmissionID
                         join iy in db.InductionYears on ia.InductionYearID equals iy.InductionYearID
                         join ty in db.Terms on iy.TermID equals ty.TermID

                         where ty.Semester == "fall 19" && pg.Description == "BSCS"
                         select new
                         {
                             iy.Description

                         }).ToList();



            ViewBag.fall19bscs = String.Join(",", lst8y);

            var lst9y = (from pd in db.AdmissionForms
                         join pg in db.Programs on pd.ProgramID equals pg.ProgramID
                         join ia in db.InductionYearsAdmissions on pd.InductionYearsAdmissionID equals ia.InductionYearsAdmissionID
                         join iy in db.InductionYears on ia.InductionYearID equals iy.InductionYearID
                         join ty in db.Terms on iy.TermID equals ty.TermID

                         where ty.Semester == "Spring 20" && pg.Description == "BSCS"
                         select new
                         {
                             iy.Description

                         }).ToList();



            ViewBag.spring20bscs = String.Join(",", lst9y);

            var lstay = (from pd in db.AdmissionForms
                         join pg in db.Programs on pd.ProgramID equals pg.ProgramID
                         join ia in db.InductionYearsAdmissions on pd.InductionYearsAdmissionID equals ia.InductionYearsAdmissionID
                         join iy in db.InductionYears on ia.InductionYearID equals iy.InductionYearID
                         join ty in db.Terms on iy.TermID equals ty.TermID

                         where ty.Semester == "fall 20" && pg.Description == "BSCS"
                         select new
                         {
                             iy.Description

                         }).ToList();



            ViewBag.fall20bscs = String.Join(",", lstay);


            //bsse

            var lstby = (from pd in db.AdmissionForms
                         join pg in db.Programs on pd.ProgramID equals pg.ProgramID
                         join ia in db.InductionYearsAdmissions on pd.InductionYearsAdmissionID equals ia.InductionYearsAdmissionID
                         join iy in db.InductionYears on ia.InductionYearID equals iy.InductionYearID
                         join ty in db.Terms on iy.TermID equals ty.TermID

                         where ty.Semester == "Spring 19" && pg.Description == "BSSE"
                         select new
                         {
                             iy.Description

                         }).ToList();



            ViewBag.spring19bsse = String.Join(",", lstby);
            var lstcy = (from pd in db.AdmissionForms
                         join pg in db.Programs on pd.ProgramID equals pg.ProgramID
                         join ia in db.InductionYearsAdmissions on pd.InductionYearsAdmissionID equals ia.InductionYearsAdmissionID
                         join iy in db.InductionYears on ia.InductionYearID equals iy.InductionYearID
                         join ty in db.Terms on iy.TermID equals ty.TermID

                         where ty.Semester == "fall 19" && pg.Description == "BSSE"
                         select new
                         {
                             iy.Description

                         }).ToList();



            ViewBag.fall19bsse = String.Join(",", lstcy);

            var lstdy = (from pd in db.AdmissionForms
                         join pg in db.Programs on pd.ProgramID equals pg.ProgramID
                         join ia in db.InductionYearsAdmissions on pd.InductionYearsAdmissionID equals ia.InductionYearsAdmissionID
                         join iy in db.InductionYears on ia.InductionYearID equals iy.InductionYearID
                         join ty in db.Terms on iy.TermID equals ty.TermID

                         where ty.Semester == "Spring 20" && pg.Description == "BSSE"
                         select new
                         {
                             iy.Description

                         }).ToList();



            ViewBag.spring20bsse = String.Join(",", lstdy);

            var lstey = (from pd in db.AdmissionForms
                         join pg in db.Programs on pd.ProgramID equals pg.ProgramID
                         join ia in db.InductionYearsAdmissions on pd.InductionYearsAdmissionID equals ia.InductionYearsAdmissionID
                         join iy in db.InductionYears on ia.InductionYearID equals iy.InductionYearID
                         join ty in db.Terms on iy.TermID equals ty.TermID

                         where ty.Semester == "fall 20" && pg.Description == "BSSE"
                         select new
                         {
                             iy.Description

                         }).ToList();



            ViewBag.fall20bsse = String.Join(",", lstey);

            //radio

            AdmissionForm adm = db.AdmissionForms.FirstOrDefault();

            if ((bool)adm.Merit)
            {
                ViewBag.isYesMerit = "checked";
            }
            else
            {
                ViewBag.isNoMerit = "checked";
            }



            return View();
        }
        public ActionResult AlumniBSCS()
        {
            //error
            //ViewBag.Institution = db.Institutions.Where(x => x.InstitutionID == 1).Count();
            ViewBag.Institution = (from d in db.Institutions select d.InstitutionName).FirstOrDefault();

            var lst = (from d in db.Institutions
                       where d.InstitutionID == 1
                       select d).FirstOrDefault();

            var lst1 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS" && cd.YearNumber == 2015
                        select new
                        {
                            cd.NoOfGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad15 = String.Join(",", lst1);

            var lst2 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS" && cd.YearNumber == 2016
                        select new
                        {
                            cd.NoOfGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad16 = String.Join(",", lst2);

            var lst3 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS" && cd.YearNumber == 2017
                        select new
                        {
                            cd.NoOfGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad17 = String.Join(",", lst3);

            var lst4 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS" && cd.YearNumber == 2018
                        select new
                        {
                            cd.NoOfGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad18 = String.Join(",", lst4);

            var lst5 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS" && cd.YearNumber == 2019
                        select new
                        {
                            cd.NoOfGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad19 = String.Join(",", lst5);


            var lst6 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS" && cd.YearNumber == 2015
                        select new
                        {
                            cd.NoOfUnderGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad15 = String.Join(",", lst6);

            var lst7 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS" && cd.YearNumber == 2016
                        select new
                        {
                            cd.NoOfUnderGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad16 = String.Join(",", lst7);

            var lst8 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS" && cd.YearNumber == 2017
                        select new
                        {
                            cd.NoOfUnderGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad17 = String.Join(",", lst8);

            var lst9 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS" && cd.YearNumber == 2018
                        select new
                        {
                            cd.NoOfUnderGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad18 = String.Join(",", lst9);

            var lsta = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS" && cd.YearNumber == 2019
                        select new
                        {
                            cd.NoOfUnderGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad19 = String.Join(",", lsta);

            var lstb = (from pd in db.Alumni

                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS"
                        select new
                        {
                            pd.FacilityInternship

                        }).ToList();

            ViewBag.facility = String.Join(",", lstb);

            var lstc = (from pd in db.Alumni

                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS"
                        select new
                        {
                            pd.ContactAlumni

                        }).ToList();

            ViewBag.contact = String.Join(",", lstc);

            var lstd = (from pd in db.Alumni

                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS"
                        select new
                        {
                            pd.GraduateIndustryPath

                        }).ToList();

            ViewBag.industryPath = String.Join(",", lstd);

            var lste = (from pd in db.Alumni

                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS"
                        select new
                        {
                            pd.GraduateAcademicsPath

                        }).ToList();

            ViewBag.acadpath = String.Join(",", lste);

            var lstf = (from pd in db.Alumni

                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS"
                        select new
                        {
                            pd.CommunicateGraduates

                        }).ToList();

            ViewBag.comm = String.Join(",", lstf);

            var lstg = (from pd in db.Alumni

                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS"
                        select new
                        {
                            pd.AlumniAssociation

                        }).ToList();

            ViewBag.association = String.Join(",", lstg);



            return View(lst);
            //return View();
        }
        public ActionResult AlumniBSSE()
        {
            ViewBag.Institution = (from d in db.Institutions select d.InstitutionName).FirstOrDefault();

            var lst = (from d in db.Institutions
                       where d.InstitutionID == 1
                       select d).FirstOrDefault();

            var lst1 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE" && cd.YearNumber == 2015
                        select new
                        {
                           cd.NoOfGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad15 = String.Join(",", lst1);

            var lst2 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE" && cd.YearNumber == 2016
                        select new
                        {
                            cd.NoOfGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad16 = String.Join(",", lst2);

            var lst3 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE" && cd.YearNumber == 2017
                        select new
                        {
                            cd.NoOfGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad17 = String.Join(",", lst3);

            var lst4 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE" && cd.YearNumber == 2018
                        select new
                        {
                            cd.NoOfGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad18 = String.Join(",", lst4);

            var lst5 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE" && cd.YearNumber == 2019
                        select new
                        {
                            cd.NoOfGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad19 = String.Join(",", lst5);


            var lst6 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE" && cd.YearNumber == 2015
                        select new
                        {
                            cd.NoOfUnderGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad15 = String.Join(",", lst6);

            var lst7 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE" && cd.YearNumber == 2016
                        select new
                        {
                            cd.NoOfUnderGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad16 = String.Join(",", lst7);

            var lst8 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE" && cd.YearNumber == 2017
                        select new
                        {
                            cd.NoOfUnderGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad17 = String.Join(",", lst8);

            var lst9 = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE" && cd.YearNumber == 2018
                        select new
                        {
                            cd.NoOfUnderGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad18 = String.Join(",", lst9);

            var lsta = (from pd in db.Alumni
                        join cd in db.YearlyPassouts on pd.YearlyPassoutID equals cd.YearlyPassoutID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE" && cd.YearNumber == 2019
                        select new
                        {
                            cd.NoOfUnderGraduatedTotal

                        }).ToList();

            ViewBag.noOfGrad19 = String.Join(",", lsta);

            var lstb = (from pd in db.Alumni
                        
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE"
                        select new
                        {
                            pd.FacilityInternship

                        }).ToList();

            ViewBag.facility = String.Join(",", lstb);

            var lstc = (from pd in db.Alumni

                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE"
                        select new
                        {
                            pd.ContactAlumni

                        }).ToList();

            ViewBag.contact = String.Join(",", lstc);

            var lstd = (from pd in db.Alumni

                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE"
                        select new
                        {
                            pd.GraduateIndustryPath

                        }).ToList();

            ViewBag.industryPath = String.Join(",", lstd);

            var lste = (from pd in db.Alumni

                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE"
                        select new
                        {
                            pd.GraduateAcademicsPath

                        }).ToList();

            ViewBag.acadpath = String.Join(",", lste);

            var lstf = (from pd in db.Alumni

                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE"
                        select new
                        {
                            pd.CommunicateGraduates

                        }).ToList();

            ViewBag.comm = String.Join(",", lstf);

            var lstg = (from pd in db.Alumni

                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE"
                        select new
                        {
                            pd.AlumniAssociation

                        }).ToList();

            ViewBag.association = String.Join(",", lstg);






            return View(lst);
            //return View();
        }
        public ActionResult CourseDescription()
        {
            ViewBag.Institution = (from d in db.Institutions select d.InstitutionName).FirstOrDefault();

            var lst = (from d in db.Institutions
                       where d.InstitutionID == 1
                       select d).FirstOrDefault();

            var lstp = (from pd in db.CourseDescriptions
                        join cd in db.Courses on pd.CourseID equals cd.CourseID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where cd.CourseCode == "CS5120"
                        select new
                        {
                            od.Description,

                        }).ToList();

            ViewBag.prog = String.Join(",", lstp);



            var lst2 = (from pd in db.Courses
                        where pd.CourseCode == "CS5120"
                        select new
                        {
                            pd.CourseTitle
                        }).ToList();
            ViewBag.CourseName = String.Join(",", lst2);



            var lst3 = (from pd in db.Courses
                        where pd.CourseCode == "CS5120"
                        select new
                        {
                            pd.Credithr
                        }).ToList();
            ViewBag.Credithr = String.Join(",", lst3);

            var lst4 = (from pd in db.Courses
                        where pd.CourseCode == "CS5120"
                        select new
                        {
                            pd.PrereqCourse
                        }).ToList();
            ViewBag.Prereq = String.Join(",", lst4);

            var lst5 = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.AssessmentWeights,

                        }).ToList();

            ViewBag.assess = String.Join(",", lst5);


            var lst6 = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID
                        join cd in db.Instructors on pd.InstructorID equals cd.InstructorID

                        where od.CourseCode == "CS5120"
                        select new
                        {
                            cd.InstructorName
                        }).ToList();

            ViewBag.InstructorName = String.Join(",", lst6);

            var lst7 = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.URL,

                        }).ToList();

            ViewBag.url = String.Join(",", lst7);


            var lstdes = (from pd in db.CourseDescriptions
                          join od in db.Courses on pd.CourseID equals od.CourseID


                          where od.CourseCode == "CS5120"
                          select new
                          {
                              pd.CourseCatDescription,

                          }).ToList();

            ViewBag.catdescrip = String.Join(",", lstdes);

            var lst8 = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.Textbook,

                        }).ToList();

            ViewBag.textbook = String.Join(",", lst8);


            var lst9 = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.Reference,

                        }).ToList();

            ViewBag.refer = String.Join(",", lst9);

            var lsta = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.CourseGoals,

                        }).ToList();

            ViewBag.goal = String.Join(",", lsta);


            var lstb = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.topicCover,

                        }).ToList();

            ViewBag.topics = String.Join(",", lstb);

            var lstc = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.ProjectCourse,

                        }).ToList();

            ViewBag.project = String.Join(",", lstc);


            var lstd = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.ProgrammingAssignment,

                        }).ToList();

            ViewBag.prog = String.Join(",", lstd);

            var lste = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.TimeSpentTheory,

                        }).ToList();

            ViewBag.theory = String.Join(",", lste);

            var lstf = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.TimeSpentProblem,

                        }).ToList();

            ViewBag.prob = String.Join(",", lstf);

            var lstg = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.TimeSpentSolution,

                        }).ToList();

            ViewBag.sol = String.Join(",", lstg);


            var lsth = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.TimeSpentIssues,

                        }).ToList();

            ViewBag.issues = String.Join(",", lsth);

            var lsti = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.OWwritten,

                        }).ToList();

            ViewBag.Owcwritten = String.Join(",", lsti);

            var lstj = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.OWpages

                        }).ToList();

            ViewBag.Owcpages = String.Join(",", lstj);

            var lstk = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.OWpresentation,

                        }).ToList();

            ViewBag.Owcpres = String.Join(",", lstk);


            var lstl = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.OWminutes,

                        }).ToList();

            ViewBag.Owcminutes = String.Join(",", lstl);

            return View();
            // return View();
        }
        public ActionResult CourseLog()
        {
            ViewBag.Institution = (from d in db.Institutions select d.InstitutionName).FirstOrDefault();

            var lst = (from d in db.Institutions
                       where d.InstitutionID == 1
                       select d).FirstOrDefault();


            var lstp = (from pd in db.CourseDescriptions
                        join cd in db.Courses on pd.CourseID equals cd.CourseID
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where cd.CourseCode == "CS5120"
                        select new
                        {
                            od.Description,

                        }).ToList();

            ViewBag.prog = String.Join(",", lstp);

            var lst2 = (from pd in db.Courses
                        where pd.CourseCode == "CS5120"
                        select new
                        {
                            pd.CourseTitle
                        }).ToList();
            ViewBag.CourseName = String.Join(",", lst2);


            var lst3 = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID
                        join cd in db.Instructors on pd.InstructorID equals cd.InstructorID

                        where od.CourseCode == "CS5120"
                        select new
                        {
                            cd.InstructorName
                        }).ToList();

            ViewBag.InstructorName = String.Join(",", lst3);

            //ViewBag.CourseTeacher = (from d in db.Courses select d.CourseTitle).FirstOrDefault();

            //var lst3= ( from d in db.CourseDescriptions 
            //            join c in db.Courses on d.CourseID equals c.CourseID
            //            join od in db.Instructors od.InstructureID equals d.InstructorID
            //var lst3 = (from d in db.CourseDescriptions
            //           join c in db.Courses on d.CourseID equals c.CourseID

            //join e in db.Instructors e. on  equals td.TermID
            // where od.InstructorID == 2 && td.TermID == 1
            // select new
            // {
            //     cd.CourseTitle
            // }).ToList();

            var lst4 = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.Date,

                        }).ToList();

            ViewBag.date = String.Join(",", lst4);

            var lst5 = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.Duration,

                        }).ToList();

            ViewBag.duration = String.Join(",", lst5);

            var lst6 = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.topicCover,

                        }).ToList();

            ViewBag.topics = String.Join(",", lst6);

            var lst7 = (from pd in db.CourseDescriptions
                        join od in db.Courses on pd.CourseID equals od.CourseID


                        where od.CourseCode == "CS5120"
                        select new
                        {
                            pd.EvaluationInstrument,

                        }).ToList();

            ViewBag.evaluation = String.Join(",", lst7);
            return View();
            //return View();
        }
        public ActionResult CPMF()
        {
            ViewBag.Institution = (from d in db.Institutions select d.InstitutionName).FirstOrDefault();

            var lst = (from d in db.Institutions
                       where d.InstitutionID == 1
                       select d).FirstOrDefault();

            var lstp = (from pd in db.CourseDescriptions
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        join zl in db.Courses on pd.CourseID equals zl.CourseID


                        where od.Description == "BSSE" 
                        select new
                        {
                            od.Description,

                        }).ToList();

            ViewBag.prog = String.Join(",", lstp);

            var lst1 = (from pd in db.CourseDescriptions
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        join zl in db.Courses on pd.CourseID equals zl.CourseID
                        where od.Description == "BSSE" && zl.CourseTitle== "Software Achitecture"
                        select new
                        {
                            pd.CourseGoals,

                        }).ToList();

            ViewBag.objective = String.Join(",", lst1);

            var lst2 = (from pd in db.CourseDescriptions
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        join zl in db.Courses on pd.CourseID equals zl.CourseID





                        where od.Description == "BSSE" && zl.CourseTitle == "Software Achitecture"
                        select new
                        {
                            pd.topicCover,

                        }).ToList();

            ViewBag.coverage = String.Join(",", lst2);

            var lst3 = (from pd in db.CourseDescriptions
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        join zl in db.Courses on pd.CourseID equals zl.CourseID





                        where od.Description == "BSSE" && zl.CourseTitle == "Software Achitecture"
                        select new
                        {
                            pd.TimeSpentTheory,
                            pd.TimeSpentIssues,
                            pd.TimeSpentProblem,
                            pd.TimeSpentSolution,

                        }).ToList();

            ViewBag.problemSolving = String.Join(",", lst3);

            var lst4 = (from pd in db.CourseDescriptions
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        join zl in db.Courses on pd.CourseID equals zl.CourseID





                        where od.Description == "BSSE" && zl.CourseTitle == "Software Achitecture"
                        select new
                        {
                            pd.AssessmentWeights,

                        }).ToList();

            ViewBag.assess = String.Join(",", lst4);

            var lst5 = (from pd in db.CourseDescriptions
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        join zl in db.Courses on pd.CourseID equals zl.CourseID





                        where od.Description == "BSSE" && zl.CourseCode== "CS5120"
                        select new
                        {
                            pd.Application,

                        }).ToList();

            ViewBag.application = String.Join(",", lst5);




            return View();
            // return View();
        }
        public ActionResult CRI()
        {
            ViewBag.Institution = (from d in db.Institutions select d.InstitutionName).FirstOrDefault();

            var lst = (from d in db.Institutions
                       where d.InstitutionID == 1
                       select d).FirstOrDefault();

            var lstp = (from pd in db.CRIs
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        

                        where od.Description == "BSSE"
                        select new
                        {
                            od.Description,

                        }).ToList();

            ViewBag.prog = String.Join(",", lstp);

            var lsthecComp = (from pd in db.CRIs
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                


                        where od.Description == "BSSE"
                        select new
                        {
                            pd.HecComputingCore,

                        }).ToList();

            ViewBag.hecComp = String.Join(",", lsthecComp);

            var hecmajor = (from pd in db.CRIs
                              join od in db.Programs on pd.ProgramID equals od.ProgramID



                              where od.Description == "BSSE"
                              select new
                              {
                                  pd.HecMajorCore,

                              }).ToList();

            ViewBag.hecmajor = String.Join(",", hecmajor);

            var hecbased = (from pd in db.CRIs
                              join od in db.Programs on pd.ProgramID equals od.ProgramID



                              where od.Description == "BSSE"
                              select new
                              {
                                  pd.HecBasedlective,

                              }).ToList();

            ViewBag.hecbased = String.Join(",", hecbased);

            var hecCumu = (from pd in db.CRIs
                              join od in db.Programs on pd.ProgramID equals od.ProgramID



                              where od.Description == "BSSE"
                              select new
                              {
                                  pd.HecCumulative,

                              }).ToList();

            ViewBag.hecCumu = String.Join(",", hecCumu);

            var hecsuppSci = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.HecSupportingSci,

                           }).ToList();

            ViewBag.hecsuppSci = String.Join(",", hecsuppSci);

            var hecUniElect = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.HecUniversityElective,

                           }).ToList();

            ViewBag.hecUniElect = String.Join(",", hecUniElect);

            var hecGene = (from pd in db.CRIs
                               join od in db.Programs on pd.ProgramID equals od.ProgramID



                               where od.Description == "BSSE"
                               select new
                               {
                                   pd.HecGeneralElective,

                               }).ToList();

            ViewBag.hecGene = String.Join(",", hecGene);

            var hecCumu2 = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.HecCumulativeCredit,

                           }).ToList();

            ViewBag.hecCumu2 = String.Join(",", hecCumu2);

            var hectot = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.HecTotalCredit,

                           }).ToList();

            ViewBag.hectot = String.Join(",", hectot);

            var sumComp = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.SumComputingCore,

                           }).ToList();

            ViewBag.sumComp = String.Join(",", sumComp);

            var summajor = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.SumMajorCore,

                           }).ToList();

            ViewBag.summajor = String.Join(",", summajor);
            var sumBased = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.SumBasedlective,

                           }).ToList();

            ViewBag.sumBased = String.Join(",", sumBased);

            var sumCumu = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.SumCumulative,

                           }).ToList();

            ViewBag.sumCumu = String.Join(",", sumCumu);

            var sumSuppSci = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.SumSupportingSci,

                           }).ToList();

            ViewBag.sumSuppSci = String.Join(",", sumSuppSci);

            var sumGene = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.SumGeneralElective,

                           }).ToList();

            ViewBag.sumGene = String.Join(",", sumGene);

            var sumUni = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.SumUniversityElective,

                           }).ToList();

            ViewBag.sumUni = String.Join(",", sumUni);

            var sumCumu2 = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.SumCumulativeCredit,

                           }).ToList();

            ViewBag.sumCumu2 = String.Join(",", sumCumu2);

            var sumtot = (from pd in db.CRIs
                           join od in db.Programs on pd.ProgramID equals od.ProgramID



                           where od.Description == "BSSE"
                           select new
                           {
                               pd.SumTotalCredit,

                           }).ToList();

            ViewBag.sumtot = String.Join(",", sumtot);

            var course = (from pd in db.CRIs
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join cd in db.Courses on pd.CourseID equals cd.CourseID



                          where od.Description == "BSSE"
                          select new
                          {
                              cd.CourseCode,
                              cd.CourseTitle,
                          
                          }).ToList();

            ViewBag.course = String.Join(",", course);




















            return View(lst);
            //return View();
        }

        //Get
        public ActionResult FacultyWorkload()
        {
            //int FacultyID = 2;
            //int TermID = 1;


            //ViewBag.FacultyName = (from d in db.RoomTypes select d.AverageSize).FirstOrDefault();
            var lst = (from pd in db.FacultyCourses
                       join od in db.Instructors on pd.InstructorID equals od.InstructorID
                       join cd in db.Courses on pd.CourseID equals cd.CourseID
                       join td in db.Terms on pd.TermID equals td.TermID
                       where od.InstructorID == 2 && td.TermID == 1
                       select new
                       {
                           cd.CourseTitle
                       }).ToList();

            ViewBag.FacultyCourses = String.Join(",", lst);

            var lst2 = (from pd in db.FacultyCourses
                        join od in db.Instructors on pd.InstructorID equals od.InstructorID
                        join cd in db.Courses on pd.CourseID equals cd.CourseID
                        join td in db.Terms on pd.TermID equals td.TermID
                        where od.InstructorID == 2 && td.TermID == 1
                        select new
                        {
                            cd.CourseTitle
                        }).ToList();

           ViewBag.FacultyCourses2 = String.Join(",", lst2);
           //ViewBag.Save = "<script>alert('Data Save Successfully')</script>";
           return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public FileResult ExportHTML(string ExportData)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader reader = new StringReader(ExportData);
                Document PdfFile = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(PdfFile, stream);
                PdfFile.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, PdfFile, reader);
                //PdfFile.Add(new Paragraph(ExportData));
                //PdfFile.NewPage();
                PdfFile.Close();


                return File(stream.ToArray(), "application/pdf", "ExportData.pdf");
            }
        }
        public ActionResult FIF()
        {
            var lst = (from pd in db.FIFs
                        join od in db.Instructors on pd.InsructorID equals od.InstructorID


                        where od.InstructorName == "Muhammad Tauseef"
                       select new
                        {
                            pd.AcademicDegree,

                        }).ToList();

            ViewBag.AcademicDegree = String.Join(",", lst);

            var lst2 = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.DegreeAwarding,

                       }).ToList();

            ViewBag.award = String.Join(",", lst2);

            var lst3 = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.Specialization,

                       }).ToList();

            ViewBag.specialization = String.Join(",", lst3);

            var lst4 = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.ExpHigherEdu,

                       }).ToList();

            ViewBag.exphighedu = String.Join(",", lst4);

            var lst5 = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.ExpIndustry,

                       }).ToList();

            ViewBag.expindustry = String.Join(",", lst5);

            var lst6 = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.PubJnlinternational,

                       }).ToList();

            ViewBag.pubJnlinter = String.Join(",", lst6);

            var lst7 = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.PubJnlLocal,

                       }).ToList();

            ViewBag.pubJnlLocal = String.Join(",", lst7);

            var lst8 = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.PubConinternational,

                       }).ToList();

            ViewBag.pubConinter = String.Join(",", lst8);


            var lst9 = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.PubConLocal,

                       }).ToList();

            ViewBag.pubConlocal = String.Join(",", lst9);


            var lsta = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.PubBook,

                       }).ToList();

            ViewBag.books = String.Join(",", lsta);

            var lstb = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.PubBookChap,

                       }).ToList();

            ViewBag.bookchp = String.Join(",", lstb);

            var lstc = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.Patents,

                       }).ToList();

            ViewBag.patents = String.Join(",", lstc);

            var lstd = (from pd in db.FIFs
                       join od in db.Instructors on pd.InsructorID equals od.InstructorID


                       where od.InstructorName == "Muhammad Tauseef"
                       select new
                       {
                           pd.TechReports,

                       }).ToList();

            ViewBag.reports = String.Join(",", lstd);
            return View();
        }
        public ActionResult FinancialBSCS()
        {
            ViewBag.Institution = (from d in db.Institutions select d.InstitutionName).FirstOrDefault();

            var lst = (from d in db.Institutions
                       where d.InstitutionID == 1
                       select d).FirstOrDefault();

            var lstp = (from pd in db.Financials
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS"
                        select new
                        {
                            od.Description,

                        }).ToList();

            ViewBag.prog = String.Join(",", lstp);

            var lst1 = (from pd in db.Financials
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS"
                        select new
                        {
                            pd.TotalAssets,

                        }).ToList();

            ViewBag.asset = String.Join(",", lst1);

            var lst2 = (from pd in db.Financials
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSCS"
                        select new
                        {
                            pd.Fund,

                        }).ToList();

            ViewBag.fund = String.Join(",", lst2);

            var lst3w = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.WholeBudgets on pd.WholeBudgetID equals ad.WholeBudgetID
                         join yd in db.WholeYearlyBudgets on ad.WholeYearlyBudgetID equals yd.WholeYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.wholebudget16 = String.Join(",", lst3w);

            var lst4w = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.WholeBudgets on pd.WholeBudgetID equals ad.WholeBudgetID
                         join yd in db.WholeYearlyBudgets on ad.WholeYearlyBudgetID equals yd.WholeYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.wholebudget15 = String.Join(",", lst4w);

            var lst5w = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.WholeBudgets on pd.WholeBudgetID equals ad.WholeBudgetID
                         join yd in db.WholeYearlyBudgets on ad.WholeYearlyBudgetID equals yd.WholeYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.wholebudget17 = String.Join(",", lst5w);

            var lst6w = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.WholeBudgets on pd.WholeBudgetID equals ad.WholeBudgetID
                         join yd in db.WholeYearlyBudgets on ad.WholeYearlyBudgetID equals yd.WholeYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.wholebudget18 = String.Join(",", lst6w);

            //research

            var lst7w = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.WholeBudgets on pd.WholeBudgetID equals ad.WholeBudgetID
                         join yd in db.WholeYearlyBudgets on ad.WholeYearlyBudgetID equals yd.WholeYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.wholebudget19 = String.Join(",", lst7w);

            var lst3r = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ResearchBudgets on pd.ResearchBudgetID equals ad.ResearchBudgetID
                         join yd in db.RYearlyBudgets on ad.RYearlyBudgetID equals yd.RYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.researcht15 = String.Join(",", lst3r);

            var lst4r = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ResearchBudgets on pd.ResearchBudgetID equals ad.ResearchBudgetID
                         join yd in db.RYearlyBudgets on ad.RYearlyBudgetID equals yd.RYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.research16 = String.Join(",", lst4r);

            var lst5r = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ResearchBudgets on pd.ResearchBudgetID equals ad.ResearchBudgetID
                         join yd in db.RYearlyBudgets on ad.RYearlyBudgetID equals yd.RYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.research17 = String.Join(",", lst5r);

            var lst6r = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ResearchBudgets on pd.ResearchBudgetID equals ad.ResearchBudgetID
                         join yd in db.RYearlyBudgets on ad.RYearlyBudgetID equals yd.RYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.research18 = String.Join(",", lst6r);

            var lst7r = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ResearchBudgets on pd.ResearchBudgetID equals ad.ResearchBudgetID
                         join yd in db.RYearlyBudgets on ad.RYearlyBudgetID equals yd.RYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.research19 = String.Join(",", lst7r);

            //library

            var lst3l = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.LibraryBudgets on pd.LibraryBudgetID equals ad.LibraryBudgetID
                         join yd in db.LYearlyBudgets on ad.LYearlyBudgetID equals yd.LYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.library15 = String.Join(",", lst3l);


            var lst4l = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.LibraryBudgets on pd.LibraryBudgetID equals ad.LibraryBudgetID
                         join yd in db.LYearlyBudgets on ad.LYearlyBudgetID equals yd.LYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.library16 = String.Join(",", lst4l);

            var lst5l = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.LibraryBudgets on pd.LibraryBudgetID equals ad.LibraryBudgetID
                         join yd in db.LYearlyBudgets on ad.LYearlyBudgetID equals yd.LYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.library17 = String.Join(",", lst5l);

            var lst6l = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.LibraryBudgets on pd.LibraryBudgetID equals ad.LibraryBudgetID
                         join yd in db.LYearlyBudgets on ad.LYearlyBudgetID equals yd.LYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.library18 = String.Join(",", lst6l);

            var lst7l = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.LibraryBudgets on pd.LibraryBudgetID equals ad.LibraryBudgetID
                         join yd in db.LYearlyBudgets on ad.LYearlyBudgetID equals yd.LYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.library19 = String.Join(",", lst7l);

            //computing faciliies


            var lst3c = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ComputingBudgets on pd.ComputingBudgetID equals ad.ComputingBudgetID
                         join yd in db.DCYearlyBudgets on ad.CYearlyBudgetID equals yd.DCYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.computing15 = String.Join(",", lst3c);

            var lst4c = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ComputingBudgets on pd.ComputingBudgetID equals ad.ComputingBudgetID
                         join yd in db.CYearlyBudgets on ad.CYearlyBudgetID equals yd.CYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.computing16 = String.Join(",", lst4c);

            var lst5c = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ComputingBudgets on pd.ComputingBudgetID equals ad.ComputingBudgetID
                         join yd in db.CYearlyBudgets on ad.CYearlyBudgetID equals yd.CYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.computing17 = String.Join(",", lst5c);

            var lst6c = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ComputingBudgets on pd.ComputingBudgetID equals ad.ComputingBudgetID
                         join yd in db.CYearlyBudgets on ad.CYearlyBudgetID equals yd.CYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.computing18 = String.Join(",", lst6c);

            var lst7c = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ComputingBudgets on pd.ComputingBudgetID equals ad.ComputingBudgetID
                         join yd in db.CYearlyBudgets on ad.CYearlyBudgetID equals yd.CYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.computing19 = String.Join(",", lst7c);

            //department computing facility

            var lst3dc = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepComputingBudgets on pd.DepComputingBudgetID equals ad.DepComputingBudgetID
                          join yd in db.DCYearlyBudgets on ad.DCYearlyBudgetID equals yd.DCYearlyBudgetID


                          where od.Description == "BSCS" && yd.YearNumber == 2015
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dcomputing15 = String.Join(",", lst3dc);

            var lst4dc = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepComputingBudgets on pd.DepComputingBudgetID equals ad.DepComputingBudgetID
                          join yd in db.DCYearlyBudgets on ad.DCYearlyBudgetID equals yd.DCYearlyBudgetID


                          where od.Description == "BSCS" && yd.YearNumber == 2016
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dcomputing16 = String.Join(",", lst4dc);

            var lst5dc = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepComputingBudgets on pd.DepComputingBudgetID equals ad.DepComputingBudgetID
                          join yd in db.DCYearlyBudgets on ad.DCYearlyBudgetID equals yd.DCYearlyBudgetID


                          where od.Description == "BSCS" && yd.YearNumber == 2017
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dcomputing17 = String.Join(",", lst5dc);

            var lst6dc = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepComputingBudgets on pd.DepComputingBudgetID equals ad.DepComputingBudgetID
                          join yd in db.DCYearlyBudgets on ad.DCYearlyBudgetID equals yd.DCYearlyBudgetID


                          where od.Description == "BSCS" && yd.YearNumber == 2018
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dcomputing18 = String.Join(",", lst6dc);

            var lst7dc = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepComputingBudgets on pd.DepComputingBudgetID equals ad.DepComputingBudgetID
                          join yd in db.DCYearlyBudgets on ad.DCYearlyBudgetID equals yd.DCYearlyBudgetID


                          where od.Description == "BSCS" && yd.YearNumber == 2019
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dcomputing19 = String.Join(",", lst7dc);

            //offer program


            var lst3p = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.DepOfferProgBudgets on pd.DepOfferProgBudgetID equals ad.DepOfferProgBudgetID
                         join yd in db.DOPYearlyBudgets on ad.DOPYearlyBudgetID equals yd.DOPYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.prog15 = String.Join(",", lst3p);


            var lst4p = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.DepOfferProgBudgets on pd.DepOfferProgBudgetID equals ad.DepOfferProgBudgetID
                         join yd in db.DOPYearlyBudgets on ad.DOPYearlyBudgetID equals yd.DOPYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.prog16 = String.Join(",", lst4p);

            var lst5p = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.DepOfferProgBudgets on pd.DepOfferProgBudgetID equals ad.DepOfferProgBudgetID
                         join yd in db.DOPYearlyBudgets on ad.DOPYearlyBudgetID equals yd.DOPYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.prog17 = String.Join(",", lst5p);

            var lst6p = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.DepOfferProgBudgets on pd.DepOfferProgBudgetID equals ad.DepOfferProgBudgetID
                         join yd in db.DOPYearlyBudgets on ad.DOPYearlyBudgetID equals yd.DOPYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.prog18 = String.Join(",", lst6p);

            var lst7p = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.DepOfferProgBudgets on pd.DepOfferProgBudgetID equals ad.DepOfferProgBudgetID
                         join yd in db.DOPYearlyBudgets on ad.DOPYearlyBudgetID equals yd.DOPYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.prog19 = String.Join(",", lst7p);

            //department research

            var lst3dr = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepResearchBudgets on pd.DepResearchBudgetID equals ad.DepResearchBudgetID
                          join yd in db.DRYearlyBudgets on ad.DRYearlyBudgetID equals yd.DRYearlyBudgetID


                          where od.Description == "BSCS" && yd.YearNumber == 2015
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dresearch15 = String.Join(",", lst3dr);


            var lst4dr = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepResearchBudgets on pd.DepResearchBudgetID equals ad.DepResearchBudgetID
                          join yd in db.DRYearlyBudgets on ad.DRYearlyBudgetID equals yd.DRYearlyBudgetID


                          where od.Description == "BSCS" && yd.YearNumber == 2016
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dresearch16 = String.Join(",", lst4dr);



            var lst5dr = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepResearchBudgets on pd.DepResearchBudgetID equals ad.DepResearchBudgetID
                          join yd in db.DRYearlyBudgets on ad.DRYearlyBudgetID equals yd.DRYearlyBudgetID


                          where od.Description == "BSCS" && yd.YearNumber == 2017
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dresearch17 = String.Join(",", lst5dr);


            var lst6dr = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepResearchBudgets on pd.DepResearchBudgetID equals ad.DepResearchBudgetID
                          join yd in db.DRYearlyBudgets on ad.DRYearlyBudgetID equals yd.DRYearlyBudgetID


                          where od.Description == "BSCS" && yd.YearNumber == 2018
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dresearch18 = String.Join(",", lst6dr);


            var lst7dr = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepResearchBudgets on pd.DepResearchBudgetID equals ad.DepResearchBudgetID
                          join yd in db.DRYearlyBudgets on ad.DRYearlyBudgetID equals yd.DRYearlyBudgetID


                          where od.Description == "BSCS" && yd.YearNumber == 2019
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dresearch19 = String.Join(",", lst7dr);

            //fee structure

            var lst3f = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.FreeStructures on pd.FreeStructureID equals ad.FreeStructureID
                         join yd in db.FYearlyBudgets on ad.FYearlyBudgetID equals yd.FYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.fee15 = String.Join(",", lst3f);

            var lst4f = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.FreeStructures on pd.FreeStructureID equals ad.FreeStructureID
                         join yd in db.FYearlyBudgets on ad.FYearlyBudgetID equals yd.FYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.fee16 = String.Join(",", lst4f);

            var lst5f = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.FreeStructures on pd.FreeStructureID equals ad.FreeStructureID
                         join yd in db.FYearlyBudgets on ad.FYearlyBudgetID equals yd.FYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.fee17 = String.Join(",", lst5f);

            var lst6f = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.FreeStructures on pd.FreeStructureID equals ad.FreeStructureID
                         join yd in db.FYearlyBudgets on ad.FYearlyBudgetID equals yd.FYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.fee18 = String.Join(",", lst6f);


            var lst7f = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.FreeStructures on pd.FreeStructureID equals ad.FreeStructureID
                         join yd in db.FYearlyBudgets on ad.FYearlyBudgetID equals yd.FYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.fee19 = String.Join(",", lst7f);


            //source of income

            var lst3s = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.SourcesOfIncomes on pd.SourcesOfIncomeID equals ad.SourcesOfIncomeID
                         join yd in db.SYearlyBudgets on ad.SYearlyBudgetID equals yd.SYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.source15 = String.Join(",", lst3s);

            var lst4s = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.SourcesOfIncomes on pd.SourcesOfIncomeID equals ad.SourcesOfIncomeID
                         join yd in db.SYearlyBudgets on ad.SYearlyBudgetID equals yd.SYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.source16 = String.Join(",", lst4s);

            var lst5s = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.SourcesOfIncomes on pd.SourcesOfIncomeID equals ad.SourcesOfIncomeID
                         join yd in db.SYearlyBudgets on ad.SYearlyBudgetID equals yd.SYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.source17 = String.Join(",", lst5s);

            var lst6s = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.SourcesOfIncomes on pd.SourcesOfIncomeID equals ad.SourcesOfIncomeID
                         join yd in db.SYearlyBudgets on ad.SYearlyBudgetID equals yd.SYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.source18 = String.Join(",", lst6s);

            var lst7s = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.SourcesOfIncomes on pd.SourcesOfIncomeID equals ad.SourcesOfIncomeID
                         join yd in db.SYearlyBudgets on ad.SYearlyBudgetID equals yd.SYearlyBudgetID


                         where od.Description == "BSCS" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.source19 = String.Join(",", lst7s);


            return View(lst);
            //return View();
        }
        public ActionResult FinancialBSSE()
        {
            ViewBag.Institution = (from d in db.Institutions select d.InstitutionName).FirstOrDefault();

            var lst = (from d in db.Institutions
                       where d.InstitutionID == 1
                       select d).FirstOrDefault();

            var lstp = (from pd in db.Financials
                       join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE"
                        select new
                        {
                            od.Description,

                        }).ToList();

            ViewBag.prog = String.Join(",", lstp);

            var lst1 = (from pd in db.Financials
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE"
                        select new
                        {
                            pd.TotalAssets,

                        }).ToList();

            ViewBag.asset = String.Join(",", lst1);

            var lst2 = (from pd in db.Financials
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE"
                        select new
                        {
                            pd.Fund,

                        }).ToList();

            ViewBag.fund = String.Join(",", lst2);

            var lst3w = (from pd in db.Financials
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        join ad in db.WholeBudgets on pd.WholeBudgetID equals ad.WholeBudgetID
                        join yd in db.WholeYearlyBudgets on ad.WholeYearlyBudgetID equals yd.WholeYearlyBudgetID


                        where od.Description == "BSSE" && yd.YearNumber == 2016
                        select new
                        {
                            yd.Description,

                        }).ToList();

            ViewBag.wholebudget16 = String.Join(",", lst3w);

            var lst4w = (from pd in db.Financials
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        join ad in db.WholeBudgets on pd.WholeBudgetID equals ad.WholeBudgetID
                        join yd in db.WholeYearlyBudgets on ad.WholeYearlyBudgetID equals yd.WholeYearlyBudgetID


                        where od.Description == "BSSE" && yd.YearNumber == 2015
                        select new
                        {
                            yd.Description,

                        }).ToList();

            ViewBag.wholebudget15 = String.Join(",", lst4w);

            var lst5w = (from pd in db.Financials
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        join ad in db.WholeBudgets on pd.WholeBudgetID equals ad.WholeBudgetID
                        join yd in db.WholeYearlyBudgets on ad.WholeYearlyBudgetID equals yd.WholeYearlyBudgetID


                        where od.Description == "BSSE" && yd.YearNumber == 2017
                        select new
                        {
                            yd.Description,

                        }).ToList();

            ViewBag.wholebudget17 = String.Join(",", lst5w);

            var lst6w = (from pd in db.Financials
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        join ad in db.WholeBudgets on pd.WholeBudgetID equals ad.WholeBudgetID
                        join yd in db.WholeYearlyBudgets on ad.WholeYearlyBudgetID equals yd.WholeYearlyBudgetID


                        where od.Description == "BSSE" && yd.YearNumber== 2018
                        select new
                        {
                            yd.Description,

                        }).ToList();

            ViewBag.wholebudget18 = String.Join(",", lst6w);

            //research

            var lst7w = (from pd in db.Financials
                        join od in db.Programs on pd.ProgramID equals od.ProgramID
                        join ad in db.WholeBudgets on pd.WholeBudgetID equals ad.WholeBudgetID
                        join yd in db.WholeYearlyBudgets on ad.WholeYearlyBudgetID equals yd.WholeYearlyBudgetID


                        where od.Description == "BSSE" && yd.YearNumber == 2019
                        select new
                        {
                            yd.Description,

                        }).ToList();

            ViewBag.wholebudget19 = String.Join(",", lst7w);

            var lst3r = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ResearchBudgets on pd.ResearchBudgetID equals ad.ResearchBudgetID
                         join yd in db.RYearlyBudgets on ad.RYearlyBudgetID equals yd.RYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.researcht15 = String.Join(",", lst3r);

            var lst4r = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ResearchBudgets on pd.ResearchBudgetID equals ad.ResearchBudgetID
                         join yd in db.RYearlyBudgets on ad.RYearlyBudgetID equals yd.RYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.research16 = String.Join(",", lst4r);

            var lst5r = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ResearchBudgets on pd.ResearchBudgetID equals ad.ResearchBudgetID
                         join yd in db.RYearlyBudgets on ad.RYearlyBudgetID equals yd.RYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.research17 = String.Join(",", lst5r);

            var lst6r = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ResearchBudgets on pd.ResearchBudgetID equals ad.ResearchBudgetID
                         join yd in db.RYearlyBudgets on ad.RYearlyBudgetID equals yd.RYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.research18 = String.Join(",", lst6r);

            var lst7r = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ResearchBudgets on pd.ResearchBudgetID equals ad.ResearchBudgetID
                         join yd in db.RYearlyBudgets on ad.RYearlyBudgetID equals yd.RYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.research19 = String.Join(",", lst7r);

            //library

            var lst3l = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.LibraryBudgets on pd.LibraryBudgetID equals ad.LibraryBudgetID
                         join yd in db.LYearlyBudgets on ad.LYearlyBudgetID equals yd.LYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.library15 = String.Join(",", lst3l);


            var lst4l = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.LibraryBudgets on pd.LibraryBudgetID equals ad.LibraryBudgetID
                         join yd in db.LYearlyBudgets on ad.LYearlyBudgetID equals yd.LYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.library16 = String.Join(",", lst4l);

            var lst5l = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.LibraryBudgets on pd.LibraryBudgetID equals ad.LibraryBudgetID
                         join yd in db.LYearlyBudgets on ad.LYearlyBudgetID equals yd.LYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.library17 = String.Join(",", lst5l);

            var lst6l = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.LibraryBudgets on pd.LibraryBudgetID equals ad.LibraryBudgetID
                         join yd in db.LYearlyBudgets on ad.LYearlyBudgetID equals yd.LYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.library18 = String.Join(",", lst6l);

            var lst7l = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.LibraryBudgets on pd.LibraryBudgetID equals ad.LibraryBudgetID
                         join yd in db.LYearlyBudgets on ad.LYearlyBudgetID equals yd.LYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.library19 = String.Join(",", lst7l);

            //computing faciliies


            var lst3c = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ComputingBudgets on pd.ComputingBudgetID equals ad.ComputingBudgetID
                         join yd in db.DCYearlyBudgets on ad.CYearlyBudgetID equals yd.DCYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.computing15 = String.Join(",", lst3c);

            var lst4c = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ComputingBudgets on pd.ComputingBudgetID equals ad.ComputingBudgetID
                         join yd in db.CYearlyBudgets on ad.CYearlyBudgetID equals yd.CYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.computing16 = String.Join(",", lst4c);

            var lst5c = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ComputingBudgets on pd.ComputingBudgetID equals ad.ComputingBudgetID
                         join yd in db.CYearlyBudgets on ad.CYearlyBudgetID equals yd.CYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.computing17 = String.Join(",", lst5c);

            var lst6c = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ComputingBudgets on pd.ComputingBudgetID equals ad.ComputingBudgetID
                         join yd in db.CYearlyBudgets on ad.CYearlyBudgetID equals yd.CYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.computing18 = String.Join(",", lst6c);

            var lst7c = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.ComputingBudgets on pd.ComputingBudgetID equals ad.ComputingBudgetID
                         join yd in db.CYearlyBudgets on ad.CYearlyBudgetID equals yd.CYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.computing19 = String.Join(",", lst7c);

            //department computing facility

            var lst3dc = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.DepComputingBudgets on pd.DepComputingBudgetID equals ad.DepComputingBudgetID
                         join yd in db.DCYearlyBudgets on ad.DCYearlyBudgetID equals yd.DCYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.dcomputing15 = String.Join(",", lst3dc);

            var lst4dc = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepComputingBudgets on pd.DepComputingBudgetID equals ad.DepComputingBudgetID
                          join yd in db.DCYearlyBudgets on ad.DCYearlyBudgetID equals yd.DCYearlyBudgetID


                          where od.Description == "BSSE" && yd.YearNumber == 2016
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dcomputing16 = String.Join(",", lst4dc);

            var lst5dc = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepComputingBudgets on pd.DepComputingBudgetID equals ad.DepComputingBudgetID
                          join yd in db.DCYearlyBudgets on ad.DCYearlyBudgetID equals yd.DCYearlyBudgetID


                          where od.Description == "BSSE" && yd.YearNumber == 2017
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dcomputing17 = String.Join(",", lst5dc);

            var lst6dc = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepComputingBudgets on pd.DepComputingBudgetID equals ad.DepComputingBudgetID
                          join yd in db.DCYearlyBudgets on ad.DCYearlyBudgetID equals yd.DCYearlyBudgetID


                          where od.Description == "BSSE" && yd.YearNumber == 2018
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dcomputing18 = String.Join(",", lst6dc);

            var lst7dc = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepComputingBudgets on pd.DepComputingBudgetID equals ad.DepComputingBudgetID
                          join yd in db.DCYearlyBudgets on ad.DCYearlyBudgetID equals yd.DCYearlyBudgetID


                          where od.Description == "BSSE" && yd.YearNumber == 2019
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dcomputing19 = String.Join(",", lst7dc);

            //offer program


            var lst3p = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepOfferProgBudgets on pd.DepOfferProgBudgetID equals ad.DepOfferProgBudgetID
                          join yd in db.DOPYearlyBudgets on ad.DOPYearlyBudgetID equals yd.DOPYearlyBudgetID


                          where od.Description == "BSSE" && yd.YearNumber == 2015
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.prog15 = String.Join(",", lst3p);


            var lst4p = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.DepOfferProgBudgets on pd.DepOfferProgBudgetID equals ad.DepOfferProgBudgetID
                         join yd in db.DOPYearlyBudgets on ad.DOPYearlyBudgetID equals yd.DOPYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.prog16 = String.Join(",", lst4p);

            var lst5p = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.DepOfferProgBudgets on pd.DepOfferProgBudgetID equals ad.DepOfferProgBudgetID
                         join yd in db.DOPYearlyBudgets on ad.DOPYearlyBudgetID equals yd.DOPYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.prog17 = String.Join(",", lst5p);

            var lst6p = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.DepOfferProgBudgets on pd.DepOfferProgBudgetID equals ad.DepOfferProgBudgetID
                         join yd in db.DOPYearlyBudgets on ad.DOPYearlyBudgetID equals yd.DOPYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.prog18 = String.Join(",", lst6p);

            var lst7p = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.DepOfferProgBudgets on pd.DepOfferProgBudgetID equals ad.DepOfferProgBudgetID
                         join yd in db.DOPYearlyBudgets on ad.DOPYearlyBudgetID equals yd.DOPYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.prog19 = String.Join(",", lst7p);

            //department research

            var lst3dr = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.DepResearchBudgets on pd.DepResearchBudgetID equals ad.DepResearchBudgetID
                         join yd in db.DRYearlyBudgets on ad.DRYearlyBudgetID equals yd.DRYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.dresearch15 = String.Join(",", lst3dr);


            var lst4dr = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepResearchBudgets on pd.DepResearchBudgetID equals ad.DepResearchBudgetID
                          join yd in db.DRYearlyBudgets on ad.DRYearlyBudgetID equals yd.DRYearlyBudgetID


                          where od.Description == "BSSE" && yd.YearNumber == 2016
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dresearch16 = String.Join(",", lst4dr);



            var lst5dr = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepResearchBudgets on pd.DepResearchBudgetID equals ad.DepResearchBudgetID
                          join yd in db.DRYearlyBudgets on ad.DRYearlyBudgetID equals yd.DRYearlyBudgetID


                          where od.Description == "BSSE" && yd.YearNumber == 2017
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dresearch17 = String.Join(",", lst5dr);


            var lst6dr = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepResearchBudgets on pd.DepResearchBudgetID equals ad.DepResearchBudgetID
                          join yd in db.DRYearlyBudgets on ad.DRYearlyBudgetID equals yd.DRYearlyBudgetID


                          where od.Description == "BSSE" && yd.YearNumber == 2018
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dresearch18 = String.Join(",", lst6dr);


            var lst7dr = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.DepResearchBudgets on pd.DepResearchBudgetID equals ad.DepResearchBudgetID
                          join yd in db.DRYearlyBudgets on ad.DRYearlyBudgetID equals yd.DRYearlyBudgetID


                          where od.Description == "BSSE" && yd.YearNumber == 2019
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.dresearch19 = String.Join(",", lst7dr);

            //fee structure

            var lst3f = (from pd in db.Financials
                          join od in db.Programs on pd.ProgramID equals od.ProgramID
                          join ad in db.FreeStructures on pd.FreeStructureID equals ad.FreeStructureID
                          join yd in db.FYearlyBudgets on ad.FYearlyBudgetID equals yd.FYearlyBudgetID


                          where od.Description == "BSSE" && yd.YearNumber == 2015
                          select new
                          {
                              yd.Description,

                          }).ToList();

            ViewBag.fee15 = String.Join(",", lst3f);

            var lst4f = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.FreeStructures on pd.FreeStructureID equals ad.FreeStructureID
                         join yd in db.FYearlyBudgets on ad.FYearlyBudgetID equals yd.FYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.fee16 = String.Join(",", lst4f);

            var lst5f = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.FreeStructures on pd.FreeStructureID equals ad.FreeStructureID
                         join yd in db.FYearlyBudgets on ad.FYearlyBudgetID equals yd.FYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.fee17 = String.Join(",", lst5f);

            var lst6f = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.FreeStructures on pd.FreeStructureID equals ad.FreeStructureID
                         join yd in db.FYearlyBudgets on ad.FYearlyBudgetID equals yd.FYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.fee18 = String.Join(",", lst6f);


            var lst7f = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.FreeStructures on pd.FreeStructureID equals ad.FreeStructureID
                         join yd in db.FYearlyBudgets on ad.FYearlyBudgetID equals yd.FYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.fee19 = String.Join(",", lst7f);


            //source of income

            var lst3s = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.SourcesOfIncomes on pd.SourcesOfIncomeID equals ad.SourcesOfIncomeID
                         join yd in db.SYearlyBudgets on ad.SYearlyBudgetID equals yd.SYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2015
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.source15 = String.Join(",", lst3s);

            var lst4s = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.SourcesOfIncomes on pd.SourcesOfIncomeID equals ad.SourcesOfIncomeID
                         join yd in db.SYearlyBudgets on ad.SYearlyBudgetID equals yd.SYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2016
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.source16 = String.Join(",", lst4s);

            var lst5s = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.SourcesOfIncomes on pd.SourcesOfIncomeID equals ad.SourcesOfIncomeID
                         join yd in db.SYearlyBudgets on ad.SYearlyBudgetID equals yd.SYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2017
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.source17 = String.Join(",", lst5s);

            var lst6s = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.SourcesOfIncomes on pd.SourcesOfIncomeID equals ad.SourcesOfIncomeID
                         join yd in db.SYearlyBudgets on ad.SYearlyBudgetID equals yd.SYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2018
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.source18 = String.Join(",", lst6s);

            var lst7s = (from pd in db.Financials
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         join ad in db.SourcesOfIncomes on pd.SourcesOfIncomeID equals ad.SourcesOfIncomeID
                         join yd in db.SYearlyBudgets on ad.SYearlyBudgetID equals yd.SYearlyBudgetID


                         where od.Description == "BSSE" && yd.YearNumber == 2019
                         select new
                         {
                             yd.Description,

                         }).ToList();

            ViewBag.source19 = String.Join(",", lst7s);










































            return View();
            //return View();
        }
        public ActionResult HECadministration()
        {
            ViewBag.SharedRoom = db.AvailableRooms.Where(x => x.RoomTypeID == 1).Count();

            ViewBag.Dedicated = db.AvailableRooms.Where(x => x.RoomTypeID == 2).Count();

            ViewBag.AverageRoomSize = (from d in db.RoomTypes select d.AverageSize).FirstOrDefault();

            var lst = (from d in db.AvailableRooms
                       where d.RoomTypeID == 1
                       select d).FirstOrDefault();

            var lst1 = (from pd in db.HecAdministrations
                        join od in db.ComputingBudgets on pd.ComputingBudgetID equals od.ComputingBudgetID


                      
                        select new
                        {
                            od.TotalCompLab,

                        }).ToList();

            ViewBag.totalLab = String.Join(",", lst1);

            var lst2 = (from pd in db.HecAdministrations
                        join od in db.ComputingBudgets on pd.ComputingBudgetID equals od.ComputingBudgetID



                        select new
                        {
                            od.AvgCompLab,

                        }).ToList();

            ViewBag.avgLab = String.Join(",", lst2);

            var lst3 = (from pd in db.HecAdministrations
                        join od in db.ComputingBudgets on pd.ComputingBudgetID equals od.ComputingBudgetID



                        select new
                        {
                            od.AvgLifetimePC,

                        }).ToList();

            ViewBag.avgLifeTime = String.Join(",", lst3);

            var lst4 = (from pd in db.HecAdministrations
                        join od in db.ComputingBudgets on pd.ComputingBudgetID equals od.ComputingBudgetID



                        select new
                        {
                            od.LabContact,

                        }).ToList();

            ViewBag.LabContact = String.Join(",", lst4);

            var lst5 = (from pd in db.HecAdministrations
                        join od in db.ComputingBudgets on pd.ComputingBudgetID equals od.ComputingBudgetID



                        select new
                        {
                            od.DLDlab,

                        }).ToList();

            ViewBag.DLDlab = String.Join(",", lst5);

            var lst6 = (from pd in db.HecAdministrations
                        join od in db.ComputingBudgets on pd.ComputingBudgetID equals od.ComputingBudgetID



                        select new
                        {
                            od.FYPLab,

                        }).ToList();

            ViewBag.FYPlab = String.Join(",", lst6);

            //student ratio

            var lst7r = (from pd in db.HecAdministrations
                        join od in db.ComputingBudgets on pd.ComputingBudgetID equals od.ComputingBudgetID
                        join ad in db.ComputerRatios on od.ComputerRatioID equals ad.ComputerRatioID
                        join rd in db.RatioYearlyBudgets on ad.RatioYearlyBudgetID equals rd.RatioYearlyBudgetID


                        where rd.YearNumber==2020
                        select new
                        {
                            rd.Description,

                        }).ToList();

            ViewBag.ratio20 = String.Join(",", lst7r);

            var lst8r = (from pd in db.HecAdministrations
                         join od in db.ComputingBudgets on pd.ComputingBudgetID equals od.ComputingBudgetID
                         join ad in db.ComputerRatios on od.ComputerRatioID equals ad.ComputerRatioID
                         join rd in db.RatioYearlyBudgets on ad.RatioYearlyBudgetID equals rd.RatioYearlyBudgetID


                         where rd.YearNumber == 2019
                         select new
                         {
                             rd.Description,

                         }).ToList();

            ViewBag.ratio19 = String.Join(",", lst8r);

            var lst9r = (from pd in db.HecAdministrations
                         join od in db.ComputingBudgets on pd.ComputingBudgetID equals od.ComputingBudgetID
                         join ad in db.ComputerRatios on od.ComputerRatioID equals ad.ComputerRatioID
                         join rd in db.RatioYearlyBudgets on ad.RatioYearlyBudgetID equals rd.RatioYearlyBudgetID


                         where rd.YearNumber == 2018
                         select new
                         {
                             rd.Description,

                         }).ToList();

            ViewBag.ratio20 = String.Join(",", lst9r);

            //library


            var lsta = (from pd in db.HecAdministrations
                         join od in db.LibraryBudgets on pd.LibraryBudgetID equals od.LibraryBudgetID
                         


                         select new
                         {
                             od.TotalBooks,

                         }).ToList();

            ViewBag.totalBooks = String.Join(",", lsta);

            var lstb = (from pd in db.HecAdministrations
                        join od in db.LibraryBudgets on pd.LibraryBudgetID equals od.LibraryBudgetID



                        select new
                        {
                            od.NumberOfTitles,

                        }).ToList();

            ViewBag.Titles = String.Join(",", lstb);

            var lstc = (from pd in db.HecAdministrations
                        join od in db.LibraryBudgets on pd.LibraryBudgetID equals od.LibraryBudgetID



                        select new
                        {
                            od.HecLib,

                        }).ToList();

            ViewBag.HecConnected = String.Join(",", lstc);

            var lstd = (from pd in db.HecAdministrations
                        join od in db.LibraryBudgets on pd.LibraryBudgetID equals od.LibraryBudgetID



                        select new
                        {
                            od.LibManagment,

                        }).ToList();

            ViewBag.libMgnt = String.Join(",", lstd);

            var lste = (from pd in db.HecAdministrations
                        join od in db.LibraryBudgets on pd.LibraryBudgetID equals od.LibraryBudgetID



                        select new
                        {
                            od.IEEEElib,

                        }).ToList();

            ViewBag.IEEEE = String.Join(",", lste);

            var lstf = (from pd in db.HecAdministrations
                        join od in db.LibraryBudgets on pd.LibraryBudgetID equals od.LibraryBudgetID
                        join yd in db.LYearlyBudgets on od.LYearlyBudgetID equals yd.LYearlyBudgetID


                        where yd.YearNumber== 2020
                        select new
                        {
                            yd.ComputingBooksAdded,

                        }).ToList();

            ViewBag.BooksAdded20 = String.Join(",", lstf);

            var lstg = (from pd in db.HecAdministrations
                        join od in db.LibraryBudgets on pd.LibraryBudgetID equals od.LibraryBudgetID
                        join yd in db.LYearlyBudgets on od.LYearlyBudgetID equals yd.LYearlyBudgetID


                        where yd.YearNumber == 2020
                        select new
                        {
                            yd.NumberOfMagazines,

                        }).ToList();

            ViewBag.magazines20 = String.Join(",", lstg);

            var lsth = (from pd in db.HecAdministrations
                        join od in db.LibraryBudgets on pd.LibraryBudgetID equals od.LibraryBudgetID
                        join yd in db.LYearlyBudgets on od.LYearlyBudgetID equals yd.LYearlyBudgetID


                        where yd.YearNumber == 2019
                        select new
                        {
                            yd.ComputingBooksAdded,

                        }).ToList();

            ViewBag.BooksAdded19 = String.Join(",", lsth);

            var lsti = (from pd in db.HecAdministrations
                        join od in db.LibraryBudgets on pd.LibraryBudgetID equals od.LibraryBudgetID
                        join yd in db.LYearlyBudgets on od.LYearlyBudgetID equals yd.LYearlyBudgetID


                        where yd.YearNumber == 2019
                        select new
                        {
                            yd.ComputingBooksAdded,

                        }).ToList();

            ViewBag.magazines19 = String.Join(",", lsti);

            var lstj = (from pd in db.HecAdministrations
                        join od in db.LibraryBudgets on pd.LibraryBudgetID equals od.LibraryBudgetID
                        join yd in db.LYearlyBudgets on od.LYearlyBudgetID equals yd.LYearlyBudgetID


                        where yd.YearNumber == 2018
                        select new
                        {
                            yd.ComputingBooksAdded,

                        }).ToList();

            ViewBag.BooksAdded18 = String.Join(",", lstj);

            var lstk = (from pd in db.HecAdministrations
                        join od in db.LibraryBudgets on pd.LibraryBudgetID equals od.LibraryBudgetID
                        join yd in db.LYearlyBudgets on od.LYearlyBudgetID equals yd.LYearlyBudgetID


                        where yd.YearNumber == 2018
                        select new
                        {
                            yd.ComputingBooksAdded,

                        }).ToList();

            ViewBag.magazines18 = String.Join(",", lstk);

            //checkboxes

            var lstins = (from pd in db.HecAdministrations
                        join od in db.InstructionalFacilities on pd.InstructionalFacilitiesID equals od.InstructionalFacilitiesID


                    
                        select new

                        {
                            od.multimedia,
                            od.sound,
                            od.AC,
                            od.wifi,
                            od.advanced,

                        }).ToList();

       

            ViewBag.ismultimedia = lstins[0].multimedia;
            ViewBag.isair = lstins[0].AC;
            ViewBag.iswifi = lstins[0].wifi;
            ViewBag.issound = lstins[0].sound;
            ViewBag.isadvanced = lstins[0].advanced;

            var lstother = (from pd in db.HecAdministrations
                          join od in db.OtherFacilities on pd.OtherFacilitiesID equals od.OtherFacilitiesID



                          select new

                          {
                              od.Ac,
                              od.lights,
                              od.fans,
                              od.whiteboard,
                              od.projector,

                          }).ToList();



            ViewBag.isAc = lstother[0].Ac;
            ViewBag.isLight = lstother[0].lights;
            ViewBag.isFans = lstother[0].fans;
            ViewBag.isWhiteboard = lstother[0].whiteboard;
            ViewBag.isproj = lstother[0].projector;


            var level = (from pd in db.HecAdministrations
                            join od in db.ComputingBudgets on pd.ComputingBudgetID equals od.ComputingBudgetID
                            join ld in db.LevelNetworkings on od.LevelNetworkingID equals ld.LevelNetworkingID



                            select new

                            {
                                ld.Cisco,
                                ld.WAN,
                                ld.HecDigitalLibrary,
                                ld.Virtualizaion,
                            }).ToList();



            ViewBag.isCisco = level[0].Cisco;
            ViewBag.isWAN = level[0].WAN;
            ViewBag.isDigi = level[0].HecDigitalLibrary;
            ViewBag.isVirtual = level[0].Virtualizaion;

            var lab = (from pd in db.HecAdministrations
                         join od in db.ComputingBudgets on pd.ComputingBudgetID equals od.ComputingBudgetID
                         join ld in db.LabAvailabilities on od.LabAvailabilityID equals ld.LabAvailabilityID



                         select new

                         {
                             ld.AdvancedLab,
                             ld.Projectors,
                             ld.sound,
                             ld.LAN,
                             ld.whiteboards,
                             ld.supportStaff,
                             ld.Printers,
                         }).ToList();



            ViewBag.isLab = lab[0].AdvancedLab;
            ViewBag.isprojec = lab[0].Projectors;
            ViewBag.isSounds = lab[0].sound;
            ViewBag.isLAN = lab[0].LAN;
            ViewBag.isWhite = lab[0].whiteboards;
            ViewBag.isStaff = lab[0].supportStaff;
            ViewBag.isPrint = lab[0].Printers;











            return View();

        }
        public ActionResult PMPF()
        {
            ViewBag.Institution = (from d in db.Institutions select d.InstitutionName).FirstOrDefault();

            var lst = (from d in db.Institutions
                       where d.InstitutionID == 1
                       select d).FirstOrDefault();


            var lstp = (from pd in db.PMPFs
                        join od in db.Programs on pd.ProgramID equals od.ProgramID


                        where od.Description == "BSSE"
                        select new
                        {
                            od.Description,

                        }).ToList();

            ViewBag.prog = String.Join(",", lstp);

            var lst1 = (from pd in db.PMPFs
                         join od in db.Programs on pd.ProgramID equals od.ProgramID
                         


                         where od.Description == "BSSE"
                         select new
                         {
                             pd.Objective,

                         }).ToList();

            ViewBag.objective = String.Join(",", lst1);

            var lst2 = (from pd in db.PMPFs
                        join od in db.Programs on pd.ProgramID equals od.ProgramID



                        where od.Description == "BSSE"
                        select new
                        {
                            pd.Reviewed

                        }).ToList();

            ViewBag.review = String.Join(",", lst2);

            var lst3 = (from pd in db.PMPFs
                        join od in db.Programs on pd.ProgramID equals od.ProgramID



                        where od.Description == "BSSE"
                        select new
                        {
                            pd.SummaryProblem,

                        }).ToList();

            ViewBag.problem = String.Join(",", lst3);

            var lst4 = (from pd in db.PMPFs
                        join od in db.Programs on pd.ProgramID equals od.ProgramID



                        where od.Description == "BSSE"
                        select new
                        {
                            pd.SummaryTech,

                        }).ToList();

            ViewBag.tech = String.Join(",", lst4);

            var lst5 = (from pd in db.PMPFs
                        join od in db.Programs on pd.ProgramID equals od.ProgramID



                        where od.Description == "BSSE"
                        select new
                        {
                            pd.Assesment,

                        }).ToList();

            ViewBag.assess = String.Join(",", lst5);

            var lst6 = (from pd in db.PMPFs
                        join od in db.Programs on pd.ProgramID equals od.ProgramID



                        where od.Description == "BSSE"
                        select new
                        {
                            pd.CorrelateIndus,

                        }).ToList();

            ViewBag.coRelate = String.Join(",", lst6);

            var lst7 = (from pd in db.PMPFs
                        join od in db.Programs on pd.ProgramID equals od.ProgramID



                        where od.Description == "BSSE"
                        select new
                        {
                            pd.Application,

                        }).ToList();

            ViewBag.application = String.Join(",", lst7);

            return View();
            //return View();
        }
    }
}