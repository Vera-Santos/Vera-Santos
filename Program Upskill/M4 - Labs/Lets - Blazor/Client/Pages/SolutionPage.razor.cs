using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;


namespace BlazorLets.Client.Pages
{
    public partial class SolutionPage : ComponentBase
    {
        [Parameter]

        public int id { get; set; }

        public List<Question> Solutions = new List<Question>();

        protected async override Task OnParametersSetAsync()
        {
            try
            {
                Solutions = await Http.GetFromJsonAsync<List<Question>>($"/api/Question/GetQuestionByTestID/{id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
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
