using Cer.Core.Abstractions;
using Cer.Core.Interfaces.Models;

namespace Cer.Core.Models
{
    public class User : BaseEntity, IUser
    {
        public string NickName { get; set; }
    }
}