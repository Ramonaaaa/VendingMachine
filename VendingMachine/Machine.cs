using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Machine
    {
        private Dictionary<IProduct, int> products;

        public Machine()
        {
            products = new Dictionary<IProduct, int>();
            FillMachine();
        }

        private void FillMachine() 
        {
            products.Add(new Coke("Coke", 1.5, 0.5, 1), 1);
            products.Add(new Pepsi("Pepsi", 1, 0.35, 2), 15);
            products.Add(new KitKat("Kit-Kat", 0.5, 65, 3), 18);

        }

        public void Menu()
        {
            string answer;
            do
            {
                IProduct selectedProduct = SelectProduct();
                BuyProduct(selectedProduct);
                Console.WriteLine("Do you want to continue with your shopping? y/n");
                answer = Console.ReadLine().ToLower();
            }
            while (answer == "y");
            


        }

        private IProduct SelectProduct()
        {
            int selectionCode = 0;
            IProduct selectedProduct = null;
            do
            {
                Console.WriteLine($"    Product    Quantity Price Tasta");
                foreach (var product in products)
                {
                    Console.WriteLine(product.Key.ToString());
                }

                Console.WriteLine("\nPlease select an option:");
                int.TryParse(Console.ReadLine(), out selectionCode);

                foreach (var item in products.Keys)
                {
                    if (item.ProductCode == selectionCode)
                    {
                        selectedProduct = item;
                    }
                }
            }
            while (selectedProduct == null); //atata timp cat utilizatorul nu a introdus o tasta valide, se repeta procedeul
            return selectedProduct;
        }

        private void BuyProduct(IProduct selectedProduct)
        {
            double currentAmount = 0;

            do
            {
                Console.WriteLine($"Please insert {selectedProduct.Price - currentAmount:C2}");
                double money;
                if (double.TryParse(Console.ReadLine(), out money))
                {
                    if (money > 0)
                    {
                        currentAmount += money;
                    }
                }

            }
            while (currentAmount < selectedProduct.Price);

            Console.WriteLine($"You just bought a {selectedProduct.Name}. Enjoy it!");

            if (currentAmount > selectedProduct.Price)
            {
                Console.WriteLine($"Don't forget to take your change: {currentAmount - selectedProduct.Price:C2}!");
            }

            products[selectedProduct]--;

            if (products[selectedProduct] == 0) //sterg produsul din lista initiala in cazul in care am luat ultimul produs
            {
                products.Remove(selectedProduct);
            }
        }


    }
}
