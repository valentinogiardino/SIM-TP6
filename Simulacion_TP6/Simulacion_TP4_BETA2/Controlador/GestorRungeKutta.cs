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
        Gestor gestor;
        double duracionAtentadoBloqueo;
        double duracionAtentadoServidor;
        double tiempoProximoAtentado;
        double h;
        double X0;
        double Y0;
        double L;
        double S;
        double k;

        public GestorRungeKutta(Gestor gestor)
        {
            this.Gestor = gestor;
        }

        public Gestor Gestor { get => gestor; set => gestor = value; }

        public double ecuacionDiferencialLlegada(double Ym)
        {
            return this.k * Ym;
        }

        public double ecuacionDiferencialBloqueo(double L)
        {
            return -((L / 0.8) * Math.Pow(L, 2)) - L;
        }

        public double ecuacionDiferencialServidor(double S, double t)
        {
            return (0.2*S)+ 3 - t;
        }

        public FilaRungeKutta generarFilaLlegada(FilaRungeKutta filaAnterior)
        {
            
            double Xm = filaAnterior.ProxXm;
            double Ym = filaAnterior.ProxYm;
            double K1 = ecuacionDiferencialLlegada(Ym);
            double A = Xm + (this.h / 2);
            double B = Ym + (this.h / 2) * K1;
            double K2 = ecuacionDiferencialLlegada(B);
            double C = A;
            double D = Ym + (this.h / 2) * K2;
            double K3 = ecuacionDiferencialLlegada(D);
            double E = Xm + this.h;
            double F = Ym + (this.h / 2) * K3;
            double K4 = ecuacionDiferencialLlegada(F);
            double proxXm = E;
            double proxYm = Ym + (this.h / 6) * K1 + (2 * K2) + (2 * K3) + K4;


            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);
            return fila;

        }

        public FilaRungeKutta generarFilaBloqueo( FilaRungeKutta filaAnterior)
        {
            double Xm = filaAnterior.ProxXm;
            double Ym = filaAnterior.ProxYm;
            double K1 = ecuacionDiferencialBloqueo(Ym);
            double A = Xm + (this.h / 2);
            double B = Ym + (this.h / 2) * K1;
            double K2 = ecuacionDiferencialBloqueo(B);
            double C = A;
            double D = Ym + (this.h / 2) * K2;
            double K3 = ecuacionDiferencialBloqueo(D);
            double E = Xm + this.h;
            double F = Ym + (this.h / 2) * K3;
            double K4 = ecuacionDiferencialBloqueo(F);
            double proxXm = E;
            double proxYm = Ym + (this.h / 6) * K1 + (2 * K2) + (2 * K3) + K4;


            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);
            return fila;
        }

        public FilaRungeKutta generarFilaServidor( FilaRungeKutta filaAnterior)
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
            double proxYm = Ym + (this.h / 6) * K1 + (2 * K2) + (2 * K3) + K4;


            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);
            return fila;
        }

        public void generarTablaRungeKuttaLlegada()
        {
            
            double Xm = this.X0;
            double Ym = this.Y0;
            double K1 = ecuacionDiferencialLlegada(Ym);
            double A = Xm + (this.h / 2);
            double B = Ym + (this.h / 2) * K1;
            double K2 = ecuacionDiferencialLlegada(B);
            double C = A;
            double D = Ym + (this.h / 2) * K2;
            double K3 = ecuacionDiferencialLlegada(D);
            double E = Xm + this.h;
            double F = Ym + (this.h / 2) * K3;
            double K4 = ecuacionDiferencialLlegada(F);
            double proxXm = E;
            double proxYm = Ym + (this.h / 6) * K1 + (2 * K2) + (2 * K3) + K4;

            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);

            while (fila.Ym1 < (this.Y0 * 2))
            {
                fila = generarFilaLlegada(fila);
                DataTable tablaRungeKutta = new DataTable();
                tablaRungeKutta.Rows.Add(fila);
            }

            this.tiempoProximoAtentado = fila.Xm1 * 9; 
        }

        public void generarTablaRungeKuttaBloqueo()
        {

            double Xm = this.X0;
            double Ym = this.L;
            double K1 = ecuacionDiferencialBloqueo(Ym);
            double A = Xm + (this.h / 2);
            double B = Ym + (this.h / 2) * K1;
            double K2 = ecuacionDiferencialBloqueo(B);
            double C = A;
            double D = Ym + (this.h / 2) * K2;
            double K3 = ecuacionDiferencialBloqueo(D);
            double E = Xm + this.h;
            double F = Ym + (this.h / 2) * K3;
            double K4 = ecuacionDiferencialBloqueo(F);
            double proxXm = E;
            double proxYm = Ym + (this.h / 6) * K1 + (2 * K2) + (2 * K3) + K4;

            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);

            while (Math.Abs(fila.ProxYm - fila.Ym1) < 1)
            {
                fila = generarFilaBloqueo(fila);
                DataTable tablaRungeKutta = new DataTable();
                tablaRungeKutta.Rows.Add(fila);
            }

            this.duracionAtentadoBloqueo = fila.Xm1 * 5;
        }

        public void generarTablaRungeKuttaServidor()
        {
       
            double Xm = this.X0;
            double Ym = this.S;
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
            double proxYm = Ym + (this.h / 6) * K1 + (2 * K2) + (2 * K3) + K4;

            FilaRungeKutta fila = new FilaRungeKutta(Xm, Ym, K1, A, B, K2, C, D, K3, E, F, K4, proxXm, proxYm);

            while (fila.Ym1 < (this.S * 1.35))
            {
                fila = generarFilaServidor(fila);
                DataTable tablaRungeKutta = new DataTable();
                tablaRungeKutta.Rows.Add(fila);
            }

            this.duracionAtentadoServidor = fila.Xm1 * 2;
        }

    }
}
