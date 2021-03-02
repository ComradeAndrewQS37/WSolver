using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace WSolver
{
    /*
    Что делает класс:
    1) MainParser получает на вход обычную запись уравнения: e^x + 3x = sin(x + 3) + 2
    2) все слагаемые переносятся в одну сторону: e^x + 3x - ( sin(x + 3) + 2 ) = 0
    3) вид формулы преобразуется в обратную польскую запись: e x ^ 3 x * + x 3 + sin 2 + -
    Затем эта запись будет использоваться для получения функции
     */

    class FParser
    {
        static string[] operators = { "+", "-", "/", "*", "^", "sin", "cos", "tg", "ctg", "ln", "lg", "log" }; // все обрабатываемые операторы
        Stack<string> st = new Stack<string>(); // стек, в котором будут храниться только скобки и знаки операций
        List<string> compiled = new List<string>(); // разбитая обратная польская запись
        static string used_variable; // используемая в данный момент переменная


        public static string MainParser(string formula, string variable)
        {
            used_variable = variable;

            formula = formula.ToLower();
            formula = formula.Replace(" ", ""); // удаление всех пробелов


            if (!formula.Contains("=") || formula.EndsWith("="))
            {
                // введено не уравнение, а что-то другое
                throw new NotEquationException("Введите уравнение\nТакая запись некорректна, проверьте ещё раз");
            }

            if (SymbolCount(formula,'(')!= SymbolCount(formula, ')'))
            {
                // пропущены одна или несколько скобок
                throw new SyntaxException("Вы пропустили одну или несколько скобок\nТакая запись некорректна, проверьте ещё раз");
            }


            formula = formula.Replace("=", "-(") + ")"; // все слагаемые переносятся влево
            formula = "(" + formula + ")"; // всё выражение заключается в скобки (не меняет смысла выражения, но удобнее обрабатывать)


            string[] ops = { "+", "-", "*", "/", "^" };
            foreach (string op in ops){
                // выделяем все операторы пробелами
                formula = formula.Replace(op, " " + op + " ");
            }
            formula = formula.Replace("(", " ( ").Replace(")", " ) "); // выделяем все скобки пробелами


            formula = formula.Replace("  "," "); // удаляем лишние двойные пробелы
            formula = formula.Trim(); // удаляем лишние пробелы в конце и начале


            formula = formula.Replace("( - ", "( 0 - "); // заменяем все знаки унарного минуса, так что -x^2 становится 0-x^2

            // обрабатываем случаи, когда опускается знак умножения, например 2x или 7sin(x)
            // переменная, функции и константы, перед которыми может опускаться знак умножения будут в массиве p_arr
            string[] p_arr = {used_variable, "sin", "cos", "tg", "ctg", "ln", "lg", "e", "pi" };

            foreach (string p in p_arr)
            {
                int displacement = 0;
                string pr_pattern = $@"([0-9]+){p}"; // шаблон вида 4x
                var matches = Regex.Matches(formula, pr_pattern); // находим все совпадения этого вида
                foreach (Match match in matches)
                {
                    string num_match = match.Value.Replace(p, ""); // находим только числовую часть совпадения (45 от 45x)
                    formula = formula.Substring(0, match.Index + displacement) + num_match + " * " + p + formula.Substring(match.Index + displacement + match.Length);// делая замену получаем, например, 45 * x
                    displacement += 3;
                }

            }


            FParser FP = new FParser();
            return FP.Compile(formula.Split(' '));
        } 
        

        public string Compile(string[] splitted_formula)
        {
            this.compiled = new List<string>();
            foreach (string symbol in splitted_formula)
            {
                try
                {
                    this.ProccessSymbol(symbol);
                }
                catch (InvalidOperationException)
                {
                    // если произошла неизвестная ошибка, связанная с вводом
                    //InvalidOperationException выбрасывается при попытке взять элемент из пустого стека
                    throw new SyntaxException("Синтаксическая ошибка в формуле\nПроверьте ещё раз");
                }
            }
            return String.Join(" ", this.compiled);
        }


        public void ProccessSymbol(string s)
        {
            if (s == "(")
            {
                this.st.Push(s);
                // когда встречаем скобку, то откладываем операцию, знак которой был перед скобкой
            }
            else if (s == ")")
            {
                this.ProccessSuspended(s); // обрабатываем отложенную операцию 
                this.st.Pop(); // удаляем скобку "(" из стека
            }
            else if (operators.Contains(s))
            {
                // как только встречаем знак следующей операции, обрабатываем все отложенные до этого операции
                this.ProccessSuspended(s);
                // и откладываем только что встреченную операцию
                this.st.Push(s);
            }
            else
            {
                CheckSymbol(s);
                // если это переменная или число, то добавляем в конечный результат, если нет, то выбрасываем исключение
                this.compiled.Add(s);
            }
        }


        public void ProccessSuspended(string s)
        {
            /* перкладываем в compiled знаки операций из стека до того момента, как
             * либо встретим открывающую скобку(в том числе ту, что стоит первой, и включает в себя всё выражение)
             * либо если сначала выполняется обрабатываемая в данный момент операция, а не та, что лежит в стеке 
            */
            while (IsBefore(st.Peek(), s))
            {
                this.compiled.Add(st.Pop());
            }
        }



        // проверяет, нужно ли обработать сначала a и потом b
        public static bool IsBefore(string a,string b)
        {
            if (a == "(")
            {
                // сначала нужно обработать всё, что осталось после открывающей скобки
                return false;
            }
            else if (b == ")")
            {
                // сначала нужно обработать всё, что осталось после закрывающей скобки
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

        // счиатет количество вхождений символа c в строку s
        public static int SymbolCount(string s, char c)
        {
            return s.Split(c).Length - 1;
        }

        public static void CheckSymbol(string s)
        {
            // кроме операторов и скобок в формуле может быть только переменная, десятичное число или константа(pi или e)
            string pattern_cor1 = $@"^(([0-9]+[\.,]?[0-9]*)|(pi)|(e)|{used_variable})$"; // корректная запись 
            string pattern_cor2 = $@"^-(([0-9]+[\.,]?[0-9]*)|(pi)|(e)|{used_variable})$"; // корректная запись с унарным минусом

            if (!Regex.IsMatch(s, pattern_cor1, RegexOptions.IgnoreCase) && !Regex.IsMatch(s, pattern_cor2, RegexOptions.IgnoreCase))
            {
                string pattern_var=@"^\w+$"; // запись возможной переменной (но она не корректна)

                if (Regex.IsMatch(s, pattern_var, RegexOptions.IgnoreCase))
                {
                    // скорее всего введена не та переменная
                    throw new WrongElementException("Неизвестная переменная: " + s + "\nПроверьте выражение ещё раз");
                }
                else if (s.Length == 1)
                {
                    // введён необрабатываемый символ
                    throw new WrongElementException("Неизвестный символ: " + s + "\nПроверьте выражение ещё раз");
                }
                else
                {
                    // введена необрабатываемая последовательность символов
                    throw new WrongElementException("Неизвестная последовательность символов: " + s + "\nПроверьте выражение ещё раз");
                }
            }
        }

    }
}
