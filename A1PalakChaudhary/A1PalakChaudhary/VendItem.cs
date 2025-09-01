namespace A1PalakChaudhary
{
    public class VendItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public VendItem(string n, double p, int s)
        {
            Name = n;
            Price = p;
            Stock = s;
        }
          
    }
}
