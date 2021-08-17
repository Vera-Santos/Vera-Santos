using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorLets.Client.Pages
{
    public partial class TestPage : ComponentBase
    {
        [Parameter]
        public List<Test> Test { get; set; }

        [Parameter]
        public ApplicationUser User { get; set; } = new ApplicationUser();

        public int verifyTestId { get; set; } 
        public int beforeVerifyTestId { get; set; }
        public int clicked { get; set; }
        public string display { get; set; } = "flex";
        private bool IsOpened { get; set; } = false;

        void onClick(MouseEventArgs e, int testeID)
        {
            verifyTestId = testeID;
            clicked = 1;
            display = "none";
            if (IsOpened == false)
            {
                IsOpened = true;
            }
            else
            {
                IsOpened = false;
            }
            StateHasChanged();
        }

        void onClick2(MouseEventArgs e, int testeID)
        {
            beforeVerifyTestId = testeID;
            clicked = 1;
            OpenCloseModal();
            display = "flex";
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;
                User.Id = user.FindFirst(c => c.Type == "sub")?.Value;
                
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        void OpenCloseModal()
        {
            verifyTestId = beforeVerifyTestId;
            if (IsOpened == false)
            {
                IsOpened = true;
            }
            else
            {
                IsOpened = false;
            }
            display = "none";
        }
    }
}
