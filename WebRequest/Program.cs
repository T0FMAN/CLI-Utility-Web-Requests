using System.Net;

var main = true;

while (main)
{
    Console.WriteLine("Введите интервал в секундах..");
    var interval = Console.ReadLine();

    while (interval?.All(char.IsNumber) != true)
    {
        Console.WriteLine("Неверно введеный параметр. Введите новое значение");

        interval = Console.ReadLine();
    }

    Console.WriteLine("Введите ссылку на ресурс..");
    var link = Console.ReadLine();

    while (true)
    {
        var code = await StatusCode(link);

        Console.WriteLine(code);

        if (code == "URL parsing error")
        {
            main = false;
            return;
        }
        await Task.Delay(Convert.ToInt32(interval) * 1000);
    }
}

async Task<string> StatusCode(string link)
{
    try
    {
        WebRequest request = (HttpWebRequest)WebRequest.Create(link);

        request.Method = "GET";

        using (var res = (HttpWebResponse)await request.GetResponseAsync())
        {
            var code = (int)res.StatusCode;

            switch (code)
            {
                case 200:
                    return "OK(200)";
                default:
                    return $"ERR({code})";
            }
        }
    }
    catch (Exception exception)
    {
        if (exception.Source == "System.Private.Uri")
        {
            return "URL parsing error";
        }

        var index = exception.Message.IndexOf(":")+1;
        var error = exception.Message.Substring(index, 3);

        return $"ERR({error})";
    }
}
