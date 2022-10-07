using BlazorAppCodingDroplets.Models;
using BlazorAppCodingDroplets.Pages.ContactComponents;
using Microsoft.AspNetCore.Components;

namespace BlazorAppCodingDroplets.Pages
{
    public partial class Index
    {
        [Inject] private IContactService ContactService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        private List<Contact> contacts;
        private ContactList contactList;
        private bool isContactsDisplay=true;
        private Dictionary<string, object> MyTextBoxAttributes = new()
        {
            {"placeholder","Email"},
            {"type","text"},
            {"disabled","disabled"}
        };

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1000);//模拟延迟
            contacts = ContactService.GetContacts();
            /*contacts = new List<Contact>
            {
                new() {FirstName = "John",LastName = "Thomas",Email = "john@gmail.com"},
                new() {FirstName = "Peter",LastName = "Bob",Email = "peter@gmail.com"},
                new() {FirstName = "George",LastName = "David",Email = "george@gmail.com"}
            };*/
            await base.OnInitializedAsync();
        }

        private void ShowOrHideContacts()
        {
            if (isContactsDisplay) contactList.HideContacts();
            else contactList.ShowContacts();
            isContactsDisplay = !isContactsDisplay;
        }

        private void NavigateToTest()
        {
            NavigationManager.NavigateTo("./test");
        }
    }
}
