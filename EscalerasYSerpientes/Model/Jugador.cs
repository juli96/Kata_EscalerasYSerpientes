using System;
using System.Collections.Generic;
using System.Text;

namespace EscalerasYSerpientes.Model
{
    //Constantes para no tener que añadir información Hardcode
  
    public class Jugador
    {
        //Propiedad de la clase Ususario
        public string Nombre { get; set;}
        public int Casilla { get; set; }
        public bool EsGanador { get; set; }
        public int UltimaTirada { get; set; }
        private Random rdm = null;

        //Constructor inicial de la clase Jugador
        public Jugador(string _nombre, int? _casilla = null)
        {
            this.Nombre = _nombre;
            this.EsGanador = false;
            this.Casilla = _casilla ?? (int)Constantes.Juego.CasillaInicial;
            rdm = new Random();
        }


        public string LanzarDado(int? tirada = null) 
        {
            //Se guarda el valor de la casilla anterior, si escoje un valor aleatorio del dado (1 al 6) y se le agrega a la casilla del jugador.
            int casillaAnterior = this.Casilla;
            UltimaTirada = tirada ?? rdm.Next(1, 6);
            this.Casilla += UltimaTirada;
            
            //Si la casilla actual es mayor a la casilla final (en este caso 100) vuelve a la casilla anterior
            if (this.Casilla > (int)Constantes.Juego.CasillaFinal)
                this.Casilla = casillaAnterior;

            //Si la casilla actual es igual a la casilla final (en este caso 100) el jugador ha ganado el juego.
            if (this.Casilla == (int)Constantes.Juego.CasillaFinal)
                EsGanador = true;

            //Se devuelve el mensaje para mostrarlo por consola.
            return String.Format(Constantes.MLanzarDados,this.Nombre, UltimaTirada, casillaAnterior,this.Casilla);
        }

    }
}
