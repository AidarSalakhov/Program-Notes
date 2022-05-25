using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


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
            if (notes.Length == 0)
            {
                Console.WriteLine("У вас нет заметок");
            }
            else
            {
                Console.WriteLine("Ваши заметки:");

                for (int i = 0; i < notes.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + notes[i]);
                }
            }
        }

        static void NewNote(ref string[] notes, string newNote)
        {
            Array.Resize(ref notes, notes.Length + 1);

            notes[notes.Length - 1] = newNote;
        }

        static void ChangeNote(ref string[] notes, int noteIndex, string newNote)
        {
            if (noteIndex > notes.Length || noteIndex == 0)
            {
                Console.WriteLine("\n[Ошибка!] Заметки с таким номером не существует\n");
            }
            else
            {
                notes[noteIndex - 1] = newNote;
            }
        }

        static void DeleteNote(ref string[] notes, int noteIndex)
        {
            if (noteIndex > notes.Length || noteIndex == 0)
            {
                Console.WriteLine("\n[Ошибка!] Заметки с таким номером не существует\n");
            }
            else
            {
                string[] resizedNotes = new string[notes.Length - 1];

                for (int i = 0; i < noteIndex - 1; i++)
                {
                    resizedNotes[i] = notes[i];
                }

                for (int i = noteIndex - 1; i < resizedNotes.Length; i++)
                {
                    resizedNotes[i] = notes[i + 1];
                }

                notes = resizedNotes;
            }
        }

        static void SaveToDisc(string[] notes)
        {
            File.WriteAllLines("Notes.txt", notes);
        }

        static void LoadFromDisc(ref string[] notes)
        {
            notes = File.ReadAllLines("Notes.txt");
        }

        static void DeleteAllNotes(ref string[] notes)
        {
            notes = Array.Empty<string>();
        }

        static void Main(string[] args)
        {
            string[] notes = new string[0];

            int noteIndex = 0;

            string newNote = "";

            while (true)
            {
                Console.WriteLine("\n\t----Выберите действие----");
                Console.WriteLine("\t[A] - Посмотреть все заметки");
                Console.WriteLine("\t[N] - Добавить новую заметку");
                Console.WriteLine("\t[C] - Изменить существующую заметку");
                Console.WriteLine("\t[D] - Удалить заметку");
                Console.WriteLine("\t[S] - Сохранить заметки в файл Notes.txt");
                Console.WriteLine("\t[L] - Загрузить заметки из файла Notes.txt");
                Console.WriteLine("\t[Delete] - Удалить все заметки");
                Console.WriteLine("\t[Escape] - Завершить работу программы\n");

                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                    break;

                switch (key)
                {
                    case ConsoleKey.A:
                        Console.Clear();

                        PrintNotes(notes);

                        break;

                    case ConsoleKey.N:
                        Console.Clear();

                        Console.WriteLine("Введите новую заметку:");

                        newNote = Console.ReadLine();

                        NewNote(ref notes, newNote);

                        PrintNotes(notes);

                        break;

                    case ConsoleKey.C:
                        Console.Clear();

                        PrintNotes(notes);

                        Console.WriteLine("Заметку с каким номером изменить?");

                        try
                        {
                            noteIndex = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\n[Ошибка!] Неверный номер заметки. Введите целое число\n");

                            break;
                        }

                        Console.WriteLine("Новый текст заметки:");

                        newNote = Console.ReadLine();

                        ChangeNote(ref notes, noteIndex, newNote);

                        PrintNotes(notes);

                        break;

                    case ConsoleKey.D:
                        Console.Clear();

                        PrintNotes(notes);

                        Console.WriteLine("Заметку с каким номером удалить?");

                        try
                        {
                            noteIndex = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\n[Ошибка!] Неверный номер заметки. Введите целое число\n");

                            break;
                        }

                        DeleteNote(ref notes, noteIndex);

                        PrintNotes(notes);

                        break;

                    case ConsoleKey.S:
                        Console.Clear();

                        SaveToDisc(notes);

                        Console.WriteLine("Заметки сохранены в файл Notes.txt в папке программы");

                        PrintNotes(notes);

                        break;

                    case ConsoleKey.L:
                        Console.Clear();

                        LoadFromDisc(ref notes);

                        Console.WriteLine("Заметки загружены из файла Notes.txt в папке программы");

                        PrintNotes(notes);

                        break;

                    case ConsoleKey.Delete:
                        Console.Clear();

                        DeleteAllNotes(ref notes);

                        PrintNotes(notes);

                        break;

                    default:
                        Console.Clear();

                        Console.WriteLine("\n[Ошибка!] Вы нажали неверную клавишу. Выберете один из вариантов:\n");

                        break;
                }
            }
        }
    }
}
