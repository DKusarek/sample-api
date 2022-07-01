using hp_api.Models;

namespace hp_api.Data
{
    public static class IceCreamsData
    {
        public static readonly List<IceCream> ICECREAMS = new List<IceCream>
        {
            new IceCream("Vanilla", 50),
            new IceCream("Strawberry", 50),
            new IceCream("Chocolate", 50)
        };
    }
}


