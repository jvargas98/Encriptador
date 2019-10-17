using System;

namespace Encriptador
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcionReintentar;
            do
            {
                string opcionString, cadena;
                int opcion;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Encriptar");
                    Console.WriteLine("2. Desencriptar");
                    Console.WriteLine("Escoge una opcion");
                    opcionString = Console.ReadLine();
                    opcion = int.Parse(opcionString);
                } while (opcion > 2);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingresa la cadena a encriptar: ");
                        cadena = Console.ReadLine();

                        Encriptar(cadena);
                        break;
                    case 2:
                        Console.WriteLine("Ingresa la cadena a desencriptar: ");
                        cadena = Console.ReadLine();
                        Desencriptar(cadena);
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("¿Desea realizar otra operacion? (S / N)");
                opcionReintentar = Console.ReadLine();
            } while ((opcionReintentar == "s") || (opcionReintentar == "S"));
        }

        static void Encriptar(string cadena)
        {
            string operacion = "suma";
            char[] array;

            array = cadena.ToCharArray();

            array = fibonacci(array, operacion);
            foreach (char caracter in array)
            {
                Console.Write(caracter);
            }

            String[] arrayConvertido = new String[array.Length];

            arrayConvertido = convertirHex(array);
            Console.Write("Cadena encriptada : ");
            foreach (string caracter in arrayConvertido)
            {
                Console.Write(caracter);
            }
        }

        static void Desencriptar(string cadenaEncriptada)
        {
            string operacion = "resta";
            string cadena = convertirCadena(cadenaEncriptada);

            char[] array;

            array = cadena.ToCharArray();

            array = fibonacci(array, operacion);
            Console.Write("Cadena desencriptada : ");
            foreach (char caracter in array)
            {
                Console.Write(caracter);
            }
        }

        static char[] fibonacci(char[] array, string operacion) {
           
            int[] fibonacci = new int[array.Length+1]; 
            fibonacci[1] = 1; 
            fibonacci[2] = 1; 
            
            for (int i = 3; i < array.Length+1; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2]; 
            }
            
            for (int i = 1; i < fibonacci.Length; i++)
            { 
                if(operacion == "suma")
                    array[i - 1] += (char)fibonacci[i];
                else
                    array[i - 1] -= (char)fibonacci[i];
            }
            return array;
        }

        static String[] convertirHex(char[] array) {

            int aux;
            String[] arrayConvertido = new String[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                aux = Convert.ToInt32(array[i]);
                string hexCaracter = String.Format("{0:X}", aux);
                arrayConvertido[i] = hexCaracter;
            }

            return arrayConvertido;
        }

        static string convertirCadena(string cadenaHex)
        {
            string cadena = "";
            for (int i = 0; i < cadenaHex.Length; i += 2)
            {
                string hexChar = cadenaHex.Substring(i, 2);
                cadena += ((char)Convert.ToByte(hexChar, 16));
            }
            return cadena;
        }
    }
}
