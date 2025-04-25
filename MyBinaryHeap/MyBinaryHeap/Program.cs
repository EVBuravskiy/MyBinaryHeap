using MyBinaryHeap.Models;
using System.Diagnostics;

namespace MyBinaryHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            var rnd = new Random();
            var startItems = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                startItems.Add(rnd.Next(-10, 10));
            }

            timer.Start();
            SimpleListBinaryHeap<int> simpleHeap = new SimpleListBinaryHeap<int>(startItems);
            timer.Stop();
            Console.WriteLine("Первоначальная инициализация " + timer.Elapsed.ToString());

            timer.Restart();
            for (int i = 0; i < 10; i++)
            {
                simpleHeap.Push(rnd.Next(-10, 10));
            }
            timer.Stop();
            Console.WriteLine("Добавление элементов " + timer.Elapsed.ToString());

            timer.Restart();
            foreach (var item in simpleHeap)
            {
                Console.WriteLine(item);
            }
            timer.Stop();
            Console.WriteLine("Вывод элементов " + timer.Elapsed.ToString());
        }
    }
}