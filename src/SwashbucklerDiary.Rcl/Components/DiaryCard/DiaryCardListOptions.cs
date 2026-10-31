using SwashbucklerDiary.Shared;

namespace SwashbucklerDiary.Rcl.Components
{
    public class DiaryCardListOptions
    {
        public DiaryModel SelectedItemValue { get; set; } = new();

        public string? TimeFormat { get; set; }

        public bool Template { get; set; }

        public Guid? DefaultTemplateId { get; set; }

        public bool Markdown { get; set; }

        public bool AutoTitle { get; set; }

        /// <summary>
        /// 每日首条日记的 ID 集合，用于在时间轴中渲染日期分组标题
        /// </summary>
        public HashSet<Guid> FirstDayDiaryIds { get; set; } = [];
    }
}
