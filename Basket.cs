namespace basketapp.domain;
class Basket
{
    private int IdCounter = 0;

    public List<BasketItem> BasketItems { get; } = new List<BasketItem>();
    public string Name { get; private set; }
    

    public Basket(string name) 
    {
        if ( string.IsNullOrWhiteSpace( name ) ) {
            throw new ArgumentNullException( "name" );
        }

        Name = name;
    }

    public void AddItem(BasketItem basketItem) 
    {
        basketItem.Id = IdCounter++;
        BasketItems.Add(basketItem);
    }

    public void RemoveItem(int id)
    {
        BasketItem itemToRemove = null;

        foreach(BasketItem item in BasketItems) {
            if (item.Id == id) {
                itemToRemove = item;
            }
        }    
        if (itemToRemove != null) {
            BasketItems.Remove(itemToRemove);
        }
    }

    public int CalculateTotalPrice() {
        int totalPrice = 0;
        foreach (BasketItem item in BasketItems) {
            totalPrice += item.CalculateTotalPrice();
        }
        return totalPrice;
    }

}
