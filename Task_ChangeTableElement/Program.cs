// Задача 2 HARD необязательная. Считается за четыре обязательных,
// то есть три этих и одна с будущего семинара. Сгенерировать 
// массив случайных целых чисел размерностью m*n (размерность 
// (вводим с клавиатуры), причем чтоб количество элементов
// было четное. Вывести на экран красивенько таблицей.
// Перемешать случайным образом элементы массива, причем чтобы
// каждый элемент гарантированно и только один раз переместился
// на другое место и выполнить перемешивание за m*n / 2 итераций. 
// То есть, если массив три на четыре, то надо выполнить за 6 
// итераций. И далее в конце опять вывести на экран как таблицу.
try
{
    Console.WriteLine("Enter the size of the table, count of cells must be even");
    Console.WriteLine("Enter the number of rows of the table");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the number of columns of the table");
    int cols = Convert.ToInt32(Console.ReadLine());

    if (rows < 1 || cols < 1)
        Console.WriteLine("Enter positive numbers only!");
    else if (rows * cols % 2 == 1)
        Console.WriteLine("Enter even at least 1 of 2 numbers");
    else
    {
        int[,] array = CreateAndFillArray(rows, cols);
        Console.WriteLine("The random array of {0} rows and {1} columns is:", rows, cols);
        PrintTable(array);
        Console.WriteLine("This is array after random changing:");
        ChangeRandomArray(array);
        PrintTable(array);
    }
}
catch
{
    Console.WriteLine("You should enter numbers only!");
}

int[,] CreateAndFillArray(int n, int m)
{
    int[,] array = new int[n, m];
    for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
            array[i, j] = new Random().Next(-100, 101);
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

void ChangeRandomArray(int[,] array)
{
    int rows = array.GetLength(0);
    int cols = array.GetLength(1);
    bool[,] wasChanged = new bool[rows, cols];
   
    for (int i = 0; i < rows * cols / 2; i++)
    {
        int[] adressCurrent = GetUniqueAdressRandom(wasChanged);
        SetWasChanged(adressCurrent, wasChanged);
        int[] adressForChanging = GetUniqueAdressRandom(wasChanged);
        SetWasChanged(adressForChanging, wasChanged);
        ChangeElementsArray(array, adressCurrent, adressForChanging);
    }
}

void ChangeElementsArray(int[,] array, int[] element1, int[] element2)
{
    int temp = array[element1[0], element1[1]];
    array[element1[0], element1[1]] = array[element2[0], element2[1]];
    array[element2[0], element2[1]] = temp;
}

bool WasChanged(int[] adress, bool[,] wasChanged)
{
    return wasChanged[adress[0], adress[1]];
}

void SetWasChanged(int[] adress, bool[,] wasChanged)
{
    wasChanged[adress[0], adress[1]] = true;
}

int[] GetAdressRandom(int rows, int cols)
{
    int index1 = new Random().Next(0, rows);
    int index2 = new Random().Next(0, cols);
    return new int[2] { index1, index2 };
}

int[] GetUniqueAdressRandom(bool[,] wasChanged)
{
    int rows = wasChanged.GetLength(0);
    int cols = wasChanged.GetLength(1);
    int[] adress = GetAdressRandom(rows, cols);
    while (WasChanged(adress, wasChanged))
        adress = GetAdressRandom(rows, cols);
    return adress;
}