using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using BlazorLets.Shared.Models;

namespace BlazorLets.Client.Pages
{
    public partial class EditLearn : ComponentBase
    {
        [Parameter]
        public string id { get; set; }
        string imageToDisplay;
        public Learn Learn { get; set; } = new Learn();
        IList<IBrowserFile> files = new List<IBrowserFile>();

        protected async override Task OnParametersSetAsync()
        {
            //int learnId = Int.Parse(LearnID);
            Learn = await Http.GetFromJsonAsync<Learn>($"api/Learn/Get/{id}");
        }

        async Task Edit()
        {
            await Http.PutAsJsonAsync("api/Learn/Put", Learn);
            NavigationManager.NavigateTo($"/Lets/{Learn.SubjectID}");
        }
        private void RemoveImage()
        {
            Learn.Image = null;
        }

        async Task UploadFile(InputFileChangeEventArgs e)
        {
            var format = "image/png";
            var resizedImage = await e.File.RequestImageFileAsync(format, 1060, 1060);
            Learn.Image = new byte[resizedImage.Size];
            await resizedImage.OpenReadStream().ReadAsync(Learn.Image);
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
    }
}
