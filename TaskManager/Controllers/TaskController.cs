using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {

        private static IList<TaskModel> tasks = new List<TaskModel>()
        {
            new TaskModel(){TaskId = 1, Name = "Go to the doctor.", Descryption = "5 pm", Done = false },
            new TaskModel(){TaskId = 2, Name = "Do shoping.", Descryption = "After work.", Done = false },
            new TaskModel(){TaskId = 3, Name = "Repair a car.", Descryption = "Call a mechanic and make an appointment.", Done = false }
        };

        // GET: Task
        public ActionResult Index()
        {
            return View(tasks.Where(x => !x.Done));
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            try
            {
                taskModel.TaskId = tasks.Count + 1;
                tasks.Add(taskModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tasks);
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            try
            {
                TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
                task.Name = taskModel.Name;
                task.Descryption = taskModel.Descryption;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tasks);
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            try
            {
                TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
                tasks.Remove(task);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tasks);
            }
        }
        //GET: Task/Done
        public ActionResult Done(int id)
        {
            try
            {
                TaskModel task = tasks.FirstOrDefault(x => x.TaskId == id);
                task.Done = true;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tasks);
            }
        }
    }
}
