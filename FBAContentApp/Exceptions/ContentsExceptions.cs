using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBAContentApp.Exceptions
{
    [System.Serializable]
    public class NonSaveableException : Exception
    {
        public NonSaveableException() {
        }

        public NonSaveableException(string message) : base(message) { }

        public NonSaveableException(string message, Exception inner) : base(message, inner) { }

        protected NonSaveableException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [System.Serializable]
    public class AlreadyExistsInDBException : Exception
    {
        public AlreadyExistsInDBException() { }
        public AlreadyExistsInDBException(string message) : base(message) { }
        public AlreadyExistsInDBException(string message, Exception inner) : base(message, inner) { }
        protected AlreadyExistsInDBException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    
}
