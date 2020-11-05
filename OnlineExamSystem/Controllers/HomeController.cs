using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamSystem.Entities;
using OnlineExamSystem.Models;

namespace OnlineExamSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Exam()
        {
            var _ctx = new ExamModelEntities();

            ViewBag.Tests = _ctx.Tests.Where(x => x.IsActive == true).Select(x => new { x.Id, x.Name }).ToList();

            SessionModel _model = null;

            if (Session["SessionModel"] == null)
                _model = new SessionModel();

            else
                _model = (SessionModel)Session["SessionModel"];

            //ViewBag.Message = "Online Exam Page";
            return View(_model);
        }

        public ActionResult Instruction(SessionModel model)
        {
            if (model != null)
            {
                var _ctx = new ExamModelEntities();
                var test = _ctx.Tests.Where(x => x.IsActive == true && x.Id == model.TestId).FirstOrDefault();

                if (test != null)
                {
                    ViewBag.TestName = test.Name;
                    ViewBag.TestDescription = test.Description;
                    ViewBag.QuestionCount = test.TestXQuestions.Count();
                    ViewBag.TestDuration = test.DurationInMinute.Value.ToString("HH:mm:ss");

                    return View(model);
                }
            }
            return View("Exam", model);
        }

        public ActionResult Register(SessionModel model)
        {
            if (model != null)
                Session["SessionModel"] = model;

            if (model == null || string.IsNullOrEmpty(model.UserName) || model.TestId < 1)
            {
                TempData["tempMessage"] = "Invalid Registration details. Please try again.";

                return RedirectToAction("Exam");
            }

            //kullanıcıyı sisteme kaydetmek için
            //kullanıcının giriş yaptığı testi kaydetmek için
            var _ctx = new ExamModelEntities();
            var user = _ctx.Students.Where(x => x.Name == model.UserName && x.Email == model.Email).FirstOrDefault();

            if (user != null)
            {
                Student student = new Student
                {
                    Name = model.UserName,
                    Phone = model.Phone,
                    Email = model.Email,
                    AccessLevel = 100
                };

                _ctx.Students.Add(student);
                _ctx.SaveChanges();
            }

            Registiration registiration = _ctx.Registirations.Where(x => x.StudentId == user.Id && x.TestId == model.TestId && x.TokenExpireTime > DateTime.UtcNow).FirstOrDefault();
            if (registiration != null)
            {
                this.Session["TOKEN"] = registiration.Token;
                this.Session["TOKENEXPIRE"] = registiration.TokenExpireTime;
            }
            else
            {
                Test test = _ctx.Tests.Where(x => x.IsActive == true && x.Id == model.TestId).FirstOrDefault();
                if (test != null)
                {
                    // add new Registiration 
                }

            }

            return RedirectToAction("EvalPage", new { @token = Session["TOKEN"] });
        }


        public ActionResult EvalPage(Guid token, int? qno)
        {
            if (token == null)
            {
                TempData["message"] = "Invalid token.";
                return RedirectToAction("Index");
            }



            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}