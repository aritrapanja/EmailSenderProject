using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailSenderLib
{
    public class Inputvalidator : IInputValidator
    {
        private static readonly string EmailRegex = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        private static readonly int MaxAddressCount = 1000;

        // private static readonly int BodyCount = 999999;

        public static bool IsValidEmail(string addr)
        {
            if( string.IsNullOrWhiteSpace(addr))
            {
                return false;
            }
            if (Regex.IsMatch(addr, EmailRegex))
            {
                return true;
            }
            return false;
        }

        public static bool IsValidEmails(string addrs)
        {
            string[] partsFromAddrs = addrs.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            if (partsFromAddrs.Length > MaxAddressCount)
            {
                return false;
            }

            foreach (var add in partsFromAddrs)
            {
                if (!IsValidEmail(add))
                {
                    return false;
                }
            }
            return true;
        }

        public List<string> ValidateInputs(Request req)
        {
            var errors = new List<string>();

            if (!IsValidEmail(req.From))
            {
                errors.Add("From field is invalid email address");
            }

            if (string.IsNullOrWhiteSpace(req.To) && string.IsNullOrWhiteSpace(req.Cc) && string.IsNullOrWhiteSpace(req.Bcc))
            {
                errors.Add("To, Cc, Bcc none is populated.");
            }

            if (!string.IsNullOrWhiteSpace(req.To) && !IsValidEmails(req.To))
            {
                errors.Add(string.Format("To field {0} has invalid email address or exceeds maximum count", req.To));
            }

            if (!string.IsNullOrWhiteSpace(req.Bcc) && !IsValidEmails(req.Bcc))
            {
                errors.Add(string.Format("Bcc field {0} has invalid email address or exceeds maximum count", req.Bcc));
            }

            if (!string.IsNullOrWhiteSpace(req.Cc) && !IsValidEmails(req.Cc))
            {
                errors.Add(string.Format("CC field {0} has invalid email address or exceeds maximum count", req.Cc));
            }

            if (string.IsNullOrWhiteSpace(req.Body) && string.IsNullOrWhiteSpace(req.Subject))
            {
                errors.Add(string.Format("Subject and Body both are null, empty or whitespace(s)", req.Cc));
            }
            return errors;
        }
    }
}





