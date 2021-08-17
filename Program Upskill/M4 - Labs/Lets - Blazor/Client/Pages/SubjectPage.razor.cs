using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;




namespace BlazorLets.Client.Pages
{
    public partial class SubjectPage : ComponentBase
    {
        [Parameter]
        public string id { get; set; }

        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public List<Subject> SubjectsForBreadCrumbs { get; set; } = new List<Subject>();

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

        protected async override Task OnParametersSetAsync()
        {
            try
            {
                Subjects = await Http.GetFromJsonAsync<List<Subject>>($"/api/Subject/GetSubjectID/{id}");
                SubjectsForBreadCrumbs = await Http.GetFromJsonAsync<List<Subject>>($"/api/Subject/GetCycleGradeCourseBySubjectID/{id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
