using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Entity;
using NUnit.Framework;
using static System.Net.Mime.MediaTypeNames;

namespace UseCase
{
    public class UC_Iteration
    {
        public int dim1;
        public int dim2;
        public int sum1;
        public int sum2;
        public List<int> var1;
        public List<int> var2;

        public UC_Iteration()
        {
            this.dim1 = 0;
            this.dim2 = 0;
            this.sum1 = 10;
            this.sum2 = 87;
            this.var1 = new List<int> { 0, 0, 0, 0 };
            this.var2 = new List<int> { 0, 0, 0, 0 };
        }

        public bool Run()
        {
            bool result = true;

            ForLoopSkip(10, 87);    // 10, 87
            //ForLoopSimple(5, 7);    // 10, 87

            //BT(dim1, dim2, sum1, sum2, var1, var2);

            //result &= this.PrepareOriginalTs();
            return result;
        }

        private void BT(int dim1, int dim2, int sum1, int sum2, List<int> var1, List<int> var2)
        {

        }

        private void ForLoopSimple(int sum1, int sum2)
        {
            String timeStamp = DateTime.Now.ToString("yyyy.MM.dd.HH-mm-ss.");
            string fileName = timeStamp + "result.csv";
            string path = Path.Combine(Environment.CurrentDirectory, @"result\", fileName);
            //Directory.CreateDirectory(path);

            using (var w = new StreamWriter(path))
            {
                w.WriteLine(string.Format("a1,b1,c1,e1,a2,b2,c2,d2"));
                for (int a1 = 0; a1 <= sum1; a1++)
                {
                    for (int b1 = 0; b1 <= sum1; b1++)
                    {
                        for (int c1 = 0; c1 <= sum1; c1++)
                        {
                            for (int e1 = 0; e1 <= sum1; e1++)
                            {
                                for (int a2 = 0; a2 <= sum2; a2++)
                                {
                                    for (int b2 = 0; b2 <= sum2; b2++)
                                    {
                                        for (int c2 = 0; c2 <= sum2; c2++)
                                        {
                                            for (int d2 = 0; d2 <= sum2; d2++)
                                            {
                                                if ((a1 + b1 + c1 + e1) == sum1 && (a2 + b2 + c2 + d2) == sum2)
                                                {
                                                    var line = string.Format(
                                                        "{0},{1},{2},{3},{4},{5},{6},{7}",
                                                        a1, b1, c1, e1, a2, b2, c2, d2);
                                                    w.WriteLine(line);
                                                    w.Flush();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ForLoopSkip(int sum1, int sum2)
        {
            String timeStamp = DateTime.Now.ToString("yyyy.MM.dd.HH-mm-ss.");
            string fileName = timeStamp + "result.csv";
            string path = Path.Combine(Environment.CurrentDirectory, @"result\", fileName);
            //Directory.CreateDirectory(path);

            int a1 = 0;
            int b1 = 0;
            int c1 = 0;
            int e1 = 0;
            int a2 = 0;
            int b2 = 0;
            int c2 = 0;
            int d2 = 0;

            using (var w = new StreamWriter(path))
            {
                w.WriteLine(string.Format("a1,b1,c1,e1,a2,b2,c2,d2"));
                for (; a1 <= sum1; a1++)
                {
                    if ((a1 + b1 + c1 + e1) > sum1) break;
                    for (; b1 <= sum1; b1++)
                    {
                        if ((a1 + b1 + c1 + e1) > sum1) break;
                        for (; c1 <= sum1; c1++)
                        {
                            if ((a1 + b1 + c1 + e1) > sum1) break;
                            for (; e1 <= sum1; e1++)
                            {
                                if ((a1 + b1 + c1 + e1) > sum1) break;
                                for (; a2 <= sum2; a2++)
                                {
                                    if ((a2 + b2 + c2 + d2) > sum2) break;
                                    for (; b2 <= sum2; b2++)
                                    {
                                        if ((a2 + b2 + c2 + d2) > sum2) break;
                                        for (; c2 <= sum2; c2++)
                                        {
                                            if ((a2 + b2 + c2 + d2) > sum2) break;
                                            for (; d2 <= sum2; d2++)
                                            {
                                                if ((a1 + b1 + c1 + e1) == sum1 && (a2 + b2 + c2 + d2) == sum2)
                                                {
                                                    var line = string.Format(
                                                        "{0},{1},{2},{3},{4},{5},{6},{7}",
                                                        a1, b1, c1, e1, a2, b2, c2, d2);
                                                    w.WriteLine(line);
                                                    w.Flush();
                                                }
                                            }
                                            d2 = 0;
                                        }
                                        c2 = 0;
                                    }
                                    b2 = 0;
                                }
                                a2 = 0;
                            }
                            e1 = 0;
                        }
                        c1 = 0;
                    }
                    b1 = 0;
                }
                a1 = 0;
            }
        }
    }
}
