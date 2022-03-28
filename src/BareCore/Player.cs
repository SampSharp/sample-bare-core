using SampSharp.Core.Natives.NativeObjects;

namespace BareCore
{
    [NativeObjectIdentifiers("Id")] // Prepend all native function wrappers within this class with the (integer) value of the "Id" property.
    public class Player
    {
        public Player(int id)
        {
            Id = id;
        }

        public int Id { get; }

        [NativeProperty(GetFunction = "GetPlayerMoney")]
        // If the property was called "PlayerMoney", I wouldn't have had explicitly specify the getter functions.
        public virtual int Money
        {
            get => throw new NativeNotImplementedException();
            set
            {
                // SampSharp won't be able to find a native function called "SetMoney", so this base implementation will be called.
                var diff = value - Money;

                if (diff != 0)
                    GivePlayerMoney(diff);
            }
        }

        [NativeMethod]
        protected virtual void GivePlayerMoney(int amount) => throw new NativeNotImplementedException();

        [NativeMethod(Function = "GetPlayerName")]
        public virtual void GetName(out string name, int length) => throw new NativeNotImplementedException();

        [NativeMethod]
        public virtual void SendClientMessage(int color, string message) => throw new NativeNotImplementedException();
        
        [NativeMethod(ignoreIdentifiers: true)] // Don't prepend the native object identifiers of this class; the signature of this native function is "native SendClientMessageToAll(color, const message[])".
        public virtual void SendClientMessageToAll(int color, string message) =>
            throw new NativeNotImplementedException();
    }
}