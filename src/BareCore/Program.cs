using SampSharp.Core;

namespace BareCore
{
    internal static class Program
    {
        public static void Main()
        {
            new GameModeBuilder()
                .Use<GameMode>()
                .Run();
        }
    }
}