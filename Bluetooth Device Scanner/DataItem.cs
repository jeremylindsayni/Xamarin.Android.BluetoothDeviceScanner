namespace Bluetooth_Device_Scanner
{
    public class DataItem : IListItem
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public ListItemType GetListItemType()
        {
            return ListItemType.DataItem;
        }

        public DataItem(string title, string subtitle)
        {
            Title = title;
            SubTitle = subtitle;
        }
    }
}