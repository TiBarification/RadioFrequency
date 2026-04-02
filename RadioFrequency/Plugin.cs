using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using PlayerRoles;
using RadioFrequency.Features;

namespace RadioFrequency
{
    public class Plugin : Plugin<Config>
    {
        private IEnumerable<SettingBase> _settings;

        public override string Name { get; } = "RadioFrequency";
        public override string Author { get; } = "Bolton & TiBarification";
        public override Version Version { get; } = new(1, 1, 0);
        public override Version RequiredExiledVersion { get; } = new(9, 13, 0);

        public static Plugin Singleton { get; private set; }

        public override void OnEnabled()
        {
            Singleton = this;

            if (Config.UseDefaultRadio)
            {
                Frequency defaultFrequency = new(Config.DefaultRadioName, new HashSet<RoleTypeId>(), true);
                defaultFrequency.Init();
            }

            foreach (Frequency frequency in Config.Frequencies)
            {
                frequency.Init();
            }

            _settings =
			[
				new HeaderSetting(Config.SettingHeaderId, Config.SettingHeaderLabel),
                new KeybindSetting(Config.KeybindId, Config.KeybindLabel, default, hintDescription: Config.KeybindHint),
            ];
            SettingBase.Register(_settings);

            EventHandlers.RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;

            SettingBase.Unregister((Func<Player, bool>)null, _settings);
            _settings = null;

            EventHandlers.UnregisterEvents();

            base.OnDisabled();
        }
    }
}
