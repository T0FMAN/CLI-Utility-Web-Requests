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
            var code = await StatusCode(args[1]);

            if (!code.Item2)
            {
                Console.WriteLine("URL parsing error");

                return;
            }
            Console.WriteLine($"Checking '{args[1]}'. Result: {code.Item1}");

            await Task.Delay(delay * 1000);
        }

        static async Task<Tuple<string, bool>> StatusCode(string link)
        {
            try
            {
                WebRequest request = (HttpWebRequest)WebRequest.Create(link);

                request.Method = "GET";

                using (var res = (HttpWebResponse)await request.GetResponseAsync())
                {
                    return new Tuple<string, bool>("OK(200)", true);
                }
            }
            catch (WebException ex)
            {
                var error = (int)((HttpWebResponse)ex.Response).StatusCode;

                return new Tuple<string, bool>($"ERR({error})", true);
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
