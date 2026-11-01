#if ANDROID
using Android.App;
using Android.Content;
using Android.OS;
using Microsoft.Extensions.Logging;
using SwashbucklerDiary.Maui.Platforms.Android;
#endif

namespace SwashbucklerDiary.Maui.Essentials
{
    public partial class PlatformIntegration
    {
        public async Task<bool> RequestNotificationPermissionAsync()
        {
#if ANDROID
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu)
            {
                var status = await Permissions.CheckStatusAsync<Permissions.PostNotifications>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.PostNotifications>();
                }
                return status == PermissionStatus.Granted;
            }
            return true;
#else
            return await Task.FromResult(true);
#endif
        }

        public Task ScheduleDailyReminderAsync(bool enable, int hour, int minute, string title, string content)
        {
#if ANDROID
            try
            {
                var context = global::Android.App.Application.Context;
                var alarmManager = (AlarmManager?)context.GetSystemService(Context.AlarmService);
                if (alarmManager == null) return Task.CompletedTask;

                var intent = new Intent(context, typeof(DiaryReminderReceiver));
                intent.SetAction(DiaryReminderReceiver.ActionDailyReminder);
                intent.PutExtra("title", title);
                intent.PutExtra("content", content);

                var pendingIntent = PendingIntent.GetBroadcast(
                    context, 
                    DiaryReminderReceiver.NotificationId, 
                    intent, 
                    PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);

                if (pendingIntent == null) return Task.CompletedTask;

                if (!enable)
                {
                    alarmManager.Cancel(pendingIntent);
                    return Task.CompletedTask;
                }

                // 计算提醒时间戳
                var now = DateTime.Now;
                var targetTime = new DateTime(now.Year, now.Month, now.Day, hour, minute, 0);
                if (targetTime <= now)
                {
                    targetTime = targetTime.AddDays(1);
                }

                long triggerAtMillis = new DateTimeOffset(targetTime).ToUnixTimeMilliseconds();

                if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                {
                    alarmManager.SetExactAndAllowWhileIdle(AlarmType.RtcWakeup, triggerAtMillis, pendingIntent);
                }
                else
                {
                    alarmManager.SetExact(AlarmType.RtcWakeup, triggerAtMillis, pendingIntent);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Failed to schedule daily reminder");
            }
#endif
            return Task.CompletedTask;
        }
    }
}