using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialDeJohnDoe.Entidades
{
    public  class Ortoedro
    {
        public int AristaA { get; set; }

        public int AristaB { get; set; }

        public int AristaC { get; set; }

        public Relleno relleno { get; set; }  

        public int GetArea()
        {
            return 2 * (AristaA * AristaB + AristaB * AristaC + AristaC * AristaA);
        }
        public int GetVolumen()
        {
            return (AristaA * AristaB * AristaC);
        }
        public bool validar()
        {
            bool valido = true;
            if ((AristaA == AristaB) && (AristaB == AristaC) && (AristaA == AristaC))
            {
                valido = false;

            }
            if (AristaA < 0 || AristaB <0 || AristaC < 0)
            {
                valido = false;
            }
            return valido;

        }
    }
}
