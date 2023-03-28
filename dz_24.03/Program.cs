using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_24._03
{
    public interface IItem
    {
        int GetCost();
        void Print();
    }

    public class Leaf : IItem
    {
        private string Name;
        private int Cost;
        public Leaf(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
        public void Print()
        {
            Console.WriteLine(Name);
        }
        public int GetCost()
        {
            return Cost;
        }
    }

    public class Composite : IItem
    {
        private string Name;
        private int Cost;
        private List<IItem> Items = new List<IItem>();

        public Composite(string name)
        {
            Name = name;
        }

        public void Add(IItem Leaf)
        {
            Items.Add(Leaf);
        }

        public int GetCost()
        {
            int total = 0;
            foreach (var item in Items)
                total += item.GetCost();
            return total;
        }

        public void Print()
        {
            Console.WriteLine(Name);
            foreach (var item in Items)
                item.Print();
        }
    }
    public class Client
    {
        public static Composite Build()
        {
            var root = new Composite("Офис");
            var reception = new Composite("Приемная");
            reception.Add(new Leaf("Должна быть выполнена в теплых тонах", 100));
            var table = new Composite("Журнальный столик");
            table.Add(new Leaf("10-20 журналов типа «компьютерный мир»", 25));
            reception.Add(table);
            reception.Add(new Leaf("Мягкий диван", 300));
            reception.Add(new Leaf("Стол секретаря", 150));
            var computer = new Composite("Компьютер");
            computer.Add(new Leaf("Важно наличие большого объема жесткого диска", 500));
            computer.Add(new Leaf("Офисный инструментарий", 300));
            reception.Add(computer);
            reception.Add(new Leaf("Кулер с теплой и холодной водой", 100));
            root.Add(reception);
            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var room = Client.Build();
            room.Print();
            Console.WriteLine();
            Console.WriteLine($"Общая стоимость: {room.GetCost()} $");
        }
    }
}
