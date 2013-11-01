namespace Batch2Work.Helpers
{
    public static class StringExt
    {
        public static string NormaliseUrl(this string src)
        {
            if (src.EndsWith("/"))
                return src;
            return src + "/";
        }
    }
}