namespace Checkout.Models
{
    public class OfferItem
    {
        public string SKU;
        public int Quantity { get; set; }
        public double OfferPrice { get; set; }
    }
}