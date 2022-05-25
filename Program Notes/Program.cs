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

        static void ChangeNote(ref string[] notes, int noteIndex, string newNote)
        {
            if (noteIndex > notes.Length)
            {
                Console.WriteLine("\n[Ошибка!] Заметки с таким номером не существует\n");
            }
            else
            {
                notes[noteIndex - 1] = newNote;
            }
        }

        static void DeleteAllNotes(ref string[]notes)
        {
            notes = Array.Empty<string>();
        }

        static void DeleteNote(ref string[] notes, int noteIndex)
        {
            string[] resizedNotes = new string[notes.Length - 1];
                        
            for (int i = 0; i < noteIndex - 1; i++)
                resizedNotes[i] = notes[i];

            for (int i = noteIndex - 1; i < resizedNotes.Length; i++)
                resizedNotes[i] = notes[i + 1];

            notes = resizedNotes;
        }

        static void NewNote(ref string[] notes, string newNote)
        {
            Array.Resize(ref notes, notes.Length + 1);
                        
            notes[notes.Length - 1] = newNote;
        }

        static void PrintNotes(string[] notes)
        {
            if (notes.Length == 0)
            {
                Console.WriteLine("У вас нет заметок");
            }
            else
            {
                Console.WriteLine("Ваши заметки:");

                for (int i = 0; i < notes.Length; i++)
                    Console.WriteLine((i + 1) + ". " + notes[i]);
            }
        }

        static void Main(string[] args)
        {
            string[] notes = new string[0];

            int noteIndex = 0;

            string newNote = "";

            while (true)
            {
                Console.WriteLine("\n----Выберите действие----");
                Console.WriteLine("[A] - Посмотреть все заметки");
                Console.WriteLine("[N] - Добавить новую заметку");
                Console.WriteLine("[C] - Изменить существующую заметку");
                Console.WriteLine("[D] - Удалить заметку");
                Console.WriteLine("[Delete] - Удалить все заметки");
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
                        Console.WriteLine("Введите новую заметку:");
                        newNote = Console.ReadLine();
                        NewNote(ref notes, newNote);
                        PrintNotes(notes);
                        break;

                    case ConsoleKey.C:
                        Console.WriteLine("Заметку с каким номером изменить?");
                        noteIndex = int.Parse(Console.ReadLine());
                        Console.WriteLine("Новый текст заметки:");
                        newNote = Console.ReadLine();
                        ChangeNote(ref notes, noteIndex, newNote);
                        PrintNotes(notes);
                        break;

                    case ConsoleKey.D:
                        Console.WriteLine("Заметку с каким номером удалить?");
                        noteIndex = int.Parse(Console.ReadLine());
                        DeleteNote(ref notes, noteIndex);
                        PrintNotes(notes);
                        break;

                    case ConsoleKey.Delete:
                        DeleteAllNotes(ref notes);
                        PrintNotes(notes);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
