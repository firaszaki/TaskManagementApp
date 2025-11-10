using MudBlazor;

namespace TaskManagementApp.WebManagement.Components.Themes;

public static class UiTheme
{
    public static MudTheme MainTheme = new MudTheme
    {
        PaletteLight = new PaletteLight
        {
            AppbarBackground = "#044A80",
            Background = "rgba(136, 106, 181, 0.04)",
            DrawerBackground = "#0060A9",
            Primary = "#1565C0",
            Secondary = "#5E35B1",
            Tertiary = "#4CAF50",
            Success = "#43A047",
            Error = "#D6291C",
            Warning = "#D97900",
            Info = "#03A9F4",
            Dark = "#424242",
            Divider = "#737D98"
        },

        Typography = new Typography
        {

            Default = new DefaultTypography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                FontSize = "1rem",
                LetterSpacing = "0.02rem"
            },
            H1 = new H1Typography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                FontSize = "48px",
                LetterSpacing = "0.02rem"
            },
            H2 = new H2Typography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                FontSize = "40px",
                LetterSpacing = "0.02rem"
            },
            H3 = new H3Typography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                FontSize = "36px",
                LetterSpacing = "0.02rem"
            },
            H4 = new H4Typography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                FontSize = "26px",
                LetterSpacing = "0.02rem"
            },
            H5 = new H5Typography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                FontSize = "20px",
                LetterSpacing = "0.02rem"
            },
            H6 = new H6Typography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                FontSize = "18px",
                LetterSpacing = "0.02rem"
            },
            Body1 = new Body1Typography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                //FontSize = "0.9rem",
                FontSize = "1rem",
                LetterSpacing = "0.02rem"
            },
            Body2 = new Body2Typography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                FontSize = "1rem",
                FontWeight = "400",
                LetterSpacing = "0.02rem"
            },
            Subtitle1 = new Subtitle1Typography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                FontSize = "1rem",
                LetterSpacing = "0.02rem"
            },
            Subtitle2 = new Subtitle2Typography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                FontSize = "1rem",
                LetterSpacing = "0.02rem"

            },
            Caption = new CaptionTypography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                FontSize = "0.75rem",
                LetterSpacing = "0.02rem"
            },
            Button = new ButtonTypography
            {
                FontFamily = new string[] { "Poppins-Regular" },
                TextTransform = "none",
                LetterSpacing = "0.02rem"

            }
        }
    };
}
