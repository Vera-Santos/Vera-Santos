using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using BlazorLets.Shared.Models;



namespace BlazorLets.Client.Pages
{
    public partial class Path : ComponentBase
    {
        public string id { get; set; }

        public List<Enrollment> Enrollments { get; set; }

        public string display { get; set; } = "none";

        public string display2 { get; set; } = "block";

        public string display3 { get; set; } = "none";

        public string display4 { get; set; } = "block";

        public string display5 { get; set; } = "none";
        public int verifyId { get; set; }
        public int clicked { get; set; }
        private bool IsOpened { get; set; } = false;

        public List<Question> Questions = new List<Question>();


        protected async override Task OnParametersSetAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var ApplicationUserID = user.FindFirst(c => c.Type == "sub")?.Value;
            id = ApplicationUserID;
            try
            {
                Enrollments = await Http.GetFromJsonAsync<List<Enrollment>>($"/api/Enrollment/GetEnrollmentbyApplicationUserID/{id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }


        private async Task conquistas()
        {
            await OnParametersSetAsync();
            display = "block";
            display2 = "none";
            StateHasChanged();
        }

        private async Task tentativas()
        {
            await OnParametersSetAsync();
            display3 = "block";
            display4 = "none";
            StateHasChanged();
        }

        void OpenCloseModal(MouseEventArgs e, int EnrollmentID)
        {
            if (IsOpened == false)
            {
                IsOpened = true;
            }
            else
            {
                IsOpened = false;
            }
            verifyId = EnrollmentID;
            clicked = 1;
            StateHasChanged();
        }

        void onClick(MouseEventArgs e, int EnrollmentID)
        {
            verifyId = EnrollmentID;
            clicked = 1;

            StateHasChanged();
        }
    }
}
