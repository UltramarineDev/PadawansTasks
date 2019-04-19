using System;

namespace PadawansTask10
{
    public static class NullableTypeExtensions
    {
        public static bool IsNull(this object variable)
        {
            // put your code here
            // throw new NotImplementedException();
            if (variable == null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
