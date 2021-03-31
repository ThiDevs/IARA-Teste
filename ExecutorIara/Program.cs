using System;
using System.Collections.Generic;
using System.Linq;

namespace ExecutorIara
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
            var valid = SomenteImpar(numeros);
            Console.WriteLine(valid ? "O Array contém somente números impares" : "O Array contém pares");

            int[] numeros2 = { 1, 3, 5, 13, 21, 55, 89 };
            //int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
            valid = SomenteImpar(numeros2);
            Console.WriteLine(valid ? "O Array contém somente números impares" : "O Array contém pares");


            string[] duplicados = { "abracadabra", "allottee", "assessee" };
            var lista = RemoverDuplicados(duplicados);

            Console.WriteLine(string.Join(", ", lista));

            string[] duplicados2 = { "kelless", "keenness" };
            lista = RemoverDuplicados(duplicados2);

            Console.WriteLine(string.Join(", ", lista));

          


        }

        public static bool SomenteImpar(int[] numeros) {

            var valid = false;
            numeros.ToList().All( n => {
                valid = !(n % 2 == 0);

                return valid;
            });

            return valid;
        }

        public static List<String> RemoverDuplicados(string[] duplicados)
        {

            var valid = false;
            var letraaux = "";
            var palavra = "";

            var lista = new List<String>();

            duplicados.ToList().All(n => {
                valid = n.All(s => {
                    var letra = s.ToString();

                    if (letra != letraaux)
                        palavra += letra;

                    letraaux = s.ToString();

                    return true;
                });
                lista.Add(palavra);
                letraaux = "";
                palavra = "";
                return valid;
            });

            return lista;
        }

    }
}
