using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_Notes
{
    internal class Program
    {
        //Программа “Заметки”
        //Программа хранит список заметок, пользователь может добавлять, редактировать и удалять заметки.

        //Функционал:

        //•Вывод всех заметок
        //•Добавление новой заметки в список
        //•Удаление существующей заметки из списка
        //•Удаление всех заметок.
        //•Изменение существующей заметки
        //•(Дополнительно) сохранение заметок в файл и загрузка

        static void PrintNotes(string[] notes)
        {
            for (int i = 0; i < notes.Length; i++)
            {
                Console.WriteLine(i + ". " + notes[i]);
            }
        }



        static void Main(string[] args)
        {
            while (true)
            {
                string[] notes = { "Пожрать", "Поспасть", "Посрать", "Посмотреть", "Поиграть", "Попинать", "Погулять", "Поугарать", "Попрактиковаться", "Поинтересоваться" };







                Console.WriteLine("Выберите действие");
                Console.WriteLine("Нажмите A - Посмотреть все заметки");
                Console.WriteLine("Нажмите Q - Завершить работу программы");



                switch (Console.ReadKey())
                {
                    case ConsoleKey.Q:
                        break;

                    case "a":
                        PrintNotes(notes);

                    default:
                        break;
                }


            }
        }
    }
}
