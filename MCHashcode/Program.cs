namespace MCHashcode
{
    using System;
    using System.Text;

    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter text to compute hash (ENTER to quit): ");
                var text = Console.ReadLine();

                if (string.IsNullOrEmpty(text))
                {
                    break;
                }

                var h = ComputeHash(text);
                Console.WriteLine(h);
            }

            while (true)
            {
                Console.Write("Enter hash to compute text (ENTER to quit): ");
                var value = Console.ReadLine();

                if (string.IsNullOrEmpty(value))
                {
                    break;
                }

                if (!int.TryParse(value, out var hash))
                {
                    continue;
                }

                var rng = new Random();
                var count = 0;

                while (!Console.KeyAvailable)
                {
                    var len = rng.Next(1, 15);
                    var text = new StringBuilder(len);

                    for (int i = 0; i < len; i++)
                    {
                        text.Append((char)rng.Next(32, 126));
                    }

                    var h = ComputeHash(text.ToString());

                    if (h == hash)
                    {
                        Console.WriteLine();
                        Console.WriteLine(text.ToString());
                        Console.WriteLine();
                    }

                    if (++count % 10000 == 0)
                    {
                        Console.Write(".");
                    }
                }
            }
        }

        private static int ComputeHash(string text)
        {
            var n = (long)text.Length;
            var h = (long)0;

            for (var i = h; i < n; i++)
            {
                var c = text[(int)i];
                var v = (long)c;
                var x = n - 1 - i;
                var y = (long)Math.Pow(31, x);
                var f = v * y;
                var hash = h + f;
                h = (int)hash;
            }

            return (int)h;
        }
    }
}