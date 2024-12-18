namespace basketapp;
class QuantityBasketItem : BasketItem
{
    public QuantityBasketItem()
    {
    }
    public QuantityBasketItem(int id) : base(id)
    {
    }

    public override int CalculateTotalPrice() {
        return Price * Quantity;
    }

    public int Quantity {get;set;}

    public override string ToString()
    {
        return base.ToString() + $", met {Quantity} als hoeveelheid";
    }
}