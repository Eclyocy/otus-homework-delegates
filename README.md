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

Реализация: [CollectionExtensions.cs](Delegates/Extensions/CollectionExtensions.cs)<br/>
Тесты: [CollectionExtensionsTests.cs](Delegates.Tests/Extensions/CollectionExtensionsTests.cs)
