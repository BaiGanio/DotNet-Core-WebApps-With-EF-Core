using System;

namespace Chorap4e.Domain
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
            string output = 
                $"Чорап with ID: {this.Id} & price {this.Price} have color {this.Color}, size {this.Size} and is produced by {this.Material} material! ";
            return output;
        }
    }
}
