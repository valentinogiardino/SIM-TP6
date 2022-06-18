using Simulacion_TP1.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_TP1.Controlador
{
    public class GestorAtentados
    {
        Gestor gestor;

        public GestorAtentados(Gestor gestor)
        {
            this.Gestor = gestor;
        }

        public Gestor Gestor { get => gestor; set => gestor = value; }

        public Fila generarAtentado(Fila filaAnterior)
        {
            Random random = new Random();
            GestorRungeKutta gestorRungeKutta = new GestorRungeKutta(199, filaAnterior.Hora);
            Fila filaNueva = new Fila();
            filaNueva.clonar(filaAnterior);

            filaNueva.Hora = filaAnterior.Atentado.Tiempo;
            filaNueva.EventoActual = filaAnterior.Atentado;

            double numRandom = random.NextDouble();

            if (numRandom < 0.70)
            {
                filaNueva.EventoActual.Nombre = "atentadoBloqueo";
                filaNueva.EventoActual.Duracion = calcularDuracionAtentadoLlegada();
            }

            return filaNueva;
        }

        public double calcularDuracionAtentadoLlegada()
        {
            double duracion = 0;
            duracion = gestorRungeKutta.duracionAtentadoBloqueo();
            return duracion;
        }

    }
   
}
