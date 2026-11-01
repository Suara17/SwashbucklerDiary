using SwashbucklerDiary.Rcl.Components;
using SwashbucklerDiary.Rcl.Essentials;

namespace SwashbucklerDiary.Rcl.Pages
{
    public partial class AlertSettingPage : ImportantComponentBase
    {
        private int timeout;

        private bool showTimeout;

        private bool achievementsAlert;

        private bool dailyReminder;

        private string dailyReminderTimeStr = "21:00";

        private TimeOnly dailyReminderTime = new(21, 0);

        private bool showTimePicker;

        private Dictionary<string, int> timeoutItems = [];

        protected override void OnInitialized()
        {
            base.OnInitialized();

            InitTimeoutItems();
        }

        protected override void ReadSettings()
        {
            base.ReadSettings();

            timeout = SettingService.Get(s => s.AlertTimeout);
            achievementsAlert = SettingService.Get(s => s.AchievementsAlert);
            dailyReminder = SettingService.Get(s => s.DailyReminder);
            dailyReminderTimeStr = SettingService.Get(s => s.DailyReminderTime, "21:00");
            if (TimeOnly.TryParse(dailyReminderTimeStr, out var parsed))
            {
                dailyReminderTime = parsed;
            }
        }

        private string TimeoutText => timeoutItems.FirstOrDefault(it => it.Value == timeout).Key;

        private async Task UpdateSetting()
        {
            await SettingService.SetAsync(s => s.AlertTimeout, timeout);
        }

        private async Task HandleDailyReminderChanged(bool value)
        {
            dailyReminder = value;
            if (dailyReminder)
            {
                var granted = await PlatformIntegration.RequestNotificationPermissionAsync();
                if (!granted)
                {
                    await AlertService.WarningAsync(I18n.Culture.Name.StartsWith("zh") ? "请先开启系统通知权限" : "Please enable notification permission");
                }
            }

            await ApplyReminderScheduleAsync();
        }

        private async Task HandleTimeChanged(TimeOnly time)
        {
            dailyReminderTime = time;
            dailyReminderTimeStr = time.ToString("HH:mm");
            showTimePicker = false;
            await SettingService.SetAsync(s => s.DailyReminderTime, dailyReminderTimeStr);
            await ApplyReminderScheduleAsync();
        }

        private async Task ApplyReminderScheduleAsync()
        {
            string title = I18n.Culture.Name.StartsWith("zh") ? "侠客日记" : "Swashbuckler Diary";
            string content = I18n.Culture.Name.StartsWith("zh") 
                ? "今天的故事记录下来了吗？记录此刻的心情与思绪吧。" 
                : "Have you recorded today's story? Write down your thoughts and moments.";

            await PlatformIntegration.ScheduleDailyReminderAsync(
                dailyReminder, 
                dailyReminderTime.Hour, 
                dailyReminderTime.Minute, 
                title, 
                content);
        }

        private void InitTimeoutItems()
        {
            Dictionary<string, int> items = [];
            for (int i = 0; i < 5; i++)
            {
                items.Add($"{i + 1}s", (i + 1) * 1000);
            }

            timeoutItems = items;
        }
    }
}
