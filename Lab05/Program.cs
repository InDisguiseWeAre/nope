using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Таблица многочленов */
            
            Console.WriteLine("Введите степень, до которой будет построена таблица неприводимых многочленов:");
            int exp = int.Parse(Console.ReadLine());

            List<ZTwo> p = new List<ZTwo>()
            {
                ZTwo.ParseFromBits("10"),
                ZTwo.ParseFromBits("11")
            };

            UInt64 maxValue = Convert.ToUInt64(String.Empty.PadLeft(exp + 1, '1'), 2);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (UInt64 i = 5; i <= maxValue; i++)
            {
                if (i % 2 == 0) { continue; };

                bool simpleNum = true;

                foreach (ZTwo z in p)
                {
                    if (ZTwo.mod(i, z.Value) == 0)
                    {
                        simpleNum = false;
                        break;
                    }
                }

                if (simpleNum)
                {
                    p.Add(new ZTwo() { Value = i });
                }
            }

            sw.Stop();

            Console.WriteLine("Таблица неприводимых многочленов до степени {0} включительно:", exp);

            foreach (ZTwo z in p)
            {
                Console.WriteLine("{0} : {1}", z.ToString(), z.Value);
            }

            /* Обратный элемент */
            /*
            Console.WriteLine("\n\nВведите многочлен X:");
            ZTwo x = new ZTwo() { Value = Convert.ToUInt64(Console.ReadLine(), 2) };

            Console.WriteLine("Введите многочлен MOD:");
            ZTwo mod = new ZTwo() { Value = Convert.ToUInt64(Console.ReadLine(), 16) };

            if (p.Contains(mod))
            {
                Console.WriteLine("Обратный многочлен не найти, если MOD не является неприводимым.");
                Console.ReadLine();
                return;
            }

            ZTwo y = new ZTwo() { Value = 1 };

            while (ZTwo.mod((x * y).Value, mod.Value) != 1)
            {
                Console.WriteLine("{0} * {1} mod {2} = {3}", x, y, mod,
                    new ZTwo() { Value = ZTwo.mod((x * y).Value, mod.Value) });

                y.Value += 1;
            }

            Console.WriteLine("Обратный элемент для {0} по модулю {1}:\n{2}", x, mod, y);

            Console.WriteLine("{0} * {1} mod {2} = {3}", x, y, mod,
                new ZTwo() { Value = ZTwo.mod((x * y).Value, mod.Value) });

            */
            Console.WriteLine("Время выполнения {0}", sw.Elapsed);

            Console.ReadLine();
        }
    }
}
