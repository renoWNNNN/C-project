// Programa sencillo (Tarea 2)

using System;

class Program
{
    static void Main()
    {
        // solicitar numeros
        Console.Write("Ingresa un número: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("No ingresaste un número válido.");
            return;
        }

        int number;
        if (int.TryParse(input, out number))
        {
            // esta parte sirve para verificar
            if (number % 2 == 0)
            {
                Console.WriteLine("El número " + number + " es par.");
            }
            else
            {
                Console.WriteLine("El número " + number + " es impar.");
            }
        }
        else
        {
            Console.WriteLine("No ingresaste un número válido.");
        }
    }
}