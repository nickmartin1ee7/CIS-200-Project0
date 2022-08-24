/* Author: Nick Martin (5111752)
 * Program: 0
 * Due: 09/09/2022
 * 
 * Class Descriptions in Project0.ClassLib:
 *    Models.Parcel    An abstract class that defines an origin and destination address, along with a method to calculate the shipping cost.
 *    Models.Letter    A concrete class, inheriting from Parcel, that accepts a fixed shipping cost.
 *    Models.Address   A concrete class that stores data about a named address with an optional second address, as well as the city, state, and zipcode.
 *    Extensions.GuardExtensions   Provides a useful API for throwing exceptions when evaluating the state of a given parameter.
 *    
 * Notes to Instructor:
 *    For a general description, pre and post-conditions, I represent them with the XML-documentation style that Visual Studio supports.
 *    Pre-condition is represented with <param .../>
 *    Post-condition is represented with <returns .../>
 *    I plan to do this for the rest of the semester since it makes documentation more intuitive. Please let me know if that's an issue.
 */

using Project0.ClassLib.Models;

var addresses = new List<Address>
{
    new Address("Home", "123 Apple Rd.", "Louisville", "KY", 1),
    new Address("Neighbor 1", "234 Apple Rd.", "Apt 100", "Louisville", "KY", 99999),
    new Address("Neighbor 2", "345 Apple Rd.", "Louisville", "KY", 40213),
    new Address("Neighbor 3", "456 Apple Rd.", "Louisville", "KY", 00500),
};

Console.WriteLine("# ADDRESSES");
foreach (var address in addresses)
{
    Console.WriteLine(address);
}

const int MAX_COST = 1_000;

var parcels = new List<Parcel>
{
    new Letter(addresses[0], addresses[1], GetRandomCost(MAX_COST)),
    new Letter(addresses[2], addresses[3], GetRandomCost(MAX_COST)),
    new Letter(
        new Address("Neighbor 4", "567 Apple Rd.", "Louisville", "KY", 40213),
        new Address("Neighbor 5", "678 Apple Rd.", "Louisville", "KY", 40213),
        GetRandomCost(MAX_COST)),
};


Console.WriteLine("# PARCELS");
foreach (var parcel in parcels)
{
    Console.WriteLine(parcel);
}

_ = Console.ReadLine();

// Creates a pseudo-random cost limited to a max cost for the whole dollar amount
static decimal GetRandomCost(int maxCost) =>
    (decimal)(Random.Shared.Next(maxCost) + Random.Shared.NextDouble());