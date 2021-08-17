using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorLets.Client.Pages
{
    public partial class EditExample : ComponentBase
    {
        [Parameter] public string id { get; set; }
        string imageToDisplay;
        public Example Example { get; set; } = new Example();
        IList<IBrowserFile> files = new List<IBrowserFile>();

        protected async override Task OnParametersSetAsync()
        {
            Example = await Http.GetFromJsonAsync<Example>($"api/Example/{id}");
        }

        async Task Edit()
        {
            await Http.PutAsJsonAsync($"api/Example/{id}", Example);
            NavigationManager.NavigateTo($"/Lets/{Example.SubjectID}");
        }

        private void RemoveImage()
        {
            Example.Image = null;
        }

        async Task UploadFile(InputFileChangeEventArgs e)
        {
            var format = "image/png";
            var resizedImage = await e.File.RequestImageFileAsync(format, 1060, 1060);
            Example.Image = new byte[resizedImage.Size];
            await resizedImage.OpenReadStream().ReadAsync(Example.Image);
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
