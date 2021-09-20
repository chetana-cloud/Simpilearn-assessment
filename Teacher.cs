using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public int clss { get; set; }
        public char sec { get; set; }
    }

    class teacher_record
    {
        static public void add_teacher(Teacher new_record, List<Teacher> teacher_list)
        {
            Console.WriteLine("\n Enter the number of records");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("\n Enter teacher id : ");
                int ID = int.Parse(Console.ReadLine());

                Console.WriteLine("\n Enter teacher name : ");
                string nm = Console.ReadLine();

                Console.WriteLine("\n Enter Class : ");
                int cls = int.Parse(Console.ReadLine());

                Console.WriteLine("\n Enter Section : ");
                char secn = Console.ReadLine()[0];

                new_record = new Teacher();
                new_record.id = ID;
                new_record.name = nm;
                new_record.clss = cls;
                new_record.sec = secn;
                teacher_list.Add(new_record);

            }
        }

        static public void display_teacher(Teacher new_record, List<Teacher> teacher_list)
        {
            for (int i = 0; i < teacher_list.Count; i++)
            {
                Console.WriteLine("\n\nID = " + teacher_list[i].id);
                Console.WriteLine("Teacher name = " + teacher_list[i].name);
                Console.WriteLine("Class = " + teacher_list[i].clss);
                Console.WriteLine("Section = " + teacher_list[i].sec + "\n\n");
            }

            if (teacher_list.Count < 1)
                Console.WriteLine("\n No teacher data found");
        }

        static public void add_to_textfile(List<Teacher> teacher_list)
        {
            string path = @"C:\Users\Chetana\Desktop\teacher_record.txt";
            string rec = "";

            for (int i = 0; i < teacher_list.Count; i++)
            {
                rec += teacher_list[i].id + " " + teacher_list[i].name + " " + teacher_list[i].clss + " " + teacher_list[i].sec + "\n";
            }

            File.WriteAllText(path, rec);
        }

        static public void convert_to_list(Teacher new_record, List<Teacher> teacher_list)
        {
            string path = @"C:\Users\Chetana\Desktop\teacher_record.txt";

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                String[] text_data;

                for (int i = 0; i < lines.Length; i++)
                {
                    text_data = lines[i].Split(' ');
                    new_record = new Teacher();
                    new_record.id = int.Parse(text_data[0]);
                    new_record.name = text_data[1];
                    new_record.clss = int.Parse(text_data[2]);
                    new_record.sec = text_data[3][0];
                    teacher_list.Add(new_record);
                }
            }

            else
                Console.WriteLine("\n File not found, a new file will be created");
        }


        static public void update(List<Teacher> teacher_list)
        {
            Console.WriteLine("Enter teacher id to update data");
            int update_id = int.Parse(Console.ReadLine());

            int index = teacher_list.FindIndex(x => x.id == update_id);
            if (index > -1)
            {
                Console.WriteLine("Enter Choice \n1.Name \n2.Class \n3.Section");
                int ch = int.Parse(Console.ReadLine());

                if (ch == 1)
                {
                    Console.WriteLine("Enter new name ");
                    string nn = Console.ReadLine();
                    teacher_list[index].name = nn;
                }

                if (ch == 2)
                {
                    Console.WriteLine("Enter new class ");
                    int nc = int.Parse(Console.ReadLine());
                    teacher_list[index].clss = nc;
                }

                if (ch == 3)
                {
                    Console.WriteLine("Enter new section ");
                    char ns = Console.ReadLine()[0];
                    teacher_list[index].sec = ns;
                }
            }

            else
                Console.WriteLine("\n Index not found ");
        }

        static public void delete(List<Teacher> teacher_list)
        {
            Console.WriteLine("\n Enter the id to be deleted");
            int del_id = int.Parse(Console.ReadLine());
            int index = teacher_list.FindIndex(x => x.id == del_id);

            if (index > -1)
            {
                Console.WriteLine("\n Teacher Name: " + teacher_list[index].name + "\nAllocated Class: " + teacher_list[index].clss + "\n Allocated Section: " + teacher_list[index].sec);
                Console.WriteLine("Will be deleted");
                teacher_list.RemoveAt(index);
            }

            else
                Console.WriteLine("ID not found");
        }
        static void Main(string[] args)
        {
            List<Teacher> teacher_list = new List<Teacher>();
            Teacher new_record = null;

            convert_to_list(new_record, teacher_list);

            while (true)
            {
                Console.WriteLine("Enter Choice \n 1.Add record \n 2.Display records \n 3.Save data to textfile and exit \n 4.Update data \n 5.Delete record \n 6.Exit without saving");
                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        add_teacher(new_record, teacher_list);
                        break;
                    case 2:
                        display_teacher(new_record, teacher_list);
                        break;
                    case 3:
                        add_to_textfile(teacher_list);
                        break;
                    case 4:
                        update(teacher_list);
                        break;
                    case 5:
                        delete(teacher_list);
                        break;
                    case 6:
                        break;
                }

                if (ch == 3 || ch == 6)
                {
                    break;
                }
            }


        }

    }

}
