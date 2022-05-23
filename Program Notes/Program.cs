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



        static void Menu(ConsoleKey key, string[] notes, string newNote = "")
        {
            switch (key)
            {
                case ConsoleKey.A:
                    PrintNotes(notes);
                    break;

                case ConsoleKey.N:
                    NewNote(notes, newNote);
                    break;


                default:
                    break;
            }
        }

        static string[] NewNote(string[]notes, string newNote)
        {
            string [] resizedNotes = new string[notes.Length + 1];

            resizedNotes[notes.Length + 1] = newNote;

            notes = resizedNotes;

            return notes;
        }

        static void PrintNotes(string[] notes)
        {
            for (int i = 0; i < notes.Length; i++)
                Console.WriteLine(i + ". " + notes[i]);
        }


        static void Main(string[] args)
        {
            string[] notes = { "Пожрать", "Поспасть", "Посрать", "Посмотреть", "Поиграть", "Попинать", "Погулять", "Поугарать", "Попрактиковаться", "Поинтересоваться" };


            while (true)
            {
                Console.WriteLine("\nВыберите действие");
                Console.WriteLine("Нажмите A - Посмотреть все заметки");
                Console.WriteLine("Нажмите N - Добавить новую заметку");
                Console.WriteLine("Нажмите Escape - Завершить работу программы\n");

                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                    break;

                Menu(key, notes);
            }

        }
    }
}
