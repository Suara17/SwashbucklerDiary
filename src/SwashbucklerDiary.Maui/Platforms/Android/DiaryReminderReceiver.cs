#if ANDROID
using Android.App;
using Android.Content;
using AndroidX.Core.App;

namespace SwashbucklerDiary.Maui.Platforms.Android
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class DiaryReminderReceiver : BroadcastReceiver
    {
        public const string ActionDailyReminder = "com.yucore.swashbucklerdiary.DAILY_REMINDER";
        public const string ChannelId = "diary_daily_reminder_channel";
        public const int NotificationId = 1001;

        public override void OnReceive(Context? context, Intent? intent)
        {
            if (context == null) return;

            string title = intent?.GetStringExtra("title") ?? "侠客日记";
            string content = intent?.GetStringExtra("content") ?? "今天的故事记录下来了吗？记录此刻的心情与思绪吧。";

            var notificationManager = (NotificationManager?)context.GetSystemService(Context.NotificationService);
            if (notificationManager == null) return;

            // Android 8.0+ 创建通知渠道
            if (global::Android.OS.Build.VERSION.SdkInt >= global::Android.OS.BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(ChannelId, "每日日记提醒", NotificationImportance.High)
                {
                    Description = "每天定时提醒记录日记"
                };
                channel.EnableVibration(true);
                channel.EnableLights(true);
                notificationManager.CreateNotificationChannel(channel);
            }

            // 点击通知拉起 MainActivity
            var clickIntent = new Intent(context, typeof(MainActivity));
            clickIntent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            var pendingIntent = PendingIntent.GetActivity(context, 0, clickIntent, 
                PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Immutable);

            var builder = new NotificationCompat.Builder(context, ChannelId)
                .SetContentTitle(title)
                .SetContentText(content)
                .SetSmallIcon(global::Android.Resource.Drawable.IcDialogInfo)
                .SetAutoCancel(true)
                .SetPriority(NotificationCompat.PriorityHigh)
                .SetDefaults(NotificationCompat.DefaultAll);

            if (pendingIntent != null)
            {
                builder.SetContentIntent(pendingIntent);
            }

            var notification = builder.Build();
            if (notification != null)
            {
                notificationManager.Notify(NotificationId, notification);
            }
        }
    }
}
#endif