using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSolver
{
    // вместо переменной или числовой константы введено что-то другое
    class WrongElementException : Exception
    {
        public WrongElementException(string message)
            : base(message)
        { }
    }

    // введено не уравнение, а что-то другое
    class NotEquationException : Exception
    {
        public NotEquationException(string message)
            : base(message)
        { }
    }

    // синтаксическая ошибка в введённом уравнении(например, отстутсвует скобка)
    class SyntaxException : Exception
    {
        public SyntaxException(string message)
            : base(message)
        { }
    }

    // найдено слишком много корней, и скорее всего их бесконечно много
    class TooManyRootsException : Exception
    {
        public TooManyRootsException(string message)
            : base(message)
        { }
    }
}
