namespace ClothingDependencySolver.Tests
{
    [TestFixture]
    public class ClothingDependencySolverTests
    {
        private Assessment.ClothingDependencySolver _solver;

        [SetUp]
        public void Setup()
        {
            _solver = new Assessment.ClothingDependencySolver();
        }

        [Test]
        public void TestRunMethod_AllItems()
        {
            var input = new string[,]
            {
                {"t-shirt", "dress shirt"},
                {"dress shirt", "pants"},
                {"dress shirt", "suit jacket"},
                {"tie", "suit jacket"},
                {"pants", "suit jacket"},
                {"belt", "suit jacket"},
                {"suit jacket", "overcoat"},
                {"dress shirt", "tie"},
                {"suit jacket", "sun glasses"},
                {"sun glasses", "overcoat"},
                {"left sock", "pants"},
                {"pants", "belt"},
                {"suit jacket", "left shoe"},
                {"suit jacket", "right shoe"},
                {"left shoe", "overcoat"},
                {"right sock", "pants"},
                {"right shoe", "overcoat"},
                {"t-shirt", "suit jacket"}
            };

            string expectedOutput = "right sock\r\n" +
                                    "left sock\r\n" +
                                    "t-shirt\r\n" +
                                    "dress shirt\r\n" +
                                    "tie\r\n" +
                                    "pants\r\n" +
                                    "belt\r\n" +
                                    "suit jacket\r\n" +
                                    "right shoe\r\n" +
                                    "left shoe\r\n" +
                                    "sun glasses\r\n" +
                                    "overcoat\r\n";

            string result = _solver.Run(input);
            string[] resultLines = result.Split('\r', '\n').Where(line => !string.IsNullOrEmpty(line)).ToArray();
            string[] expectedLines = expectedOutput.Split('\r', '\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            Assert.That(resultLines.Length, Is.EqualTo(expectedLines.Length), "Number of output lines mismatch.");

            for (int i = 0; i < expectedLines.Length; i++)
            {
                Assert.That(resultLines[i], Is.EqualTo(expectedLines[i]), $"Line {i + 1} mismatch.");
            }
        }
    }
}
