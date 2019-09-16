using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        #region Validacion
        /// <summary>
        /// Valida si el operador ingresado como string es valido para operar
        /// </summary>
        /// <param name="strNumero">String a validar</param>
        /// <returns>En el caso de ser un signo valido retorna el mismo y si no es un signo valido retorna + </returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }
        #endregion

        #region Operar
        /// <summary>
        /// Realiza una operacion entre dos objetos de la misma clase.
        /// </summary>
        /// <param name="num1">1er objeto</param>
        /// <param name="num2">2do objeto</param>
        /// <param name="operador">Operador del cual quiera llevar a cabo la operacion</param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            switch (ValidarOperador(operador))
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    return 0;
            }
        }
        #endregion
    }

    public class Numero
    {
        #region Atributos - Constructores
        private double numero;
        /// <summary>
        /// Contruye un objeto sin pasarle ningun parametro - El atributo se incizializa en 0 - 
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Contruye un objeto mediante un double 
        /// </summary>
        /// <param name="numero">Double, que va a ser guardad en el atributo del objeto</param>
        public Numero(double numero)
        {
            SetNumero = Convert.ToString(numero);
        }
        /// <summary>
        /// Contruye un objeto mediante un string
        /// </summary>
        /// <param name="strNumero">String, el cual va a ser guardado como double en el atributo del objeto</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Valida si el numero es correcto y lo guarda en al atributo Numero
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Validacion
        /// <summary>
        /// Valida si el numero ingresado como string es realmente un numero
        /// </summary>
        /// <param name="strNumero">String a validar</param>
        /// <returns>En el caso de ser un numero retorna el numero y si no es un numero retorna 0</returns>
        public double ValidarNumero(string strNumero)
        {
            double numero;
            if (double.TryParse(strNumero, out numero))
                return numero;
            return 0;
        }
        #endregion

        #region Pasajes de Binario - Decimal
        /// <summary>
        /// Realiza la convercion de un numero Binario a su numero Decimal
        /// </summary>
        /// <param name="binario">Numero binario a convertir</param>
        /// <returns>Si el binario es correcto devuelve su decimal, caso contrario devuelve "Valor invalido"</returns>
        public static string BinarioDecimal(string binario)
        {
            string numero;
            try
            {
                int entero = Convert.ToInt32(binario, 2);

                numero = Convert.ToString(entero);

                return numero;
                
            }
            catch 
            {
                return "Valor invalido";
            }

        }
        /// <summary>
        /// Realiza la convercion de un numero Decimal a su numero Binario
        /// </summary>
        /// <param name="binario">Numero en double Decimal a convertir</param>
        /// <returns>Si el decimal es correcto devuelve su binario, caso contrario devuelve "Valor invalido"</returns>
        public static string DecimalBinario(double numero)
        {
            string binario = "";

            int entero = (int)numero;
            if (entero > 0)
            {
                while (entero > 0)
                {
                    binario = entero % 2 + binario;
                    entero = entero / 2;
                }

                return binario;
            }
            else if (entero == 0)
            {
                return "0";
            }
            else
            {
                return "Valor invalido";
            }

        }
        /// <summary>
        /// Realiza la convercion de un numero Decimal a su numero Binario
        /// </summary>
        /// <param name="binario">Numero en string Decimal a convertir</param>
        /// <returns>Si el decimal es correcto devuelve su binario, caso contrario devuelve "Valor invalido"</returns>
        public static string DecimalBinario(string numero)
        {
            return DecimalBinario(double.Parse(numero));
        }
        #endregion

        #region Sobrecargas de operadores
        /// <summary>
        /// Realiza la suma entre los atributos de los objetos.
        /// </summary>
        /// <param name="n1">1er objeto</param>
        /// <param name="n2">2do objeto</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Realiza la resta entre los atributos de los objetos.
        /// </summary>
        /// <param name="n1">1er objeto</param>
        /// <param name="n2">2do objeto</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Realiza la multiplicacion entre los atributos de los objetos.
        /// </summary>
        /// <param name="n1">1er objeto</param>
        /// <param name="n2">2do objeto</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Realiza la divicion entre los atributos de los objetos.
        /// </summary>
        /// <param name="n1">1er objeto</param>
        /// <param name="n2">2do objeto</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
                return n1.numero / n2.numero;
            return double.MinValue;
        }
        #endregion

    }
}
