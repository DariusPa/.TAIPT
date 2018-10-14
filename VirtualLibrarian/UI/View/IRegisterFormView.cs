using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrarian.Model;
using static VirtualLibrarian.RegisterForm;

namespace VirtualLibrarian.View
{
    interface IRegisterFormView
    {
        IUserModel User { get; set; }
        event RegistrationEventHandler RegisterCompleted;





    }
}
