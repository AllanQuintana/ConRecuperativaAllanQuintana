using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] matriz = {
            { 0, 0, 0, 0, 0 },
            { 129, 99, 0, 110, 130 },
            { 145, -1, 100, 110, 110 },
            { -1, 123, 0, 0, -1 },
            { 160, 160, 0, 0, 170 },
            { 120, 110, 0, 112, 0 },
            { 0, 0, 110, 0, 110 },
            { 100, 0, 150, 140, 0 },
            { 90, 99, 0, -1, 0 },
            { 89, -1, 0, 110, 120 },
            { 200, 0, 180, 190, 0 }
        };

        while (true)
        {
            Console.WriteLine("Menú");
            Console.WriteLine("1. Calcular el gasto común");
            Console.WriteLine("2. Deptos. que han pagado los gastos comunes");
            Console.WriteLine("3. Dinero por pagar");
            Console.WriteLine("4. Dinero por pagar del piso 5");
            Console.WriteLine("5. Cantidad de Dptos. que han pagado el gasto común");
            Console.WriteLine("6. Mostrar la matriz de los gastos comunes");
            Console.WriteLine("7. Salir del menú");
            
            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida seleccionada una opción.");
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    CalcularGastoComun(matriz);
                    Console.WriteLine("Gasto común calculado.");
                    Console.WriteLine();
                    break;
                case 2:
                    int deptosPagados = DeptosPagados(matriz);
                    Console.WriteLine("Deptos. que han pagado los gastos comunes: " + deptosPagados);
                    Console.WriteLine();
                    break;
                case 3:
                    double deudaTotal = CalcularDeudaTotal(matriz);
                    Console.WriteLine("Dinero por pagar: " + deudaTotal.ToString("0.00"));
                    Console.WriteLine();
                    break;
                case 4:
                    double deudaP5 = CalcularDeudaPiso(matriz, 5);
                    Console.WriteLine("Dinero por pagar del piso 5: " + deudaP5.ToString("0.00"));
                    Console.WriteLine();
                    break;
                case 5:
                    int deptosPagadosIndividuales = DeptosPagadosIndividuales(matriz);
                    Console.WriteLine("Cantidad de Dptos. que han pagado el gasto común: " + deptosPagadosIndividuales);
                    Console.WriteLine();
                    break;
                case 6:
                    MostrarMatriz(matriz);
                    Console.WriteLine();
                    break;
                case 7:
                    Console.WriteLine("Saliendo del prograam");
                    return;
                default:
                    Console.WriteLine("Seleccione una opción válida.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    static void CalcularGastoComun(int[,] matriz)
    {
        Console.Write("Ingrese el monto a aplicar el factor 0.0333: ");
        double monto;
        if (!double.TryParse(Console.ReadLine(), out monto))
        {
            Console.WriteLine("Monto inválido.");
            return;
        }

        double factor = 0.0333;

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (matriz[i, j] == -1)
                {
                    matriz[i, j] = (int)(monto * factor);
                }
            }
        }
    }

    static int DeptosPagados(int[,] matriz)
    {
        int pagados = 0;

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (matriz[i, j] == 0)
                {
                    pagados++;
                }
            }
        }

        return pagados;
    }

    static double CalcularDeudaTotal(int[,] matriz)
    {
        double deudaTotal = 0;

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (matriz[i, j] > 0)
                {
                    deudaTotal += matriz[i, j];
                }
            }
        }

        return deudaTotal;
    }

    static double CalcularDeudaPiso(int[,] matriz, int piso)
    {
        double deudaPiso = 0;

        for (int j = 0; j < matriz.GetLength(1); j++)
        {
            if (matriz[piso, j] > 0)
            {
                deudaPiso += matriz[piso, j];
            }
        }

        return deudaPiso;
    }

    static int DeptosPagadosIndividuales(int[,] matriz)
    {
        int dptpagadosIndividuales = 0;

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            bool todosPagados = true;

            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (matriz[i, j] != 0)
                {
                    todosPagados = false;
                    break;
                }
            }

            if (todosPagados)
            {
                dptpagadosIndividuales++;
            }
        }

        return dptpagadosIndividuales;
    }

    static void MostrarMatriz(int[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
