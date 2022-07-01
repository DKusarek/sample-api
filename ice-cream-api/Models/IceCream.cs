namespace hp_api.Models
{
    public class IceCream
    {
        public string Name { get; set; } = default!;
        public int Portions { get; set; } = default;


        public IceCream(string name)
        {
            Name = name;
        }
        public IceCream(string name, int portions)
        {
            Name = name;
            Portions = portions;
        }

        public void CalculatePortionsFromWeight(double weight)
        {
            Portions = (int)Math.Floor(weight / 80);
        }

    }
}
