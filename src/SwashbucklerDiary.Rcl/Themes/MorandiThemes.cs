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

        // 全局整套主题的页面底色、容器背景、文字色与边框色
        public string PageBg { get; set; } = string.Empty;
        public string SurfaceBg { get; set; } = string.Empty;
        public string SurfaceContainer { get; set; } = string.Empty;
        public string TextColor { get; set; } = string.Empty;
        public string SubTextColor { get; set; } = string.Empty;
        public string BorderColor { get; set; } = string.Empty;
        public string TagColor { get; set; } = string.Empty;
        public bool IsContrastTheme { get; set; } = false;
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
                LightBg = "#151821",
                DarkBg = "#151821",
                BadgeBg = "#2E1B24",
                DarkBadgeBg = "#2E1B24",
                PageBg = "#0A0C0F",
                SurfaceBg = "#12151B",
                SurfaceContainer = "#191D26",
                TextColor = "#F8FAFC",
                SubTextColor = "#94A3B8",
                BorderColor = "rgba(255, 124, 162, 0.22)",
                TagColor = "墨黑色",
                IsContrastTheme = true,
                Description = "甜酷先锋：胭脂粉 × 墨黑色，全页面极夜黑底与高光粉碰撞"
            },
            new()
            {
                Id = "periwinkle-brown",
                Name = "长春花蓝",
                NameEn = "Periwinkle & Brown",
                Primary = "#7B8AD7",
                LightBg = "#271D18",
                DarkBg = "#271D18",
                BadgeBg = "#3D2B24",
                DarkBadgeBg = "#3D2B24",
                PageBg = "#1B1411",
                SurfaceBg = "#241B17",
                SurfaceContainer = "#2F231E",
                TextColor = "#F8FAFC",
                SubTextColor = "#BBAEA8",
                BorderColor = "rgba(123, 138, 215, 0.28)",
                TagColor = "可可棕",
                IsContrastTheme = true,
                Description = "美拉德复古：长春花蓝 × 可可棕，全页面醇厚可可底与冷蓝撞色"
            },
            new()
            {
                Id = "sun-wormwood",
                Name = "浅松艾草",
                NameEn = "Pine & Wormwood",
                Primary = "#FFC44F",
                LightBg = "#15241D",
                DarkBg = "#15241D",
                BadgeBg = "#23382B",
                DarkBadgeBg = "#23382B",
                PageBg = "#0C1712",
                SurfaceBg = "#122019",
                SurfaceContainer = "#182C22",
                TextColor = "#F8FAFC",
                SubTextColor = "#8EA396",
                BorderColor = "rgba(255, 196, 79, 0.25)",
                TagColor = "艾草青",
                IsContrastTheme = true,
                Description = "清新生机：浅松黄 × 艾草青，全页面深林幽绿底与暖金撞色"
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
                string extraCss = string.Empty;
                if (theme.IsContrastTheme)
                {
                    extraCss = $@"
                        /* 1. 全局背景与应用包裹层 */
                        html, body, .m-application, .m-application--wrap, .m-main, .my-container,
                        .page-cache-container, .scroll-container, .adaptive-card-container {{
                            background-color: {theme.PageBg} !important;
                            color: {theme.TextColor} !important;
                        }}

                        /* 2. 顶栏、底栏、导航抽屉 */
                        .m-app-bar, .m-toolbar, .m-toolbar.m-sheet {{
                            background-color: {theme.SurfaceBg} !important;
                            color: {theme.TextColor} !important;
                            border-bottom: 1px solid {theme.BorderColor} !important;
                        }}
                        .m-bottom-navigation {{
                            background-color: {theme.SurfaceBg} !important;
                            color: {theme.TextColor} !important;
                            border-top: 1px solid {theme.BorderColor} !important;
                        }}
                        .m-navigation-drawer {{
                            background-color: {theme.SurfaceBg} !important;
                            border-right: 1px solid {theme.BorderColor} !important;
                            color: {theme.TextColor} !important;
                        }}

                        /* 3. 标签栏与导航项 */
                        .m-tabs, .my-tab, .m-tabs-bar {{
                            background-color: transparent !important;
                            color: {theme.TextColor} !important;
                        }}
                        .m-tab {{
                            color: {theme.SubTextColor} !important;
                        }}
                        .m-tab--active {{
                            color: {theme.Primary} !important;
                        }}
                        .m-bottom-navigation .m-btn {{
                            background-color: transparent !important;
                            color: {theme.SubTextColor} !important;
                        }}
                        .m-bottom-navigation .m-btn.material-symbols_active {{
                            color: {theme.Primary} !important;
                        }}

                        /* 4. 所有页面卡片、列表容器与分类卡片 */
                        .m-card, .m-sheet {{
                            background-color: {theme.SurfaceBg} !important;
                            color: {theme.TextColor} !important;
                        }}
                        .m-card:not(.diary-card-compact) {{
                            border: 1px solid {theme.BorderColor} !important;
                        }}
                        .m-list {{
                            background-color: transparent !important;
                            color: {theme.TextColor} !important;
                        }}
                        .m-list-item {{
                            color: {theme.TextColor} !important;
                        }}
                        .m-list-item__title, .m-list-item__subtitle {{
                            color: {theme.TextColor} !important;
                        }}
                        .m-list-item__subtitle {{
                            opacity: 0.72;
                        }}

                        /* 5. 日记时间轴卡片与专属内容微排版 */
                        .diary-card-compact--default {{
                            background: {theme.LightBg} !important;
                            border: 1px solid {theme.BorderColor} !important;
                            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.45) !important;
                        }}
                        .compact-card__title, .compact-card__content, .m-toolbar-title {{
                            color: {theme.TextColor} !important;
                        }}
                        .compact-card__content {{
                            opacity: 0.88;
                        }}
                        .timeline-row::before, .timeline-time-col {{
                            color: {theme.SubTextColor} !important;
                        }}
                        .compact-card__inner-box {{
                            background: {theme.SurfaceContainer} !important;
                            color: {theme.SubTextColor} !important;
                            border: 1px solid {theme.BorderColor} !important;
                        }}
                        .compact-card__inner-box strong, .compact-card__inner-box span {{
                            color: {theme.TextColor} !important;
                        }}
                        .compact-card__pill {{
                            background: {theme.DarkBadgeBg} !important;
                            color: {theme.Primary} !important;
                            border: 1px solid {theme.BorderColor} !important;
                        }}
                        .timeline-node-badge:not(.timeline-node-badge--top) {{
                            background: {theme.BadgeBg} !important;
                            color: {theme.Primary} !important;
                            border: 2px solid {theme.PageBg} !important;
                        }}
                        .setting-title {{
                            color: {theme.Primary} !important;
                        }}

                        /* 6. 输入框、搜索栏、弹窗、气泡 */
                        .m-input, .m-text-field, .m-text-field--solo .m-input__slot {{
                            background-color: {theme.SurfaceContainer} !important;
                            color: {theme.TextColor} !important;
                        }}
                        .m-text-field input, .m-text-field textarea {{
                            color: {theme.TextColor} !important;
                        }}
                        .m-dialog, .m-dialog > .m-card {{
                            background-color: {theme.SurfaceBg} !important;
                            color: {theme.TextColor} !important;
                            border: 1px solid {theme.BorderColor} !important;
                        }}
                        .morandi-dialog-card {{
                            background-color: {theme.SurfaceBg} !important;
                            color: {theme.TextColor} !important;
                        }}
                        .morandi-palette-card {{
                            background: {theme.SurfaceContainer} !important;
                            border: 1.5px solid {theme.BorderColor} !important;
                            color: {theme.TextColor} !important;
                        }}
                        .morandi-palette-card.is-selected {{
                            background: {theme.SurfaceContainer} !important;
                            border-color: {theme.Primary} !important;
                        }}
                        .morandi-name {{
                            color: {theme.TextColor} !important;
                        }}
                        .morandi-desc {{
                            color: {theme.SubTextColor} !important;
                        }}
                        .m-divider {{
                            border-color: {theme.BorderColor} !important;
                            opacity: 0.5;
                        }}
                        .m-icon {{
                            color: inherit;
                        }}

                        /* 7. 日历页面 MDatePicker 深度撞色适配 */
                        .m-picker, .m-picker__body, .m-date-picker-table, .m-date-picker-header {{
                            background-color: {theme.SurfaceBg} !important;
                            color: {theme.TextColor} !important;
                        }}
                        .m-date-picker-table th, .m-date-picker-table .m-btn__content {{
                            color: {theme.TextColor} !important;
                        }}
                        .m-date-picker-table .m-btn--active {{
                            background-color: {theme.Primary} !important;
                            color: #FFFFFF !important;
                        }}

                        /* 8. Markdown 编辑器与预览区域沉浸撞色 */
                        .vditor, .vditor-toolbar, .vditor-reset, .write-input-wrap, .write-markdown-wrap {{
                            background-color: {theme.PageBg} !important;
                            color: {theme.TextColor} !important;
                            border-color: {theme.BorderColor} !important;
                        }}
                        .vditor-toolbar {{
                            background-color: {theme.SurfaceBg} !important;
                            border-top: 1px solid {theme.BorderColor} !important;
                        }}
                        .vditor-toolbar__item svg {{
                            fill: {theme.TextColor} !important;
                        }}
                        .vditor-reset * {{
                            color: {theme.TextColor} !important;
                        }}
                    ";
                }

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
                    {extraCss}
                ".Replace("\r\n", " ").Replace("\n", " ").Replace("\"", "\\\"");

                string injectScript = $"(function(){{var s=document.getElementById('morandi-theme-override');if(!s){{s=document.createElement('style');s.id='morandi-theme-override';document.head.appendChild(s);}}s.textContent=\"{cssContent}\";return true;}})()";
                await jsRuntime.EvaluateJavascript(injectScript);
            }
            catch { }
        }
    }
}