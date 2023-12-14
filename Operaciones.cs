using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCalculadora
{
    //Esta clase es para realizar las operaciones
    public class Operaciones
    {
        public double HacerOperacion(double num1, double num2, string operacion, string lblNumeros)
        {

            if (lblNumeros != string.Empty)
            {

                num2 = double.Parse(lblNumeros);
                double resultado = 0;

                switch (operacion)
                {
                    case "÷":
                        resultado = num1 / num2;
                        break;
                    case "x":
                        resultado = num2 * num1;
                        break;
                    case "+":
                        resultado = num1 + num2;
                        break;
                    case "-":
                        resultado = num1 - num2;
                        break;
                }
                return resultado;
            } else {
                return double.Parse("ERROR");
            }
        }

        //Este método multiplica el número por el mismo
        public double ElevarNumero (double num1) { 
            
            double resultado = 0;
            resultado = num1 * num1;
            return resultado;
        }
    }
}
