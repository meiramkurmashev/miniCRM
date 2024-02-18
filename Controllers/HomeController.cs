using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using miniCRM.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace miniCRM.Controllers
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
            Workers workers = new Workers();
           
            List<WorkersList> listWorkers = new List<WorkersList>();

            workers.GetWorkers(ref listWorkers);
            
            ViewBag.listWorkers = listWorkers;

           

            
            return View();
        }
        public IActionResult Report()
        {
            
                Tasks report = new Tasks();
                
                List<ReportList> listReport = new List<ReportList>();
                
                
                report.Report(ref listReport);
                
                ViewBag.listReport = listReport;
              

                return View();

            
        }
        public IActionResult Reportred()
        {

            Tasks report = new Tasks();

            //List<ReportList> listRed = new List<ReportList>();


            report.Reportred();

            //ViewBag.listReport = listRed;


            return View();



        }
        public IActionResult Add()
        { 
            return View();
        }
        public IActionResult AddComplete(string fio, string work)
        {
            Workers add = new Workers();
            add.Add(fio, work);
            return View();
           
        }
        public IActionResult Edit()
        {
            Workers workers = new Workers();
            
            List<WorkersList> listWorkers = new List<WorkersList>();

           
            workers.GetWorkers(ref listWorkers);
          
            ViewBag.listWorkers = listWorkers;

            


            return View();
        }
        public IActionResult EditProcess(int id, string fio, string work)
        {
            ViewBag.Id = id;
            ViewBag.Fio = fio;
            ViewBag.Work = work;
            return View();
        }
        public IActionResult EditComplete(int id, string fio, string work)
        {
            Workers edit = new Workers();
            edit.Edit(id, fio, work);
           
            return View();
        }
        public IActionResult Delete()
        {
            Workers workers = new Workers();

            List<WorkersList> listWorkers = new List<WorkersList>();


            workers.GetWorkers(ref listWorkers);

            ViewBag.listWorkers = listWorkers;
            return View();
        }
        public IActionResult DeleteComplete(int id)
        {
            Workers delete = new Workers();



            delete.Delete(id);
            return View();
            
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Auth(int id, string password)
        {
            Workers auth = new Workers();
            List<User> listUsers = new List<User>();


            


            auth.Auth(ref listUsers, id, password);
            ViewBag.listUsers = listUsers;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
