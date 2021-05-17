using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChatSharedCode
{
    public enum Status
    {
        None,Successful,Error,SuccessfulLogin,WrongEmailOrPassword,AlreadyLoggedIn,TokenInvalid,EmployeeAlreadyExist,IdentityNumberNotFound
    }
}
