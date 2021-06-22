using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotionlabGui.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MotionlabGui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new RequestModel());
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(RequestModel Request, string submit)
        {
            if (submit == "Send request")
            {
                if (Request.IsValid())
                {
                    var NewRequest = new Motionlab.InterviewTest(Request.Key, Request.Email, Request.Name);
                    await NewRequest.SendApplicationAsync();
                    Request.ProceedData(NewRequest);
                    Request.IsNotCompleted = false;
                    return View(Request);
                }
                else
                {
                    return View(Request);
                }
            }
            return View();
        }


        public async Task<IActionResult> HistoryAsync()
        {
            return View(await Motionlab.DB.InterviewTestControl.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> History(string submit)
        {
            if (submit == "Remove All")
            {
                await Motionlab.DB.InterviewTestControl.DeleteAllAsync();
            }
            return View(await Motionlab.DB.InterviewTestControl.GetAllAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
