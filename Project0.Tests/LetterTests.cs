using Project0.ClassLib.Models;

namespace Project0.Tests;

public class LetterTests
{
    [Test]
    public void OriginAddress_ShouldThrow_WhenInvalid()
    {
        try
        {
            new Letter(null, new Address("a", "a", "a", "a", 1), 10M);

            Assert.Fail();
        }
        catch (ArgumentOutOfRangeException)
        {
            Assert.Pass();
        }
    }

    [Test]
    public void DestinationAddress_ShouldThrow_WhenInvalid()
    {
        try
        {
            new Letter(new Address("a", "a", "a", "a", 1), null, 10M);

            Assert.Fail();
        }
        catch (ArgumentOutOfRangeException)
        {
            Assert.Pass();
        }
    }

    [TestCase(-1)]
    public void FixedCost_ShouldThrow_WhenInvalid(decimal fixedCost)
    {
        try
        {
            var addr = new Address("a", "a", "a", "a", 1);
            new Letter(addr, addr, fixedCost);

            Assert.Fail();
        }
        catch (ArgumentOutOfRangeException)
        {
            Assert.Pass();
        }
    }
}