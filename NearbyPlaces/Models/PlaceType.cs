namespace NearbyPlaces.Models;

public enum PlaceType
{

    Unknown = 0,

    // Geography
    Country = 1,
    City = 2,
    Town = 3,
    Village = 4,

    // Food & Drink
    Restaurant = 10,
    Cafe = 11,
    FastFood = 12,
    Bakery = 13,
    Bar = 14,

    // Transportation
    GasStation = 20,
    Parking = 21,
    EVChargingStation = 22,
    Airport = 23,
    TrainStation = 24,
    BusStation = 25,

    // Health
    Hospital = 30,
    Clinic = 31,
    Pharmacy = 32,

    // Finance
    ATM = 40,
    Bank = 41,

    // Shopping
    Supermarket = 50,
    ShoppingMall = 51,
    ConvenienceStore = 52,

    // Tourism
    Hotel = 60,
    Museum = 61,
    Beach = 62,
    Park = 63,

    // Government
    PoliceStation = 70,
    FireStation = 71,
    PostOffice = 72,

    // Education
    School = 80,
    University = 81

}