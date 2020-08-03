using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knn_class
{
    /// <summary>
    /// Элемент класса/кластера, содержит метрику
    /// </summary>
    public class Dot
    {
        /// <summary>
        /// Список параметров объекта
        /// </summary>
        public List<double> prms;    
        /// <summary>
        /// Имя объекта (для отображения в списке элементов)
        /// </summary>
        public string name; 
        /// <summary>
        /// Имя класса объекта
        /// </summary>
        public string class_name;
        /// <summary>
        /// Цвет объекта (для 2D и консоли)
        /// </summary>
        public string clr_name;
        /// <summary>
        /// поле для хранения различных числовых значений, используемых для сортировки списка объектов
        /// </summary>
        public double mean;    
        /// <summary>
        /// Вероятность отношения объекта к его текущему классу
        /// </summary>
        public double expectation;
        private static Random rnd; // статичный рандомизатор, используемый внутри класса
        
        public Dot(List<double> Prms, string Cls_name = "none", string Clr = "DimGray")
        {
            prms = Prms;
            class_name = Cls_name;
            clr_name = Clr;
            mean = 0;
            expectation = 0;
        }
        /// <summary>
        /// Возвращает строку вида Имя_объекта{параметры}: вероятность%
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.name + "{" + this.prms_list() + "} " + ": " + expectation * 100 + "%";
        }
        /// <summary>
        /// возвращение списка параметров объекта в виде строки, по-умолчанию ограничено двумя
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string prms_list(int n = 2) 
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
        /// <summary>
        /// Получение массива соседей данного элемента
        /// </summary>
        /// <param name="Dots"></param>
        /// <param name="k"></param>
        /// <param name="metric"></param>
        /// <returns></returns>
        public Dot[] get_neighbours(List<Dot> Dots, int k, Metric metric)
        {
            Dot[] neighbours = new Dot[k]; // массив соседей
            List<Dot> temp_Dots = Dots;   // копия списка объектов, с которой будет производиться операция сортировки
            foreach (Dot d in temp_Dots)
                d.mean = metric.Distance(d, this); // для каждого объекта списка вычисляется расстояние до текущего объекта...
                                         // ...и сохраняется в поле mean

            // сортировка списка по значению поля mean и имени класса
            // все безклассовые объекты, включая текущий, остаются в конце списка
            temp_Dots = temp_Dots.OrderBy(d => d.class_name == "none").ThenBy(d => d.mean).ToList();
            for (int i = 0; i < k; i++)
                neighbours[i] = Dots[i];
            return neighbours;
        }        
        /// <summary>
        /// Абстрактный класс метрики
        /// </summary>
        public abstract class Metric
        {
            public abstract string type { get; }
            /// <summary>
            /// Расстояние между двумя объектами типа Dot
            /// </summary>
            /// <param name="d1">Объект типа Dot с n параметров</param>
            /// <param name="d2">Объект типа Dot с n параметров</param>
            /// <returns>Расстояние между двумя объектами с плавающей точкой</returns>
            public abstract double Distance(Dot d1, Dot d2);
        }
        /// <summary>
        /// Евклидово расстояние
        /// </summary>
        public class Evklid : Metric
        {
            public override string type 
            {
                get
                {
                    return "Евклидово расстояние";
                }
            }
            public override double Distance(Dot d1, Dot d2)
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
        }
        /// <summary>
        /// Квадрат евклидова расстояния
        /// </summary>
        public class Evklidx2 : Metric
        {
            public override string type 
            {
                get
                {
                    return "Квадрат евклидова расстояния"; 
                }
            }
            public override double Distance(Dot d1, Dot d2)
            {
                double s = 0;
                int i = 0;
                foreach (double a in d1.prms)
                {
                    s += Math.Pow(d1.prms[i] - d2.prms[i], 2);
                    i++;
                }
                return Math.Abs(s);
            }
         }
        /// <summary>
        /// Манхэттенское расстояние
        /// </summary>
        protected internal class Manhattan : Metric
        {
            public override string type 
            {
                get
                {
                    return "Манхэттенское расстояние"; 
                }
            }
            public override double Distance(Dot d1, Dot d2)
            {
                double s = 0;
                int i = 0;
                foreach (double a in d1.prms)
                {
                    s += Math.Abs(d1.prms[i] - d2.prms[i]);
                    i++;
                }
                return s;
            }
        }
        /// <summary>
        /// Расстояние Чебышева
        /// </summary>
        public class Chebyshev : Metric
        {
            public override string type 
            {
                get
                {
                    return "Расстояние Чебышева"; 
                }
            }
            public override double Distance(Dot d1, Dot d2)
            {
                List<double> Diff = new List<double>();
                double s = 0;
                int i = 0;
                foreach (double a in d1.prms)
                {
                    s = Math.Abs(d1.prms[i] - d2.prms[i]);
                    Diff.Add(s);
                    i++;
                }
                return Diff.Max();
            }
        }
        /// <summary>
        /// Расстояние Хэмминга
        /// </summary>
        public class Hamming : Metric
        {
            public override string type 
            {
                get
                {
                    return "Расстояние Хэмминга"; 
                }
            }
            public override double Distance(Dot d1, Dot d2)
            {
                double s = 0;
                int i = 0;
                try // если параметры элементов представляют собой строковые символы
                {
                    List<char> s1 = new List<char>();
                    List<char> s2 = new List<char>();
                    foreach (double p in d1.prms)
                        s1.Add((char)p);
                    foreach (double p in d2.prms)
                        s2.Add((char)p);
                    string p1 = new string(s1.ToArray());
                    string p2 = new string(s2.ToArray());

                    int shift = 0;
                    if (p1.Length == p2.Length)
                    {
                        foreach (char c in p1)
                        {
                            if (p1[shift] != p2[shift])
                                s++;
                            shift++;
                        }
                        i++;
                        s += p1.Length - p2.Length;
                    }
                    else if (p2.Length < p1.Length)
                    {
                        foreach (char c in p2)
                        {
                            if (p1[shift] != p2[shift])
                                s++;
                            shift++;
                        }
                        i++;
                        s += p1.Length - p2.Length;
                    }
                }
                catch
                {
                    foreach (double a in d1.prms)
                    {
                        string p1 = Convert.ToString(BitConverter.DoubleToInt64Bits(d1.prms[i]), 2);
                        string p2 = Convert.ToString(BitConverter.DoubleToInt64Bits(d2.prms[i]), 2);
                        //string p1 = Convert.ToString((int)d1.prms[i], 2).PadLeft(63, '0');
                        //string p2 = Convert.ToString((int)d2.prms[i], 2).PadLeft(63, '0');
                        int shift = 0;
                        if (p1.Length == p2.Length)
                        {
                            foreach (char c in p1)
                            {
                                if (p1[shift] != p2[shift])
                                    s++;
                                shift++;
                            }
                            i++;
                            s += p1.Length - p2.Length;
                        }
                        else if (p2.Length < p1.Length)
                        {
                            foreach (char c in p2)
                            {
                                if (p1[shift] != p2[shift])
                                    s++;
                                shift++;
                            }
                            i++;
                            s += p1.Length - p2.Length;
                        }
                    }
                }
                
                return s;
            }
        }
        /// <summary>
        /// Расстояние Левенштейна
        /// </summary>
        public class Levenshtein : Metric
        {
            public override string type 
            {
                get
                {
                    return "Расстояние Левенштейна"; 
                }
            }
            public override double Distance(Dot d1, Dot d2)
            {
                double s = 0;
                int indx = 0;
                try // если параметры элементов представляют собой строковые символы
                {
                    List<char> s1 = new List<char>();
                    List<char> s2 = new List<char>();
                    foreach (double p in d1.prms)
                        s1.Add((char)p);
                    foreach (double p in d2.prms)
                        s2.Add((char)p);
                    string p1 = new string(s1.ToArray());
                    string p2 = new string(s2.ToArray());

                    if (p1 == null) throw new ArgumentNullException("string1");
                    if (p2 == null) throw new ArgumentNullException("string2");
                    double diff;
                    double[,] m = new double[p1.Length + 1, p2.Length + 1];

                    for (int i = 0; i <= p1.Length; i++) { m[i, 0] = i; }
                    for (int j = 0; j <= p2.Length; j++) { m[0, j] = j; }
                    for (int i = 1; i <= p1.Length; i++)
                    {
                        for (int j = 1; j <= p2.Length; j++)
                        {
                            diff = (p1[i - 1] == p2[j - 1]) ? 0 : 1;

                            m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1,
                                                     m[i, j - 1] + 1),
                                                     m[i - 1, j - 1] + diff);
                        }
                    }
                    s += m[p1.Length, p2.Length];

                    indx++;

                }
                catch 
                {                    
                    foreach (double a in d1.prms)
                    {
                        string p1 = Convert.ToString(BitConverter.DoubleToInt64Bits(d1.prms[indx]), 2);
                        string p2 = Convert.ToString(BitConverter.DoubleToInt64Bits(d2.prms[indx]), 2);
                        //string p1 = Convert.ToString((int)d1.prms[i], 2).PadLeft(63, '0');
                        //string p2 = Convert.ToString((int)d2.prms[i], 2).PadLeft(63, '0');

                        if (p1 == null) throw new ArgumentNullException("string1");
                        if (p2 == null) throw new ArgumentNullException("string2");
                        double diff;
                        double[,] m = new double[p1.Length + 1, p2.Length + 1];

                        for (int i = 0; i <= p1.Length; i++) { m[i, 0] = i; }
                        for (int j = 0; j <= p2.Length; j++) { m[0, j] = j; }
                        for (int i = 1; i <= p1.Length; i++)
                        {
                            for (int j = 1; j <= p2.Length; j++)
                            {
                                diff = (p1[i - 1] == p2[j - 1]) ? 0 : 1;

                                m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1,
                                                         m[i, j - 1] + 1),
                                                         m[i - 1, j - 1] + diff);
                            }
                        }
                        s += m[p1.Length, p2.Length];

                        indx++;
                    }
                }                
                return s;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Класс для классов/кластеров элементов
    /// </summary>
    public class Klass
    {   
        /// <summary>
        /// Имя класса
        /// </summary>
        public string name;
        /// <summary>
        /// Цвет элементов класса
        /// </summary>
        public string clr_name;
        /// <summary>
        /// Список элементов класса
        /// </summary>
        public List<Dot> Dots;
        /// <summary>
        /// В WPGMA: число объединенных кластеров
        /// </summary>
        public double mean;
        private static Random rnd; // статичный рандомизатор, используемый внутри класса

        public Klass(string Name, string Colorname)
        {
            name = Name;
            clr_name = Colorname;
            this.Dots = new List<Dot>();
            mean = 1;
        }        
        /// <summary>
        /// Подсчет количества элементов класса
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return this.Dots.Count();
        }
        /// <summary>
        /// Добавить элемент в класс
        /// </summary>
        /// <param name="d"></param>
        public void Add(Dot d)
        {
            this.Dots.Add(d);
            d.clr_name = this.clr_name;
            d.class_name = this.name;
           
        }
        /// <summary>
        /// Исключить элемент из класса
        /// </summary>
        /// <param name="d"></param>
        public void Remove(Dot d)
        {
            Dots.Remove(d);
        }
        /// <summary>
        /// Очистить класс от элементов
        /// </summary>
        public void RemoveAll()
        {
            Dots.Clear();
        }
        /// <summary>
        /// Возвращает строку вида Имя_класса(число элементов)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.name + "(" + this.Dots.Count + ")";
        }
        /// <summary>
        /// Получение общего списка элементов всех классов
        /// </summary>
        /// <param name="kls"></param>
        /// <returns></returns>
        public static List<Dot> Kls_to_List(List<Klass> kls)
        {
            List<Dot> AllDots = new List<Dot>();
            foreach (Klass k in kls)
            {
                AllDots.AddRange(k.Dots);
            }
            return AllDots;
        }
        /// <summary>
        /// Обновление содержимого классов (элементы перераспределяются по своим классам)
        /// </summary>
        /// <param name="kls"></param>
        /// <param name="Dots"></param>        
        public static void RefreshAll(List<Klass> kls)
        {
            List<Dot> Dots = Kls_to_List(kls);
            foreach (Klass k in kls)
            {
                k.RemoveAll();
                foreach (Dot d in Dots)
                {
                    if (d.class_name == k.name)
                    {
                        k.Add(d);
                        if (d.clr_name != k.clr_name)
                            d.clr_name = k.clr_name;
                    }
                }
            }           
        }
        /// <summary>
        /// Метод чистки списка от пустых классов (класс none сохраняется в отдельный список)
        /// </summary>
        /// <param name="kls">Целевой список классов</param>
        /// <param name="trash">Список хранения пустого класса none</param>
        public static void Clear_empty(List<Klass> kls, List<Klass> trash)
        {
            List<Klass> full_kls = new List<Klass>();
            foreach (Klass k in kls)
                if (k.Dots.Count > 0)
                    full_kls.Add(k);             
                else if (k.Dots.Count < 1 && k.name == "none")
                {
                    trash.Add(k);
                }
            kls.Clear();
            kls.AddRange(full_kls);                    
        }
        /// <summary>
        /// Вычисляет среднее значение вероятности для списка объектов
        /// </summary>
        /// <param name="Dots"></param>
        /// <returns></returns>
        public static double average_predict(List<Dot> Dots)
        {
            double pred = 0;
            int sum = 0;
            foreach (Dot d in Dots)
            {
                pred += d.expectation;
                if (d.expectation > 0)
                    sum++;
            }
            return pred / sum;
        }
        /// <summary>
        /// Создаёт резервную копию текущего списка элементов (для отката изменений)
        /// </summary>
        /// <param name="from">Откуда</param>
        /// <param name="to">Куда</param>
        public static void CopyDots(List<Dot> from, List<Dot> to)
        {
            to.Clear();
            foreach (Dot d in from)
            {
                Dot d2 = new Dot(d.prms);
                d2.name = d.name;
                d2.mean = d.mean;
                d2.class_name = d.class_name;
                d2.clr_name = d.clr_name;
                to.Add(d2);
            }
        }
        /// <summary>
        /// Копирует список элементов одного класса в другой
        /// </summary>
        /// <param name="from">откуда</param>
        /// <param name="to">куда</param>
        public static void AppendDots(Klass from, Klass to)
        {
            foreach (Dot d in from.Dots)
            {
                Dot d2 = new Dot(d.prms);
                d2.name = d.name;
                d2.mean = d.mean;
                //d2.clr_name = this.clr_name;
                //d2.class_name = this.name;
                to.Add(d2);
            }
        }
        /// <summary>
        /// Вычисление центра класса
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Генерация параметров центра из списка элементов
        /// </summary>
        /// <param name="Dots"></param>
        /// <returns></returns>
        public static List<double> get_center(List<Dot> Dots)
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
        /// <summary>
        /// Генерация кластеров объектов
        /// </summary>
        /// <param name="Dots">Список, в который сохраняются соенерированные кластеры</param>
        /// <param name="prms">Число параметров для генерируемых объектов</param>
        /// <param name="klasters">Число генерируемых кластеров</param>
        /// <param name="kelements">Число элементов в кластерах</param>
        /// <param name="max_prm">Максимальное значение для генерируемых параметров (от 0 до max_prm)</param>
        /// <param name="distance">Модификатор расстояния между кластерами</param>
        /// <param name="class_name">Имя класса, для которого генерируются кластеры</param>
        /// <param name="metric">Используемая метрика</param>
        public static void Generate(List<Dot> Dots, int prms, double max_prm, int klasters, int kelements, Dot.Metric metric, string class_name = "none", double distance = 3)
        {
            rnd = new Random();
            double r;
            int number = 1;
            string name;
            double radius = Math.Log(kelements, Math.Sqrt(Math.Sqrt(max_prm))) / 10; // максимальное расстояние, на котором могут находиться элементы одного кластера
            List<Dot> temp = new List<Dot>();
            List<Dot> cents = new List<Dot>();

            for (int k = 0; k < klasters; k++)
            {
                temp.Clear(); // временный список, хранящий элементы текущего кластера
                List<double> center = new List<double>(); // для каждого кластера сначала генерируется его центр
                if (k > 0 && distance > 0)
                {
                    int steps = 0;
                    Dot cent = new Dot(center);

                    while (steps < cents.Count())
                    {
                        steps = 0;
                        center.Clear();
                        for (int p = 0; p < prms; p++)
                        {
                            r = rnd.NextDouble() * max_prm; // запись случайных параметров в центр
                            center.Add(r);
                        }
                        cent.prms = center;
                        foreach (Dot c in cents)
                            if (metric.Distance(cent, c) > (radius * distance))
                                steps++;
                        //foreach (BDot c in cents)
                        //    if (cent.Evklid(c) > (radius * distance))
                        //        steps++;
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
                    foreach (double c_prm in center) // число параметров для новых элементов наследуется от центра
                    {
                        if (rnd.Next(0, 1) < 1) // увеличение/уменьшение параметра на случайную величину
                            prm = Math.Abs(c_prm - max_prm * (radius * rnd.NextDouble())) % max_prm;
                        else
                            prm = Math.Abs(c_prm + max_prm * (radius * rnd.NextDouble())) % max_prm;

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
        /// <summary>
        /// Классификация методом KNN
        /// </summary>
        /// <param name="klasses">Список классов</param>
        /// <param name="k">Количество соседей</param>
        /// <param name="metric">Метрика</param>
        /// <param name="cycles">Кол-во циклов повторной классификации, предотвращает бесконечный цикл</param>
        public static void Knn(List<Klass> klasses, int k, Dot.Metric metric, int cycles = 10) // классификация всех элементов списка по числу соседей
        {
            List<Dot> Dots = Kls_to_List(klasses);
            List<Dot> nones = new List<Dot>(); // список бесклассовых объектов

            foreach (Klass kl in klasses)
                if (kl.name == "none")
                    nones.AddRange(kl.Dots.ToList());

            cycles = cycles * nones.Count(); // ограничение количества циклов 10*число бесклассовых элементов
            rnd = new Random();
            int r;
            while (nones.Any() && cycles > 0) // пока список содержит элементы и остались циклы
            {
                r = rnd.Next(nones.Count - 1); // выбор случайного объекта из списка бесклассовых объектов
                foreach (Dot d in Dots)
                    d.mean = metric.Distance(d, nones[r]);
                Dots = Dots.OrderBy(d => d.class_name == "none").ThenBy(d => d.mean).ToList();
                Dot[] neighbours = new Dot[k];
                for (int i = 0; i < k; i++)
                    neighbours[i] = Dots[i];
                Knn(nones[r], neighbours);
                if (nones[r].class_name != "none")
                    nones.RemoveAt(r);
                cycles--;
            }
        }
        /// <summary>
        /// Классификация методом KNN
        /// </summary>
        /// <param name="none">Бесклассовый элемент</param>
        /// <param name="neighbours">Список ближайших соседей</param>
        public static void Knn(Dot none, Dot[] neighbours) // определение класса объекта none по числу соседей
        {
            var temp_classes = from n in neighbours
                               select n.class_name;
            string[] classes = temp_classes.ToArray(); // текстовый массив классов
            classes = classes.Distinct().ToArray();
            int[] votes = new int[classes.Length]; // целочисленный массив голосов 
            double all_votes = 0;

            for (int i = 0; i < classes.Length; i++)
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
        /// <summary>
        /// Классификация методом взвешенный KNN
        /// </summary>
        /// <param name="klasses">Список классов</param>
        /// <param name="k">Количество соседей</param>
        /// <param name="weight">Вес элементов</param>
        /// <param name="cycles">Кол-во циклов повторной классификации, предотвращает бесконечный цикл</param>
        public static void Knn(List<Klass> klasses, int k, double weight, Dot.Metric metric, int cycles = 10) 
        {
            List<Dot> Dots = Kls_to_List(klasses);
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
                    d.mean = metric.Distance(d, nones[r]);
                Dots = Dots.OrderBy(d => d.class_name == "none").ThenBy(d => d.mean).ToList();
                Dot[] neighbours = new Dot[k];
                for (int i = 0; i < k; i++)
                    neighbours[i] = Dots[i];
                Knn(nones[r], neighbours, weight);
                if (nones[r].class_name != "none")
                    nones.RemoveAt(r);

                cycles--;
            }
        }
        /// <summary>
        /// Классификация методом взвешенный KNN
        /// </summary>
        /// <param name="none">Бесклассовый элемент</param>
        /// <param name="neighbours">Список ближайших соседей</param>
        /// <param name="weight">Вес элементов</param>
        public static void Knn(Dot none, Dot[] neighbours, double weight) // определение класса объекта none по "весу" соседей
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
        /// <summary>
        /// Классификация методом центрированный KNN
        /// </summary>
        /// <param name="klasses">Список классов</param>
        /// <param name="metric">Метрика</param>
        /// <param name="cycles">Кол-во циклов повторной классификации, предотвращает бесконечный цикл</param>
        public static void Knn(List<Klass> klasses, Dot.Metric metric, int cycles = 10) // классификация всех элементов списка по близости к центрам
        {
            if (klasses.Count > 1)
            {
                List<Dot> Dots = Kls_to_List(klasses);
                List<Dot> nones = new List<Dot>();  // список бесклассовых объектов
                List<Dot> cents = new List<Dot>(); // список центров
                foreach (Klass gls in klasses)    // копируем список бесклассовых элементов в nones'ы
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
                    foreach (Klass gls in klasses)  // и заполянем заново
                    {
                        if (gls.name != "none" && gls.Count() > 0)      // центры пустых классов и класса none не учитываются
                            cents.Add(gls.get_center());
                    }
                    r = rnd.Next(nones.Count - 1);   // выбор случайного элемента из списка бесклассовых
                    for (int i = 0; i < cents.Count; i++)
                    {
                        cents[i].mean = metric.Distance(cents[i], nones[r]);// записываем в mean расстояние до центра класса                                           
                    }
                    if (cents.Count > 0)  // если в списке есть хотя бы 1 центр класса
                    {
                        cents = cents.OrderBy(c => c.mean).ToList();      // сортируем центры по значению mean
                        if (cents[0].class_name != "none")               // ещё раз проверяем класс первого центра в списке
                        {
                            nones[r].class_name = cents[0].class_name;  // присваиваем нашему элементу имя этого класса
                        }
                        foreach (Klass gls in klasses)
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
        /// <summary>
        /// Классификация методом взвешенный центрированный KNN
        /// </summary>
        /// <param name="klasses">Список классов</param>
        /// <param name="metric">Метрика</param>
        /// <param name="weight">Вес элементов</param>
        /// <param name="cycles">Кол-во циклов повторной классификации, предотвращает бесконечный цикл</param>
        public static void Knn(List<Klass> klasses, Dot.Metric metric, double weight, int cycles = 10)
        {
            if (klasses.Count > 1)
            {
                List<Dot> Dots = Kls_to_List(klasses);
                List<Dot> nones = new List<Dot>();   // список бесклассовых объектов
                List<Dot> cents = new List<Dot>();  // список центров классов
                foreach (Klass gls in klasses)     // копируем список бесклассовых элементов в nones'ы
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
                    foreach (Klass gls in klasses)  // и заполянем заново
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
                        cents[i].mean = cents[i].mean / metric.Distance(cents[i], nones[r]); // записываем в mean число элементов класса/расстояние до центра класса                                              
                        all_cents += cents[i].mean;
                    }
                    if (cents.Count > 0) // если в списке есть хотя бы 1 центр класса
                    {
                        cents = cents.OrderByDescending(c => c.mean).ToList();     // сортируем центры по значению mean
                        if (cents[0].class_name != "none")              // ещё раз проверяем класс первого центра в списке
                        {
                            nones[r].class_name = cents[0].class_name; // присваиваем нашему элементу имя этого класса
                            nones[r].expectation = (double)cents[0].mean / (double)all_cents;
                            nones[r].expectation = Math.Round(nones[r].expectation, 4);
                        }
                        foreach (Klass gls in klasses)
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
        /// <summary>
        /// Кластеризация методом K-means (K средних)
        /// </summary>
        /// <param name="Dots">Список элементов</param>
        /// <param name="cents">Список центров кластеров</param>
        /// <param name="metric">Метрика</param>
        /// <param name="cycles">Кол-во циклов повторной классификации, предотвращает бесконечный цикл</param>
        public static void Kmeans(List<Dot> Dots, List<Dot> cents, Dot.Metric metric, int cycles = 50000)
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
                        cents[i].mean = metric.Distance(cents[i], d);// записываем в mean расстояние до центра класса                                             
                    }
                    cents = cents.OrderBy(c => c.mean).ToList();      // сортируем центры по значению mean
                    if (cents[0].class_name != "none")               // ещё раз проверяем класс первого центра в списке
                    {
                        d.class_name = cents[0].class_name;  // присваиваем нашему элементу имя этого класса
                    }
                }
                for (int i = 0; i < cents.Count; i++)
                {
                    if (Dots.Where(d => d.class_name == cents[i].class_name).ToList().Count > 0) // если в классе с данным центром есть элементы
                        cents[i].prms = get_center(Dots.Where(d => d.class_name == cents[i].class_name).ToList()); // центр перевычисляется
                }
                cents = cents.OrderBy(c => c.class_name).ToList();
                old_cents = old_cents.OrderBy(c => c.class_name).ToList();
                for (int i = 0; i < cents.Count; i++)
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
                if (count > cycles) // выход из цикла при достижении 'cycles' итераций
                    break;
                count++;
                same_prms = 0;
            }
        }
        /// <summary>
        /// Пошаговая кластеризация
        /// </summary>
        /// <param name="Dots">Список элементов</param>
        /// <param name="cents">Список центров</param>
        /// <param name="metric">Метрика</param>
        public static void Kmeans_debug(List<Dot> Dots, List<Dot> cents, Dot.Metric metric)
        {
            foreach (Dot d in Dots)
            {
                for (int i = 0; i < cents.Count; i++)
                {
                    cents[i].mean = metric.Distance(cents[i], d); // записываем в mean расстояние до центра класса                      
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
        /// <summary>
        /// Иерархическая кластеризация (hierarchical clustering)
        /// </summary>
        /// <param name="kls">Список классов/кластеров</param>
        /// <param name="metric">Метрика расстояния между элементами классов/кластеров</param>
        /// <param name="last_stand">Конечное число получаемых кластеров</param>
        /// <param name="kls_metric">Критерий связности между классами/кластерами</param>
        public static void lab3(List<Klass> kls, Dot.Metric metric, int last_stand, Klass.Metric kls_metric)
        {    
            List<Klass> trash = new List<Klass>();            
            Klass.Clear_empty(kls, trash); // Очишаем список классов от пустых классов, none (если пустой) сохраняем в trash
            List<Klass> klasses = new List<Klass>();
            klasses.AddRange(kls.ToList()); // список непустых классов, с которым будем работать
            double[,] matrix = new double[klasses.Count, klasses.Count];
            int[] united = new int[2]; // Для WPGMA, хранит индекс объединенного кластера и число кластеров в нём
            int[] deleted = new int[2]; // Для WPGMA, хранит индекс удалённого кластера и число кластеров в нём
            while (klasses.Count > last_stand)
            {
                List<Klass> neighbours = new List<Klass>(); // список для двух ближайших кластеров                
                //if(kls_metric.type=="Метод взвешенного попарного среднего"&&united.Max()>0)
                //{
                //    matrix =kls_metric.Next_matrix(matrix, united, deleted);
                //}
                //else
                //{
                    matrix = new double[klasses.Count, klasses.Count]; 
                    for (int i = 0; i < klasses.Count; i++)
                        for (int j = 0; j < klasses.Count; j++)
                            matrix[i, j] = kls_metric.Distance(klasses[i], klasses[j], metric);
                //}
                
                double min = matrix[0,1];
                neighbours.Add(klasses[0]);
                neighbours.Add(klasses[1]);
                for (int i = 0; i < klasses.Count; i++)
                    for (int j = 0; j < klasses.Count; j++)
                        if(matrix[i,j]<min&&matrix[i, j] != 0)
                        {
                            double[,] mk = matrix;
                            neighbours.Clear();
                            neighbours.Add(klasses[i]);
                            neighbours.Add(klasses[j]);
                            united[0] = i; united[1] = (int)klasses[i].mean;
                            deleted[0] = j; deleted[1] = (int)klasses[j].mean;
                        }
                List<Klass> n1 = new List<Klass>();
                List<Klass> n2 = new List<Klass>();                
                n2 = neighbours.ToList();                
                int kk1 = united[0];
                int kk2 = deleted[0];
                n1 = klasses.ToList();
                double[,] kkm = matrix;


                if (neighbours[0].Dots.Count> neighbours[1].Dots.Count
                    &&neighbours[0].name != "none")
                {
                    AppendDots(neighbours[1], neighbours[0]);
                    neighbours[0].mean += neighbours[1].mean;
                    neighbours[1].Dots.Clear();
                    klasses.Remove(neighbours[1]);
                }
                else
                {
                    AppendDots(neighbours[0], neighbours[1]);
                    neighbours[1].mean += neighbours[0].mean;
                    neighbours[0].Dots.Clear();
                    if(neighbours[0].name == "none")
                        trash.Add(neighbours[0]);
                    klasses.Remove(neighbours[0]);
                    int[] temp = new int[2];
                    deleted.CopyTo(temp, 0);
                    united.CopyTo(deleted, 0);
                    temp.CopyTo(united, 0);
                }
            }
            kls.Clear();
            kls.AddRange(trash.ToList()); // добавляем в начало класс none
            kls.AddRange(klasses.ToList()); // добавляем полученные кластеры
        }
        /// <summary>
        /// Критерий связности между двумя кластерами
        /// </summary>
        public abstract class Metric
        {
            public abstract string type { get; }
            /// <summary>
            /// Расстояние между двумя объектами типа Klass
            /// </summary>
            /// <param name="k1">Объект типа Klass</param>
            /// <param name="k2">Объект типа Klass</param>
            /// <returns>Расстояние между двумя классами с плавающей точкой</returns>
            public abstract double Distance(Klass k1, Klass k2, Dot.Metric metric);
            public virtual double[,] Next_matrix(double[,] matrix, int[] united, int[] deleted)
            {
                return matrix;
            }
        }
        /// <summary>
        /// Метод ближайшего соседа
        /// </summary>
        public class Nearest : Metric
        {
            public override string type
            {
                get
                {
                    return "Метод ближайшего соседа";
                }
            }
            public override double Distance(Klass k1, Klass k2, Dot.Metric metric)
            {
                if (k1.name == k2.name)
                    return 0;
                double min = metric.Distance(k1.Dots[0], k2.Dots[0]);
                foreach (Dot d1 in k1.Dots)
                {
                    foreach (Dot d2 in k2.Dots)
                    {
                        double temp = metric.Distance(d1, d2);
                        if (temp < min)
                            min = temp;
                    }
                }
                return min;
            }
        }
        /// <summary>
        /// Метод дальнего соседа
        /// </summary>
        public class Furthest : Metric
        {
            public override string type
            {
                get
                {
                    return "Метод дальнего соседа";
                }
            }
            public override double Distance(Klass k1, Klass k2, Dot.Metric metric)
            {
                if (k1.name == k2.name)
                    return 0;
                double max = metric.Distance(k1.Dots[0], k2.Dots[0]);
                foreach (Dot d1 in k1.Dots)
                {
                    foreach (Dot d2 in k2.Dots)
                    {
                        double temp = metric.Distance(d1, d2);
                        if (temp > max)
                            max = temp;
                    }
                }
                return max;
            }
        }
        /// <summary>
        /// Метод невзвешенного попарного среднего
        /// </summary>
        public class UPGMA : Metric
        {
            public override string type
            {
                get
                {
                    return "Метод невзвешенного попарного среднего";
                }
            }
            public override double Distance(Klass k1, Klass k2, Dot.Metric metric)
            {
                if (k1.name == k2.name)
                    return 0;
                double average = 0;
                double count = k1.Dots.Count + k2.Dots.Count;
                foreach (Dot d1 in k1.Dots)
                {
                    foreach (Dot d2 in k2.Dots)
                    {
                        double temp = metric.Distance(d1, d2);
                        average += temp;
                    }
                }
                average = average / 2;
                return average;
            }
        }
        /// <summary>
        /// Метод взвешенного попарного среднего
        /// </summary>
        public class WPGMA : Metric
        {
            public override string type
            {
                get
                {
                    return "Метод взвешенного попарного среднего";
                }
            }
            public override double Distance(Klass k1, Klass k2, Dot.Metric metric)
            {
                if (k1.name == k2.name)
                    return 0;
                double average = 0;
                double count = k1.Dots.Count + k2.Dots.Count;
                foreach (Dot d1 in k1.Dots)
                {
                    foreach (Dot d2 in k2.Dots)
                    {
                        double temp = metric.Distance(d1, d2);
                        average += temp;
                    }
                }
                average = average / count;
                return average;
            }
            public override double[,] Next_matrix(double[,] matrix, int[] united, int[] deleted)
            {
                int count = matrix.GetLength(0);
                int k1 = united[0]; int k1mean = united[1];
                int k2 = deleted[0]; int k2mean = deleted[1];
                
                // Перезаписываем расстояния для объединенного кластера
                for (int i = 0; i < count; i++)
                {
                    if (i != k1 || i != k2)
                    {
                        matrix[k1, i] = (k1mean * matrix[k1, i] + k2mean * matrix[k2, i]) / (k1mean + k2mean);
                        matrix[i, k1] = matrix[k1, i];
                    }
                }
                matrix[k1, k1] = 0;
                // Создаём новую матрицу, убирая из старой строку и столбец кластера k2
                double[,] matrix_new = TrimArray(k2, k2, matrix);  
                return matrix_new;
            }
            public double[,] TrimArray(int rowToRemove, int columnToRemove, double[,] originalArray)
            {
                double[,] result = new double[originalArray.GetLength(0) - 1, originalArray.GetLength(1) - 1];

                for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
                {
                    if (i == rowToRemove)
                        continue;

                    for (int k = 0, u = 0; k < originalArray.GetLength(1); k++)
                    {
                        if (k == columnToRemove)
                            continue;

                        result[j, u] = originalArray[i, k];
                        u++;
                    }
                    j++;
                }

                return result;
            }
        }        
    }    
}
