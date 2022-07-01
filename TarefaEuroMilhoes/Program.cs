using System;

namespace TarefaEuroMilhoes
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            Desenvolver um programa em C# recorrendo à classe Random que gere os números do EuroMilhões.

            1º Os números estão compreendidos entre 1 e 50.

            2º As estrelas entre 1 e 12.

            3º Não devem existir números repetidos. quer nos números de 1 a 50 quer nas estrelas.

            4º A lista dos números deve surgir ordenada.

            Nota: Consulte algoritmos anteriores para resolver este problema.
            */
            int[] estrelas = new int[2];
            int[] numeros = new int[5];
            Random geradorAleartorio = new Random();

            //dar o primeiro valor a estrela entre 1 e 12
            estrelas[0] = geradorAleartorio.Next(1, 12);

            //atribuir um novo numero a 2 estrela se for repetido volta a fazer
            do
            {
                estrelas[1] = geradorAleartorio.Next(1, 12);
            } while (estrelas[0] == estrelas[1]);

            //gerar os numeros
            for (int indice = 0; indice < numeros.Length; indice++)
            {
                do
                {
                    //Gerar um numero aleartorio ate nao existir igual
                    numeros[indice] = geradorAleartorio.Next(1, 50);
                } while (checkExists(numeros[indice], indice, numeros));

            }

            estrelas = sortArray(estrelas);
            numeros = sortArray(numeros);

            Console.WriteLine("Os números do Euro milhoes são: ");

            foreach (int numero in numeros)
            {
                Console.Write("{0} ", numero);
            }
            Console.Write("+ ");

            foreach (int estrela in estrelas)
            {
                Console.Write("{0} ", estrela);
            }
            Console.ReadKey();


        }
        
        private static bool checkExists(int newValue, int index, int[] array)
        {//percorre o array a ver se o numero ja existe. se existir devolve true
            for (int i = 0; i < index; i++)
            {
                if (array[i] == newValue)
                {
                    return true;
                }

            }
            return false;
        }
        //faz o ordenamento bubblesort
        private static int[] sortArray(int[] array)
        {
            for (int i = 0; i <= array.Length - 2; i++)
            {
                for (int j = 0; j <= array.Length - 2; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array; // devolve o array ordenado

        }
    }

}
