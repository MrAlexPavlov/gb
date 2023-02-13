// Задача: Написать программу которая из имеющегося массива строк формирует 
// массив из строк, длина которых меньше либо равна 3 символа. 
// Первоначальный массив можно ввести с клавиатуры либо задать на старте выполненмя алгоритма. 
// При решении не рекомендуется пользоваться коллекциями 
// лучше обойтись исключительно массивами


//Метод пользовательского ввода нескольких значений через разделитель
string[] UserEnteredArray(string text, char delim)
{
    //ожидаем пользовательского ввода
    Console.WriteLine(text);
    string usersText = Console.ReadLine() ?? string.Empty;
    //преобразуем строку в строковый массив и возвращаем его
    return usersText.Split(delim, System.StringSplitOptions.RemoveEmptyEntries);
}

//Метод пользовательского ввода для целых чисел
int InsertDigit(string text) 
{
    int result;bool parse;
    Console.WriteLine(text);
    parse = Int32.TryParse(Console.ReadLine(), out result);
    if (!parse || result <= 0) result = InsertDigit(text);//Если пользователь ввел некорректное значение вызываем повтороно метод.
    return result;
}

//Метод преобразования массива в строку
string ArrayToString(string[] array)
{
    string result = "[";
    for (int i = 0; i < array.Length; i++)
    {
        result = result + $" {array[i]}";
        result = i < (array.Length - 1) ? result = result + "," : result;//для корректности вывода запятых
    }
    return result + " ]";
}

// Возвращаем массив с элементами по количеству знаков меньше или равными limit
string[] RefillArray(string[] array, int limit, string tmpSeparate = "<<")
{
    string tmpText = string.Empty;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length > limit) continue;
        tmpText+=$"{array[i]}{tmpSeparate}";
    }
    string[] resArray = tmpText.Split(tmpSeparate, 
                                        System.StringSplitOptions.RemoveEmptyEntries);
    return resArray;
}

// int n = 3; // Максимальное количество символов в значении массива
// string[] insArray = {"hello","world",":>)","smt","end","start"};

// Запрашиваем у пользователя ввести данные через разделитель
char delimText = ',';
string messageText = "Введите значние массива через запятую `,`:";
string[] insArray = UserEnteredArray(messageText, delimText);
string basicArrText = ArrayToString(insArray);

// Запрашиваем у пользователя максимальную длину элемента массива
messageText = "\nЗадайте максимальную длинну элемента массива (max,>0):";
int n = InsertDigit(messageText);

// формируем новый массив с элементами длинна которых меньше или равна заданой длине
string[] newArray = RefillArray(insArray,n,"<<#>>"); 
string newArrText = ArrayToString(newArray);

// Выводим на экран все данные
Console.WriteLine( $"\nНачальный массив данных\n{basicArrText}\n" );
Console.WriteLine( $"Максимальная длинна элемента массива {n}\n" );
Console.WriteLine( $"Конечный массив данных.\n{newArrText}\n" );

