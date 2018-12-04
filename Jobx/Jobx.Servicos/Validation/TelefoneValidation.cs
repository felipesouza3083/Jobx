using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jobx.Servicos.Validation
{
    public class TelefoneValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                if (value.ToString().Length <= 10)
                {
                    return false;
                }

                //return Regex.Match(value.ToString(), @"^\([1-9]{2}\)9[1-9][0-9]{3}\-[0-9]{4}$").Success;
                return value.ToString().All(char.IsDigit);
            }
            return false;
        }
    }
}