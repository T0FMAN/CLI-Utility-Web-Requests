# CLI-утилита, проверяющая соединение с веб-ресурсом на каждой итерации с определенным интервалом

Пример использования в среде разработки или при установленном .NET в папке проекта:

dotnet run [время интервала в секундах] [https://example.com]

Или:

dotnet run (встроенные в файл Properties/launchSettings.json аргументы командной строки)

Пример использования при сборке Release/Debug в папке:

WebRequest [время интервала в секундах] [https://example.com]

Результат:

![image](https://user-images.githubusercontent.com/67320747/170112507-34d77426-638e-4075-ad4f-b4ec34447f8c.png)
