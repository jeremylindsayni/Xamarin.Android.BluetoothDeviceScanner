namespace Bluetooth_Device_Scanner.ListView
{
    public class DataItem : IListItem
    {
        public DataItem(string title, string subtitle)
        {
            Text = title;
            SubTitle = subtitle;
        }

        public string SubTitle { get; }

        public string Text { get; set; }

        public ListItemType GetListItemType()
        {
            return ListItemType.DataItem;
        }
    }
}