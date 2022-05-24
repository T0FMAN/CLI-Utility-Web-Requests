# CLI-утилита, проверяющая соединение с веб-ресурсом на каждой итерации с определенным интервалом

<b>Пример использования в среде разработки или при установленном .NET в папке проекта:</b>

<code>dotnet run [время интервала в секундах] [https://example.com]</code>

<b>Или:</b>

<code>dotnet run (предустановленные в файле Properties/launchSettings.json аргументы командной строки)</code>

<b>Пример использования при сборке Release/Debug в папке:</b>

<code>WebRequest [время интервала в секундах] [https://example.com]</code>

<b>Результат успешного GET-запроса (200):</b>

![image](https://user-images.githubusercontent.com/67320747/170118374-6dbe31dd-68c0-47e9-90f1-3910c939ab0a.png)

<b>Результат полученного статус кода с ошибкой:</b>

![image](https://user-images.githubusercontent.com/67320747/170118758-7f500395-650b-460b-aac3-54ca2de6fe9f.png)

<b>Результат невалидной ссылки (второго аргумента):</b>

![image](https://user-images.githubusercontent.com/67320747/170118917-33c807fc-ade0-43e2-bbdc-fb5c45289000.png)
