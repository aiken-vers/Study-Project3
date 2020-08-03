using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Knn_class
{
    public class Dot
    {
        public List<double> prms;    // список параметров
        public string name;         // имя объекта (для отображения в списке элементов)
        public string class_name;  // имя класса объекта
        public string clr_name;  // цвет класса (для 2D и консоли)
        public double mean;     // значение, относительно которого будет осуществляться сортировка объектов
        public double expectation;
        private static Random rnd; // статичный рандомизатор, используемый классом

        public Dot(List<double> Prms, string Cls_name = "none", string Clr = "DimGray")
        {
            prms = Prms;
            class_name = Cls_name;
            clr_name = Clr;
            mean = 0;
            expectation = 0;
        }
        public override string ToString()
        {
            //return this.name+"{"+this.prms_list()+"} " +": "+mean;
            return this.name + "{" + this.prms_list() + "} " + ": " + expectation * 100 + "%";
        }
        public string prms_list(int n = 2) // возвращение списка параметров объекта в виде строки, по-умолчанию ограничено двумя
        {
            StringBuilder sb = new StringBuilder();
            if (this.prms.Count < n)
                n = this.prms.Count;
            if (this.prms.Count > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    sb.Append(this.prms[i].ToString() + ';');
                }
                if (sb.ToString().EndsWith(";"))
                    sb = sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
            return null;
        }
        public double Evklid(Dot d2) // вычисление расстояния от текущего объекта до указанного
        {
            double s = 0;
            int i = 0;
            foreach (double a in this.prms)
            {
                s += Math.Pow(this.prms[i] - d2.prms[i], 2);
                i++;
            }
            return Math.Sqrt(s);
        }
        public static double Evklid(Dot d1, Dot d2) // вычисление расстояния между двумя объектами
        {
            double s = 0;
            int i = 0;
            foreach (double a in d1.prms)
            {
                s += Math.Pow(d1.prms[i] - d2.prms[i], 2);
                i++;
            }
            return Math.Sqrt(s);
        }
        public static double average_predict(List<Dot> Dots)
        {
            double pred=0;
            int sum=0;
            foreach(Dot d in Dots)
            {
                pred += d.expectation;
                if (d.expectation > 0)
                    sum++;
            }
            return pred / sum;            
        }
        public static List<double> get_center(List<Dot> Dots) //генерация параметров центра из заданного списка элементов
        {
            Dot center = new Dot(new List<double>());

            foreach (Dot d in Dots)
            {
                if (center.prms.Count() < d.prms.Count())
                    center.prms.AddRange(new double[d.prms.Count()]);
                for (int i = 0; i < d.prms.Count(); i++)
                {
                    center.prms[i] += d.prms[i];
                }
            }
            for (int i = 0; i < center.prms.Count(); i++)
            {
                center.prms[i] = center.prms[i] / Dots.Count();
            }
            return center.prms;
        }        
        public static void Generate(List<Dot> Dots, int prms, int klasters, int kelements, double max_prm, string class_name="none", double distance=3)
        {
            rnd = new Random();
            double r;
            int number = 1;
            string name;
            double radius = Math.Log(kelements, Math.Sqrt(Math.Sqrt(max_prm))) / 10; // максимальное расстояние, на котором могут находиться элементы одного кластера
            List<Dot> temp = new List<Dot>();
            List<Dot> cents = new List<Dot>();

            for (int k=0;k<klasters;k++)
            {
                temp.Clear(); // временный список, хранящий элементы текущего кластера
                List<double> center = new List<double>(); // для каждого кластера сначала генерируется его центр
                if (k > 0 &&distance>0)
                {
                    int steps = 0;
                    Dot cent = new Dot(center);

                    while (steps<cents.Count())
                    {
                        steps = 0;
                        center.Clear();
                        for (int p = 0; p < prms; p++)
                        {
                            r = rnd.NextDouble() * max_prm; // запись случайных параметров в центр
                            center.Add(r);
                        }
                        cent.prms=center;
                        foreach (Dot c in cents)
                            if (cent.Evklid(c) > (radius*distance))
                                steps++;
                    }     
                    cents.Add(cent);
                }
                else 
                {
                    for (int p = 0; p < prms; p++)
                    {
                        r = rnd.NextDouble() * max_prm; // запись случайных параметров в центр
                        center.Add(r);
                    }
                    Dot cent = new Dot(center);
                    cents.Add(cent);
                }

                name = "P" + number; number++;
                Dot rand = new Dot(center, name); // создание первого элемента с параметрами центра кластера
                rand.class_name = class_name;
                temp.Add(rand);
                for (int i = 1; i < kelements; i++)
                {
                    center = get_center(temp); // пересчёт центра кластера в начале цикла
                    List<double> p_prms = new List<double>();
                    double prm = 0;
                    foreach(double c_prm in center) // число параметров для новых элементов наследуется от центра
                    {
                        if (rnd.Next(0, 1) < 1) // увеличение/уменьшение параметра на случайную величину
                            prm = Math.Abs(c_prm - max_prm * (radius * rnd.NextDouble()))%max_prm;
                        else
                            prm = Math.Abs(c_prm + max_prm * (radius * rnd.NextDouble()))% max_prm;

                        p_prms.Add(prm);
                    }
                    name = "P" + number; number++;
                    Dot rad = new Dot(p_prms, name);
                    rad.class_name = class_name;
                    temp.Add(rad);
                }
                Dots.AddRange(temp);
            }
        }
        public static void knn(List<Dot> Dots, int k, int cycles=10) // классификация всех элементов списка по числу соседей
        {
            List<Dot> nones = new List<Dot>(); // список бесклассовых объектов
            foreach (Dot d in Dots)
                if (d.class_name == "none")
                    nones.Add(d);
            cycles = cycles * nones.Count(); // ограничение количества циклов 10*число бесклассовых элементов
            rnd = new Random();
            int r;
            while(nones.Any()&&cycles>0) // пока список содержит элементы и остались циклы
            {
                r = rnd.Next(nones.Count-1); // выбор случайного объекта из списка бесклассовых объектов
                foreach (Dot d in Dots)
                    d.mean = d.Evklid(nones[r]);
                Dots = Dots.OrderBy(d => d.class_name == "none").ThenBy(d => d.mean).ToList();
                Dot[] neighbours = new Dot[k];
                for (int i = 0; i < k; i++)
                    neighbours[i] = Dots[i];
                knn(nones[r], neighbours);
                if (nones[r].class_name != "none")
                    nones.RemoveAt(r);

                cycles--;
            } 
        }
        public Dot[] get_neighbours(List<Dot> Dots, int k) // получаем массив соседей текущего объекта
        {
            Dot[] neighbours = new Dot[k]; // массив соседей
            List<Dot> temp_Dots = Dots;   // копия списка объектов, с которой будет производиться операция сортировки
            foreach (Dot d in temp_Dots)
                d.mean = d.Evklid(this); // для каждого объекта списка вычисляется расстояние до текущего объекта...
                                         // ...и сохраняется в поле mean

            // сортировка списка по значению поля mean и имени класса
            // все безклассовые объекты, включая текущий, остаются в конце списка
            temp_Dots = temp_Dots.OrderBy(d => d.class_name == "none").ThenBy(d => d.mean).ToList(); 
            for (int i = 0; i < k; i++)
                neighbours[i] = Dots[i];
            return neighbours;
        }
        public static void knn(Dot none, Dot[] neighbours) // определение класса объекта none по числу соседей
        {            
            var temp_classes = from n in neighbours
                          select n.class_name;            
            string[] classes = temp_classes.ToArray(); // текстовый массив классов
            classes = classes.Distinct().ToArray();
            int[] votes = new int[classes.Length]; // целочисленный массив голосов 
            double all_votes = 0;

            for (int i=0; i< classes.Length; i++)
            {
                foreach (Dot d in neighbours)
                {
                    if (classes[i] == d.class_name && d.class_name != "none")
                        votes[i]++;
                    all_votes++;
                }
                // соседи "голосуют" за свои классы
               // голоса бесклассовых элементов не учитываются
            }
            int max = votes.Max(); // выбирается максимальный элемент
            int index = votes.ToList().IndexOf(max); // индекс максимального элемента в массиве
            // проверяем, есть ли в массиве другие элементы, равные максимальному
            int max_sum = votes.ToList().FindAll(item=>item==max).Count();
            if (max_sum == 1)
            {
                none.class_name = classes[index];
                none.expectation = (double)max/(double)all_votes;
                none.expectation = Math.Round(none.expectation, 4);
            }
            else if (max_sum > 1)
            {
                //string log = "";
            }
            else if (max_sum == 0)
            {
                //string log = "";
            }
        }
        /*
         ВЗВЕШЕННЫЙ KNN
        */
        public static void knn(List<Dot> Dots, int k, double weight, int cycles=10) // классификация всех элементов списка по числу соседей
        {
            List<Dot> nones = new List<Dot>(); // список бесклассовых объектов
            foreach (Dot d in Dots)
                if (d.class_name == "none")
                    nones.Add(d);
            cycles = cycles * nones.Count(); // ограничение количества циклов 10*число бесклассовых элементов
            rnd = new Random();
            int r;
            while (nones.Any() && cycles > 0) // пока список содержит элементы и остались циклы
            {
                r = rnd.Next(nones.Count - 1); // выбор случайного объекта из списка бесклассовых объектов
                foreach (Dot d in Dots)
                    d.mean = d.Evklid(nones[r]);
                Dots = Dots.OrderBy(d => d.class_name == "none").ThenBy(d => d.mean).ToList();
                Dot[] neighbours = new Dot[k];
                for (int i = 0; i < k; i++)
                    neighbours[i] = Dots[i];
                knn(nones[r], neighbours, weight);
                if (nones[r].class_name != "none")
                    nones.RemoveAt(r);

                cycles--;
            }
        }
        public static void knn(Dot none, Dot[] neighbours, double weight) // определение класса объекта none по "весу" соседей
        {
            var temp_classes = from n in neighbours
                               select n.class_name;
            string[] classes = temp_classes.ToArray(); // текстовый массив классов
            classes = classes.Distinct().ToArray();
            double[] votes = new double[classes.Length]; // массив голосов  
            double all_votes = 0;

            for (int i = 0; i < classes.Length; i++)
            {
                // соседи "голосуют" за свои классы
                // голоса бесклассовых элементов не учитываются
                foreach (Dot d in neighbours)
                {
                    if (classes[i] == d.class_name && d.class_name != "none")
                        votes[i] += weight / d.mean;
                    all_votes += weight / d.mean;
                }
            }
            double max = votes.Max(); // выбирается максимальный элемент
            int index = votes.ToList().IndexOf(max); // индекс максимального элемента в массиве
            // проверяем, есть ли в массиве другие элементы, равные максимальному
            int max_sum = votes.ToList().FindAll(item => item == max).Count();
            if (max_sum == 1)
            {
                none.class_name = classes[index];
                none.expectation = (double)max / (double)all_votes;
                none.expectation = Math.Round(none.expectation, 4);
            }
            else if (max_sum > 1)
            {
                //string log = "";
            }
            else if (max_sum == 0)
            {
                //string log = "";
            }
        }
        /*
         * ЦЕНТРИРОВАННЫЙ KNN
         */        
        public static void knn(List<Dot> Dots, List<Glass> classes, int cycles = 10) // классификация всех элементов списка по близости к центрам
        {
            if (classes.Count > 1)
            {
                List<Dot> nones = new List<Dot>();  // список бесклассовых объектов
                List<Dot> cents = new List<Dot>(); // список центров
                foreach (Glass gls in classes)    // копируем список бесклассовых элементов в nones'ы
                {
                    if (gls.name == "none")
                        nones = gls.Dots;
                }               
                cycles = cycles * nones.Count(); // ограничение количества циклов cycles*число бесклассовых элементов
                rnd = new Random();
                int r;
                
                while (nones.Any() && cycles > 0) // пока список содержит элементы и остались циклы
                {
                    cents.Clear();                   // в начале цикла очищаем список центров
                    foreach (Glass gls in classes)  // и заполянем заново
                    {
                        if(gls.name!="none"&&gls.Count()>0)      // центры пустых классов и класса none не учитываются
                            cents.Add(gls.get_center());
                    }
                    r = rnd.Next(nones.Count - 1);   // выбор случайного элемента из списка бесклассовых
                    for (int i = 0; i < cents.Count; i++)
                    {
                        cents[i].mean = cents[i].Evklid(nones[r]);  // записываем в mean расстояние до центра класса                        
                    }
                    if (cents.Count > 0)  // если в списке есть хотя бы 1 центр класса
                    {
                        cents = cents.OrderBy(c => c.mean).ToList();      // сортируем центры по значению mean
                        if (cents[0].class_name != "none")               // ещё раз проверяем класс первого центра в списке
                        {
                            nones[r].class_name = cents[0].class_name;  // присваиваем нашему элементу имя этого класса
                        } 
                        foreach (Glass gls in classes)
                        {
                            if (gls.name == nones[r].class_name)
                                gls.Add(nones[r]);      // добавляем элемент в его новый класс                                
                        }
                    }
                    if (nones[r].class_name != "none")
                        nones.RemoveAt(r);      // удаляем элемент из списка бесклассовых

                    cycles--;
                }
            }
        }
        // классификация всех элементов списка по близости к центрам классов и количеству элементов в классах
        public static void knn(List<Dot> Dots, List<Glass> classes, double weight, int cycles = 10) 
        {
            if (classes.Count > 1)
            {
                List<Dot> nones = new List<Dot>();   // список бесклассовых объектов
                List<Dot> cents = new List<Dot>();  // список центров классов
                foreach (Glass gls in classes)     // копируем список бесклассовых элементов в nones'ы
                {
                    if (gls.name == "none")
                        nones = gls.Dots;
                }
                cycles = cycles * nones.Count(); // ограничение количества циклов 10*число бесклассовых элементов
                rnd = new Random();
                int r;               
                while (nones.Any() && cycles > 0) // пока список содержит элементы и остались циклы
                {
                    double all_cents = 0;
                    cents.Clear();                   // в начале цикла очищаем список центров
                    foreach (Glass gls in classes)  // и заполянем заново
                    {
                        if (gls.name != "none" && gls.Count() > 0)   // центры пустых классов и класса none не учитываются
                        {
                            Dot cent = gls.get_center();  // находим центр класса
                            cent.mean = gls.Count();     // сохраняем в mean число элементов в классе
                            cents.Add(cent);
                        }
                    }
                    r = rnd.Next(nones.Count - 1);  // выбор случайного объекта из списка бесклассовых объектов
                    for (int i = 0; i < cents.Count; i++)
                    {
                        cents[i].mean = cents[i].mean/ cents[i].Evklid(nones[r]); // записываем в mean число элементов класса/расстояние до центра класса                        
                        all_cents += cents[i].mean;
                    }
                    if (cents.Count > 0) // если в списке есть хотя бы 1 центр класса
                    {
                        cents = cents.OrderByDescending(c => c.mean).ToList();     // сортируем центры по значению mean
                        if (cents[0].class_name != "none")              // ещё раз проверяем класс первого центра в списке
                        {
                            nones[r].class_name = cents[0].class_name; // присваиваем нашему элементу имя этого класса
                            nones[r].expectation = (double)cents[0].mean / (double)all_cents;
                            //double cmean = cents[0].mean;
                            //double amean = all_cents;
                            //nones[r].expectation = cmean/amean;
                            nones[r].expectation = Math.Round(nones[r].expectation, 4);
                        }
                        foreach (Glass gls in classes)
                        {
                            if (gls.name == nones[r].class_name)
                                gls.Add(nones[r]); // добавляем элемент в его новый класс
                        }
                    }
                    if (nones[r].class_name != "none")
                        nones.RemoveAt(r); // удаляем элемент из списка бесклассовых

                    cycles--;
                }
            }
        }
        //
        // КЛАСТЕРИЗАЦИЯ
        //
        public static void kmeans(List<Dot> Dots, List<Dot> cents)
        {
            List<Dot> old_cents = new List<Dot>();
            int count = 0;
            int same_prms = 0;
            int same = 0;
            while (true)
            {
                old_cents.Clear();
                old_cents.AddRange(cents);

                foreach (Dot d in Dots)
                {
                    for (int i = 0; i < cents.Count; i++)
                    {
                        cents[i].mean = cents[i].Evklid(d);  // записываем в mean расстояние до центра класса                        
                    }
                    cents = cents.OrderBy(c => c.mean).ToList();      // сортируем центры по значению mean
                    if (cents[0].class_name != "none")               // ещё раз проверяем класс первого центра в списке
                    {
                        d.class_name = cents[0].class_name;  // присваиваем нашему элементу имя этого класса
                    }  
                }
                for(int i=0;i<cents.Count;i++)
                {
                    if(Dots.Where(d => d.class_name == cents[i].class_name).ToList().Count>0) // если в классе с данным центром есть элементы
                        cents[i].prms = get_center(Dots.Where(d=>d.class_name == cents[i].class_name).ToList()); // центр перевычисляется
                }
                cents = cents.OrderBy(c => c.class_name).ToList();
                old_cents = old_cents.OrderBy(c => c.class_name).ToList();
                for(int i=0; i < cents.Count; i++)
                {
                    if (cents[i].prms.ToArray().SequenceEqual(old_cents[i].prms.ToArray())) // сравнение параметров старых и новых центров
                        same_prms++;
                }
                               
                if (same_prms == cents.Count) // кол-во совпадений между центрами == кол-во центров
                    same++;
                else
                    same = 0; // если центры различаются, same обнуляется
                if (same > 5) // если центры совпадают 5 циклов подряд
                    break;
                if (count > 50000) // выход из цикла при достижении 50000 итераций
                    break;
                count++;
                same_prms = 0;
            }
        }
        public static void kmeans_debug(List<Dot> Dots, List<Dot> cents)
        {
            Dot[] old_cents = cents.ToArray();
            foreach (Dot d in Dots)
            {
                for (int i = 0; i < cents.Count; i++)
                {
                    cents[i].mean = cents[i].Evklid(d);  // записываем в mean расстояние до центра класса                        
                }
                cents = cents.OrderBy(c => c.mean).ToList();      // сортируем центры по значению mean
                if (cents[0].class_name != "none")               // ещё раз проверяем класс первого центра в списке
                {
                    d.class_name = cents[0].class_name;  // присваиваем нашему элементу имя этого класса
                }
            }
            for (int i = 0; i < cents.Count; i++)
            {
                if (Dots.Where(d => d.class_name == cents[i].class_name).ToList().Count > 0)
                    cents[i].prms = get_center(Dots.Where(d => d.class_name == cents[i].class_name).ToList());
            }
        }
    }
    public class Glass
    {
        public string name;
        public System.Drawing.Color clr;
        public string clr_name;
        public List<Dot> Dots;
        static Color default_color=Color.FromKnownColor(KnownColor.DimGray);

        public Glass(string Name, string Colorname)
        {
            name = Name;
            clr_name = Colorname;
            this.Dots = new List<Dot>();
        }
        public Dot get_center()
        {
            Dot center = new Dot(new List<double>(), this.name, this.clr_name);

            foreach (Dot d in this.Dots)
            {
                if (center.prms.Count() < d.prms.Count())
                    center.prms.AddRange(new double[d.prms.Count()]);
                for (int i = 0; i < d.prms.Count(); i++)
                {
                    center.prms[i] += d.prms[i];
                }
            }
            for (int i = 0; i < center.prms.Count(); i++)
            {
                center.prms[i] = center.prms[i] / this.Count();
            }
            return center;
        }
        public int Count()
        {
            return this.Dots.Count();
        }
        public void Add(Dot dot)
        {
            Dots.Add(dot);
            dot.clr_name = this.clr_name;
            dot.class_name = this.name;
        }
        public void Remove(Dot d)
        {
            Dots.Remove(d);
        }
        public void RemoveAll()
        {
            Dots.Clear();
        }
        public override string ToString()
        {
            return this.name +"("+this.Dots.Count+")";
        }
    }
}
