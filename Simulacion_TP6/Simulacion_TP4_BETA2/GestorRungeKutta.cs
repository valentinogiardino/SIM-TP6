using Simulacion_TP1.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_TP1.Controlador
{
    public class GestorRungeKutta
    {

        double duracionAtentadoBloqueo;
        double duracionAtentadoServidor;
        double tiempoProximoAtentado;
        List<FilaRungeKutta> tablaProximaLlegada = new List<FilaRungeKutta>();
        List<FilaRungeKutta> tablaDuracionBloqueoLlegada = new List<FilaRungeKutta>();
        List<FilaRungeKutta> tablaDuracionBloqueoServidor = new List<FilaRungeKutta>();
        double h;
        double X0;
        double Y0;
        double L;
        double S;
        //double k;

        public GestorRungeKutta()
        {

        }


        public double DuracionAtentadoBloqueo { get => duracionAtentadoBloqueo; set => duracionAtentadoBloqueo = value; }
        public double DuracionAtentadoServidor { get => duracionAtentadoServidor; set => duracionAtentadoServidor = value; }
        public double TiempoProximoAtentado { get => tiempoProximoAtentado; set => tiempoProximoAtentado = value; }
        public List<FilaRungeKutta> TablaProximaLlegada { get => tablaProximaLlegada; set => tablaProximaLlegada = value; }
        public List<FilaRungeKutta> TablaDuracionBloqueoLlegada { get => tablaDuracionBloqueoLlegada; set => tablaDuracionBloqueoLlegada = value; }
        public List<FilaRungeKutta> TablaDuracionBloqueoServidor { get => tablaDuracionBloqueoServidor; set => tablaDuracionBloqueoServidor = value; }


        public double generarTablaRungeKuttaLlegada(double Xo, double Yo, double rnd)
        {
            this.h = 0.05;
            List<FilaRungeKutta> listaFilasRungeKutta = new List<FilaRungeKutta>();
            FilaRungeKutta filaEspacio = new FilaRungeKutta();
            listaFilasRungeKutta.Add(filaEspacio);
            listaFilasRungeKutta.Add(filaEspacio);
            listaFilasRungeKutta.Add(filaEspacio);

            double Xm = Xo;
            double Ym = Yo;
            double K1 = ecuacionDiferencialLlegada(rnd, Ym);
            double A = Xm + (this.h / 2);
            double B = Ym + (this.h / 2) * K1;
            double K2 = ecuacionDiferencialLlegada(rnd, B);
            double C = A;
            double D = Ym + (this.h / 2) * K2;
            double K3 = ecuacionDiferencialLlegada(rnd, D);
            double E = Xm + this.h;
            double F = Ym + (this.h / 2) * K3;
            double K4 = ecuacionDiferencialLlegada(rnd, F);
            double proxXm = E;
            double proxYm = Ym + (this.h / 6) * (K1 + (2 * K2) + (2 * K3) + K4);

            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);


            listaFilasRungeKutta.Add(fila);
            while (fila.Ym1 < (Yo * 2))
            {
                fila = generarFilaLlegada(fila, rnd);
                listaFilasRungeKutta.Add(fila);
            }
            this.TablaProximaLlegada.AddRange(listaFilasRungeKutta);

            double tiempoProximoAtentado = fila.Xm1 * 9;
            return tiempoProximoAtentado;

        }
        public FilaRungeKutta generarFilaLlegada(FilaRungeKutta filaAnterior, double rnd)
        {

            double Xm = filaAnterior.ProxXm;
            double Ym = filaAnterior.ProxYm;
            double K1 = ecuacionDiferencialLlegada(rnd, Ym);
            double A = Xm + (this.h / 2);
            double B = Ym + (this.h / 2) * K1;
            double K2 = ecuacionDiferencialLlegada(rnd, B);
            double C = A;
            double D = Ym + (this.h / 2) * K2;
            double K3 = ecuacionDiferencialLlegada(rnd, D);
            double E = Xm + this.h;
            double F = Ym + (this.h / 2) * K3;
            double K4 = ecuacionDiferencialLlegada(rnd, F);
            double proxXm = E;
            double proxYm = Ym + (this.h / 6) * (K1 + (2 * K2) + (2 * K3) + K4);


            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);
            return fila;

        }
        private double ecuacionDiferencialLlegada(double B, double Ym)
        {
            return B * Ym;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public double generarTablaRungeKuttaBloqueo(double Xo, double Yo)
        {
            this.h = 0.05;
            List<FilaRungeKutta> listaFilasRungeKutta = new List<FilaRungeKutta>();
            FilaRungeKutta filaEspacio = new FilaRungeKutta();
            listaFilasRungeKutta.Add(filaEspacio);
            listaFilasRungeKutta.Add(filaEspacio);
            listaFilasRungeKutta.Add(filaEspacio);

            double Xm = Xo;
            double Ym = Yo;
            double K1 = ecuacionDiferencialBloqueo(Xm, Ym);
            double A = Xm + (this.h / 2);
            double B = Ym + (this.h / 2) * K1;
            double K2 = ecuacionDiferencialBloqueo(A, B);
            double C = A;
            double D = Ym + (this.h / 2) * K2;
            double K3 = ecuacionDiferencialBloqueo(C, D);
            double E = Xm + this.h;
            double F = Ym + (this.h / 2) * K3;
            double K4 = ecuacionDiferencialBloqueo(E, F);
            double proxXm = E;
            double proxYm = Ym + (this.h / 6) * (K1 + (2 * K2) + (2 * K3) + K4);

            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);

            listaFilasRungeKutta.Add(fila);
            while (Math.Abs(fila.ProxYm - fila.Ym1) >= 1)
            {
                fila = generarFilaBloqueo(fila);
                listaFilasRungeKutta.Add(fila);
            }

            this.tablaDuracionBloqueoLlegada.AddRange(listaFilasRungeKutta);
            double duracionAtentadoBloqueo = fila.Xm1 * 5;
            return duracionAtentadoBloqueo;
        }
        public FilaRungeKutta generarFilaBloqueo(FilaRungeKutta filaAnterior)
        {
            double Xm = filaAnterior.ProxXm;
            double Ym = filaAnterior.ProxYm;
            double K1 = ecuacionDiferencialBloqueo(Xm, Ym);
            double A = Xm + (this.h / 2);
            double B = Ym + (this.h / 2) * K1;
            double K2 = ecuacionDiferencialBloqueo(A, B);
            double C = A;
            double D = Ym + (this.h / 2) * K2;
            double K3 = ecuacionDiferencialBloqueo(C, D);
            double E = Xm + this.h;
            double F = Ym + (this.h / 2) * K3;
            double K4 = ecuacionDiferencialBloqueo(E, F);
            double proxXm = E;
            double proxYm = Ym + (this.h / 6) * (K1 + (2 * K2) + (2 * K3) + K4);


            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);
            return fila;
        }
        public double ecuacionDiferencialBloqueo(double Xm, double L)
        {
            return -((L / 0.8) * Math.Pow(Xm, 2)) - L;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public double generarTablaRungeKuttaServidor(double Xo, double Yo)
        {
            this.h = 0.05;
            List<FilaRungeKutta> listaFilasRungeKutta = new List<FilaRungeKutta>();
            FilaRungeKutta filaEspacio = new FilaRungeKutta();
            listaFilasRungeKutta.Add(filaEspacio);
            listaFilasRungeKutta.Add(filaEspacio);
            listaFilasRungeKutta.Add(filaEspacio);

            double Xm = Xo;
            double Ym = Yo;
            double K1 = ecuacionDiferencialServidor(Ym, Xm);
            double A = Xm + (this.h / 2);
            double B = Ym + (this.h / 2) * K1;
            double K2 = ecuacionDiferencialServidor(B, A);
            double C = A;
            double D = Ym + (this.h / 2) * K2;
            double K3 = ecuacionDiferencialServidor(D, C);
            double E = Xm + this.h;
            double F = Ym + (this.h / 2) * K3;
            double K4 = ecuacionDiferencialServidor(F, E);
            double proxXm = E;
            double proxYm = Ym + (this.h / 6) * (K1 + (2 * K2) + (2 * K3) + K4);

            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);

            listaFilasRungeKutta.Add(fila);
            while (fila.Ym1 < (Yo * 1.35))
            {
                fila = generarFilaServidor(fila);
                listaFilasRungeKutta.Add(fila);

            }

            this.tablaDuracionBloqueoServidor.AddRange(listaFilasRungeKutta);
            double duracionAtentadoServidor = fila.Xm1 * 2;
            return duracionAtentadoServidor;
        }
        public FilaRungeKutta generarFilaServidor(FilaRungeKutta filaAnterior)
        {
            double Xm = filaAnterior.ProxXm;
            double Ym = filaAnterior.ProxYm;
            double K1 = ecuacionDiferencialServidor(Ym, Xm);
            double A = Xm + (this.h / 2);
            double B = Ym + (this.h / 2) * K1;
            double K2 = ecuacionDiferencialServidor(B, A);
            double C = A;
            double D = Ym + (this.h / 2) * K2;
            double K3 = ecuacionDiferencialServidor(D, C);
            double E = Xm + this.h;
            double F = Ym + (this.h / 2) * K3;
            double K4 = ecuacionDiferencialServidor(F, E);
            double proxXm = E;
            double proxYm = Ym + (this.h / 6) * (K1 + (2 * K2) + (2 * K3) + K4);


            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);
            return fila;
        }
        public double ecuacionDiferencialServidor(double S, double t)
        {
            return (0.2 * S) + 3 - t;
        }

    }
}
