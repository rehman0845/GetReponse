using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestGet360.Models.Contacts;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestGet360.Models.Icontacts
{
    public interface  IGRContact
    {
        Task<string> PostContact(PostContacts ct);
        //IList<GetContact> GetContacts();
        Task<string> GetContacts();

        Task<bool> CheckContact(string email);
    }
}