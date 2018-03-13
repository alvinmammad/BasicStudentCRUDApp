using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _130318crud
{
    class Student
    {
        public static List<Student> db = new List<Student>();
        public string Name;
        public string Surname;
        public int Age;
        public static int Count=1;
        public int ID;
        public Student (string _name , string _surname , int _age)
        {
            Name = _name;
            Surname = _surname;
            Age = _age;
            db.Add(this);
        }
        public static void Admin ()
        {
            Console.WriteLine("Istifadechi adini daxil edin :");
            var login = Console.ReadLine();
            Console.WriteLine("Istifadechi kodunu daxil edin :");
            var password = Console.ReadLine();

            if (login=="admin" && password == "admin")
            {
                Instructions();
            }
            else
            {
                Console.WriteLine("Sehv istifadechi adi ve istifadechi kodu ! ");
                Read();
                Exit();
            }
           
            
        }
        public static void Instructions()
        {
            Console.WriteLine("1 . Telebe melumatini daxil et :");
            Console.WriteLine("2 . Telebe melumatini goster :");
            Console.WriteLine("3 . Telebe melumatini deyish :" );
            Console.WriteLine("4 . Telebe melumatini sil :");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Emrin nomresini daxil et :");
            var emrNomresi = Convert.ToInt32(Console.ReadLine());
            
            if (emrNomresi == 1)
            {
                Create();
            }
            else if (emrNomresi == 2)
            {
                Read();
            }
            else if (emrNomresi == 3)
            {
                Update();
            }
            else if (emrNomresi == 4)
            {
                Delete();
            }
            else
            {
                Console.WriteLine("Yeniden emr sechin :");
                Instructions();
            }
        }
        public static void Create()
        {
            Console.WriteLine("Telebe adini daxil edin :");
            var name = Console.ReadLine();
            Console.WriteLine("Telebe soyadini daxil edin :");
            var surname = Console.ReadLine();
            Console.WriteLine("Telebenin yashini daxil edin :");
            var age = Convert.ToInt32(Console.ReadLine());
            var Telebe = new Student(name, surname, age);
            Telebe.ID = Count;
            Count++;
            Instructions();

        }

        public static void Read()
        {
            foreach (var item in db)
            {
                Console.WriteLine(item.ID + " " + item.Name + " " + item.Surname + " " + item.Age);
                Console.WriteLine("--------------------------");
                               
            }
            Instructions();
        }
        public static void Update()
        {
            Console.WriteLine("Yenilemek istediyiniz melumatin 'ID' nomresini daxil edin :");

            foreach (var item in db)
            {
                Console.WriteLine(item.ID + " " + item.Name +  " " + item.Surname + " " + item.Age);
            }
            var RandomID = Convert.ToInt32(Console.ReadLine());

            foreach (var item in db)
            {
                if (item.ID == RandomID)
                {
                    Console.WriteLine("Telebenin adini daxil edin :");
                    var name = Console.ReadLine();
                    Console.WriteLine("Telebenin soyadini daxil edin :");
                    var surname = Console.ReadLine();
                    Console.WriteLine("Telebenin yashini daxil edin :");
                    var age = Convert.ToInt32(Console.ReadLine());

                    item.Name = name;
                    item.Surname = surname;
                    item.Age = age;

                    Read();
                }
            }
        }
        public static void Delete()
        {
            Console.WriteLine("Silmek istediyiniz melumatin 'ID' nomresini daxil edin :");
            var _ID = Convert.ToInt32(Console.ReadLine());

            foreach (var item in db)
            {
                if (item.ID == _ID)
                {
                    db.Remove(item);
                    break;
                }
            }
            Instructions();
        
        }

        public static void Details()
        {
            Console.WriteLine("Detalli melumatini gormek istediyiniz telebenin 'ID' deyerini daxil edin :");
            var _id = Convert.ToInt32(Console.ReadLine());
            foreach (var item in db)
            {
                if (item.ID == _id)
                {
                    Console.WriteLine("Telebenin adi : {0} " , item.Name);
                    Console.WriteLine("Telebenin soyadi : {0} " , item.Surname);
                    Console.WriteLine("Telebenin yashi : {0} " , item.Age);
                }
            }
            Instructions();
        }

         public static void Exit()
        {
            Console.WriteLine(" Chixmag uchun 5 regemini daxil edin ");
            Environment.Exit(5);
        }


    }
}
