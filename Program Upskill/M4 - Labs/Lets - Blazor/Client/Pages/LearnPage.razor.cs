using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using BlazorLets.Shared.Models;

namespace BlazorLets.Client.Pages
{
    public partial class LearnPage : ComponentBase
    {
        [Parameter]
        public Learn Learn { get; set; }

        public IdentityRole<string> identityRole { get; set; } = new IdentityRole<string>();

        public ApplicationUser User { get; set; } = new ApplicationUser();

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(5000);
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            User.Id = user.FindFirst(c => c.Type == "sub")?.Value;
            if (User.Id != null)
            {
                identityRole = await Http.GetFromJsonAsync<IdentityRole<string>>($"/api/ApplicationUser/GetRole/{User.Id}");
            }
        }

        string ConvertImageToDisplay(byte[] image)
        {
            if (image != null)
            {
                var imageData = Convert.ToBase64String(image);
                var imageBase64 = string.Format("data:image/jpg;base64,{0}", imageData);
                return imageBase64;
            }
            return "";
        }
    }
}
