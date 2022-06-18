using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_TP1.Clases
{
    public class FilaRungeKutta
    {
        double Xm;
        double Ym;
        double K1;
        double a;
        double b;
        double K2;
        double c;
        double d;
        double K3;
        double e;
        double f;
        double K4;
        double proxXm;
        double proxYm;

        public FilaRungeKutta(double xm, double ym, double k1, double a, double b, double k2, double c, double d, double k3, double e, double f, double k4, double proxXm, double proxYm)
        {
            Xm1 = xm;
            Ym1 = ym;
            K11 = k1;
            this.A = a;
            this.B = b;
            K21 = k2;
            this.C = c;
            this.D = d;
            K31 = k3;
            this.E = e;
            this.F = f;
            K41 = k4;
            this.ProxXm = proxXm;
            this.ProxYm = proxYm;
        }

        public FilaRungeKutta()
        {

        }

        public double Xm1 { get => Xm; set => Xm = value; }
        public double Ym1 { get => Ym; set => Ym = value; }
        public double K11 { get => K1; set => K1 = value; }
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double K21 { get => K2; set => K2 = value; }
        public double C { get => c; set => c = value; }
        public double D { get => d; set => d = value; }
        public double K31 { get => K3; set => K3 = value; }
        public double E { get => e; set => e = value; }
        public double F { get => f; set => f = value; }
        public double K41 { get => K4; set => K4 = value; }
        public double ProxXm { get => proxXm; set => proxXm = value; }
        public double ProxYm { get => proxYm; set => proxYm = value; }



    }

}
