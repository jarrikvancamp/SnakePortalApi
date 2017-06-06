using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Portal.UnitTests.CustomAsserts
{
    public static class AssertOnException
    {
        public static TException Catch<TException>(Action action) where TException : Exception
        {
            try
            {
                action();
            }
            catch(TException exception)
            {
                return exception;
            }

            Assert.Fail($"Expected an exception of type {typeof(TException).Name}");
            return null;
        }
    }
}
