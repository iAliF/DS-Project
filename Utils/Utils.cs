namespace Utils
{
    public static class Utils
    {
        public static bool IsAlphaNum(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '1' && c <= '9');
        }
        
        public static bool IsOperator(char c)
        {
            return !IsAlphaNum(c) && c != '(' && c != ')' && c != ' ';
        }
    }
}