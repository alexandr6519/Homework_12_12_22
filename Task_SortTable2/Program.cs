// Задача HARD SORT необязательная. Считается за три обязательных
// Задайте двумерный массив из целых чисел. Количество строк и
// столбцов задается с клавиатуры. Отсортировать элементы по 
// возрастанию слева направо и сверху вниз.
// Например, задан массив:     1 4 7 2
//                             5 9 10 3
// После сортировки:            1 2 3 4
//                              5 7 9 10
// try
// {
    Console.WriteLine("Enter the number of rows of the table");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the number of columns of the table");
    int cols = Convert.ToInt32(Console.ReadLine());

    if (cols < 1 || rows < 1) Console.WriteLine("Enter positive numbers only!");
    else
    {
        int[,] array = CreateAndFillArray(rows, cols);
        Console.WriteLine("The random array of {0} rows and {1} columns is:", rows, cols);
        PrintTable(array);
        SortArray(array);
        Console.WriteLine("The sorting array is:");
        PrintTable(array);
    }
// }
// catch
// {
//     Console.WriteLine("You should enter numbers only!");
// }

int[,] CreateAndFillArray(int n, int m)
{
    int[,] array = new int[n, m];
    for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
            array[i, j] = new Random().Next(-20, 21);
    return array;
}

void PrintTable(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write("{0,5:d}", array[i, j]);
        Console.WriteLine();
    }
}

void SortArray(int[,] array)
{
    int rows = array.GetLength(0);
    int cols = array.GetLength(1);
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            for (int k = 0; k < rows; k++)
                for (int m = 0; m < cols; m++)
                    if (array[i, j] < array[k, m])
                    {
                        int temp = array[i, j];
                        array[i, j] = array[k, m];
                        array[k, m] = temp;
                    }
}
