using System;
using SampSharp.Core;
using SampSharp.Core.Callbacks;
using SampSharp.Core.Natives.NativeObjects;

namespace BareCore
{
    public class GameMode : IGameModeProvider
    {
        private IGameModeClient _client;

        public void Initialize(IGameModeClient client)
        {
            _client = client;

            // Load callbacks from the the current instance.
            _client.RegisterCallbacksInObject(this);

            // Could also have explicitly specify which callbacks should load. That way you wouldn't need to add [Callback] attributes.
            // _client.RegisterCallback("OnGameModeInit", this, GetType().GetMethod(nameof(OnGameModeInit)));

            // Log errors to the console
            _client.UnhandledException += (sender, args) => Console.WriteLine($"ERROR ({args.CallbackName}): {args.Exception}");
        }

        [Callback]
        public void OnGameModeInit()
        {
            Console.WriteLine("Game mode is loading");

            var server = NativeObjectProxyFactory.CreateInstance<ServerNative>();

            server.AddPlayerClass(0, 1482.9055f, 1504.2122f, 10.5474f, 0, 0, 0, 0, 0, 0, 0);
            server.SetGameModeText("Empty server");
        }

        [Callback]
        public void OnPlayerConnect(int playerId)
        {
            var player = NativeObjectProxyFactory.CreateInstance<Player>(playerId);

            player.GetName(out var name, 32);
            player.SendClientMessage(-1, $"Hello, {name}");

            player.SendClientMessageToAll(0x00FF00FF, $"Please welcome {name} to the server!");

            player.Money = 9000;
        }

        public void Tick()
        {
        }

        public void Dispose()
        {
        }
    }
}