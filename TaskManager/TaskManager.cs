using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentSystem
{
    public class TaskManager
    {
        private class Task
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public int Priority { get; set; }
            public bool IsCompleted { get; set; }
            public List<int> Dependencies { get; set; }

            public Task(int id, string description, string category, int priority)
            {
                Id = id;
                Description = description;
                Category = category;
                Priority = priority;
                IsCompleted = false;
                Dependencies = new List<int>();
            }
        }

        private Dictionary<int, Task> tasks;
        private int taskIdCounter;
        private Dictionary<string, List<int>> categoryTasks;

        public TaskManager()
        {
            tasks = new Dictionary<int, Task>();
            taskIdCounter = 1;
            categoryTasks = new Dictionary<string, List<int>>();
        }

        public void AddTask(string description, string category, int priority)
        {
            Task newTask = new Task(taskIdCounter, description, category, priority);
            tasks.Add(taskIdCounter, newTask);

            if (!categoryTasks.ContainsKey(category))
                categoryTasks[category] = new List<int>();

            categoryTasks[category].Add(taskIdCounter);

            Console.WriteLine($"Task created successfully. Task ID is {taskIdCounter}");
            taskIdCounter++;
        }

        public void DeleteTask(int taskId)
        {
            if (tasks.ContainsKey(taskId))
            {
                if (tasks[taskId].Dependencies.Count == 0)
                {
                    string category = tasks[taskId].Category;
                    categoryTasks[category].Remove(taskId);
                    tasks.Remove(taskId);
                    Console.WriteLine("Task deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Error - unable to delete a task with a dependency.");
                }
            }
            else
            {
                Console.WriteLine("Error - Task not found.");
            }
        }

        public void GetTasks()
        {
            foreach (var category in categoryTasks.Keys)
            {
                foreach (var taskId in categoryTasks[category])
                {
                    var task = tasks[taskId];
                    if (!task.IsCompleted)
                        Console.WriteLine($"{task.Category}, {task.Description}, {task.Priority}");
                }
            }
        }

        public void BulkUpdatePriority(string category, int newPriority)
        {
            int updatedTasks = 0;
            if (categoryTasks.ContainsKey(category))
            {
                foreach (var taskId in categoryTasks[category])
                {
                    var task = tasks[taskId];
                    if (!task.IsCompleted)
                    {
                        task.Priority = newPriority;
                        updatedTasks++;
                    }
                }
            }

            Console.WriteLine($"{updatedTasks} tasks updated successfully.");
        }

        public void UpdatePriority(int taskId, int newPriority)
        {
            if (tasks.ContainsKey(taskId))
            {
                var task = tasks[taskId];
                task.Priority = newPriority;
                Console.WriteLine("1 task updated successfully.");
            }
            else
            {
                Console.WriteLine("Error - Task not found.");
            }
        }

        public void CompleteTask(int taskId)
        {
            if (tasks.ContainsKey(taskId))
            {
                tasks[taskId].IsCompleted = true;
                Console.WriteLine("Task completed successfully.");
            }
            else
            {
                Console.WriteLine("Error - Task not found.");
            }
        }

        public void GetCompletedTasks()
        {
            foreach (var task in tasks.Values)
            {
                if (task.IsCompleted)
                    Console.WriteLine($"{task.Category}, {task.Description}, {task.Priority}");
            }
        }

        public void AddDependency(int dependentTaskId, int dependencyTaskId)
        {
            if (tasks.ContainsKey(dependentTaskId) && tasks.ContainsKey(dependencyTaskId))
            {
                tasks[dependentTaskId].Dependencies.Add(dependencyTaskId);
                Console.WriteLine("Dependency created successfully.");
            }
            else
            {
                Console.WriteLine("Error - Task not found.");
            }
        }
    }
}
