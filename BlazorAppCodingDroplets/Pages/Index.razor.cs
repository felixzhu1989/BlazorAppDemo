using BlazorAppCodingDroplets.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAppCodingDroplets.Pages
{
    public partial class Index
    {
        [Inject] private IContactService ContactService { get; set; }
        private List<Contact> contacts;

        private Dictionary<string, object> MyTextBoxAttributes = new()
        {
            {"placeholder","Email"},
            {"type","text"},
            {"disabled","disabled"}
        };

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(3000);//模拟延迟
            contacts = ContactService.GetContacts();
            /*contacts = new List<Contact>
            {
                new() {FirstName = "John",LastName = "Thomas",Email = "john@gmail.com"},
                new() {FirstName = "Peter",LastName = "Bob",Email = "peter@gmail.com"},
                new() {FirstName = "George",LastName = "David",Email = "george@gmail.com"}
            };*/
            await base.OnInitializedAsync();
        }
    }
}
