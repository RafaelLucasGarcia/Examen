using System;
using System.Collections.Generic;

namespace Figuras
{
    class Program
    {
        static void Main(string[] args)
        {
            var ColoresDisponibles = new List<Colores>();
            var FormasDisponibles = new List<Formas>();
            var AccionesDisponibles = new List<Acciones>();

            foreach (Colores color in Enum.GetValues(typeof(Colores)))
            {
                ColoresDisponibles.Add(color);
            }
            foreach (Formas forma in Enum.GetValues(typeof(Formas)))
            {
                FormasDisponibles.Add(forma);
            }
            foreach (Acciones accion in Enum.GetValues(typeof(Acciones)))
            {
                AccionesDisponibles.Add(accion);
            }

            var toolbar = new Toolbar(ColoresDisponibles, FormasDisponibles, AccionesDisponibles);
            var consola = new Consola();
            var lienzo = new Lienzo();

            var paint = new Paint(lienzo, toolbar, consola);
            var exit = false;
            string input = "";

            do {
                paint.Consola.Escribir(paint.Toolbar.MostrarAcciones());
                input = paint.Consola.Leer();
                Acciones accion = (Acciones)Convert.ToInt32(input);

                if (accion == Acciones.Nueva)
                {
                    paint.NuevaFigura();
                }
                else if (accion == Acciones.Ver)
                {
                    var figuras = paint.VerFiguras();
                    paint.Consola.Escribir(figuras);
                }
                else if (accion == Acciones.Salir)
                {
                    exit = true;
                }
                
                
                
            } while (!exit);                                             
        }
    }
}
