using Simulacion_TP1.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulacion_TP1.Controlador
{
    public class GestorAtentados
    {
        Gestor gestor;
        Random randomTipoAtentado;
        Random randomLlegadaAtentado;
        GestorRungeKutta gestorRungeKutta;

        public GestorAtentados(Gestor gestor)
        {
            this.randomTipoAtentado = new Random();
            Thread.Sleep(1);
            this.randomLlegadaAtentado = new Random();
            this.GestorRungeKutta = new GestorRungeKutta();
            this.gestor = gestor;
        }

        public Gestor Gestor { get => gestor; set => gestor = value; }
        public GestorRungeKutta GestorRungeKutta { get => gestorRungeKutta; set => gestorRungeKutta = value; }

        public Fila llegadaAtentado(Fila filaAnterior)
        {

            Fila filaNueva = new Fila();
            filaNueva.clonar(filaAnterior);

            filaNueva.Hora = filaAnterior.Atentado.Tiempo;
            filaNueva.EventoActual = filaAnterior.Atentado;

            filaNueva.Atentado = null;

            double numRandom = this.randomTipoAtentado.NextDouble();
            if (numRandom < 0.7)
            {
                double duracion = GestorRungeKutta.generarTablaRungeKuttaBloqueo(0, filaNueva.Hora);
                filaNueva.FinAtentadoLlegada = new Evento("finAtentadoLlegada", filaNueva.Hora + duracion);
                filaNueva.LlegadaBloqueda = true;

            }
            else
            {
                double duracion = GestorRungeKutta.generarTablaRungeKuttaServidor(0, filaNueva.Hora);
                filaNueva.FinAtentadoServidor = new Evento("finAtentadoServidor", filaNueva.Hora + duracion);

                //Si el servidor esta atendiendo:
                //estado del servidor a bloqueado
                //aumentar el tiempo fin atencion al remanente actual mas la duracion del bloqueo
                //estado del cliente en esperando fin bloqueo servidor
                //Si el servidor no esta atendiendo:
                //estado del servidor a bloqueado


                //filaNueva.Alicia1.Estado = "BloqueadoSinCliente";
                //filaNueva.BloqueoActivo = true;

                //if (filaAnterior.Alicia1.Estado == "Ocupado")
                //{
                //    filaNueva.Alicia1.Estado = "BloqueadoConCliente";
                //    double tiempoRemanente = filaAnterior.FinAtencionMatriculaAlicia.Tiempo - filaNueva.Hora;
                //    filaNueva.FinAtencionMatriculaAlicia.Tiempo = filaNueva.Hora + tiempoRemanente + duracion;
                //    filaNueva.FinAtencionMatriculaAlicia.ClienteMatricula.Estado = "Esperando Fin Bloqueo Servidor";

                //}

                filaNueva.BloqueoActivo = true;
                bool ocupado = false;
                if (filaAnterior.Alicia1.Estado == "Ocupado")
                {
                    ocupado = true;
                }
                if (ocupado)
                {
                    filaNueva.Alicia1.Estado = "BloqueadoConCliente";
                    double tiempoRemanente = filaAnterior.FinAtencionMatriculaAlicia.Tiempo - filaNueva.Hora;
                    filaNueva.FinAtencionMatriculaAlicia.Tiempo = filaNueva.Hora + tiempoRemanente + duracion;
                    filaNueva.FinAtencionMatriculaAlicia.ClienteMatricula.Estado = "Esperando Fin Bloqueo Servidor";

                }
                if (!ocupado)
                {
                    filaNueva.Alicia1.Estado = "BloqueadoSinCliente";
                }
            }





            return filaNueva;
        }

        public Fila finAtentadoBloqueoServidor(Fila filaAnterior)
        {
            Fila filaNueva = new Fila();
            filaNueva.clonar(filaAnterior);

            filaNueva.Hora = filaAnterior.FinAtentadoServidor.Tiempo;
            filaNueva.EventoActual = filaAnterior.FinAtentadoServidor;
            //Generar proximo atentado
            double numRandom = this.randomLlegadaAtentado.NextDouble();///ATENCIONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN USAR GENERADOR DISTINTO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            double duracion = GestorRungeKutta.generarTablaRungeKuttaLlegada(0, 199, numRandom);
            filaNueva.Atentado = new Evento("atentado", filaNueva.Hora + duracion);
            filaNueva.FinAtentadoServidor = null;

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
            filaNueva.BloqueoActivo = false;

            if (! (filaAnterior.Descanso.Servidor.Nombre == "Maria"))
            {
                bool flag = false;
                Cliente clienteBloqueado = null;
                foreach (Cliente cliente in filaAnterior.ClientesMatriculaEnElSistema)
                {
                    if (cliente.Estado == "Esperando Fin Bloqueo Servidor")
                    {
                        flag = true;
                        clienteBloqueado = cliente;
                        break;
                    }
                }

                if (flag)
                {
                    clienteBloqueado.Estado = "Siendo Atendido";
                    filaNueva.Alicia1.Estado = "Ocupado";
                }
                else
                {
                    if (filaAnterior.ColaMatricula > 0 && (filaAnterior.Alicia1.DescansoPendiente == false))
                    {
                        List<Cliente> clientesEnElSistema = filaAnterior.ClientesMatriculaEnElSistema;
                        Cliente cliente = gestor.buscarProximoCliente(clientesEnElSistema);
                        if (cliente == null)
                        {
                            filaNueva.Alicia1.Estado = "Libre";
                            filaNueva.FinAtencionMatriculaAlicia = null;
                            filaNueva.ColaMatricula--;

                        }
                        else
                        {
                            cliente.Estado = "Siendo Atendido";
                            Evento finAtencionMatricula = new Evento("finAtencionMatriculaAlicia", cliente, filaAnterior.Alicia1, gestor.obtenerProximoFinAtencionMatricula() + filaNueva.Hora);
                            filaNueva.FinAtencionMatriculaAlicia = finAtencionMatricula;
                            filaNueva.ColaMatricula--;
                            filaNueva.Alicia1.Estado = "Ocupado";
                        }

                    }
                    if (filaAnterior.ColaMatricula == 0 && (filaAnterior.Alicia1.DescansoPendiente == false))
                    {
                        filaNueva.Alicia1.Estado = "Libre";
                        filaNueva.FinAtencionMatriculaAlicia = null;
                    }
                    if (filaAnterior.ColaMatricula >= 0 && (filaAnterior.Alicia1.DescansoPendiente == true))
                    {

                        filaNueva.Descanso = new Evento("descanso", filaAnterior.Maria1, filaNueva.Hora + 30, 30);
                        filaNueva.Alicia1.Estado = "Descansando";
                        filaNueva.Alicia1.DescansoPendiente = false;
                        filaNueva.FinAtencionMatriculaAlicia = null;
                        //filaNueva.ColaMatricula--;
                    }
                }



     
            }
            else
            {
                filaNueva.Alicia1.Estado = "Descansando";
            }

            //if (filaAnterior.DescansoActivo1)
            //{
            //    filaNueva.Alicia1.Estado = "Descansando";
            //}

            return filaNueva;

            

        }

        public Fila finAtentadoBloqueoLlegada(Fila filaAnterior)
        {

            Fila filaNueva = new Fila();
            filaNueva.clonar(filaAnterior);

            filaNueva.Hora = filaAnterior.FinAtentadoLlegada.Tiempo;
            filaNueva.EventoActual = filaAnterior.FinAtentadoLlegada;
            //Generar proximo atentado
            double numRandom = this.randomLlegadaAtentado.NextDouble();///ATENCIONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN USAR GENERADOR DISTINTO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            double duracion = GestorRungeKutta.generarTablaRungeKuttaLlegada(0, 199, numRandom);
            filaNueva.Atentado = new Evento("atentado", filaNueva.Hora + duracion);
            filaNueva.LlegadaBloqueda = false;
            filaNueva.FinAtentadoLlegada = null;
            

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
            filaNueva.ClientesColaLlegada.Clear();

            return filaNueva;
        }


        public double obtenerProximoAtentado()
        {
            double numRandom = this.randomLlegadaAtentado.NextDouble();
            return GestorRungeKutta.generarTablaRungeKuttaLlegada(0, 199, numRandom);
            
        }

        
    }
   
}
