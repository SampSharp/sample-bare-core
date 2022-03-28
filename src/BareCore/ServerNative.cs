using SampSharp.Core.Natives.NativeObjects;

namespace BareCore
{
    public class ServerNative
    {
        [NativeMethod]
        public virtual void AddPlayerClass(int model, float x, float y, float z, float angle, int weapon1, int ammo1,
            int weapon2, int ammo2, int weapon3, int ammo3) => throw new NativeNotImplementedException();

        [NativeMethod]
        public virtual void SetGameModeText(string text) => throw new NativeNotImplementedException();
    }
}