using Project0.ClassLib.Models;

namespace Project0.Tests;

public class AddressTests
{
    [TestCase("")]
    [TestCase(null)]
    [TestCase("    ")]
    public void Name_ShouldThrow_WhenInvalid(string name)
    {
        try
        {
            new Address(name,
                "a",
                "a",
                "a",
                1
                );
            Assert.Fail();
        }
        catch(ArgumentException)
        {
            Assert.Pass();
        }
    }
}