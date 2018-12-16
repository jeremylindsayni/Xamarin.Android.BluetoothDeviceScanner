namespace Bluetooth_Device_Scanner.ListView
{
    public class HeaderListItem : IListItem
    {
        public HeaderListItem(string text)
        {
            Text = text;
        }

        public string Text { get; set; }

        public ListItemType GetListItemType()
        {
            return ListItemType.Header;
        }
    }
}