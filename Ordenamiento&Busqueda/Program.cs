using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenamiento_Busqueda
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    namespace sort_search
    {

        public class MainClass
        {
            public static int[] selectQuantity()
            {
                long dataQuantity = 0; // Cantidad inicial de datos a procesar

                int[] myVector = new int[1]; // Generación de un vector con 2 enteros
                // myVector queda sin referencia (deja de apuntar al vector[2] cuando cumple la condición del ciclo) 
                // y el Garbage Collector lo eliminará

                do
                {
                    System.Console.Write("Por favor digite la cantidad de datos:");
                    
                    dataQuantity = long.Parse(System.Console.ReadLine()); // Parse string input to 64 bit long integer

                    if (dataQuantity < 100000)
                        System.Console.WriteLine("La cantidad de datos debe ser mayor a cien mil.");
                    else
                        myVector = new int[dataQuantity];
                } while (dataQuantity < 100000);
                
                return myVector;
            }

            public static void fillVector(int[] vector, int dataQuantity)
            {
                Random random = new Random();
                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i] = i;
                }
            }

            public static void fillVectorRandom(int[] vector, int dataQuantity )
            {
                Random random = new Random();
                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i] = random.Next(50000, dataQuantity);
                }
            }

            public static long getId()
            {
                long id = 0;

                do
                {
                    System.Console.Write("Por favor digite la identificación a buscar: ");
                    
                    id = long.Parse(System.Console.ReadLine());
                    
                    if (id < 100000 || id > 1250000000)
                        
                        System.Console.WriteLine("Identificación fuera de rango.\n Intente de nuevo.");
                
                } while (id < 100000 || id > 1250000000);
                
                return id;
            }

            public static void printVector(int[] vector)
            {
                for (int i = 0; i < vector.Length; i++)
                    System.Console.WriteLine(vector[i].ToString() + "\t");
            }

            public static int linearSearch(int[] vector, long target)
            {
                
                System.Console.WriteLine("Inicio de la busqueda...");
                
                for (int i = 0; i < vector.Length; i++)
                {
                    if (vector[i] == target)
                    {
                        return i; // Elemento encontrado
                    }
                }
                
                System.Console.WriteLine("Fin de la busqueda. Elemento no encontrado.");
                
                return -1;
            }
            // Linear Complexity (O^n)

            public static int binarySearch(int[] array, long target)
            {
                int low = 0;
                int high = array.Length - 1;

                while (low <= high)
                {
                    int mid = (low + high) / 2;

                    if (array[mid] == target)
                    {
                        return mid; // Elemento encontrado
                    }
                    else if (array[mid] < target)
                    {
                        low = mid + 1; // Buscar en la mitad superior
                    }
                    else
                    {
                        high = mid - 1; // Buscar en la mitad inferior
                    }
                }

                return -1; // Elemento no encontrado
            }
            //The data structure must be sorted.
            // O(Log n) Complexity -> Faster


            // Para volúmenes pequeños de datos
            public static void bubbleSort(int[] array)
            {
                int l = array.Length;
                System.Console.Write("Inicio ordenamiento burbuja");
                for (int i = 0; i < l - 1; i++)
                {
                    for (int j = 0; j < l - i - 1; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            // Intercambio
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
                System.Console.Write("Fin ordenamiento burbuja");
            }

            static void insertionSort(int[] array)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    int current = array[i]; // 1
                    int prev = i - 1; // 0

                    // Ex:[14, 56, 12, 45]

                    // Current[i = 1] = 56, Prev = 0, Prev[0] = 14

                    // Current [i = 2] = 12, Prev = 1, Prev[1] = 56
                    // [14, 56, 56, 45]
                    // Current [i = 2] = 12, Prev = 0, Prev[0] = 14
                    // [14, 14, 56, 45]
                    // Current [i = 2] = 12, Prev = -1
                    // [12, 14, 56, 45]

                    // Current [i = 3] = 45, Prev = 2, Prev[2] = 56
                    // [12, 14, 56, 56]
                    // Current [i = 3] = 45, Prev = 1, Prev[1] = 14
                    // [12, 14, 45, 56]

                    while (prev >= 0 && array[prev] > current)
                    {
                        array[prev + 1] = array[prev];
                        prev--;
                    }

                    array[prev + 1] = current;
                }
            }



            static void selectionSort(int[] array)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    int current = array[i]; // 1
                    int prev = i - 1; // 0

                    // Mueve los elementos mayores hacia la derecha
                    while (prev >= 0 && array[prev] > current)
                    {
                        array[prev + 1] = array[prev];
                        prev--; // -1
                    }

                    array[prev + 1] = current; // array[0] = current
                }
            }

            public static void shellSort(int[] array, int dataQuantity)
            {
                int salto = 0;
                int sw = 0;
                int auxi = 0;
                int e = 0;
                salto = array.Length / 2;

                while (salto > 0)
                {
                    sw = 1;
                    while (sw != 0)
                    {
                        sw = 0;
                        e = 1;
                        while (e <= (array.Length - salto))
                        {
                            if (array[e - 1] > array[(e - 1) + salto])
                            {
                                auxi = array[(e - 1) + salto];
                                array[(e - 1) + salto] = array[e - 1];
                                array[(e - 1)] = auxi;
                                sw = 1;
                            }
                            e++;
                        }
                    }

                    salto = salto / 2;
                }
            }
            // O(n log² n)

            public static void Main(string[] args)
            {
                int idPosition = -1;
                short selection = 0;
                long id = 0;
                int[] myVector;

                Stopwatch sw = new Stopwatch();

                do
                {
                    System.Console.WriteLine(" ");
                    System.Console.WriteLine("\t\t\t\tMenu de Metodos de Busqueda y Ordenamiento");
                    System.Console.WriteLine(" ");
                    System.Console.WriteLine("1.Busqueda Lineal"); // Check
                    System.Console.WriteLine("2 Busqueda binaria"); // Check
                    System.Console.WriteLine("3.Ordenamiento burbuja"); // Check
                    System.Console.WriteLine("4.ordenamiento Inserccion"); 
                    System.Console.WriteLine("5.Ordenamiento seleccion");
                    System.Console.WriteLine("6.Ordenamiento Shell");
                    System.Console.WriteLine("7.Ordenamiento Mezcla");
                    System.Console.WriteLine("8.Ordenamiento rapido");
                    System.Console.WriteLine("9.Ordenamiento por conteo");
                    System.Console.WriteLine("10.Ordenamiento Radix");
                    System.Console.WriteLine(" ");
                    System.Console.WriteLine("Seleccione su opcion: ");
                    
                    selection = short.Parse(System.Console.ReadLine());
                    
                    switch (selection)
                    
                    {

                        case 1:
                            System.Console.Clear();

                            myVector = selectQuantity(); // Definición del vector y su tamaño

                            fillVector(myVector, myVector.Length);

                            id = getId();

                            sw.Start();  // Inicia cronómetro
                            idPosition = linearSearch(myVector, id);
                            sw.Stop();   // Detiene cronómetro
                            
                            if (idPosition != -1)
                                System.Console.WriteLine("La identificación está en la posición " + idPosition.ToString() + " del vector.");

                            Console.WriteLine($"Tiempo transcurrido: {sw.ElapsedMilliseconds} ms");
                            break;

                        case 2:
                            System.Console.Clear();

                            myVector = selectQuantity();
                            fillVector(myVector, myVector.Length);
                            id = getId();

                            sw.Start();  // Inicia cronómetro
                            int position = binarySearch(myVector, id);
                            sw.Stop();   // Detiene cronómetro


                            if (position != -1)
                            {
                                System.Console.WriteLine("La identificacion esta en la posicion" + position.ToString() + "del vector");
                                Console.WriteLine($"Tiempo transcurrido: {sw.ElapsedMilliseconds} ms");
                            }
                            else
                                System.Console.WriteLine("La identificacion no se encontro en el vector");
                            break;
                        case 3:
                            System.Console.Clear();

                            myVector = selectQuantity();
                            fillVectorRandom(myVector, myVector.Length);

                            sw.Start();  // Inicia cronómetro
                            bubbleSort(myVector);
                            sw.Stop();   // Detiene cronómetro
                            Console.WriteLine($"Tiempo transcurrido: {sw.ElapsedMilliseconds} ms");

                            break;

                         case 4:
                            System.Console.Clear();

                            myVector = selectQuantity();
                            fillVectorRandom(myVector, myVector.Length);

                            sw.Start();  // Inicia cronómetro
                            insertionSort(myVector);
                            sw.Stop();   // Detiene cronómetro
                            Console.WriteLine($"Tiempo transcurrido: {sw.ElapsedMilliseconds} ms");

                            break;

                        case 5:
                            System.Console.Clear();

                            myVector = selectQuantity();
                            fillVectorRandom(myVector, myVector.Length);

                            sw.Start();  // Inicia cronómetro
                            selectionSort(myVector);
                            sw.Stop();   // Detiene cronómetro
                            Console.WriteLine($"Tiempo transcurrido: {sw.ElapsedMilliseconds} ms");

                            break;

                        case 6:
                            System.Console.Clear();

                            myVector = selectQuantity();
                            fillVectorRandom(myVector, myVector.Length);

                            sw.Start();  // Inicia cronómetro
                            shellSort(myVector, myVector.Length);
                            sw.Stop();   // Detiene cronómetro
                            Console.WriteLine($"Tiempo transcurrido: {sw.ElapsedMilliseconds} ms");
                            
                            break;
                    }
                } while (selection != 11);
            }
        }
    }
}



