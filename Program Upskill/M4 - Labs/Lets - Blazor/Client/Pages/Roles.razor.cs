using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using BlazorLets.Shared.Models;


namespace BlazorLets.Client.Pages
{
    public partial class Roles : ComponentBase
    {
        public List<UserWithRoles> usersWithRoles { get; set; }
        public ApplicationUser obj { get; set; } = new ApplicationUser();
        public UserWithRoles newUserWithRoles { get; set; } = new UserWithRoles();
        string knowRole { get; set; } = "";
        string rightRole = "";
        string getId { get; set; } = "";
        public string knowFirstRole { get; set; } = "";
        string Admin { get; set; } = "Admin";
        string User { get; set; } = "User";
        List<string> Options = new List<string>() { "User", "Admin" };
        List<string> Options2 = new List<string>() { "Admin", "User" };
        string Message { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                usersWithRoles = await Http.GetFromJsonAsync<List<UserWithRoles>>($"/api/ApplicationUser/GetApplicationUserWithRole");

            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        async Task Edit()
        {
            if (newUserWithRoles.Id == "Selecione o Id do utilizador para o editar" || newUserWithRoles.Id == null)
            {
                Message = "Por favor, selecione o Id do utilizador";
            }
            else
            {
                Message = "Utilizador editado com sucesso";
                newUserWithRoles.Role = rightRole;
                await Http.PostAsJsonAsync($"/api/ApplicationUser/EditUserRole/{newUserWithRoles.Role}", newUserWithRoles);
                NavigationManager.NavigateTo("/Roles", true);
            }


        }
        string funcao1(string role)
        {
            knowFirstRole = role;
            rightRole = role;
            return role;
        }

        string funcao2(string role)
        {
            if (role == "User")
            {
                knowFirstRole = "";
                rightRole = "Admin";
                return "Admin";
            }
            else
            {
                knowFirstRole = "";
                rightRole = "User";
                return "User";
            }
        }
    }
}
