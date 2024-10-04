using Example.TestAutomation.DemoTests.Settings.Models;
using Example.TestAutomation.Ui.Options;

namespace Example.TestAutomation.DemoTests.Settings
{
    public class UserProvider
    {
        private readonly IExampleOptions _options;

        public UserProvider(IExampleOptions oneIncOptions)
        {
            _options = oneIncOptions;
        }

        public User DefaultUser => new(_options.BaseConfigOptions.ClaimsPayApiUserName!,
            _options.BaseConfigOptions.ClaimsPayApiPassword!);

        public User DefaultUiUser => new(_options.SwagLabsOptions!.WebAppUserName,
            _options.SwagLabsOptions.WebAppPassword);

        public User Admin => new(_options.BaseConfigOptions.AdminUserLogin,
            _options.BaseConfigOptions.AdminUserPassword);



        public enum Users
        {
            DefaultUser,
            DefaultUiUser,
            Admin,
            DefaultUiIEPR,
            VendorAdmin,
            WithPreference,
            WithoutPreference,
            DefaultUiLogs,
            DefaultUiUtil,
            NglsUser
        };
    }
}
