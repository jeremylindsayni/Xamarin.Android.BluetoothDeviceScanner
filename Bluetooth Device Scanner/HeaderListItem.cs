namespace Bluetooth_Device_Scanner
{
    public class HeaderListItem : IListItem
     {
        public string Text { get; set; }

        public ListItemType GetListItemType()
        {
            return ListItemType.Header;
        }

        public HeaderListItem(string text)
        {
            Text = text;
        }
    }
}