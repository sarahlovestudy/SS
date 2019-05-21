using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public interface ITimeProvider
    {
        DateTime CurrentDate { get; }
    }
    public class SystemTimeProvider : ITimeProvider
    {
        public DateTime CurrentDate { get { return DateTime.Now; } }
    }
    public class UtcNowTimeProvider:ITimeProvider
    {
        public DateTime CurrentDate { get { return DateTime.UtcNow; } }
    }
    public class Assembler
    {
        /// <summary>
        /// 保存“类型名称-实体类型”
        /// </summary>
        private static Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
        static Assembler()
        {
            dictionary.Add("SystemTimeProvider", typeof(SystemTimeProvider));
            dictionary.Add("UtcTimeProvider", typeof(UtcNowTimeProvider));
        }
        static void RegisterType(string name,Type type)
        {
            if (type == null || dictionary.ContainsKey(name))
                throw new NullReferenceException();
            dictionary.Add(name, type); 
        }
        static void Remove(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new NullReferenceException();
            dictionary.Remove(name);
        }
        /// <summary>
        /// 根据程序需要的类型名称选择相应的实体类型，并返回类型实例
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ITimeProvider Create(string type)
        {
            if (type == null || !dictionary.ContainsKey(type)) throw new NullReferenceException();
            Type targetType = dictionary[type];
            return (ITimeProvider)Activator.CreateInstance(targetType);
        }
        //在构造函数中注入
        class Client
        {
            private ITimeProvider timeProvider;
            public ITimeProvider TimeProvider
            {
                get => this.timeProvider;
                set { this.timeProvider = value; }
            }
            //public Client(ITimeProvider timeProvider)
            //{
            //    this.timeProvider = timeProvider;
            //}            
        }
        class ConstructorInjectionTest
        {
            public static void Test()
            {
                ITimeProvider timeProvider = (new Assembler()).Create("SystemTimeProvider");
                // Client client = new Client(timeProvider);//在构造函数中注入
                Client client = new Client();
                client.TimeProvider = timeProvider;
            }
        }
        //基于Attribute实现注入
        [AttributeUsage(AttributeTargets.Class,AllowMultiple =true)]
        sealed class DecoratorAttribute:Attribute
        {
            public readonly object Injector;
            private Type type;
            public DecoratorAttribute(Type type)
            {
                if (type == null) throw new NullReferenceException();
                this.type = type;
                Injector = (new Assembler()).Create("SystemTTimeProvider");
            }
            public Type Type { get { return type; } }

        }
        static class AttributeHelper
        {
            public static  T Injector<T>(object target) where T:class
            {
                if (target == null) throw new ArgumentNullException("target");
                Type targetType = target.GetType();
                object[] attributes = targetType.GetCustomAttributes(typeof(DecoratorAttribute),false);
                if ((attributes == null) || (attributes.Length <= 0)) return null;
                foreach(DecoratorAttribute attribute in (DecoratorAttribute[])attributes)
                {
                    if (attribute.Type == typeof(T))
                        return (T)attribute.Injector;
                }
                return null;
            }
        }
        [Decorator(typeof(ITimeProvider))]
        class Client2
        {
            public string GetTime()
            {
                ITimeProvider provider = AttributeHelper.Injector<ITimeProvider>(this);
                return provider.CurrentDate.ToString();
            }
        }
        class AttributeInjectionTest
        {            static void Main(string[] args)
            {
                Client2 client = new Client2();
                string time = client.GetTime();
            }
        }
    }
}
