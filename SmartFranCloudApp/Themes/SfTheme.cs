using MudBlazor;

namespace SmartFranCloudApp.Themes;

public static class SmartFranTheme
{
	public static MudTheme Create() => new MudTheme {
		PaletteLight = new PaletteLight	{
			Primary        = "#6e59ee",
			PrimaryDarken  = "#5444d4",
			PrimaryLighten = "#9080f5",

			Secondary        = "#6558a0",
			SecondaryDarken  = "#4d4188",
			SecondaryLighten = "#c8bef8",

			Tertiary        = "#006267",
			TertiaryDarken  = "#004f53",
			TertiaryLighten = "#40dae3",

			Background = "#f9f8ff",
			Surface    = "#f9f8ff",

			TextPrimary   = "#19124a",
			TextSecondary = "#4c4568",

			Error             = "#ba1a1a",
			ErrorContrastText = "#ffffff",

			Divider      = "rgba(129,114,135,0.15)",
			TableLines   = "rgba(129,114,135,0.10)",
			LinesDefault = "rgba(129,114,135,0.15)",
			LinesInputs  = "rgba(0,0,0,0)",

			AppbarBackground = "#19124a",
			AppbarText       = "#f9f8ff",

			DrawerBackground = "#2c2458",
			DrawerText       = "#f9f8ff",
			DrawerIcon       = "#c5bbff",

			ActionDefault            = "#4c4568",
			ActionDisabled           = "rgba(25,18,74,0.26)",
			ActionDisabledBackground = "rgba(25,18,74,0.12)",

			HoverOpacity  = 0.08,
			RippleOpacity = 0.10,
		},

		Typography = new Typography	{
			Default = new DefaultTypography	{
				FontFamily = new[] { "Manrope", "sans-serif" },
				FontSize   = "1rem",
				FontWeight = "400",
				LineHeight = "1.5",
			},
			H1 = new H1Typography	{
				FontFamily = new[] { "Plus Jakarta Sans", "sans-serif" },
				FontSize   = "3.5rem",
				FontWeight = "800",
				LineHeight = "1.1",
			},
			H2 = new H2Typography	{
				FontFamily = new[] { "Plus Jakarta Sans", "sans-serif" },
				FontSize   = "2.5rem",
				FontWeight = "700",
			},
			H3 = new H3Typography	{
				FontFamily = new[] { "Plus Jakarta Sans", "sans-serif" },
				FontSize   = "2rem",
				FontWeight = "700",
			},
			H4 = new H4Typography	{
				FontFamily = new[] { "Plus Jakarta Sans", "sans-serif" },
				FontSize   = "1.5rem",
				FontWeight = "700",
			},
			H5 = new H5Typography	{
				FontFamily = new[] { "Plus Jakarta Sans", "sans-serif" },
				FontSize   = "1.25rem",
				FontWeight = "700",
			},
			H6 = new H6Typography	{
				FontFamily = new[] { "Plus Jakarta Sans", "sans-serif" },
				FontSize   = "1rem",
				FontWeight = "700",
			},
			Button = new ButtonTypography	{
				FontFamily    = new[] { "Plus Jakarta Sans", "sans-serif" },
				FontSize      = "1rem",
				FontWeight    = "700",
				TextTransform = "none",
				LetterSpacing = "0",
			},
			Subtitle1 = new Subtitle1Typography	{
				FontFamily = new[] { "Manrope", "sans-serif" },
				FontWeight = "600",
			},
			Caption = new CaptionTypography	{
				FontFamily    = new[] { "Manrope", "sans-serif" },
				FontSize      = "0.75rem",
				LetterSpacing = "0.08em",
			},
		},

		// MudBlazor v8: Shape fue reemplazado por LayoutProperties
		LayoutProperties = new LayoutProperties	{
			DefaultBorderRadius = "16px",
		},

		Shadows = new Shadow {
			Elevation = new string[] {
				"none",
				"0 2px 8px -2px rgba(25,18,74,0.06)",
				"0 4px 16px -4px rgba(25,18,74,0.08)",
				"0 8px 24px -6px rgba(25,18,74,0.10)",
				"0 12px 40px -8px rgba(25,18,74,0.12)",
				"0 16px 40px -5px rgba(25,18,74,0.06), 0 8px 20px -8px rgba(110,89,238,0.15)",
				"0 20px 40px -5px rgba(25,18,74,0.06)",
				"0 24px 40px -5px rgba(25,18,74,0.06)",
				"0 28px 40px -5px rgba(25,18,74,0.06)",
				"0 32px 40px -5px rgba(25,18,74,0.06)",
				"0 36px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
				"0 40px 40px -5px rgba(25,18,74,0.06)",
			},
		},

		// MudBlazor v8: ZIndex.Modal → ZIndex.Dialog
		ZIndex = new ZIndex {
			Dialog  = 1400,
			Drawer  = 1200,
			AppBar  = 1100,
			Tooltip = 1600,
			Popover = 1300,
		},
	};
}
