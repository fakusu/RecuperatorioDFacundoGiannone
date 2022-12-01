using ParcialDeJohnDoe.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialDeJohnDoe.Datos
{
    public class Repositorio
    { 
        
        private List<Ortoedro> listaOrtoedros;
        private bool hayCambios = false;

        public Repositorio()
        {
            listaOrtoedros = new List<Ortoedro>();
            listaOrtoedros = ManejadorArchivoSecuencial.LeerDelArchivo();
        }

        public void Agregar(Ortoedro ortoedro)
        {
            listaOrtoedros.Add(ortoedro);
            hayCambios = true;
        }

        public void Borrar(Ortoedro ortoedro)
        {
            listaOrtoedros.Remove(ortoedro);
            hayCambios = true;
        }

        public void Editar(Ortoedro ortoedro)
        {
            hayCambios = true;
        }

        public List<Ortoedro> GetLista()
        {
            return listaOrtoedros;
        }

        public int GetCantidad()
        {
            return listaOrtoedros.Count;
        }

        public void GuardarEnArchivo()
        {
            if (hayCambios)
            {
                ManejadorArchivoSecuencial.GuardarEnArchivo(listaOrtoedros);
            }
        }


        
    }


}
