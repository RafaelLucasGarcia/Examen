using System;
using System.Collections.Generic;
using System.Text;

namespace Figuras
{
    public enum Colores {
        Blanco,
        Rojo,
        Verde,
        Azul,
        Negro
    }
    public enum Formas {
        Cuadrado,
        Circulo,
        Triangulo,
        Rectangulo
    }

    public enum Acciones
    {
        Nueva,
        Ver,
        Salir,        
    }

    public class Figura {
        public Figura(Formas forma = Formas.Cuadrado, Colores fondo = Colores.Blanco, Colores borde = Colores.Negro)
        {
            Fondo = fondo;
            Borde = borde;
            Forma = forma;
        }
        public Colores Fondo { get; set; }
        public Colores Borde { get; set; }
        public Formas Forma { get; set; }

        override public string ToString() {
            return "Forma: " + Forma + ",  Fondo: " + Fondo + ", Borde: " + Borde;
        }

    }   

    public class Lienzo {

        public List<Figura> Figuras { get; }

        public Lienzo(List<Figura> figuras = null){
            Figuras = figuras ?? new List<Figura>();
        }
        public void AnadirFigura(Figura f) {
            this.Figuras.Add(f);
        }
        
    }

    public class Consola {

        public void Escribir(string s = "") {
            Console.WriteLine(s);
        }
        public string Leer() {
            return Console.ReadLine();
        }
    }

    public class Toolbar
    {
        public List<Colores> ColoresDisponibles { get; }
        public List<Formas> FormasDisponibles { get; }
        public List<Acciones> AccionesDisponibles { get; }

        public Toolbar(List<Colores> c, List<Formas> f, List<Acciones> a)
        {
            ColoresDisponibles = c;
            FormasDisponibles = f;
            AccionesDisponibles = a;
            
        }

        public Formas SeleccionarForma(string input)
        {            
            var numeroFormas = Enum.GetNames(typeof(Formas)).Length;
            int opcion = Convert.ToInt32(input);

            if (opcion < 0 || opcion > numeroFormas) {
                throw new Exception("Forma seleccionada no disponible");
            }
            Formas forma = (Formas)opcion;
            return forma;
        }
        public Colores SeleccionarColor(string input)
        {
            var numeroFormas = Enum.GetNames(typeof(Colores)).Length;
            int opcion = Convert.ToInt32(input);

            if (opcion < 0 || opcion > numeroFormas)
            {
                throw new Exception("Color seleccionado no disponible");
            }

            Colores color = (Colores)opcion;
            return color;
        }


        public string MostrarFormas()
        {
            string resultado = "";
            int indice = 0;
            foreach (var opcion in Toolbar.FormasDisponibles)
            {
                resultado += indice + " - " + opcion.ToString() + '\n';
                indice++;
            }
            return resultado;
        }

        public string MostrarColores()
        {
            string resultado = "";
            int indice = 0;
            foreach (var opcion in Toolbar.ColoresDisponibles)
            {
                resultado += indice + " - " + opcion.ToString() + '\n';
                indice++;
            }
            return resultado;
        }

        public string MostrarAcciones()
        {
            string resultado = "";
            int indice = 0;

            foreach (var opcion in Toolbar.AccionesDisponibles)
            {
                resultado += indice + " - " + opcion.ToString() + '\n';
                indice++;
            }
            return resultado;
        }

    }

    public class Paint
    {
        public Paint(Lienzo l, Toolbar t, Consola c) {
            Lienzo = l;
            Toolbar = t;
            Consola = c;
        }

        public Lienzo Lienzo { get; set; }
        public Toolbar Toolbar { get; set; }
        public Consola Consola { get; set; }

        public string VerFiguras() {
            var figuras = Lienzo.Figuras;            
            StringBuilder sb = new StringBuilder();

            foreach (var actual in figuras)
            {
                sb.Append(actual.ToString());
                sb.Append("\n");
            }
            return sb.ToString();           
        }

        public void NuevaFigura() {

            Consola.Escribir(Toolbar.MostrarFormas());
            string input = Consola.Leer();
            Formas Forma = Toolbar.SeleccionarForma(input);

            Consola.Escribir(Toolbar.MostrarColores());
            string input = Consola.Leer();
            Colores Borde = Toolbar.SeleccionarColor(input);

            Consola.Escribir(Toolbar.MostrarColores());
            string input = Consola.Leer();
            Colores Fondo = Toolbar.SeleccionarColor(input);
            
            var figura = new Figura(Forma, Fondo, Borde);
            Lienzo.AnadirFigura(figura);
        }        
    }
}