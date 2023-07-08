using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Class8
{
    internal class Program
    {
        static void Main()
        {
            List<int> lst = new();
            ArrayList arlst = new();
            LinkedList<int> llist = new();
            AddMet(lst,1000000);
            Console.WriteLine(new string('-', 60));
            AddMet(arlst, 1000000);
            Console.WriteLine(new string('-', 60));
            AddMet(llist, 1000000);
            Console.WriteLine(new string('=', 60));
            GetElement(lst, 496753);
            Console.WriteLine(new string('-', 60));
            GetElement(arlst, 496753);
            Console.WriteLine(new string('-', 60));
            GetElement(llist, 496753);
            Console.WriteLine(new string('=', 60));
            DivdMet(lst, 777);
            Console.WriteLine(new string('-', 60));
            DivdMet(arlst, 777);
            Console.WriteLine(new string('-', 60));
            DivdMet(llist, 777);
            Console.ReadLine();
        }

        #region метод добавления элементов в коллекцию
        /// <summary>
        /// Метод принимает коллекцию и добавляет заданное колиество элементов в неё
        /// </summary>
        /// <param name="collection">коллекция</param>
        /// <param name="amount">количество добавляемых элементов</param>
        static void AddMet(IEnumerable collection, int amount)
        {
            string s = collection.GetType().Name;
            string colstr = CollectionName(s);
            Console.WriteLine($"запоняем коллекцию " + colstr);
            if (collection is List<int> | collection is ArrayList)
            {
                IList? list=collection as IList;
                Stopwatch sw = Stopwatch.StartNew();
                for(int i=0; i<amount;i++)
                    list?.Add(i);
                sw.Stop();  
                Console.WriteLine($"на заполнение коллекции понадобилось {sw.ElapsedMilliseconds} миллисекуд");
            }
            if(collection is LinkedList<int>)
            {
                LinkedList<int>? ldlist = collection as LinkedList<int>;
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < 1000000; i++)
                    ldlist?.AddLast(i);
                sw.Stop();
                Console.WriteLine($"на заполнение коллекции понадобилось {sw.ElapsedMilliseconds} миллисекуд");
            }
        }
        #endregion

        #region Метод поиска заданного элемента коллекции
        /// <summary>
        /// Поиск элемента в коллекции
        /// </summary>
        /// <param name="collection">коллекция</param>
        /// <param name="e">элемент, который нужно найти</param>
        static void GetElement(IEnumerable collection, int e)
        {
            string s = collection.GetType().Name;
            string colstr = CollectionName(s);
            Console.WriteLine($"ищем элемент {e} в коллекции {colstr}");
            if (collection is List<int> | collection is ArrayList)
            {
                IList? list = collection as IList;
                Stopwatch sw = Stopwatch.StartNew();
                list?.IndexOf(e);
                sw.Stop();
                Console.WriteLine($"на поиск элемента {e} понадобилось {sw.ElapsedMilliseconds} миллисекуд");
            }
            if (collection is LinkedList<int>)
            {
                LinkedList<int>? ldlist = collection as LinkedList<int>;
                Stopwatch sw = Stopwatch.StartNew();
                ldlist?.Find(e);
                sw.Stop();
                Console.WriteLine($"на поиск элемента {e} понадобилось {sw.ElapsedMilliseconds} миллисекуд");
            }
        }
        #endregion

        #region Вывод множителей коллекции
        /// <summary>
        /// Вывод множителей коллекции
        /// </summary>
        /// <param name="collection">коллекция</param>
        /// <param name="div">множитель</param>
        static void DivdMet(IEnumerable collection,int div)
        {
            string s = collection.GetType().Name;
            string colstr = CollectionName(s);
            Console.WriteLine($"выводим кол-во элементов коллекции {colstr}, которые делятся на {div} без остатка");
            Stopwatch sw = Stopwatch.StartNew();
            foreach(int i in collection)
            {
                if(i%div==0)
                    Console.Write(i+", ");
            }
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine($"на вывод множителей {div} коллекции {colstr} понадобилось {sw.ElapsedMilliseconds} миллисекуд");
        }
        #endregion

        #region тип коллекции
        /// <summary>
        /// Возвращает тип коллекции
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        static string CollectionName(string collection)
        {
            Regex reglist = new Regex(@"^List`1");
            Regex regarlist = new Regex(@"\w*ArrayList\w*");
            Regex regldlist = new Regex(@"^LinkedList`1");
            if (reglist.IsMatch(collection))
                return "List<int>";
            else if (regarlist.IsMatch(collection))
                return "ArrayList";
            else if (regldlist.IsMatch(collection))
                return "LinkedList<int>";
            else return collection;
        }
        #endregion
    }
}