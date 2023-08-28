namespace Assessment
{
    public class ClothingDependencySolver
    {
        public string Run(string[,] input)
        {
            Dictionary<string, List<string>> dependencies = new Dictionary<string, List<string>>();
            HashSet<string> allItems = new HashSet<string>();

            // Create dependency graph
            for (int i = 0; i < input.GetLength(0); i++)
            {
                string dependency = input[i, 0];
                string item = input[i, 1];

                if (!dependencies.ContainsKey(dependency))
                {
                    dependencies[dependency] = new List<string>();
                }
                dependencies[dependency].Add(item);
                allItems.Add(dependency);
                allItems.Add(item);
            }

            // Topological sort
            List<string> order = new List<string>();
            HashSet<string> visited = new HashSet<string>();

            void sort(string item)
            {
                visited.Add(item);
                if (dependencies.ContainsKey(item))
                {
                    foreach (var dependentItem in dependencies[item])
                    {
                        if (!visited.Contains(dependentItem))
                        {
                            sort(dependentItem);
                        }
                    }
                }
                order.Insert(0, item);
            }

            foreach (var item in allItems)
            {
                if (!visited.Contains(item))
                {
                    sort(item);
                }
            }

            // Output sorted items
            List<string> outputLines = new List<string>();
            string currentLine = "";
            string previousItem = null;

            foreach (var item in order)
            {
                if (previousItem != null && !dependencies.ContainsKey(previousItem))
                {
                    outputLines.Add(currentLine);
                    currentLine = "";
                }

                if (currentLine.Length > 0)
                {
                    currentLine += "\r\n";
                }

                currentLine += item;
                previousItem = item;
            }

            if (currentLine.Length > 0)
            {
                outputLines.Add(currentLine);
            }

            return outputLines[0].ToString();
        }
    }
}
