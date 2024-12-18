namespace basketapp;
class BulkBasketItem : BasketItem
{
    public BulkBasketItem() 
    {

    }

    public BulkBasketItem(int id) : base(id) 
    {
        
    }

    public int Weight {get;set;}

    public override int CalculateTotalPrice() {
        return (Price * Weight) / 1000;
    }

    public override string ToString()
    {
        return base.ToString() + $", with {Weight} as weight";
    }
}
