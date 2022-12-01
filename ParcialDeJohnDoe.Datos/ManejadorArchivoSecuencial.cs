using ParcialDeJohnDoe.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialDeJohnDoe.Datos
{
    class ManejadorArchivoSecuencial
    {
        
        private static string archivo = "Ortoedros.text";

        public static void GuardarEnArchivo(List<Ortoedro> lista)
        {
            using (var escritor = new StreamWriter(archivo))
            {
                foreach (var ortoedro in lista)
                {
                    string linea = ConstuirLinea(ortoedro);
                    escritor.WriteLine(linea);
                }
            }
        }

        private static string ConstuirLinea(Ortoedro ortoedro)
        {
            return $"{ortoedro.AristaA}|{ortoedro.AristaB}|{ortoedro.AristaC}|{(int)ortoedro.relleno}";
        }

        public static List<Ortoedro> LeerDelArchivo()
        {
            List<Ortoedro> lista = new List<Ortoedro>();
            using (var lector = new StreamReader(archivo))
            {
                while (!lector.EndOfStream)
                {
                    string linea = lector.ReadLine();
                    Ortoedro ortoedro = CrearOrtoedro(linea);
                    lista.Add(ortoedro);
                }
            }

            return lista;
        }

        private static Ortoedro CrearOrtoedro(string linea)
        {
            var campos = linea.Split('|');
            Ortoedro ortoedro = new Ortoedro()
            {
                AristaA = int.Parse(campos[0]),
                AristaB = int.Parse(campos[1]),
                AristaC = int.Parse(campos[2]),
                relleno = (Relleno)int.Parse(campos[3]),
            };
            return ortoedro;
        }
    }
}
