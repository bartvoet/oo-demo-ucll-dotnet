namespace basketapp;

using basketapp.domain;
class Program
{
    private static string MENU = 
@"A. Toon basketmandje
B. Totale prijs
C. Voeg éénvoudig item toe
D. Voeg bulk-item toe
E. Voeg unit-item toe
F. Verwijder item
Q. Stop de applicatie";

    static string RequestTextAnswer(string message) 
    {
        Console.WriteLine(message);
        Console.Write("> ");
        return Console.ReadLine();
    }

    static int RequestNumberAnswer(string message) 
    {
        int number;
        
        string answer = RequestTextAnswer(message);        
        while(! int.TryParse(answer, out number) || number < 0) {
            Console.WriteLine($"Gelieve een positief natuurlijk getal in te geven");
            answer = RequestTextAnswer(message);
        }
        
        return number;
    }

    static int RequestPrice()
    {
        return RequestNumberAnswer("Gelieve de prijs in te geven");
    }

    static string RequestDescription()
    {
        return RequestTextAnswer("Gelieve de beschrijving in te geven");
    }


    static void Main(string[] args)
    {
        Basket basket = new Basket("test");

        bool go = true;
        while(go) {
            Console.WriteLine(MENU);
            string choice = RequestTextAnswer("Gelieve uw keuze uit het menu in te geven");
            switch(choice) {
                case("A"):  {
                    foreach(BasketItem item in basket.BasketItems) {
                        Console.WriteLine(item);
                    }
                }
                break;
                case("B"):  {
                    Console.WriteLine(basket.CalculateTotalPrice());
                }
                break;
                case("C"):  {
                    BasketItem simpleBasketItem = new BasketItem() {
                        Price = RequestPrice(),
                        Description = RequestDescription()
                    };
                    basket.AddItem(simpleBasketItem);
                }
                break;
                case("D"):  {
                    BasketItem bulkBasketItem = new BulkBasketItem() {
                        Price = RequestPrice(),
                        Description = RequestDescription(),
                        Weight = RequestNumberAnswer("Gelieve het gewicht in te geven")

                    };
                    basket.AddItem(bulkBasketItem);
                }
                break;
                case("E"):  {
                    BasketItem bulkBasketItem = new QuantityBasketItem() {
                        Price = RequestPrice(),
                        Description = RequestDescription(),
                        Quantity = RequestNumberAnswer("Gelieve het aantal elementen in te geven")
                    };
                    basket.AddItem(bulkBasketItem);
                }
                break;
                case("F"):  {
                    int id = RequestNumberAnswer("Gelieve de id van het item te geven");
                    basket.RemoveItem(id);
                }
                break;
                case("Q"):  {
                    Console.WriteLine("Quiting the application");
                    go = false;
                }
                break;
                default: Console.WriteLine("Foutieve keuze");break;
            }
        }
    }
}
