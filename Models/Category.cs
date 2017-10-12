using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    private string _name;
    private int _id;
    private List<Task> _tasks;
    private static List<Category> _instances = new List<Category> {};

    public Category(string categoryName)
    {
      _name = categoryName;
      _tasks = new List<Task>{};
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
   {
     return _id;
   }
     public List<Task> GetTasks()
    {
      return _tasks;
    }

    public void AddTask(Task task)
    {
      _tasks.Add(task);
    }

   public static List<Category> GetAll()
   {
     return _instances;
   }

   public static void Clear()
    {
      _instances.Clear();
    }

    public void ClearTasks()
    {
      _tasks = new List<Task>{};
    }

    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }

  }
}
