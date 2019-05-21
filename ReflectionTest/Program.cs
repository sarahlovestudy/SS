using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest
{
    public class NewClass
    {
        public string a;
        public int b;
        public int Name { get; set; }
        public int Age { set; get; }
        public NewClass(string m,int n) { a = m;b = n; }
        public NewClass() { Console.WriteLine("invoke construction."); }
        public void show() { Console.WriteLine("new a object " + a + this.Name + this.Age); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person pp = new Person { Name = "toto", Age = 5 };
            Type tPerson = pp.GetType();

            ConstructorInfo[] constructors = tPerson.GetConstructors();
            foreach(var ctor in constructors)
            {
                Console.WriteLine(ctor.Name);
                Console.WriteLine(ctor.GetParameters().Length);
            }

            Person person1, person2;
            ConstructorInfo c1 = tPerson.GetConstructor(new Type[2] { typeof(String), typeof(int) });
            if(c1!=null)
            {
                person1 = c1.Invoke(new object[] { "toto", 2 }) as Person;
            }
            ConstructorInfo c2 = tPerson.GetConstructor(new Type[0]);
            if(c2!=null)
            {
                person2 = c2.Invoke(null) as Person;
            }

            PropertyInfo propertyinfo = tPerson.GetProperty("Name");
            propertyinfo.SetValue(pp, "titi");
            Console.WriteLine(pp.Name);
 
            MethodInfo[] methodsPublic = tPerson.GetMethods();
            MethodInfo[] methodsPublicStatic = tPerson.GetMethods(BindingFlags.Public |
                                                                  BindingFlags.Static);
            MethodInfo[] methodsPublicInstance = tPerson.GetMethods(BindingFlags.Public |
                                                                    BindingFlags.Instance);
            MethodInfo[] methodsPublicDeclareOnly = tPerson.GetMethods(BindingFlags.Public |
                                                                        BindingFlags.DeclaredOnly |
                                                                        BindingFlags.Static);


            PropertyInfo[] props = tPerson.GetProperties();
            StringBuilder builder = new StringBuilder(30);
            foreach(var prop in props)
            {
                builder.Append(prop.Name + "=" + prop.GetValue(pp) + "\n");
            }
            FieldInfo[] fields = tPerson.GetFields();
            foreach(var f in fields)
            {
                builder.Append(f.Name + "=" + f.GetValue(pp) + "\n");
            }
            Console.WriteLine(builder);


            Assembly[] ass = AppDomain.CurrentDomain.GetAssemblies();
            Person p = new Person();
            p.TestAssembly();
            p.CreatePersonObject();
            Console.ReadLine();
        }
    }
    class Person
    {
        public String Name { get; set; }
        public int Age { get; set; }
        private int id;
        public void TestAssembly()
        {
            Assembly ass = this.GetType().Assembly;
            Type[] types = ass.GetTypes();
            Type currentType = ass.GetType();
            Type typeByFullName = ass.GetType("ReflectionTest.Person");

            Type type = this.GetType();
            MethodInfo[] methods = this.GetType().GetMethods();
            this.GetType().GetMethods();
            this.GetType().GetMember("Name");
            FieldInfo field = type.GetField("id");
            PropertyInfo prop = type.GetProperty("Name");
        }
        ///new method
        public void CreatePersonObject()
        {
            Type type = this.GetType();
            //使用Person类的Type对象，创建一个Person对象
            Person p = Activator.CreateInstance(type) as Person;
            Person p1 = Activator.CreateInstance<Person>();

            //使用Person类的Name属性对象，为p的Name属性赋值
            PropertyInfo prop = type.GetProperty("Name");
            prop.SetValue(p1, "toto");
            Console.WriteLine(p1.Name);

            //使用Person类的Sayhi方法对象，调用p1的Sayhi方法
            MethodInfo method = type.GetMethod("Sayhi");
            method.Invoke(p1, null);
            MethodInfo method1 = type.GetMethod("ShowNumber");
            object[] arrParams = { 2 };
            method1.Invoke(p1, arrParams);
            MethodInfo method2 = type.GetMethod("GetString");
            String retStr = method2.Invoke(p1, null).ToString();
            Console.WriteLine(retStr);
        }

        public void Sayhi()
        {
            Console.WriteLine("Hiiiiii");
        }

        public void ShowNumber(int no)
        {
            Console.WriteLine(no);
        }

        public String GetString()
        {
            return "Hello";
        }

    }
}
