using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;
using PlayerRoles;
using RadioFrequency.Features;

namespace RadioFrequency
{
    public class Config : IConfig
    {
        [Description("Whether the plugin is enabled or disabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether the debug mode is enabled or disabled.")]
        public bool Debug { get; set; } = false;

        [Description("Whether the default radio channel is enabled or disabled.")]
        public bool UseDefaultRadio { get; set; } = true;

        [Description("The default radio frequency name.")]
        public string DefaultRadioName { get; set; } = "All";

        [Description("All radio frenquency.")]
        public List<Frequency> Frequencies { get; set; } = new()
        {
            new Frequency
            {
                Name = "446 MHz",
                AuthorizedRoles = new HashSet<RoleTypeId>(),
                CanBePickedUp = false,
            }
        };

		[Description("The centered text (header) of the category.")]
		public int SettingHeaderId { get; set; } = 101;

        [Description("The centered text (header) of the category.")]
        public string SettingHeaderLabel { get; set; } = "RadioFrequency";

		[Description("The unique id of the setting.")]
        public int KeybindId { get; set; } = 201;

        [Description("The keybind label.")]
        public string KeybindLabel { get; set; } = "Change radio frequency.";

        [Description("The keybind hint used to provides additional information.")]
        public string KeybindHint { get; set; } = "Allows you to change the frequency of your radio.";

        [Description("Hint displayed when the player has no radio.")]
        public string NoRadioHint { get; set; } = "You need a radio to change its frequency.";

        [Description("Hint displayed when the frequency has been changed.")]
        public string ChangedFrequencyHint { get; set; } = "You changed the radio frequency to {radio_frequency}.";
    }
}
