using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using SwashbucklerDiary.Rcl.Services;
using SwashbucklerDiary.Rcl.Themes;

namespace SwashbucklerDiary.Rcl.Components
{
    public partial class MorandiThemeDialog : DialogComponentBase
    {
        private string selectedThemeId = MorandiThemes.DefaultThemeId;
        private string originalThemeId = MorandiThemes.DefaultThemeId;

        [Inject]
        private ISettingService SettingService { get; set; } = default!;

        [Inject]
        private IJSRuntime JSRuntime { get; set; } = default!;

        [Inject]
        private MasaBlazor MasaBlazor { get; set; } = default!;

        [Inject]
        private II18nService I18n { get; set; } = default!;

        [Parameter]
        public EventCallback<string> OnThemeChanged { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            selectedThemeId = SettingService.Get(s => s.ThemeColorId, MorandiThemes.DefaultThemeId);
            originalThemeId = selectedThemeId;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (Visible)
            {
                selectedThemeId = SettingService.Get(s => s.ThemeColorId, MorandiThemes.DefaultThemeId);
                originalThemeId = selectedThemeId;
            }
        }

        private async Task SelectTheme(MorandiThemeModel theme)
        {
            selectedThemeId = theme.Id;
            await MorandiThemes.ApplyThemeAsync(JSRuntime, MasaBlazor, theme);
        }

        protected override async Task HandleOnCancel(MouseEventArgs _)
        {
            if (selectedThemeId != originalThemeId)
            {
                var prevTheme = MorandiThemes.GetTheme(originalThemeId);
                await MorandiThemes.ApplyThemeAsync(JSRuntime, MasaBlazor, prevTheme);
            }
            await InternalVisibleChanged(false);
        }

        private async Task HandleOnConfirm()
        {
            var theme = MorandiThemes.GetTheme(selectedThemeId);
            await MorandiThemes.ApplyThemeAsync(JSRuntime, MasaBlazor, theme);
            await SettingService.SetAsync(s => s.ThemeColorId, selectedThemeId);

            if (OnThemeChanged.HasDelegate)
            {
                await OnThemeChanged.InvokeAsync(selectedThemeId);
            }

            await InternalVisibleChanged(false);
        }
    }
}