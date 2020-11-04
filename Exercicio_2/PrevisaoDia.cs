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

namespace Exercicio_2
{
    class PrevisaoDia
    {
        public string precipitaProb { get; set; }
        public string tMin { get; set; }
        public string tMax { get; set; }
        public string predWindDir { get; set; }
        public int idWeatherType { get; set; }
        public int classWindSpeed { get; set; }
        public string longitude { get; set; }
        public string forecastDate { get; set; }
        public int classPrecInt { get; set; }
        public string latitude { get; set; }
    }
}
