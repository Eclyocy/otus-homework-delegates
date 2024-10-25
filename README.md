# Delegates and Events

## Постановка задачи

### Цель

В этом задании требуется реализовать механизмы делегатов и событий для получения практического навыка их применения.

### Описание

1. Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.<br/>
Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения:
    <pre>public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber)
        where T : class;</pre>

2. Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла.

3. Оформить событие и его аргументы с использованием .NET-соглашений:
    <pre>public event EventHandler<FileArgs> FileFound;</pre>
    Здесь FileArgs содержит имя файла и наследуется от EventArgs.

4. Добавить возможность отмены дальнейшего поиска из обработчика.

5. Вывести в консоль сообщения, возникающие при срабатывании событий, и результат поиска максимального элемента.

## Решение

### CollectionExtension

Реализация: [CollectionExtensions.cs](Delegates/Extensions/CollectionExtensions.cs)

Тесты: [CollectionExtensionsTests.cs](Delegates.Tests/Extensions/CollectionExtensionsTests.cs)

### Events

Для примера взята директория со сложной структурой: [Data](Delegates/Data)

Аргументы кастомного события описаны в [FileArgs](Delegates/Events/FileArgs.cs)<br/>
FileSize добавлен для того, чтобы можно было продемонстрировать одновременно работу CollectionExtensions и кастомного Event в одной программе.

Возможность отмены дальнейшего поиска реализована посредством свойства Cancel, по которому в обработчике ([DirectoryHelper](Delegates/Helpers/DirectoryHelper.cs)) происходит выход из цикла.<br/>

Для примера Cancel выставляется после обработки третьего файла.

По завершению программа выводит информацию о файле, оказавшимся наибольшим.

#### Вывод программы без Cancel

<pre>
File found: File RootFile1.txt with size 700 (C:\Users\User\Otus\repos\otus-homework-delegates\Delegates\bin\Debug\net8.0\Data\RootFile1.txt)
File found: File RootFile2.txt with size 721 (C:\Users\User\Otus\repos\otus-homework-delegates\Delegates\bin\Debug\net8.0\Data\RootFile2.txt)
File found: File Subdirectory1File1.txt with size 325 (C:\Users\User\Otus\repos\otus-homework-delegates\Delegates\bin\Debug\net8.0\Data\Subdirectory1\Subdirectory1File1.txt)
File found: File Subdirectory2File1.txt with size 984 (C:\Users\User\Otus\repos\otus-homework-delegates\Delegates\bin\Debug\net8.0\Data\Subdirectory2\Subdirectory2File1.txt)
File found: File Subdirectory2File2.txt with size 761 (C:\Users\User\Otus\repos\otus-homework-delegates\Delegates\bin\Debug\net8.0\Data\Subdirectory2\Subdirectory2File2.txt)
Largest file is: File Subdirectory2File1.txt with size 984 (C:\Users\User\Otus\repos\otus-homework-delegates\Delegates\bin\Debug\net8.0\Data\Subdirectory2\Subdirectory2File1.txt)
</pre>

#### Вывод программы с Cancel

<pre>
File found: File RootFile1.txt with size 700 (C:\Users\User\Otus\repos\otus-homework-delegates\Delegates\bin\Debug\net8.0\Data\RootFile1.txt)
File found: File RootFile2.txt with size 721 (C:\Users\User\Otus\repos\otus-homework-delegates\Delegates\bin\Debug\net8.0\Data\RootFile2.txt)
File found: File Subdirectory1File1.txt with size 325 (C:\Users\User\Otus\repos\otus-homework-delegates\Delegates\bin\Debug\net8.0\Data\Subdirectory1\Subdirectory1File1.txt)
Cancellation received. Files searching is halted.
Largest file is: File RootFile2.txt with size 721 (C:\Users\User\Otus\repos\otus-homework-delegates\Delegates\bin\Debug\net8.0\Data\RootFile2.txt)
</pre>
