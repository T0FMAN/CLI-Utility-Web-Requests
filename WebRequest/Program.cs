using System.Net;

if (args.Length == 2)
{
    try
    {
        var interval = args[0];

        while (true)
        {
            if (interval.All(char.IsNumber))
                break;
            else
            {
                Console.WriteLine("Неверно введеный параметр. Введите новое значение");

                interval = Console.ReadLine()!;
            }
        }

        int delay = Convert.ToInt32(interval);

        while (true)
        {
            var response = await StatusCode(args[1]);

            if (!response.Item2)
            {
                Console.WriteLine(response.Item1);

                return;
            }
            Console.WriteLine($"Checking '{args[1]}'. Result: {response.Item1}");

            await Task.Delay(delay * 1000);
        }

        static async Task<Tuple<string, bool>> StatusCode(string link)
        {
            try
            {
                using (HttpClient httpClient = new())
                {
                    using (var response = await httpClient.GetAsync(link))
                    {
                        var code = (int)response.StatusCode;

                        switch (code)
                        {
                            case 200:
                                return new Tuple<string, bool>("OK(200)", true);

                            default:
                                return new Tuple<string, bool>($"ERR({code})", true);
                        }
                    }
                }
            }
            catch
            {
                return new Tuple<string, bool>("URL parsing error", false);
            }
        }
    }
    catch { }
}
else
{
    Console.WriteLine("Неверные аргументы");
}
