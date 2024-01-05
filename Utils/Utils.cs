namespace Utils
{
    public static class Utils
    {
        public static bool IsAlphaNum(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '1' && c <= '9');
        }
    }
}