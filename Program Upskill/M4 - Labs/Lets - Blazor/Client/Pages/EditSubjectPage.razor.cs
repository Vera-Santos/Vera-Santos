using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorLets.Client.Pages
{
    public partial class EditSubjectPage : ComponentBase
    {
        [Parameter]
        public string id { get; set; }

        public Subject Subject { get; set; } = new Subject();

        protected async override Task OnParametersSetAsync()
        {
            Subject = await Http.GetFromJsonAsync<Subject>($"/api/Subject/GetByID/{id}");
        }

        public async Task Edit()
        {
            await Http.PutAsJsonAsync($"/api/Subject/Put/{id}", Subject);
            NavigationManager.NavigateTo($"/SubjectPage/{Subject.CycleGradeCourseID}");
        }

        public void GoBack()
        {
            NavigationManager.NavigateTo($"/SubjectPage/{Subject.CycleGradeCourseID}");
        }
    }
}
