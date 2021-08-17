using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Components;



namespace BlazorLets.Client.Pages
{
    public partial class ExamplePage : ComponentBase
    {
        [Parameter]
        public Example Example { get; set; }

      
    }
}
