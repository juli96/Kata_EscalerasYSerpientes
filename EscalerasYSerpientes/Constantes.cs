using System;
using System.Collections.Generic;
using System.Text;

namespace EscalerasYSerpientes
{
    public class Constantes
    {
        //Constantes numericas del juego
        public enum Juego
        {
            CasillaInicial = 1,
            CasillaFinal = 100,
            MaxJugadores = 6,
            MinJugadores = 2
        }

        //Constantes alfanumericas
        public const string MAddJugador = "Añadido {0}.";
        public const string MLanzarDados = "El jugador {0} le ha salido un {1} en el dado. Pasa de la casilla {2} a la casilla {3}.";
        public const string MBienvenida = "¡¡Bienvenidos al juego de Escaleras y Serpientes!!\nIntroduzca el número de jugadores (número del {0} a {1}):";
        public const string MDespedida = "Espero que hayais disfutado. ¡Hasta pronto!";
        public const string MSelJugadores = "Debe introducir un número entre el {1} y el {2}. Si desea salir introduzca \"{0}\".";
        public const string MJugando = "Es el turno de {0}.\n¿Desea tirar el dado? (Si = s, No = n)";
        public const string MSalirJuego = "¿Desea acabar el juego?(Si = s, No = n)";
        public const string MGanador = "¡¡Enhorabuena {0} por llegar a la meta!!";
        public const string SalirJuego = "exit";
        public const string Si = "s";
        public const string No = "n";
    }
}
