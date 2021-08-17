using System.Collections.Generic;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorLets.Client.Pages
{
    public partial class TestSolutionPage : ComponentBase
    {
        [Parameter]
        public List<Test> TestSolution { get; set; }

        public int verifyId { get; set; }
        public int clicked { get; set; }
        public string display { get; set; } = "flex";

        void onClick(MouseEventArgs e, int testeID)
        {
            verifyId = testeID;
            clicked = 1;
            display = "none";
            StateHasChanged();
        }
    }
}
