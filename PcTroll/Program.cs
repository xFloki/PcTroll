using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Media;

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
            Thread generaMovimientosThread = new Thread(new ThreadStart(generaMovimiento));
            Thread generaSonidosThread = new Thread(new ThreadStart(generaSonidos));
            Thread generaPopupsThread = new Thread(new ThreadStart(generaPopups));

            DateTime inicio = DateTime.Now.AddSeconds(180);
            while (inicio > DateTime.Now) { Thread.Sleep(1000); }

            generaLetrasThread.Start();
            generaMovimientosThread.Start();
            generaSonidosThread.Start();
            generaPopupsThread.Start();

            inicio = DateTime.Now.AddSeconds(180);
            while (inicio > DateTime.Now) { Thread.Sleep(1000); }

            //Console.Read();
            generaLetrasThread.Abort();
            generaMovimientosThread.Abort();
            generaSonidosThread.Abort();
            generaPopupsThread.Abort();
        }

        static void generaLetras()
        {
            while (true)
            {
                //le añadimos una probabilidad de que escriba una letra
                if (nRandom.Next(10) > 7)
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

        static void generaMovimiento()
        {
            int movimientoX;
            int movimientoY;

            while (true)
            {
                //le añadimos una probabilidad de que escriba una letra
                if (nRandom.Next(10) > 3)
                {
                    movimientoX = nRandom.Next(10) - 5;
                    movimientoY = nRandom.Next(10) - 5;

                    Cursor.Position = new System.Drawing.Point(Cursor.Position.X + movimientoX, Cursor.Position.Y + movimientoY);


                }

                Thread.Sleep(200);
            }

        }

        static void generaSonidos()
        {
            while (true)
            {
                //le añadimos una probabilidad de que escriba una letra
                if (nRandom.Next(20) > 15)
                {
                    switch (nRandom.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;

                    }
                }

                Thread.Sleep(1000);
            }

        }

        static void generaPopups()
        {
            while (true)
            {
                //le añadimos una probabilidad de que escriba una letra
                if (nRandom.Next(100) > 90)
                {

                    switch (nRandom.Next(2))
                    {
                        case 0:
                            MessageBox.Show(
                            "Internet explorer ha dejado de funcionar",
                            "Internet Explorer",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            break;

                        case 1:
                            MessageBox.Show(
                            "Batería baja, conecte el cargador",
                            "Microsoft Windows",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                            break;
                    }
                }

                Thread.Sleep(6000);
            }

        }





    }
}

