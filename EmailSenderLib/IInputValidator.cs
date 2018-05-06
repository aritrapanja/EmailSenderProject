using System.Collections.Generic;

namespace EmailSenderLib
{
    public interface IInputValidator
    {
        List<string> ValidateInputs(Request req);
    }
}