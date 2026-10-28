using Masa.Blazor;
using Microsoft.JSInterop;
using SwashbucklerDiary.Rcl.Extensions;

namespace SwashbucklerDiary.Rcl.Themes
{
    public class MorandiThemeModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string Primary { get; set; } = string.Empty;
        public string LightBg { get; set; } = string.Empty;
        public string DarkBg { get; set; } = string.Empty;
        public string BadgeBg { get; set; } = string.Empty;
        public string DarkBadgeBg { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public static class MorandiThemes
    {
        public const string DefaultThemeId = "rouge-ink";

        public static readonly List<MorandiThemeModel> Presets = new()
        {
            // ===== 核心 3 大经典撞色 (依据设计图调配) =====
            new()
            {
                Id = "rouge-ink",
                Name = "胭脂墨黑",
                NameEn = "Rouge & Ink",
                Primary = "#FF7CA2",
                LightBg = "#FFF0F4",
                DarkBg = "#13161C",
                BadgeBg = "#FFE4EC",
                DarkBadgeBg = "#2E1B24",
                Description = "甜酷先锋：胭脂粉 × 墨黑色，极夜微光与高光粉撞色"
            },
            new()
            {
                Id = "periwinkle-brown",
                Name = "长春花蓝",
                NameEn = "Periwinkle & Brown",
                Primary = "#7B8AD7",
                LightBg = "#F2F4FC",
                DarkBg = "#281D19",
                BadgeBg = "#E5E8F8",
                DarkBadgeBg = "#3D2B24",
                Description = "美拉德复古：长春花蓝 × 可可棕，冷暖互衬的色彩碰撞"
            },
            new()
            {
                Id = "sun-wormwood",
                Name = "浅松艾草",
                NameEn = "Pine & Wormwood",
                Primary = "#FFC44F",
                LightBg = "#FFF9EC",
                DarkBg = "#14221A",
                BadgeBg = "#FFF1D4",
                DarkBadgeBg = "#23382B",
                Description = "清新生机：浅松黄 × 艾草青，初夏晨曦与青草律动"
            },

            // ===== 莫兰迪自然治愈色系 =====
            new()
            {
                Id = "haze-blue",
                Name = "雾霾蓝",
                NameEn = "Haze Blue",
                Primary = "#6C8A9C",
                LightBg = "#EDF3F6",
                DarkBg = "#1C252C",
                BadgeBg = "#E1ECF2",
                DarkBadgeBg = "#25333C",
                Description = "静谧如初晨水汽，轻柔优雅"
            },
            new()
            {
                Id = "sage-green",
                Name = "鼠尾草绿",
                NameEn = "Sage Green",
                Primary = "#738E7B",
                LightBg = "#EFF5F1",
                DarkBg = "#1C2520",
                BadgeBg = "#E2ECE5",
                DarkBadgeBg = "#24342A",
                Description = "微风拂过叶片，治愈系自然呼吸"
            },
            new()
            {
                Id = "dusty-rose",
                Name = "豆沙烟粉",
                NameEn = "Dusty Rose",
                Primary = "#A67878",
                LightBg = "#F8F1F1",
                DarkBg = "#291E20",
                BadgeBg = "#F2E4E4",
                DarkBadgeBg = "#3A272A",
                Description = "温柔低调的微醺色泽，温润不刺眼"
            },
            new()
            {
                Id = "warm-almond",
                Name = "暖杏奶咖",
                NameEn = "Warm Almond",
                Primary = "#9B8470",
                LightBg = "#F7F3EE",
                DarkBg = "#28221E",
                BadgeBg = "#EFE7DE",
                DarkBadgeBg = "#382F28",
                Description = "午后暖阳与燕麦拿铁，满溢复古感"
            },
            new()
            {
                Id = "muted-lavender",
                Name = "浅烟紫",
                NameEn = "Muted Lavender",
                Primary = "#877A99",
                LightBg = "#F3F0F7",
                DarkBg = "#231F2A",
                BadgeBg = "#EAE3F4",
                DarkBadgeBg = "#322A3D",
                Description = "暮色中的薰衣草，宁静而神秘"
            },
            new()
            {
                Id = "eucalyptus",
                Name = "云杉灰青",
                NameEn = "Eucalyptus",
                Primary = "#5C7C78",
                LightBg = "#EDF4F3",
                DarkBg = "#1A2423",
                BadgeBg = "#DEEAE8",
                DarkBadgeBg = "#243534",
                Description = "深山松柏与晨雾，清冽而沉稳"
            },
            new()
            {
                Id = "slate-grey",
                Name = "冷岩灰",
                NameEn = "Slate Grey",
                Primary = "#6E7A88",
                LightBg = "#F0F2F6",
                DarkBg = "#1F2228",
                BadgeBg = "#E2E6ED",
                DarkBadgeBg = "#292E37",
                Description = "现代建筑水泥质感，极简高级"
            },
            new()
            {
                Id = "classic-indigo",
                Name = "经典靛蓝",
                NameEn = "Classic Indigo",
                Primary = "#5C6BC0",
                LightBg = "#ECEEF9",
                DarkBg = "#1E2338",
                BadgeBg = "#DFE3F7",
                DarkBadgeBg = "#272D48",
                Description = "经典深邃的书墨蓝，纯粹沉稳"
            }
        };

        public static MorandiThemeModel GetTheme(string? id)
        {
            return Presets.FirstOrDefault(x => x.Id == id) ?? Presets[0];
        }

        public static async Task ApplyThemeAsync(IJSRuntime jsRuntime, MasaBlazor masaBlazor, MorandiThemeModel theme)
        {
            try
            {
                if (masaBlazor?.Theme?.Themes != null)
                {
                    if (masaBlazor.Theme.Themes.Light != null)
                    {
                        masaBlazor.Theme.Themes.Light.Primary = theme.Primary;
                    }
                    if (masaBlazor.Theme.Themes.Dark != null)
                    {
                        masaBlazor.Theme.Themes.Dark.Primary = theme.Primary;
                    }
                }
            }
            catch { }

            // 1. 设置 CSS 变量 (遵循 evaluateJavascript 单行表达式)
            try
            {
                await jsRuntime.EvaluateJavascript($"document.documentElement.style.setProperty('--theme-primary', '{theme.Primary}')");
                await jsRuntime.EvaluateJavascript($"document.documentElement.style.setProperty('--theme-card-bg', '{theme.LightBg}')");
                await jsRuntime.EvaluateJavascript($"document.documentElement.style.setProperty('--theme-card-bg-dark', '{theme.DarkBg}')");
                await jsRuntime.EvaluateJavascript($"document.documentElement.style.setProperty('--theme-badge-bg', '{theme.BadgeBg}')");
                await jsRuntime.EvaluateJavascript($"document.documentElement.style.setProperty('--theme-badge-bg-dark', '{theme.DarkBadgeBg}')");
                await jsRuntime.EvaluateJavascript($"document.documentElement.style.setProperty('--m-theme-primary', '{theme.Primary}')");
            }
            catch { }

            // 2. 动态向 head 注入/更新专属高优先级样式标签，覆盖所有 primary 颜色与卡片背景
            try
            {
                string cssContent = $@"
                    :root {{
                        --theme-primary: {theme.Primary} !important;
                        --theme-card-bg: {theme.LightBg} !important;
                        --theme-card-bg-dark: {theme.DarkBg} !important;
                        --theme-badge-bg: {theme.BadgeBg} !important;
                        --theme-badge-bg-dark: {theme.DarkBadgeBg} !important;
                        --m-theme-primary: {theme.Primary} !important;
                    }}
                    .diary-card-compact--default {{
                        background: {theme.LightBg} !important;
                        border: 1px solid rgba(0, 0, 0, 0.05) !important;
                    }}
                    .theme--dark .diary-card-compact--default {{
                        background: {theme.DarkBg} !important;
                        border: 1px solid rgba(255, 255, 255, 0.08) !important;
                    }}
                    .timeline-node-badge:not(.timeline-node-badge--top) {{
                        background: {theme.BadgeBg} !important;
                        color: {theme.Primary} !important;
                    }}
                    .theme--dark .timeline-node-badge:not(.timeline-node-badge--top) {{
                        background: {theme.DarkBadgeBg} !important;
                        color: {theme.Primary} !important;
                    }}
                    .material-symbols_active .m-icon {{
                        color: {theme.Primary} !important;
                    }}
                    .btn-primary, .m-btn.primary, .m-btn.m-btn--depressed.primary, .m-btn--fab.primary {{
                        background-color: {theme.Primary} !important;
                        border-color: {theme.Primary} !important;
                    }}
                    .diary-card-compact.is-active,
                    .diary-card-compact:hover {{
                        border-color: {theme.Primary} !important;
                    }}
                    .compact-card__tap-hint {{
                        color: {theme.Primary} !important;
                    }}
                ".Replace("\r\n", " ").Replace("\n", " ").Replace("\"", "\\\"");

                string injectScript = $"(function(){{var s=document.getElementById('morandi-theme-override');if(!s){{s=document.createElement('style');s.id='morandi-theme-override';document.head.appendChild(s);}}s.textContent=\"{cssContent}\";return true;}})()";
                await jsRuntime.EvaluateJavascript(injectScript);
            }
            catch { }
        }
    }
}