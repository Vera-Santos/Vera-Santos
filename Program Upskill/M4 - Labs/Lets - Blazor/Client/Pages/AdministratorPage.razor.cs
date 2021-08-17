using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorLets.Client.Pages
{
    public partial class AdministratorPage : ComponentBase
    {
        private ApplicationUser User = new ApplicationUser();
        private List<ApplicationUser> Users = new List<ApplicationUser>();
        private string nameFilter = string.Empty;
        private int currentPage = 1;
        private int totalPageQuantity;
        private int quantityPerPage = 4;

        protected override async Task OnInitializedAsync()
        {
            await LoadUsers();
        }

        private async Task SelectedPage(int page)
        {
            currentPage = page;
            await LoadUsers(page);
        }

        private async Task Filter()
        {
            await LoadUsers();
        }

        private async Task Clear()
        {
            nameFilter = string.Empty;
            await LoadUsers();
        }

        async Task LoadUsers(int page = 1)
        {
            var httpResponse = await http.GetAsync($"/api/ApplicationUser?page={page}&quantityPerPage={quantityPerPage}&name={nameFilter}");
            if (httpResponse.IsSuccessStatusCode)
            {
                totalPageQuantity = int.Parse(httpResponse.Headers.GetValues("pagesQuantity").FirstOrDefault()); //retorna a quantidade de páginas para informar ao componente Pagination
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                Users = JsonSerializer.Deserialize<List<ApplicationUser>>(responseString, //Desserialização da lista para objetos
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            else
            {
            }
        }

        async Task Delete(string id)
        {
            var user = Users.First(x => x.Id == id);
            if (await js.InvokeAsync<bool>("confirm", $"Deseja realmente excluir o registro de {user.Name}?"))
            {
                await http.DeleteAsync($"api/ApplicationUser/DeleteApplicationUser/{id}");
                await OnInitializedAsync();
            }
        }
    }
}
