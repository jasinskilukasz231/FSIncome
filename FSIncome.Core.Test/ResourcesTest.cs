namespace FSIncome.Core.Test
{
    public class ResourcesTest
    {
        [Fact]
        public void VariableTest()
        {
            var var1 = ResourcesClass.configFilePath;

            Assert.Equal("asd", var1);


        }

        [Fact]
        public void WriteFileTest()
        {
            ResourcesClass.WriteFile("#profile", ResourcesClass.configFilePath);

            Assert.Equal(1, 1);
        }
    }
}