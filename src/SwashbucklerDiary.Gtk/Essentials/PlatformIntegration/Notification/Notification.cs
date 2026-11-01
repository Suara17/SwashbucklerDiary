namespace SwashbucklerDiary.Gtk.Essentials
{
    public partial class PlatformIntegration
    {
        public Task<bool> RequestNotificationPermissionAsync()
        {
            return Task.FromResult(true);
        }

        public Task ScheduleDailyReminderAsync(bool enable, int hour, int minute, string title, string content)
        {
            return Task.CompletedTask;
        }
    }
}
