using System;

namespace DZ4
{
    class Program
    {
        // tìm số lượng các số âm của mảng 1c
        static void SS(int n, int[] a)
        {
            int d = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] < 0)
                    d++;
            }
            Console.Write("{0} ", d);
        }
        // tính tổng các số sau số có modun nhỏ nhất
        static Double Sum(int n, int[] a)
        {
            Double Sum = 0;
            int d = 0;
            int[] b = a;
            //tim min
            int Min = Math.Abs(b[0]);
            for (int i = 1; i < b.Length; i++)
            {
                if (Min > Math.Abs(b[i]))
                    Min = Math.Abs(b[i]);
            }
            //tinh tong
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(a[i]) == Min)
                {
                    d = i;
                    while (d < n)
                    {
                        Sum = Sum + a[d];
                        d++;
                    }
                    break;
                }
            }
            return Sum;
        }

        static void Output1(int n, int[] a)
        {
            int[] c = a;
            int d = 0;
            for (int i = 0; i < n; i++)
            {
                if (c[i] < 0)
                {
                    c[i] = (int)Math.Pow(c[i], 2);
                }
            }
            Array.Sort(c);//lệnh sắp xếp từ nhỏ đến lớn
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", c[i]);
            }
        }
        //in mảng 2c
        static void Output2(int m, int n, int[,] a)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("a[{0},{1}]={2}\t", i, j, a[i, j]);
                }
                Console.WriteLine();
            }
        }

        //in ra vị trí của cột đầu tiên mà k có bất kỳ ptu âm nào
        static int check0(int m, int n, int[,] a)
        {
            Boolean check = false;
            int d = 0;
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    if (a[i, j] < 0)
                    {
                        check = false;
                        d = j + 1;
                        break;
                    }
                    else check = true;
                }
                if (check == true)
                    break;
            }
            return d;
        }
        //sắp xếp sô lượng các phần tử giống nhau giữa các hàng theo thứ tự tăng dần
        static void swap(int m, int n, int[,] a)
        {
            int h, counter, max;
            max = 0;
            int[] c = new int[n];
            for (int i = 0; i < m; i++)
            {
                c[i] = 0;
                for (int j = 0; j < (n - 1); j++)
                {
                    counter = 1;
                    for (int k = j + 1; k < n; k++)
                    {
                        if (a[i, j] == a[i, k])
                            counter++;
                    }
                    if (c[i] < counter)
                        c[i] = counter;
                }
            }

            for (int i = 0; i < m - 1; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    if (c[i] > c[j])
                    {
                        //đổi chỗ dòng
                        for (int d = 0; d < n; d++)
                        {
                            h = a[i, d];
                            a[i, d] = a[j, d];
                            a[j, d] = h;
                        }
                        //đổi chỗ giá trị 
                        h = c[i];
                        c[i] = c[j];
                        c[j] = h;
                    }
                }
            }
            //kết quả
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0}  ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int choose;
            Console.WriteLine("enter 1: Одномерные массивы");
            Console.WriteLine("enter 2: Двумерные массивы");
            choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    {
                        int n;
                        Console.WriteLine("ввод n :");
                        n = int.Parse(Console.ReadLine());
                        Random r = new Random();
                        int[] a = new int[n];
                        for (int i = 0; i < n; i++)
                        {
                            a[i] = r.Next(-100, 100);
                            Console.Write("a[{0}]={1} ", i, a[i]);
                        }

                        int choice = 0;
                        while (choice != 4)
                        {
                            Console.WriteLine("\nenter 1: количество отрицательных элементов массива ");
                            Console.WriteLine("enter 2: сумму модулей элементов массива, расположенных после минимального по модулю элемента");
                            Console.WriteLine("enter 3: упорядочить элементы массива по возрастанию");
                            Console.WriteLine("enter 4: выход");
                            Console.WriteLine("наш выбор :");
                            choice = int.Parse(Console.ReadLine());
                            Console.Clear();
                            switch (choice)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("количество отрицательных элементов массива ");
                                        SS(n, a);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Сумма");
                                        Console.WriteLine("result = {0}", Sum(n, a));
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("упорядочить элементы массива по возрастанию");
                                        Output1(n, a);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        int m, n;
                        Console.WriteLine("\t2-Двумерные массивы m*n");
                        Console.WriteLine("ввод m:");
                        m = int.Parse(Console.ReadLine());
                        Console.WriteLine("ввод n:");
                        n = int.Parse(Console.ReadLine());
                        int[,] a = new int[m, n];
                        for (int i = 0; i < m; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write("a[{0},{1}]=", i, j);
                                a[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                        Console.Clear();
                        Output2(m, n, a);
                        Console.WriteLine("Упорядочить строки целочисленной прямоугольной матрицы по возрастанию количества одинаковых элементов в каждой строке");
                        swap(m, n, a);
                        Console.WriteLine("номер первого из столбцов, не содержащих ни одного отрицательного элемента {0}", check0(m, n, a) + 1);
                        Console.Read();
                        break;
                    }
            }

        }
    }
}

