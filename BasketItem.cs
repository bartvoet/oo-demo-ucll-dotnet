namespace basketapp;
class BasketItem
{
    public BasketItem():this(0)
    {
         
    }

    public BasketItem(int id) 
    {
        this.Id = id;
    }

    public int Id {get; set;}
    public int Price {get;set;}
    public string Description {get;set;}

    public virtual int CalculateTotalPrice() {
        return Price;
    }

    public override string ToString()
    {
         return $"BasketItem with id {Id}: {Description} with {Price}";
    }
}
