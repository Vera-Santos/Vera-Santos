using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using BlazorLets.Shared.Models;


namespace BlazorLets.Client.Pages
{
    public partial class Lets : ComponentBase
    {
        [Parameter]
        public string id { get; set; }

        public Learn obj { get; set; }
        public Subject subject { get; set; }
        public CycleGradeCourse cyclegradecourse { get; set; }
        public Example objExample { get; set; }
        public List<Test> objTest { get; set; }
        bool IsOpen { get; set; }
        string learn = "learn";
        string example = "example";
        string test = "test";
        string solution = "solution";

        public List<Subject> SubjectsForBreadCrumbs { get; set; } = new List<Subject>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                obj = await Http.GetFromJsonAsync<Learn>($"/api/Learn/GetLearnBySubjectID/{id}");
                subject = await Http.GetFromJsonAsync<Subject>($"/api/Subject/GetByID/{id}");
                cyclegradecourse = await Http.GetFromJsonAsync<CycleGradeCourse>($"/api/Subject/GetCycleGradeCourse/{subject.CycleGradeCourseID}");
                objExample = await Http.GetFromJsonAsync<Example>($"/api/Example/GetExampleBySubjectID/{id}");
                objTest = await Http.GetFromJsonAsync<List<Test>>($"/api/Test/GetTestBySubjectID/{id}");
                SubjectsForBreadCrumbs = await Http.GetFromJsonAsync<List<Subject>>($"/api/Subject/GetCycleGradeCourseBySubjectID/{id}");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }


        IDictionary<string, string> collapseValues { get; set; } = new Dictionary<string, string>()
        {
            {"learn", "none"},
            { "example", "none"},
            { "test", "none"},
            { "solution", "none"}
        };
        string lastOpen { get; set; } = "";
        string lastClosed { get; set; } = "";


        void onClick(MouseEventArgs e, string element)
        {

            IsOpen = !IsOpen;
            if (IsOpen)
            {
                for (int i = 0; i != collapseValues.Count; ++i)
                {
                    if (collapseValues.ElementAt(i).Key == element && lastClosed != collapseValues.ElementAt(i).Key)
                    {
                        collapseValues[collapseValues.ElementAt(i).Key] = "";
                        lastOpen = collapseValues.ElementAt(i).Key;
                        lastClosed = "";
                    }
                    else
                    {
                        collapseValues[collapseValues.ElementAt(i).Key] = "none";
                    }
                }
            }
            else
            {
                for (int i = 0; i != collapseValues.Count; ++i)
                {
                    if (collapseValues.ElementAt(i).Key == element && lastOpen != collapseValues.ElementAt(i).Key)
                    {
                        collapseValues[collapseValues.ElementAt(i).Key] = "";
                        lastOpen = "";
                        lastClosed = collapseValues.ElementAt(i).Key;
                    }
                    else
                    {
                        collapseValues[collapseValues.ElementAt(i).Key] = "none";
                    }
                }
            }
            StateHasChanged();

        }
    }
}
