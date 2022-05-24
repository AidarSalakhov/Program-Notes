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


        static string[] NewNote(ref string[] notes, string newNote)
        {
            string[] resizedNotes = new string[notes.Length + 1];

            for (int i = 0; i < notes.Length; i++)
            {
                resizedNotes[i] = notes[i];
            }

            resizedNotes[notes.Length] = newNote;

            notes = resizedNotes;

            return notes;
        }

        static void PrintNotes(string[] notes)
        {
            Console.WriteLine("Ваши заметки: ");
            for (int i = 0; i < notes.Length; i++)
                Console.WriteLine((i+1) + ". " + notes[i]);
        }


        static void Main(string[] args)
        {
            string[] notes = { "Пожрать", "Поспасть", "Посрать"};

            

            while (true)
            {
                Console.WriteLine("\n----Выберите действие----");
                Console.WriteLine("[A] - Посмотреть все заметки");
                Console.WriteLine("[N] - Добавить новую заметку");
                Console.WriteLine("[Escape] - Завершить работу программы\n");

                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                    break;

                switch (key)
                {
                    case ConsoleKey.A:
                        PrintNotes(notes);
                        break;

                    case ConsoleKey.N:
                        Console.WriteLine("Введите новую заметку");
                        string newNote = Console.ReadLine();
                        NewNote(ref notes, newNote);
                        PrintNotes(notes);
                        break;


                    default:
                        break;
                }

            }

        }
    }
}
