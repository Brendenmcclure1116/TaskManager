using TaskManagmentSystem;

TaskManager taskManager = new TaskManager();

// Scenario 1
Console.WriteLine("Scenario #1");
taskManager.AddTask("Complete math homework", "School", 1);
Console.WriteLine();

// Scenario 2
Console.WriteLine("Scenario #2");
taskManager.AddTask("Purchase Materials", "Outdoor", 2);
Console.WriteLine();

// Scenario 3
Console.WriteLine("Scenario #3");
taskManager.AddTask("Clear Shed Area", "Outdoor", 2);
Console.WriteLine();

// Scenario 4
Console.WriteLine("Scenario #4");
taskManager.AddDependency(2, 3);
Console.WriteLine();

// Scenario 5
Console.WriteLine("Scenario 5");
taskManager.GetTasks();
Console.WriteLine();

// Scenario 6
Console.WriteLine("Scenario 6");
taskManager.BulkUpdatePriority("Outdoor", 1);
Console.WriteLine();

// Scenario 7
Console.WriteLine("Scenario 7");
taskManager.UpdatePriority(1, 2);
Console.WriteLine();

// Scenario 8
Console.WriteLine("Scenario 8");
taskManager.DeleteTask(2);
Console.WriteLine();

// Scenario 9
Console.WriteLine("Scenario 9");
taskManager.DeleteTask(3);
Console.WriteLine();

// Scenario 10
Console.WriteLine("Scenario 10");
taskManager.CompleteTask(2);
Console.WriteLine();

// Scenario 11
Console.WriteLine("Scenario 11");
taskManager.GetCompletedTasks();
Console.WriteLine();

// Scenario 12
Console.WriteLine("Scenario 12");
taskManager.GetTasks();


Console.ReadLine();