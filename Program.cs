// Задача: Написать программу которая из имеющегося массива строк формирует 
// массив из строк, длина которых меньше либо равна 3 символа. 
// Первоначальный массив можно ввести с клавиатуры либо задать на старте выполненмя алгоритма. 
// При решении не рекомендуется пользоваться коллекциями 
// лучше обойтись исключительно массивами

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
string[] RefillArray(string[] array, int limit = 0, string tmpSeparate = "<<")
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

int n = 3; // Максимальное количество символов в значении массива
string[] insArray = {"hello","world",":>)","smt","end","start"};

// формируем новый массив с элементами длинна которых меньше или равна заданой длине
string[] newArray = RefillArray(insArray,n,"<<#>>"); 
string newArrText = ArrayToString(newArray);


Console.WriteLine( $"Конечный массив данных.\n{newArrText}\n" );