namespace Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[,]
            {
                // Dependency   Item
                {"t-shirt",     "dress shirt"},
                {"dress shirt", "pants"},
                {"dress shirt", "suit jacket"},
                {"tie",         "suit jacket"},
                {"pants",       "suit jacket"},
                {"belt",        "suit jacket"},
                {"suit jacket", "overcoat"},
                {"dress shirt", "tie"},
                {"suit jacket", "sun glasses"},
                {"sun glasses", "overcoat"},
                {"left sock",   "pants"},
                {"pants",       "belt"},
                {"suit jacket", "left shoe"},
                {"suit jacket", "right shoe"},
                {"left shoe",   "overcoat"},
                {"right sock",  "pants"},
                {"right shoe",  "overcoat"},
                {"t-shirt",     "suit jacket"}
            };

            ClothingDependencySolver solver = new ClothingDependencySolver();
            var result = solver.Run(input);
            Console.WriteLine(result);
        }
    }
}
