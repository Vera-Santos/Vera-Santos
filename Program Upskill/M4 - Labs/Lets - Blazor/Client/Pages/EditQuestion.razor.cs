using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace BlazorLets.Client.Pages
{
    public partial class EditQuestion : ComponentBase
    {
        [Parameter]
        public string id { get; set; }
        string imageToDisplay;
        public Question Question { get; set; } = new Question();
        IList<IBrowserFile> files = new List<IBrowserFile>();

        protected async override Task OnParametersSetAsync()
        {
            Question = await Http.GetFromJsonAsync<Question>($"api/Question/GetByID/{id}");
        }

        async Task Edit()
        {
            await Http.PutAsJsonAsync($"api/Question/{id}", Question);
            NavigationManager.NavigateTo($"Lets/1");
        }

        private void RemoveImage()
        {
            Question.Image = null;
        }

        async Task UploadFile(InputFileChangeEventArgs e)
        {
            var format = "image/png";
            var resizedImage = await e.File.RequestImageFileAsync(format, 1060, 1060);
            Question.Image = new byte[resizedImage.Size];
            await resizedImage.OpenReadStream().ReadAsync(Question.Image);
        }

        string ConvertImageToDisplay(byte[] image)
        {
            var imageData = Convert.ToBase64String(image);

            if (imageData != null)
            {
                imageToDisplay = string.Format("data:image/jpg;base64,{0}", imageData);
                return imageToDisplay;
            }

            return "";
        }

        public void GoBack()
        {
            NavigationManager.NavigateTo($"Lets/1");
        }
    }
}
