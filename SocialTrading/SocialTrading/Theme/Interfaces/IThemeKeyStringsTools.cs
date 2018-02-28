namespace SocialTrading.Theme.Interfaces
{
    public interface IThemeKeyStringsTools
    {
        string ToolBarBackgoundColorKey { get; }
        string ArrowBackImageKey { get; }
        string ToolBarTextFontStyleKey { get; }
        string ToolBarTextColorKey { get; }
        string ToolBarTextSizeKey { get; }

        string SearchBacgroundColorKey { get; }
        string SearchTextColorKey { get; }
        string SearchTextSizeKey { get; }
        string SearchTextFontStyleKey { get; }

        string CellColorKey { get; }
        string CellTextFontStyleKey { get; }
        string CellTextColorKey { get; }
        string CellTextSizeKey { get; }

        string SelectedCellColorKey { get; }
        string SelectedCellTextFontStyleKey { get; }
        string SelectedCellTextColorKey { get; }
        string SelectedCellTextSizeKey { get; }

        string DividingLineColorKey { get; }
        string DividingLineSizeKey { get; }
        string DividingLineTypeKey { get; }
    }
}
