using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionNET
{
    class Program
    {


        static void Main(string[] args)
        {

            Console.WriteLine("Bienvenid@.");
            Console.WriteLine("******************************************");
            Console.WriteLine("1. Obtener el valor absoluto de un número");
            Console.WriteLine("******************************************");
            Console.Write("Digite una opción: ");
            int opcion = int.Parse(Console.ReadLine());
            while (opcion>10 || opcion<1)
            {
                Console.Write("Digite una opción entre 1 y 10: ");
                opcion = int.Parse(Console.ReadLine());    
            }
            switch (opcion)
            {
                case 1:
                    ejercicio1();
                    break;
            }
            Console.ReadKey();
        }

        private static void ejercicio1()
        {
            Console.Write("Digite un número: ");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("El valor absoluto de {0} es: {1}", numero, getValorAbsoluto(numero));
        }


        private static int getValorAbsoluto(int numero)
        {
            //if (numero < 0)
            //{
            //    return -numero;
            //}
            //else
            //{
            //    return numero;
            //}
            //-----------------
            //if (numero<0)
            //{
            //    return -numero;
            //}
            //return numero;
            //-----------------
            return (numero < 0) ? -numero : numero;
        }






    }
}


/*
            Console.WriteLine("Digite la cantidad de pisos");
            int pisos = int.Parse(Console.ReadLine());
            int espacios = pisos - 1;
            int asteriscos = 1;
            for (int i = 0; i < pisos; i++)
            {
                string linea = "";
                for (int j = 0; j < espacios; j++)
                {
                    linea += " ";
                }
                for (int k = 0; k < asteriscos; k++)
                {
                    linea += "*";
                }
                Console.WriteLine(linea);
                espacios--;
                asteriscos += 2;
            }
            */