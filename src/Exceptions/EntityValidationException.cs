using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class EntityValidationException : Exception
    {
        public EntityValidationException(string message = DefaultExceptionMessages.ENTITY_VALIDATION_EXCEPTION) : base(message)
        {
        }
    }
}
