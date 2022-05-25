/* 
 * Start the program with only two specified command line arguments,
 * else break program.
 * Default settings (file at Properities/launchsettings.json): 
 * - one-seconds interval
 * - url destination: http://httpstat.us/503
 * Response: ERROR 503
 */
if (args.Length == 2)
{
    var interval = args[0];
    var url = args[1];

    while (!interval.All(char.IsNumber))
    {
        Console.WriteLine("The specified interval value is not valid.. Try input again");

        interval = Console.ReadLine()!;
    }

    int delay = Convert.ToInt32(interval);

    while (true)
    {
        var response = await StatusCode(url);

        if (!response.Item2)
        {
            Console.WriteLine(response.Item1);

            return;
        }
        Console.WriteLine($"Checking '{url}'. Result: {response.Item1}");

        await Task.Delay(delay * 1000);
    }

    static async Task<Tuple<string, bool>> StatusCode(string url)
    {
        try
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
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
else
    Console.WriteLine("Invalid arguments");
