using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Operando, representa un numero.
    /// </summary>
    public class Operando
    {
        #region Atributos y Propiedades
        /// <summary>
        /// Representa un numero.
        /// </summary>
        private double numero;
        
        /// <summary>
        /// Propiedad, setea el valor de numero.
        /// </summary>
        public string Numero
        {
            set { this.numero = this.ValidarOperando(value); }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto. Inicializa numero en "0"
        /// </summary>
        public Operando(): this(0) {}

        /// <summary>
        /// Recibe un Double e inicializa numero.
        /// </summary>
        /// <param name="numero">(Double)</param>
        public Operando(double numero): this(numero.ToString()) { }

        /// <summary>
        /// Recibe un string representando un numero e inicializa numero.
        /// </summary>
        /// <param name="strNumero">(String)</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Convierte un numero binario (string) a decimal (string)
        /// </summary>
        /// <param name="binario">(String)</param>
        /// <returns>(string) numeroDecimal</returns>
        public string BinarioDecimal(string binario)
        {
            if (this.EsBinario(binario))
            {
                char[] array = binario.ToCharArray();
                Array.Reverse(array);
                int numeroDecimal = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        // Usamos la potencia de 2, según la posición
                        numeroDecimal += (int)Math.Pow(2, i);
                    }
                }
                return Math.Abs(numeroDecimal).ToString();
            }
            return "Valor invalido";
        }

        /// <summary>
        /// Convierte un numero decimal (double) a binario (string)
        /// </summary>
        /// <param name="numero">(Double)</param>
        /// <returns>(string) numeroBinario</returns>
        public string DecimalBinario(double numero)
        {
            int aux = (int)numero;
            aux = Math.Abs(aux);
            string numeroBinario = "";
            double resto = 0;
            while (aux > 0)
            {
                resto = aux % 2;
                aux /= 2;
                numeroBinario = resto.ToString() + numeroBinario;
            }

            return numeroBinario;
        }

        /// <summary>
        /// Convierte un numero decimal (string) a binario (string)
        /// </summary>
        /// <param name="numero">(String)</param>
        /// <returns>(string) numeroBinario</returns>
        public string DecimalBinario(string numero)
        {
            double aux1;
            if(double.TryParse(numero, out aux1))
            {
                int aux = (int)aux1;
                aux = Math.Abs(aux);
                if (aux > 0)
                {
                    return this.DecimalBinario(aux);
                }
            }
            return "Valor invalido";
        }

        /// <summary>
        /// verifica que el string que representa el numero binario solo tenga "0" y "1".
        /// </summary>
        /// <param name="binario">(String)</param>
        /// <returns>True si es binario, False si no lo es.</returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Convierte un string a double
        /// </summary>
        /// <param name="strNumero">(string)</param>
        /// <returns>(double) numero</returns>
        private double ValidarOperando(string strNumero)
        {
            return double.Parse(strNumero);
        }
        #endregion

        #region Sobrecargas de operadores
        /// <summary>
        /// Suma 2 obj. Operando
        /// </summary>
        /// <param name="n1">(Operando)</param>
        /// <param name="n2">(Operando)</param>
        /// <returns>(double) n1+n2</returns>
        public static double operator + (Operando n1, Operando n2)
        {
            return n1.numero + n2.numero; 
        }

        /// <summary>
        /// Resta 2 obj. Operando
        /// </summary>
        /// <param name="n1">(Operando)</param>
        /// <param name="n2">(Operando)</param>
        /// <returns>(double) n1-n2</returns>
        public static double operator - (Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica 2 obj. Operando
        /// </summary>
        /// <param name="n1">(Operando)</param>
        /// <param name="n2">(Operando)</param>
        /// <returns>(double) n1*n2</returns>
        public static double operator * (Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide 2 obj. Operando
        /// </summary>
        /// <param name="n1">(Operando)</param>
        /// <param name="n2">(Operando)</param>
        /// <returns>(double) n1/n2</returns>
        public static double operator / (Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }
        #endregion

    }
}
