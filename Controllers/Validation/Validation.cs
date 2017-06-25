using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Controllers.Validation
{
    public static class Validation
    {
	    public static void ValidateNotNull(object value, string message)
	    {
			if (value == null)
			{
				throw new ValidationException(message);
			}
		}
    }
}
