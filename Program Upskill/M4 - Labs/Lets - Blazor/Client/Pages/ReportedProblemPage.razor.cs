using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorLets.Client.Pages
{
    public partial class ReportedProblemPage : ComponentBase
    {
        public ReportedProblem ReportedProblem = new ReportedProblem();

        public string LastSubmittedResult;

        private bool IsOpened { get; set; } = false;

        private async void PostForm(EditContext editContext)
        {
            bool formIsValid = editContext.Validate();
            if (formIsValid == true)
            {
                LastSubmittedResult = "Enviado com sucesso";
            }

            var reportedProblem = new ReportedProblem
            {
                Text = ReportedProblem.Text,
                UserEmail = ReportedProblem.UserEmail,
                SubmissionDate = DateTime.Now,
                Done = false
            };

            await Http.PostAsJsonAsync("/api/ReportedProblem/Post", reportedProblem);

            await Task.Delay(1000);
            NavigationManager.NavigateTo("/");
        }

        private void Exit()
        {
            NavigationManager.NavigateTo("/");
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
        }

    }
}
