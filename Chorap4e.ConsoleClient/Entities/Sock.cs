using System;

namespace Chorap4e.ConsoleClient
{
    public sealed class Sock
    {
        public Sock() { }
        public Sock(double price, Color colr, Size size, Material material, string id = null)
        {
            this.Price = price;
            this.Color = colr;
            this.Size = size;
            this.Material = material;
            this.Id = id ?? Guid.NewGuid().ToString();
        }


        public string Id { get; set; }

        public double Price { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public Material Material { get; set; }

        public override string ToString()
        {
            string output = $"4orap4e with price {this.Price} have color {this.Color}! ";
            return output;
        }
    }
}
