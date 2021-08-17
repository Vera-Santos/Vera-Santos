using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using BlazorLets.Shared.Models;



namespace BlazorLets.Client.Pages
{
    public partial class ViewTestPage : ComponentBase
    {
        
        [Parameter]

        public int id { get; set; }

        public int count { get; set; } = 0;

        public List<Answer> AnswerList;

        public Enrollment Enrollments;

        public string display { get; set; } = "none";

        public string display2 { get; set; } = "block";

        public string display3 { get; set; } = "none";


        void Count()
        {
            count++;
            if (count == 4)
            {
                count = 0;
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
                Enrollments = await Http.GetFromJsonAsync<Enrollment>($"/api/Enrollment/GetByID/{id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
