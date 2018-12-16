namespace Bluetooth_Device_Scanner.ListView
{
    public class StatusHeaderListItem : IListItem
    {
        public StatusHeaderListItem(string text)
        {
            Text = text;
        }

        public string Text { get; set; }

        public ListItemType GetListItemType()
        {
            return ListItemType.Status;
        }
    }
}