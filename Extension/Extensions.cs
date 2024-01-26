namespace System
{
    public static class Extensions
    {
        public static int ToUInt16(this object str)
        {
            return Convert.ToUInt16(str);
        }

        public static uint ToUInt32(this object str)
        {
            return Convert.ToUInt32(str);
        }
    }
}