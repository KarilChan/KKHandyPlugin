using BepInEx.Configuration;

namespace KKHandy
{
    partial class HandySync
    {
        internal static ConfigEntry<int> ConfigServerPort;

        void BindConfig()
        {
            ConfigServerPort = Config.Bind(
                "Server",
                "Port",
                42069,
                "Localhost port for the HandyPluginServer. This should match the port value in server settings."
            );
        }
    }
}
