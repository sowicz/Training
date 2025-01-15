using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Training
{

    public class TaskManager
    {

        public static string AddTask()
        {
            Console.WriteLine("Write task you would like to add :");
            string? task = Console.ReadLine();
            Console.WriteLine($"Added: {task}");

            while (string.IsNullOrEmpty(task))
            {
                Console.WriteLine("Task can not be empty:");
                task = Console.ReadLine();
                Console.WriteLine($"Added: {task}");
            }
            return task;
        }


        public static void GetTasks(List<string> tasks) 
        {
            Console.WriteLine("All of the tasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i}) Task: {tasks[i]}");
            };
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }


        public static void RemoveTask(List<string> tasks)
        {
            if (tasks.Count < 1)
            {
                Console.WriteLine("No task to remove, please Enter to continue");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("All tasks:");

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i}) Task: {tasks[i]}");
            };
            Console.WriteLine("Please type the ID of the task or type 'q' to exit:");
            string? input = Console.ReadLine();

            int numberOfTask;

            if (input == "q")
            {
                return;
            } 
            else if(int.TryParse(input, out numberOfTask))
            {
                // Add logic to handle no id in tasks
                //if (numberOfTask == 0 || numberOfTask <= tasks.Count())
                if (numberOfTask < 0 || numberOfTask >= tasks.Count)
                {
                    Console.WriteLine("Invalid task ID. Press Enter to continue.");
                    Console.ReadLine();
                    return;
                }

                tasks.RemoveAt(numberOfTask);
                Console.WriteLine("Task removed successfully! Please Enter to continue:");
                Console.ReadLine();
                return;
                
            } else
            {
                Console.WriteLine("Wrong type, should be number or 'q', please Enter to continue:");
                Console.ReadLine();
                return;
            }
        }


        public static void UpdateTask(List<string> tasks)
        {
            bool UpdateTaskOn = true;
            int taskSelect = 0;

            while (UpdateTaskOn)
            {
                Console.Clear();
                Console.WriteLine("Please select an option:");

                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine((i == taskSelect ? "[x] " : "[] ") + tasks[i]);
                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow && taskSelect != tasks.Count - 1)
                {
                    taskSelect++;
                }
                else if (key.Key == ConsoleKey.UpArrow && taskSelect >= 1)
                {
                    taskSelect--;
                }
                else if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) 
                {
                    Console.WriteLine($"Task editing: {tasks[taskSelect]}. If you want to quit type: exit");
                    string? updatedTask = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(updatedTask) && updatedTask != "exit")
                    {
                        tasks[taskSelect] = updatedTask;
                        Console.WriteLine("Task updated successfully! Press Enter to continue.");
                        return;
                    }
                    else { 
                        return;
                    }
                }


            }
        }

    }
}


