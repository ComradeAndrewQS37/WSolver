using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WSolver
{
    class FParser
    {
        Stack<string> st = new Stack<string>();
        List<string> compiled = new List<string>();
        bool wrong_symbol = false;

        4*x+3-2

        4 x * 3 + 2 -
        
        public string Compile(string[] splitted_formula)
        {
            this.compiled = new List<string>();
            foreach (string symbol in splitted_formula)
            {
                this.ProccessSymbol(symbol);
            }
            return String.Join(" ", this.compiled);
        }

        public void ProccessSymbol(string s)
        {
            if (s == "(")
            {
                this.st.Push(s);
            }
            else if (s == ")")
            {
                this.ProccessSuspended(s);
                this.st.Pop();
            }
            else if (s == "+" || s == "-"|| s == "*"|| s == "/"||s=="^")
            {
                this.ProccessSuspended(s);
                this.st.Push(s);
            }
            else
            {
                CheckSymbol(s);
                this.compiled.Add(s);
            }
        }

        public void ProccessSuspended(string s)
        {
            while (IsBefore(st.Peek(), s))
            {
                this.compiled.Add(st.Pop());
            }
        }

        public void CheckSymbol(string s)
        {
            
        }

        public static int Priority(string s)
        {
            if (s == "+" || s == "-")
            {
                return 1;
            }
            else if (s == "*" || s == "/")
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public static bool IsBefore(string a,string b)
        {
            if (a == "(")
            {
                return false;
            }
            else if (b == ")")
            {
                return true;
            }
            else
            {
                return Priority(a) >= Priority(b);
            }
        }
        public static string ToListParser(string formula)
        {
            formula = "(" + formula + "))";
            formula = formula.Replace(" ", "");
            formula = formula.Replace("=","-(");
            formula = formula.Replace("+", " + ").Replace("*", " * ").Replace("/", " / ").Replace("-", " - ").Replace("(", " ( ").Replace(")", " ) ").Replace("^", " ^ ").Replace("  "," ");
            formula = formula.Trim();


            FParser FP = new FParser();

            return FP.Compile(formula.Split(' '));
        } 
    }
}
