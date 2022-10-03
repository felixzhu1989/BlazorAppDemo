using BlazorAppCodingDroplets.Models;

namespace BlazorAppCodingDroplets
{
    public class ContactService: IContactService
    {
        private List<Contact> contacts = new();
        public List<Contact> GetContacts()
        {
            return contacts;
        }
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }
    }
}
