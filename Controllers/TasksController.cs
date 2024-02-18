using Microsoft.AspNetCore.Mvc;
using miniCRM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace miniCRM.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            Workers workers = new Workers();
            //wagons.Lee();
            List<WorkersList> listWorkers = new List<WorkersList>();

            //Console.WriteLine(www);
            //Convert.ToUInt32(www);
            workers.GetWorkers(ref listWorkers);
            //listp.Capacity = 1;
            ViewBag.listWorkers = listWorkers;

            //ViewBag.wagons.www;


            return View();
            
        }
        public IActionResult Worker(int id, string fio, string work)
        {
            Tasks tasks = new Tasks();
            
            List<TasksList> listTasks = new List<TasksList>();

            
            tasks.GetTasks(ref listTasks, id);
            
            ViewBag.listTasks = listTasks;
            ViewBag.Id = id;
            ViewBag.Fio = fio;
            ViewBag.Work = work;
            


            return View();

        }
        public IActionResult Add(int id, string fio)
        {
            ViewBag.Id = id;
            ViewBag.Fio = fio;
            return View();
        }
        public IActionResult AddComplete(int id, string name,DateTime date)
        {
            Tasks addTask = new Tasks();
            addTask.Add(id, name, date);
            return View();
        }
        public IActionResult EditProcess(int id, string fio)
        {
            Tasks tasks = new Tasks();
            
            List<TasksList> listTasks = new List<TasksList>();

            
            tasks.GetTasks(ref listTasks, id);
            //listp.Capacity = 1;
            ViewBag.listTasks = listTasks;
            ViewBag.Id = id;
            ViewBag.Fio = fio;
            //ViewBag.Work = work;
            


            return View();
        }
        public IActionResult Edit(int id, string  name, DateTime start , DateTime end, int ready)
        {

           

            ViewBag.Id = id;
            ViewBag.Name = name;
            ViewBag.Start = start.ToString("yyyy-MM-dd");
            ViewBag.End = end.ToString("yyyy-MM-dd");
            ViewBag.Ready = ready;
            return View();
        }
        public IActionResult EditComplete(int id, string name, DateTime start, DateTime end, int ready)
        {
            Tasks edit = new Tasks();
            edit.Edit(id, name, start, end, ready);
            return View();
        }
        public IActionResult Delete(int id)
        {
            Tasks tasks = new Tasks();

            List<TasksList> listTasks = new List<TasksList>();


            tasks.GetTasks(ref listTasks, id);
            //listp.Capacity = 1;
            ViewBag.listTasks = listTasks;
            ViewBag.Id = id;
          
            //ViewBag.Work = work;

            return View();
        }
        public IActionResult DeleteComplete(int id)
        {
            Tasks tasks = new Tasks();

           

            tasks.Delete(id);
            return View();
        }
    }
}
