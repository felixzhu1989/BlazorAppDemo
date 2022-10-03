using BlazorAppCodingDroplets.Models;

namespace BlazorAppCodingDroplets
{
    public interface IContactService
    {
        List<Contact> GetContacts();
        void AddContact(Contact contact);
    }
}
