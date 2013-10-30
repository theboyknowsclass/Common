namespace TheBoyKnowsClass.Common.UI.Interfaces
{
    public interface IDropTarget
    {
        bool Drop(object data, int? index = null, double? x = null, double? y = null);
    }
}
