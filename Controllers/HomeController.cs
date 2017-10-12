using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/categories")]
    public ActionResult Categories()
    {
      List<Category> allCategories = Category.GetAll();
      return View( );
    }

    [HttpGet("/categories/form")]
    public ActionResult CategoryForm()
    {
      return View();
    }

    [HttpPost("/categories")]
    public ActionResult AddCategory()
    {
      Category newCategory = new Category(Request.Form["category-name"]);
      List<Category> allCategories = Category.GetAll();
      return View("Categories", allCategories);
    }

    [HttpGet("/categories/{id}")]
    public ActionResult CategoryDetail(int id)
    //id = 1
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Task> categoryTasks = selectedCategory.GetTasks();
      model.Add("category", selectedCategory);
      model.Add("tasks", categoryTasks);
      return View(model);
    }

    [HttpGet("/categories/{id}/tasks/new")]
    public ActionResult CategoryTaskForm(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Task> allTasks = selectedCategory.GetTasks();
      model.Add("category", selectedCategory);
      model.Add("tasks", allTasks);
      return View(model);
    }

    [HttpPost("/tasks")]
    public ActionResult AddTask()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(int.Parse(Request.Form["category-id"]));
      List<Task> categoryTasks = selectedCategory.GetTasks();
      string taskDescription = Request.Form["task-description"];
      Task newTask = new Task(taskDescription);
      categoryTasks.Add(newTask);
      model.Add("tasks", categoryTasks);
      model.Add("category", selectedCategory);
      return View("CategoryDetail", model);
    }

    [HttpGet("/tasks/{id}")]
    public ActionResult TaskDetail(int id)
    {
      Task task = Task.Find(id);
      return View(task);
    }


    // [Route("/task/list")]
    // public ActionResult TaskList()
    // {
    //   List<string> allTasks = Task.GetAll();
    //   return View(allTasks);
    // }
    //
    // [HttpPost("/task/create")]
    // public ActionResult CreateTask()
    // {
    //   Task newTask = new Task (Request.Form["new-task"]);
    //   newTask.Save();
    //   return View(newTask);
    // }
    //
    // [HttpPost("/task/list/clear")]
    // public ActionResult TaskListClear()
    // {
    //   Task.ClearAll();
    //   return View();
    // }

  }
}
