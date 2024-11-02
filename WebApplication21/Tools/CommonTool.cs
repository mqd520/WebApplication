namespace WebApplication21.Tools
{
    public static class CommonTool
    {
        public static Random CreateRandom()
        {
            var buffer = Guid.NewGuid().ToByteArray();
            var iRoot = BitConverter.ToInt32(buffer, 0);
            return new Random(iRoot);
        }
    }
}
