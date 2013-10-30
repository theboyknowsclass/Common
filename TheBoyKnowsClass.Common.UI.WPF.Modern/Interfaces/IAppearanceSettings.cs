namespace TheBoyKnowsClass.Common.UI.WPF.Modern.Interfaces
{
    public interface IAppearanceSettings
    {
        string Theme { get; set; }
        string Accent { get; set; }
        void Save();
    }
}
