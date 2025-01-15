using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Training
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tasks = new List<string>();
            string[] menuOptions = new string[]
            {
                "Add task", "Print tasks", "Remove task", "Update task", "Quit"
            };
            int menuSelect = 0;
            bool programOn = true;

            while (programOn)
            {
                Console.Clear();
                Console.WriteLine("Please select an option:");
                for (int i = 0;i <menuOptions.Length; i++)
                {
                    Console.WriteLine((i == menuSelect ? "[x] " : "[] ") + menuOptions[i]);
                }

                // Read keyboard key
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
                {
                    menuSelect++;
                }
                else if (key.Key == ConsoleKey.UpArrow && menuSelect >= 1)
                {
                    menuSelect--;
                }
                else if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Spacebar) 
                {
                    switch (menuSelect)
                    {
                        case 0:
                            string task = TaskManager.AddTask();
                            tasks.Add(task);
                            break;
                        case 1:
                            TaskManager.GetTasks(tasks);
                            break;
                        case 2:
                            TaskManager.RemoveTask(tasks);
                            break;
                        case 3:
                            TaskManager.UpdateTask(tasks);
                            break;
                        case 4:
                            programOn = false;
                            break;
                    }
                }

            }
        }
        }
}