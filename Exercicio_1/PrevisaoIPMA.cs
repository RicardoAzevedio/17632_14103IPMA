/*
 Autor: Rui Neiva e Ricardo Azevedo
Data: 02/11/2020
Resolução do exercicio 1 da ficha de trabalho
codigo disponibilizado pelo professor com algumas alteraçoes
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_1
{
    class PrevisaoIPMA
    {
        public string owner { get; set; }
        public string country { get; set; }
        public PrevisaoDia[] data { get; set; }
        public int globalIdLocal { get; set; }
        public DateTime dataUpdate { get; set; }
        public string local { get; set; }
    }
}
