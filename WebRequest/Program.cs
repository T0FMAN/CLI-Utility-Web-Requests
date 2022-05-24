using System.Net;

while (true)
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
            return;

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
                    break;
                default:
                    throw new WebException($"Error: {code}");
            }

            return "OK(200)";
        }
    }
    catch (WebException ex)
    {
        var index = ex.Message.IndexOf(":") + 1;
        var error = ex.Message.Substring(index, 3);

        return $"ERR({error})";
    }
    catch
    {
        return "URL parsing error";
    }
}
