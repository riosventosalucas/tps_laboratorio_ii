using System;

namespace Entidades
{
    /// <summary>
    /// Clase estatica. Posee 2 metodos (Operar y Validar Operador) 
    /// </summary>
    public static class Calculadora
    {
        /// <summary>
        /// Operar devuelve el resultado de una operacion aritmetica entre 2 obj. del tipo Operando.
        /// </summary>
        /// <param name="num1">(Operando) obj</param>
        /// <param name="num2">(Operando) obj</param>
        /// <param name="operador">(Char) Caractaer</param>
        /// <returns>(Double) Resultado de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            switch (ValidarOperador(operador))
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    return num1 / num2;
                default:
                    return Operar(num1, num2, operador);
            }
        }

        /// <summary>
        /// ValidarOperador valida que el operador recibido sea valido.
        /// </summary>
        /// <param name="operador">(Char) operador</param>
        /// <returns>Char</returns>
        private static char ValidarOperador(char operador)
        {
            switch (operador)
            {
                case '+':
                    return '+';
                case '-':
                    return '-';
                case '/':
                    return '/';
                case '*':
                    return '*';
                default:
                    return '+';
            }
        }
    }
}
