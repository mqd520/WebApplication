namespace WebApplication15.Tools
{
    public static class CommonTool
    {
        public static Random CreateRandom()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iRoot = BitConverter.ToInt32(buffer, 0);
            return new Random(iRoot);
        }
    }
}
