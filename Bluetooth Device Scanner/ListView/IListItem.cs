namespace Bluetooth_Device_Scanner.ListView
{
    public interface IListItem
    {
        ListItemType GetListItemType();

        string Text { get; set; }
    }
}