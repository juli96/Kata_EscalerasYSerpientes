using EscalerasYSerpientes;
using EscalerasYSerpientes.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EscalasYSerpientesTests
{
    [TestClass]
    public class JuegoTest
    {
        Jugador jugador1;

        //Variables para utilizar 
        private int primeraTirada = 3;
        private int segundaTirada = 4;
        private int primerResulEsperado = 4;
        private int segundoResulEsperado = 8;

        private int posicionInicial = 97;

        #region US1

        [TestMethod]
        public void PrimerUSPrimerCaso()
        {
            jugador1 = new Jugador("Julián");
            Assert.AreEqual((int)Constantes.Juego.CasillaInicial,jugador1.Casilla);
        }

        [TestMethod]
        public void PrimerUSSegundoCaso()
        {
            jugador1 = new Jugador("Julián");
            jugador1.LanzarDado(primeraTirada);
            Assert.AreEqual(primerResulEsperado, jugador1.Casilla);              
        }

        [TestMethod]
        public void PrimerUSTercerCaso()
        {
            jugador1 = new Jugador("Julián");
            jugador1.LanzarDado(primeraTirada);
            Assert.AreEqual(primerResulEsperado, jugador1.Casilla);
            jugador1.LanzarDado(segundaTirada);
            Assert.AreEqual(segundoResulEsperado, jugador1.Casilla);
        }

        #endregion

        #region US2

        [TestMethod]
        public void SegundoUSPrimerCaso()
        {
            jugador1 = new Jugador("Pedro", posicionInicial);
            jugador1.LanzarDado(primeraTirada);
            Assert.AreEqual((int)Constantes.Juego.CasillaFinal, jugador1.Casilla);
            Assert.IsTrue(jugador1.EsGanador);
        }

        [TestMethod]
        public void SegundoUSSegundoCaso()
        {
            jugador1 = new Jugador("Pedro", posicionInicial);
            jugador1.LanzarDado(segundaTirada);
            Assert.AreEqual(posicionInicial, jugador1.Casilla);
            Assert.IsFalse(jugador1.EsGanador);
        }

        #endregion

        #region US3

        [TestMethod]
        public void TercerUSPrimerCaso()
        {
            jugador1 = new Jugador("Juan");
            jugador1.LanzarDado();
            Assert.IsTrue(jugador1.UltimaTirada >= 1 && jugador1.UltimaTirada <= 6);
        }

        [TestMethod]
        public void TercerUSSegundoCaso()
        {
            jugador1 = new Jugador("Juan");
            jugador1.LanzarDado(segundaTirada);
            Assert.AreEqual((int)Constantes.Juego.CasillaInicial + segundaTirada,jugador1.Casilla);
        }

        #endregion

    }
}
