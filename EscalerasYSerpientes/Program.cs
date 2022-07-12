using EscalerasYSerpientes.Model;
using System;
using System.Collections.Generic;

namespace EscalerasYSerpientes
{
    class Program
    {
        private static List<Jugador> listJugadores;
        static void Main(string[] args)
        {
            //Se inicializa listado de jugadores
            listJugadores = new List<Jugador>();
            
            //Se crean jugadores
            int numJugadores = CreacionJugadores();

            //En caso de no haber jugadores se finaliza el juego.
            if (numJugadores > 0)
            {
                //Empieza la partida
                EmpezarPartida(numJugadores);
            }

            //Mensaje de despedida y fin del juego
            Console.WriteLine(Constantes.MDespedida);

        }

        private static void EmpezarPartida(int numJugadores)
        {
            int turnoJugador = 0;
            while (true)
            {
                //Se selecciona el turno del jugador actual
                Jugador jugadorActual = listJugadores[turnoJugador];
                Console.WriteLine(String.Format(Constantes.MJugando,jugadorActual.Nombre));
                
                //Se espera escritura del jugador
                string lectura = Console.ReadLine();
                if (lectura.ToLower().Equals(Constantes.No)) 
                {
                    //Se finalizara el juego
                    Console.WriteLine(Constantes.MSalirJuego);
                    if (Console.ReadLine().ToLower().Equals(Constantes.Si))
                        return; 
                    
                }else if(lectura.ToLower().Equals(Constantes.Si))
                {
                    //El jugador lanzará el dado
                    Console.WriteLine(jugadorActual.LanzarDado());

                    //Comprobando si el jugador actual se encuentra en la casilla final (en este caso 100)
                    if (jugadorActual.EsGanador)
                    {
                        Console.WriteLine(String.Format(Constantes.MGanador,jugadorActual.Nombre));
                        return; 
                    }
                    //Se incrementa el número del jugador para que continue el siguiente
                    turnoJugador++;
                    if (turnoJugador >= numJugadores)
                        turnoJugador = 0;   
                }
                    
            }
        }

        private static int CreacionJugadores()
        {
            Console.WriteLine(Constantes.MBienvenida, (int)Constantes.Juego.MinJugadores, (int)Constantes.Juego.MaxJugadores);

            while (true)
            {
                //Se espera escritura con el número de jugadores
                string lectura = Console.ReadLine();
                //Si el resultado es númerico entre el número de jugadores permitidos (esta vez es de 2 a 6)
                if (int.TryParse(lectura, out int numJugadores) && numJugadores >= (int)Constantes.Juego.MinJugadores && numJugadores <= (int)Constantes.Juego.MaxJugadores)
                {
                    
                    for (int i = 1; i <= numJugadores; i++)
                    {
                        string nombre = "Jugador" + i;
                        listJugadores.Add(new Jugador(nombre));
                        Console.WriteLine(String.Format(Constantes.MAddJugador,nombre));
                    }
                    return numJugadores;
                }
                else //Si el resultado es diferente al esperado se recuerda el valor a introducir y se da la opción a finalizar el juego
                {
                    if (lectura.ToLower().Equals(Constantes.SalirJuego))
                        return 0;
                    
                    Console.WriteLine(String.Format(Constantes.MSelJugadores, Constantes.SalirJuego, (int)Constantes.Juego.MinJugadores, (int)Constantes.Juego.MaxJugadores));
                }
            }
        }
    }
}
