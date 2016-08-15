using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;





//
//  Nombre Aplicacion: PcTroll
//  Descripción: Programa que se ejectuca en segundo plano y que genera movimientos aleatorios del rantón, sonidos de sistema, inputs de teclas aleatorios y 
//  genera popups de error y alerta de modo que el usuario no sabe lo que ocurre con su ordenador 
//


namespace PcTroll
{

    class Program
    {
        static Random nRandom = new Random();
        static int numero = 5;
        static void Main(string[] args)
        {
            //Se generan una serie de hilos para que se ejectuen de manera paralela
            Thread generaLetrasThread = new Thread(new ThreadStart(generaLetras));

            generaLetrasThread.Start();


            Console.ReadLine();
            generaLetrasThread.Abort();
        }

        static void generaLetras()
        {
            while (true)
            {
                //le añadimos una probabilidad de que escriba una letra
                if (nRandom.Next(10) > 1)
                {
                    char letra = (char)((nRandom.Next(26) + 65));
                    //en caso de que la escriba esa tiene una probabilidad de ser minuscula
                    if (nRandom.Next(10) > 4)
                    {
                        letra = char.ToLower(letra);
                }

                    SendKeys.SendWait(letra.ToString());

                }

                Thread.Sleep(300);
            }

        }
    }
}
