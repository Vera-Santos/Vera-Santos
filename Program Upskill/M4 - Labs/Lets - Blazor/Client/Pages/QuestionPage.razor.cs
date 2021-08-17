using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Identity;



namespace BlazorLets.Client.Pages
{
    public partial class QuestionPage : ComponentBase
    {
        [Parameter]

        public int id { get; set; }

        public List<Question> Questions = new List<Question>();

        public List<Enrollment> Enrollments = new List<Enrollment>();

        string Status = "Teste não submetido";

        int currentScore = 0;

        bool qualification;

        public string display { get; set; } = "none";

        public string display2 { get; set; } = "block";

        public string display3 { get; set; } = "none";

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


        protected async override Task OnParametersSetAsync()
        {
            try
            {
                Questions = await Http.GetFromJsonAsync<List<Question>>($"/api/Question/GetQuestionByTestID/{id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }


        public async Task CreateNewEnrollments()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;


            if (currentScore >= 50)
            {
                qualification = true;
            }
            else
            {
                qualification = false;
            }

            var addEnrollment = new Enrollment
            {
                Score = currentScore,
                HasSuccess = qualification,
                DoneTestAt = DateTime.Now,
                TestID = id,
                ApplicationUserID = user.FindFirst(c => c.Type == "sub")?.Value
            };
            await Http.PostAsJsonAsync("/api/Enrollment/Post", addEnrollment);
        }

        void UpdateScore(int chosenAnswerIndex, int TestIndex)
        {
            var question = Questions[TestIndex];

            if (chosenAnswerIndex == question.AnswerKey)
            {
                currentScore = currentScore + 10;
            }
        }

        private async Task FormSubmitted()
        {
            Status = "Teste submetido com sucesso";
            display = "block";
            display2 = "none";
            display3 = "flex";
            StateHasChanged();
            await CreateNewEnrollments();
        }
    }
}
