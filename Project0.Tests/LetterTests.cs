using Project0.ClassLib.Models;

namespace Project0.Tests;

public class LetterTests
{
    [Test]
    public void OriginAddress_ShouldThrow_WhenInvalid()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Letter(null, new Address("a", "a", "a", "a", 1), 10M);
        });
    }

    [Test]
    public void DestinationAddress_ShouldThrow_WhenInvalid()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            new Letter(new Address("a", "a", "a", "a", 1), null, 10M);
        });
    }

    [TestCase(-1)]
    public void FixedCost_ShouldThrow_WhenInvalid(decimal fixedCost)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var addr = new Address("a", "a", "a", "a", 1);
            new Letter(addr, addr, fixedCost);
        });
    }

    [TestCase(0)]
    [TestCase(111.11)]
    public void FixedCost_ShouldReturn_CtorParameter(decimal fixedCost)
    {
        var addr = new Address("a", "a", "a", "a", 1);
        var letter = new Letter(addr, addr, fixedCost);

        Is.EqualTo(fixedCost).ApplyTo(letter.CalcCost());
    }
}