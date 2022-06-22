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
        Random random = new Random();
        GestorRungeKutta gestorRungeKutta = new GestorRungeKutta();

        public GestorAtentados()
        {
            
        }

        public Gestor Gestor { get => gestor; set => gestor = value; }

        


        public Fila llegadaAtentado(Fila filaAnterior)
        {

            Fila filaNueva = new Fila();
            filaNueva.clonar(filaAnterior);

            filaNueva.Hora = filaAnterior.Atentado.Tiempo;
            filaNueva.EventoActual = filaAnterior.Atentado;


            double numRandom = this.random.NextDouble();
            if (numRandom < 0.7)
            {
                double duracion = gestorRungeKutta.generarTablaRungeKuttaBloqueo(0, filaNueva.Hora);
                filaNueva.FinAtentadoLlegada = new Evento("finAtentadoLlegada", filaNueva.Hora + duracion);
                filaNueva.LlegadaBloqueda = true;
            }
            else
            {
                double duracion = gestorRungeKutta.generarTablaRungeKuttaServidor(0, filaNueva.Hora);
                filaNueva.FinAtentadoServidor = new Evento("finAtentadoServidor", filaNueva.Hora + duracion);
                
                //Si el servidor esta atendiendo:
                        //estado del servidor a bloqueado
                        //aumentar el tiempo fin atencion al remanente actual mas la duracion del bloqueo
                        //estado del cliente en esperando fin bloqueo servidor
                //Si el servidor no esta atendiendo:
                        //estado del servidor a bloqueado
            }


           
           

            return filaNueva;
        }

        public Fila finAtentadoBloqueoServidor(Fila filaAnterior)
        {
            Fila filaNueva = new Fila();
            filaNueva.clonar(filaAnterior);

            filaNueva.Hora = filaAnterior.FinAtentadoLlegada.Tiempo;
            filaNueva.EventoActual = filaAnterior.FinAtentadoLlegada;
            //Generar proximo atentado
            double numRandom = this.random.NextDouble();///ATENCIONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN USAR GENERADOR DISTINTO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            double duracion = gestorRungeKutta.generarTablaRungeKuttaLlegada(0, 199, numRandom);
            filaNueva.Atentado = new Evento("atentado", filaNueva.Hora + duracion);


            //Desbloquear Servidor
                //Si hay un cliente esperando fin bloqueo servidor:
                    //Cambiar el estado del servidor a ocupado
                    //Estado del cliente a siendo atendido
                //Sino:
                    //Preguntar por la colas, si hay alguien:
                        //Cambiar el estado del servidor a ocupado
                        //Buscar el cliente que llego primero y setearle el estado siendo atendido
                        //decrementar cola
                    //sino hay nadie en cola:
                        //estado del servidor es libre
                        

        }

        public Fila finAtentadoBloqueoLlegada(Fila filaAnterior)
        {

            Fila filaNueva = new Fila();
            filaNueva.clonar(filaAnterior);

            filaNueva.Hora = filaAnterior.FinAtentadoLlegada.Tiempo;
            filaNueva.EventoActual = filaAnterior.FinAtentadoLlegada;
            //Generar proximo atentado
            double numRandom = this.random.NextDouble();///ATENCIONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN USAR GENERADOR DISTINTO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            double duracion = gestorRungeKutta.generarTablaRungeKuttaLlegada(0, 199, numRandom);
            filaNueva.Atentado = new Evento("atentado", filaNueva.Hora + duracion);

            //Desbloquear
            foreach (Cliente cliente in filaAnterior.ClientesColaLlegada)
            {

                if (cliente.Tipo == "matricula")
                {
                    if (filaNueva.Tomas1.Estado == "Libre")  //&& filaAnterior.Tomas1.descansoPendiente = false) Habria que agregar un atributo en el servidor que sea una bandera para saber si tiene un descanso pendiente
                    {
                        //COMENZAR ATENCION
                        filaNueva.Tomas1.Estado = "Ocupado"; //Cambiar Estado del Servidor a Ocupado
                        cliente.Estado = "Siendo Atendido"; //Cambiar Estado del cliente a SA
                        

                        //Generar y setear fin de atencion
                        Evento finAtencionMatricula = new Evento("finAtencionMatriculaTomas", cliente, filaNueva.Tomas1, gestor.obtenerProximoFinAtencionMatricula() + filaNueva.Hora);
                        filaNueva.FinAtencionMatriculaTomas = finAtencionMatricula;

                        
                    }

                    if (filaNueva.Alicia1.Estado == "Libre")
                    {
                        //COMENZAR ATENCION
                        filaNueva.Alicia1.Estado = "Ocupado"; //Cambiar Estado del Servidor a Ocupado
                        cliente.Estado = "Siendo Atendido"; //Cambiar Estado del cliente a SA
                        

                        //Generar y setear fin de atencion
                        Evento finAtencionMatricula = new Evento("finAtencionMatriculaAlicia", cliente, filaNueva.Alicia1, gestor.obtenerProximoFinAtencionMatricula() + filaNueva.Hora);
                        filaNueva.FinAtencionMatriculaAlicia = finAtencionMatricula;

                       
                    }

                    if (filaNueva.Manuel1.Estado == "Libre")
                    {
                        //COMENZAR ATENCION
                        filaNueva.Manuel1.Estado = "Ocupado"; //Cambiar Estado del Servidor a Ocupado
                        cliente.Estado = "Siendo Atendido"; //Cambiar Estado del cliente a SA
                        

                        //Generar y setear fin de atencion
                        Evento finAtencionMatricula = new Evento("finAtencionMatriculaManuel", cliente, filaNueva.Manuel1, gestor.obtenerProximoFinAtencionMatricula() + filaNueva.Hora);
                        filaNueva.FinAtencionMatriculaManuel = finAtencionMatricula;

                       
                    }
                    else
                    {
                        cliente.Estado = "Esperando Atencion";
                        filaNueva.Estadistica.ContadorDirectoAColaMatricula++;
                        filaNueva.ColaMatricula++;
                       
                    }


                    
                }
                else
                {
                    if (filaNueva.Lucia1.Estado == "Libre")
                    {
                        //COMENZAR ATENCION
                        filaNueva.Lucia1.Estado = "Ocupado"; //Cambiar Estado del Servidor a Ocupado
                        cliente.Estado = "Siendo Atendido"; //Cambiar Estado del cliente a SA
                        

                        //Generar y setear fin de atencion
                        Evento finAtencionRenovacion = new Evento("finAtencionRenovacionLucia", cliente, filaNueva.Lucia1, gestor.obtenerProximoFinAtencionRenovacion() + filaNueva.Hora);
                        filaNueva.FinAtencionRenovacionLucia = finAtencionRenovacion;

                        
                    }

                    if (filaNueva.Maria1.Estado == "Libre")
                    {
                        //COMENZAR ATENCION
                        filaNueva.Maria1.Estado = "Ocupado"; //Cambiar Estado del Servidor a Ocupado
                        cliente.Estado = "Siendo Atendido"; //Cambiar Estado del cliente a SA
                        

                        //Generar y setear fin de atencion
                        Evento finAtencionRenovacion = new Evento("finAtencionRenovacionMaria", cliente, filaNueva.Maria1, gestor.obtenerProximoFinAtencionRenovacion() + filaNueva.Hora);
                        filaNueva.FinAtencionRenovacionMaria = finAtencionRenovacion;

                        
                    }

                    if (filaNueva.Manuel1.Estado == "Libre")
                    {
                        //COMENZAR ATENCION
                        filaNueva.Manuel1.Estado = "Ocupado"; //Cambiar Estado del Servidor a Ocupado
                        cliente.Estado = "Siendo Atendido"; //Cambiar Estado del cliente a SA
                        

                        //Generar y setear fin de atencion
                        Evento finAtencionRenovacion = new Evento("finAtencionRenovacionManuel", cliente, filaNueva.Manuel1, gestor.obtenerProximoFinAtencionRenovacion() + filaNueva.Hora);
                        filaNueva.FinAtencionRenovacionManuel = finAtencionRenovacion;

                        
                    }
                    else
                    {
                        cliente.Estado = "Esperando Atencion";
                        filaNueva.Estadistica.ContadorDirectoAColaRenovacion++;
                        filaNueva.ColaRenovacion++;
                    }
                    
                }
            }

            return filaNueva;
        }




        
    }
   
}
