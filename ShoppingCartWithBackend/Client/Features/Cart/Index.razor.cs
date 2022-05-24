using Microsoft.AspNetCore.Components;

using ShoppingCartStarter.Shared.Cart;

using System.Net.Http.Json;

namespace ShoppingCartStarter.Client.Features.Cart
{
    public partial class Index
    {
        [Inject] private HttpClient Http { get; set; }

        protected Details.Model Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ReloadCart();
        }

        protected void RemoveItem(Details.Model.LineItem item)
        {
            Model.Items.Remove(item);
        }

        protected async Task ReloadCart()
        {
            Model = await Http.GetFromJsonAsync<Details.Model>("api/cart");
        }
    }
}