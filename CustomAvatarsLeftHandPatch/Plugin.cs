using IPA;
using HarmonyLib;
using IPALogger = IPA.Logging.Logger;
using System.Linq;

namespace CustomAvatarsLeftHandPatch
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        /// <summary>
        /// Use to send log messages through BSIPA.
        /// </summary>
        internal static IPALogger Log { get; private set; }
        private Harmony _harmony;
        public const string HARMONY_ID = "com.github.rynan4818.CustomAvatarsLeftHandPatch";

        [Init]
        public Plugin(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            this._harmony = new Harmony(HARMONY_ID);
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Log.Info("OnApplicationStart");
            var tCustomAvatar = typeof(CustomAvatar.PoseManager);
            var tBeatSaberUtilities = tCustomAvatar.Assembly.GetTypes()
                .First(x => x.FullName == "CustomAvatar.Utilities.BeatSaberUtilities");
            var mBeatSaberUtilities = AccessTools.Method(tBeatSaberUtilities, "AdjustPlatformSpecificControllerPose");
            var mPrefix = AccessTools.Method(typeof(BeatSaberUtilitiesPatch), "Prefix");
            this._harmony.Patch(mBeatSaberUtilities, new HarmonyMethod(mPrefix));
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            this._harmony.UnpatchSelf();
            Log.Debug("OnApplicationQuit");
        }

    }
}
