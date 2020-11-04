/*
Autor: Rui Neiva e Ricardo Azevedo
Data: 02/11/2020
Resolução do exercicio 1 da ficha de trabalho
codigo disponibilizado pelo professor com algumas alteraçoes
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Exercicio_1
{
    class Program
    {

        static Dictionary<int, string> LerLocais(string ficheiro)
        {

            Dictionary<int, string> dicLocais = new Dictionary<int, string>();

            // Expressão Regular para instanciar objeto Regex
            String erString = @"^[0-9]{7},[123],([1-9]?\d,){2}[A-Z]{3},([^,\n]*)$";


            // Alternativa 02: depois de ler o conteúdo do ficheiro para uma stream, 
            //                    vai acedendo "linha-a-linha"
            Regex g = new Regex(erString);
            using (StreamReader r = new StreamReader(ficheiro))
            {
                string line;

                while ((line = r.ReadLine()) != null)
                {
                    // Tenta correspondência (macthing) da ER com cada linha do ficheiro
                    Match m = g.Match(line);
                    if (m.Success)
                    {
                        //  estrutura de cada linha com correspondência:
                        //      globalIdLocal,idRegiao,idDistrito,idConcelho,idAreaAviso,local
                        //  separar pelas vírgulas...
                        string[] campos = m.Value.Split(',');
                        int codLocal = int.Parse(campos[0]);
                        string cidade = campos[5];

                        // Guardar na estrutura de dados dicionário
                        dicLocais.Add(codLocal, cidade);
                    }
                    else
                    {
                        Console.WriteLine($"Linha inválida: {line}");
                    }
                }
            }
            return dicLocais;
        }

        //le o ficheiro
        static PrevisaoIPMA LerFicheiroPrevisao(int globalIdLocal)
        {
            String jsonString = null;
            using (StreamReader reader =
                       new StreamReader(@"../../data_forecast/" + globalIdLocal + ".json"))
            {
                jsonString = reader.ReadToEnd();
            }
            PrevisaoIPMA obj = JsonConvert.DeserializeObject<PrevisaoIPMA>(jsonString);
            return obj;
        }

        static void Main(string[] args)
        {
            Dictionary<int, string> dicLocais = LerLocais(@"../../locais.csv");

            // Apenas para mostrar o conteúdo da estrutura dicinário...
            foreach (KeyValuePair<int, string> kv in dicLocais)
            {
                Console.WriteLine($"globalIdLocal= {kv.Key} cidade= {kv.Value}");

                // para cada linha do ficheiro CSV ... 
                PrevisaoIPMA previsaoIPMA = LerFicheiroPrevisao(kv.Key);

                previsaoIPMA.local = kv.Value;

                //...adicionar o json
                //open file stream
                using (StreamWriter file = File.CreateText($@"./Output/{kv.Key}-detalhe.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, previsaoIPMA);
                }
            }

            Console.ReadKey();
        }
    }
}
