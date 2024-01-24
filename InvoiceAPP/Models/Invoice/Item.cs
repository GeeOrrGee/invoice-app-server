namespace InvoiceAPP.Models.Invoice;

public class Item
{
    public Item(string name, int quantity, double price)
    {
        this.name     = name;
        this.quantity = quantity;
        this.price    = price;
    }

    public string name { get; set; }
    public int    quantity { get; set; }
    public double price { get; set; }
}