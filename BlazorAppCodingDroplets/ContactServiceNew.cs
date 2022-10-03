using BlazorAppCodingDroplets.Models;

namespace BlazorAppCodingDroplets
{
    public class ContactServiceNew:IContactService
    {
        private List<Contact> contacts = new();
        public List<Contact> GetContacts()
        {
            return new List<Contact>()
            {
                new() {FirstName = "John",LastName = "Thomas",Email = "john@gmail.com"},
            };
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }
    }
}
