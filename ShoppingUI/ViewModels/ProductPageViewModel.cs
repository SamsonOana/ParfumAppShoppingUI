
using System;
using System.Collections.ObjectModel;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Input;

namespace ShoppingUI
{
    public class ProductPageViewModel
    {
        public ObservableCollection<Items> Items { get; set; }

        public ObservableCollection<Items> CartItems { get; set; }

        public Items SelectedItem { get; set; }

        public ICommand Itemclick { get; set; }
        public ICommand CartItemclick { get; set; }
        public ProductPageViewModel(INavigation navigation)
        {
            Items = new ObservableCollection<Items>
            {
                new Items
                {
                    Picture="armani_beauty.jpg",
                    Name = "Because It's You For Her",
                    Quantity = "1",
                    Price = "$80"
                },
                new Items
                {
                    Picture="carolina_herrera.jpg",
                    Name = "Carolina Herrera - Good Girl",
                    Quantity = "1",
                    Price = "$82"
                },
                new Items
                {
                    Picture="lancome.jpg",
                    Name = "Lancome - La Vie est Belle",
                    Quantity = "1",
                    Price = "$137"
                },
                new Items
                {
                    Picture="mugler.jpg",
                    Name = "Mugler - Alien",
                    Quantity = "1",
                    Price = "$101"
                },
                new Items
                {
                    Picture="tom_ford.jpg",
                    Name = "Tom Ford - Tobacco Vanille",
                    Quantity = "1",
                    Price = "$219"
                },
                new Items
                {
                    Picture="ysl.jpg",
                    Name = "Yves Saint Laurent - Black Opium",
                    Quantity = "1",
                    Price = "$98"
                }
            };
            CartItems = new ObservableCollection<Items> { };
            Itemclick = new Command<Items>(executeitemclickcommand);
            CartItemclick = new Command<Items>(executeCartitemclickcommand);
            this.navigation = navigation;
        }
        private INavigation navigation;

        async void executeitemclickcommand(Items item)
        {
            this.SelectedItem = item;
            await navigation.PushModalAsync(new DetailsPage(this));
        }

        async void executeCartitemclickcommand(Items item)
        {
            this.CartItems.Add(this.SelectedItem);
            await navigation.PushModalAsync(new CartPage(this));

        }
    }
}
