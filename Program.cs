using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        public static double Calculate(string sum)
        {
            double a = 0.0;
            var results = new List<string>();
            var opennode = new List<string>();
            var closenode = new List<string>();
            results = sum.Split(' ').ToList();

            
            while (results.Contains("(") && results.Contains(")"))
            {
                int first = 0;
                int last = 0;
                int countbracket = 0; 
                for (int i = 0; i < results.Count(); i++)
                {
                    if(results[i] == "(")
                    {
                        countbracket = countbracket + 1; 
                    }

                }

                //for one sub 
                if (countbracket == 1) {
                    for (int i = 0; i < results.Count(); i++)
                    {
                        if (results[i] == "(")
                        {
                            first = i;
                        }

                        if (results[i] == ")")
                        {
                            last = i;
                        }
                    }

                    results = calculatesub(first, last, results);
                }

                //for more than one sub
                if (countbracket > 1)
                {
                    while (results.Contains("("))
                    {
                        for (int i = 0; i < results.Count(); i++)
                        {
                            if (results[i] == "(")
                            {
                                opennode.Add(Convert.ToString(i));

                            } // store all open bracket 

                            if (results[i] == ")")
                            {
                                closenode.Add(Convert.ToString(i));

                            } // store all open bracket 

                        }

                        first = Convert.ToInt32(opennode[opennode.Count() - 1]); // take last index
                        last = Convert.ToInt32(closenode[0]); // take first index

                        if (first != 0 && last != 0)
                        {
                            results = calculatesubsub(first, last, results);
                            opennode.Clear();
                            closenode.Clear();
                        }
                    }
                    

                }

                

            }

            while (results.Count() > 1)
            {
                while (results.Contains("+"))
                {
                    for(int i = 0; i < results.Count(); i++)
                    {
                        if (results[i] == "+")
                        {
                            a = Convert.ToDouble(results[i - 1]) + Convert.ToDouble(results[i + 1]);
                            results.RemoveRange(i - 1, 3);
                            results.Insert(i - 1, a.ToString());
                            
                            
                        }
                    }
                }

                while (results.Contains("*"))
                {
                    for (int i = 0; i < results.Count(); i++)
                    {
                        if (results[i] == "*")
                        {
                            a = Convert.ToDouble(results[i - 1]) * Convert.ToDouble(results[i + 1]);
                            results.RemoveRange(i - 1, 3);
                            results.Insert(i - 1, a.ToString());


                        }
                    }
                }

                while (results.Contains("/"))
                {
                    for (int i = 0; i < results.Count(); i++)
                    {
                        if (results[i] == "/")
                        {
                            a = Convert.ToDouble(results[i - 1]) / Convert.ToDouble(results[i + 1]);
                            results.RemoveRange(i - 1, 3);
                            results.Insert(i - 1, a.ToString());


                        }
                    }
                }

                while (results.Contains("-"))
                {
                    for (int i = 0; i < results.Count(); i++)
                    {
                        if (results[i] == "-")
                        {
                            a = Convert.ToDouble(results[i - 1]) - Convert.ToDouble(results[i + 1]);
                            results.RemoveRange(i - 1, 3);
                            results.Insert(i - 1, a.ToString());


                        }
                    }
                }
            }

            return a;

        }
        
        public static List<String> calculatesub( int first  , int last  , List<string>results)
        {
            double a = 0.0;

            var temporaryresult = new List<string>(); 
            temporaryresult = results.GetRange(first + 1, 3);

            while (temporaryresult.Count() > 1)
            {
                while (temporaryresult.Contains("+"))
                {
                    for (int i = 0; i < temporaryresult.Count(); i++)
                    {
                        if (temporaryresult[i] == "+")
                        {
                            a = Convert.ToDouble(temporaryresult[i - 1]) + Convert.ToDouble(temporaryresult[i + 1]);
                            temporaryresult.RemoveRange(0, temporaryresult.Count());
                            results.RemoveRange(first , 5);
                            results.Insert(first , a.ToString());

                        }
                    }
                }

                while (temporaryresult.Contains("-"))
                {
                    for (int i = 0; i < temporaryresult.Count(); i++)
                    {
                        if (temporaryresult[i] == "-")
                        {
                            a = Convert.ToDouble(temporaryresult[i - 1]) - Convert.ToDouble(temporaryresult[i + 1]);
                            temporaryresult.RemoveRange(0, temporaryresult.Count());
                            results.RemoveRange(first , 5);
                            results.Insert(first , a.ToString());

                        }
                    }
                }

                while (temporaryresult.Contains("*"))
                {
                    for (int i = 0; i < temporaryresult.Count(); i++)
                    {
                        if (temporaryresult[i] == "*")
                        {
                            a = Convert.ToDouble(temporaryresult[i - 1]) * Convert.ToDouble(temporaryresult[i + 1]);
                            temporaryresult.RemoveRange(0, temporaryresult.Count());
                            results.RemoveRange(first, 5);
                            results.Insert(first, a.ToString());

                        }
                    }
                }

                while (temporaryresult.Contains("/"))
                {
                    for (int i = 0; i < temporaryresult.Count(); i++)
                    {
                        if (temporaryresult[i] == "/")
                        {
                            a = Convert.ToDouble(temporaryresult[i - 1]) / Convert.ToDouble(temporaryresult[i + 1]);
                            temporaryresult.RemoveRange(0, temporaryresult.Count());
                            results.RemoveRange(first, 5);
                            results.Insert(first, a.ToString());

                        }
                    }
                }
            }
               

            return results; 
        }

        public static List<String> calculatesubsub(int first, int last, List<string> results)
        {
            double a = 0.0;
            int countop = 0;

            var temporaryresult = new List<string>();
            temporaryresult = results.GetRange(first + 1, (last - 1 ) - first );

            if (temporaryresult.Contains("+"))
            {
                countop = countop + 1;
            }

            if (temporaryresult.Contains("-"))
            {
                countop = countop + 1;
            }

            if (temporaryresult.Contains("*"))
            {
                countop = countop + 1;
            }


            if (temporaryresult.Contains("*"))
            {
                countop = countop + 1;
            }

            if (countop == 1)
            {
                while (temporaryresult.Count() > 1)
                {
                    while (temporaryresult.Contains("+"))
                    {
                        for (int i = 0; i < temporaryresult.Count(); i++)
                        {
                            if (temporaryresult[i] == "+")
                            {
                                a = Convert.ToDouble(temporaryresult[i - 1]) + Convert.ToDouble(temporaryresult[i + 1]);
                                temporaryresult.RemoveRange(0, temporaryresult.Count());
                                results.RemoveRange(first, 5);
                                results.Insert(first, a.ToString());

                            }
                        }
                    }

                    while (temporaryresult.Contains("-"))
                    {
                        for (int i = 0; i < temporaryresult.Count(); i++)
                        {
                            if (temporaryresult[i] == "-")
                            {
                                a = Convert.ToDouble(temporaryresult[i - 1]) - Convert.ToDouble(temporaryresult[i + 1]);
                                temporaryresult.RemoveRange(0, temporaryresult.Count());
                                results.RemoveRange(first, 5);
                                results.Insert(first, a.ToString());

                            }
                        }
                    }

                    while (temporaryresult.Contains("*"))
                    {
                        for (int i = 0; i < temporaryresult.Count(); i++)
                        {
                            if (temporaryresult[i] == "*")
                            {
                                a = Convert.ToDouble(temporaryresult[i - 1]) * Convert.ToDouble(temporaryresult[i + 1]);
                                temporaryresult.RemoveRange(0, temporaryresult.Count());
                                results.RemoveRange(first, 5);
                                results.Insert(first, a.ToString());

                            }
                        }
                    }

                    while (temporaryresult.Contains("/"))
                    {
                        for (int i = 0; i < temporaryresult.Count(); i++)
                        {
                            if (temporaryresult[i] == "/")
                            {
                                a = Convert.ToDouble(temporaryresult[i - 1]) / Convert.ToDouble(temporaryresult[i + 1]);
                                temporaryresult.RemoveRange(0, temporaryresult.Count());
                                results.RemoveRange(first, 5);
                                results.Insert(first, a.ToString());

                            }
                        }
                    }
                }
            }else if (countop > 1)
            {
                while (temporaryresult.Count() > 1)
                {
                    while (temporaryresult.Contains("*"))
                    {
                        for (int i = 0; i < temporaryresult.Count(); i++)
                        {
                            if (temporaryresult[i] == "*")
                            {
                                a = Convert.ToDouble(temporaryresult[i - 1]) * Convert.ToDouble(temporaryresult[i + 1]);
                                temporaryresult.RemoveRange(i - 1, 3);
                                temporaryresult.Insert(i - 1, a.ToString());
                            }
                        }
                    }

                    while (temporaryresult.Contains("/"))
                    {
                        for (int i = 0; i < temporaryresult.Count(); i++)
                        {
                            if (temporaryresult[i] == "/")
                            {
                                a = Convert.ToDouble(temporaryresult[i - 1]) / Convert.ToDouble(temporaryresult[i + 1]);
                                temporaryresult.RemoveRange(i - 1, 3);
                                temporaryresult.Insert(i - 1, a.ToString());

                            }
                        }
                    }

                    while (temporaryresult.Contains("+"))
                    {
                        for (int i = 0; i < temporaryresult.Count(); i++)
                        {
                            if (temporaryresult[i] == "+")
                            {
                                a = Convert.ToDouble(temporaryresult[i - 1]) + Convert.ToDouble(temporaryresult[i + 1]);
                                temporaryresult.RemoveRange(i - 1, 3);
                                temporaryresult.Insert(i - 1, a.ToString());

                            }
                        }
                    }

                    while (temporaryresult.Contains("-"))
                    {
                        for (int i = 0; i < temporaryresult.Count(); i++)
                        {
                            if (temporaryresult[i] == "-")
                            {
                                a = Convert.ToDouble(temporaryresult[i - 1]) - Convert.ToDouble(temporaryresult[i + 1]);
                                temporaryresult.RemoveRange(i - 1, 3);
                                temporaryresult.Insert(i - 1, a.ToString());

                            }
                        }
                    }

                    results.RemoveRange(first, ( last + 1 ) - first);
                    results.Insert(first, temporaryresult[0]);


                }
            }
            


            return results;
        }

        static void Main(string[] args)
        {

            //Your code goes here
            string a;
            Console.WriteLine("Please enter equation:");
            a = Console.ReadLine();

            double result = Calculate(a);

            Console.WriteLine("Total = " + result);
            Console.ReadLine();
        }
    }
}
