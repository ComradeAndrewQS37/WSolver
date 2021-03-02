using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace WSolver
{
    /*How Parser works:
    1) MainParser takes usual notation of formula       e^x + 3x = sin(x + 3) + 2
    2) All terms are moved to the left part with minus  e^x + 3x - ( sin(x + 3) + 2 ) = 0
    3) Formula is converted to reverse polish notation  e x ^ 3 x * + x 3 + sin 2 + -
    This notation will be used to construct a function 
     */

    class FParser
    {
        // all processed operations
        static readonly string[] Operators = { "+", "-", "/", "*", "^", "sin", "cos", "tg", "ctg", "ln", "lg", "log" };
        // stack only for brackets and operators
        Stack<string> st = new Stack<string>();
        //splitted reverse polish notation
        List<string> compiled = new List<string>();

        static string used_variable;


        public static string MainParser(string formula, string variable)
        {
            used_variable = variable;

            formula = formula.ToLower();
            formula = formula.Replace(" ", "");


            if (!formula.Contains("=") || formula.EndsWith("="))
            {
                // formula is not an equation
                throw new NotEquationException("Введите уравнение\nТакая запись некорректна, проверьте ещё раз");
            }

            if (SymbolCount(formula,'(')!= SymbolCount(formula, ')'))
            {
                //missing bracket
                throw new SyntaxException("Вы пропустили одну или несколько скобок\nТакая запись некорректна, проверьте ещё раз");
            }

            // all terms to the left
            formula = formula.Replace("=", "-(") + ")";
            // all formula to brackets (nothing is changed mathematically, but easier to process
            formula = "(" + formula + ")";


            string[] ops = { "+", "-", "*", "/", "^", "(", ")" };
            foreach (string op in ops){
                // distinguish operators and brackets with whitespaces
                formula = formula.Replace(op, " " + op + " ");
            }

            // remove double whitespaces
            formula = formula.Replace("  "," ");
            // remove whitespaces in the beginning and in the end
            formula = formula.Trim();

            // change all unary minuses, so -3x becomes 0-3x
            formula = formula.Replace("( - ", "( 0 - ");

            // process cases like 45x or 6sin(y), when * is missing
            string[] pArr = {used_variable, "sin", "cos", "tg", "ctg", "ln", "lg", "e", "pi" };
            foreach (string p in pArr)
            {
                int displacement = 0;
                // pattern that matches such cases
                string prPattern = $@"([0-9]+){p}";
                var matches = Regex.Matches(formula, prPattern);

                foreach (Match match in matches)
                {
                    // only num part of match, like 45 from 45x
                    string numMatch = match.Value.Replace(p, "");
                    // after replacement have 45 * x instead of 45x
                    formula = formula.Substring(0, match.Index + displacement) + numMatch + " * " + p + formula.Substring(match.Index + displacement + match.Length);
                    displacement += 3;// len("45x") + 3 = len("45 * x")
                }

            }


            FParser FP = new FParser();
            return FP.Compile(formula.Split(' '));
        } 
        

        public string Compile(string[] splittedFormula)
        {
            this.compiled = new List<string>();
            foreach (string symbol in splittedFormula)
            {
                try
                {
                    this.ProcessSymbol(symbol);
                }
                catch (InvalidOperationException)
                {
                    // in case of unknown input error
                    //InvalidOperationException is thrown if we try pop() or peak() empty stack
                    throw new SyntaxException("Синтаксическая ошибка в формуле\nПроверьте ещё раз");
                }
            }
            return string.Join(" ", this.compiled);
        }


        public void ProcessSymbol(string s)
        {
            if (s == "(")
            {
                this.st.Push(s);
                // when we have a bracket, we delay the operation before bracket
            }
            else if (s == ")")
            {
                // process delayed operations
                this.ProcessSuspended(s);
                //remove "(" from stack
                this.st.Pop();
            }
            else if (Operators.Contains(s))
            {
                // when have new operation, process delayed operations
                this.ProcessSuspended(s);
                // and delay this operation
                this.st.Push(s);
            }
            else
            {
                // if it's an inappropriate character, throw an exception
                CheckSymbol(s);
                // otherwise put into result
                this.compiled.Add(s);
            }
        }


        public void ProcessSuspended(string s)
        {
            /*
             * move operators to compiled from st until meet "(" (including bracket in the very beginning of formula)
             * or if we need to process this operation before the first in the st
             */
            
            while (IsBefore(st.Peek(), s))
            {
                this.compiled.Add(st.Pop());
            }
        }



        // checks if a is processed before b
        public static bool IsBefore(string a,string b)
        {
            if (a == "(")
            {
                // firstly process everything after "("
                return false;
            }
            else if (b == ")")
            {
                // firstly process everything before "("
                return true;
            }
            else
            {
                return Priority(a) >= Priority(b);
            }
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

        // counts number of c in s
        public static int SymbolCount(string s, char c)
        {
            return s.Split(c).Length - 1;
        }

        public static void CheckSymbol(string s)
        {
            // besides operators and brackets only variables and num constants are possible
            string pattern_cor1 = $@"^(([0-9]+[\.,]?[0-9]*)|(pi)|(e)|{used_variable})$"; // correct character
            string pattern_cor2 = $@"^-(([0-9]+[\.,]?[0-9]*)|(pi)|(e)|{used_variable})$"; // correct character with unary minus

            if (!Regex.IsMatch(s, pattern_cor1, RegexOptions.IgnoreCase) && !Regex.IsMatch(s, pattern_cor2, RegexOptions.IgnoreCase))
            {
                string pattern_var=@"^\w+$"; // possibly a variable, but the wrong one

                if (Regex.IsMatch(s, pattern_var, RegexOptions.IgnoreCase))
                {
                    // probably wrong variable
                    throw new WrongElementException("Неизвестная переменная: " + s + "\nПроверьте выражение ещё раз");
                }
                else if (s.Length == 1)
                {
                    // symbol that is not processed
                    throw new WrongElementException("Неизвестный символ: " + s + "\nПроверьте выражение ещё раз");
                }
                else
                {
                    // sequence of symbols that cannot be processed
                    throw new WrongElementException("Неизвестная последовательность символов: " + s + "\nПроверьте выражение ещё раз");
                }
            }
        }

    }
}
