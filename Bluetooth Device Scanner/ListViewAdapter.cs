using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Bluetooth_Device_Scanner
{
    public class ListViewAdapter : ArrayAdapter<IListItem>
    {
        private Context context;
        private List<IListItem> items;
        private LayoutInflater inflater;

        public ListViewAdapter(Context context, List<IListItem> items) : base(context, 0, items)
        {
            this.context = context;
            this.items = items;
            this.inflater = (LayoutInflater)this.context.GetSystemService(Context.LayoutInflaterService);
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            try
            {
                IListItem item = items[position];
                if (item.GetListItemType() == ListItemType.Header)
                {
                    HeaderListItem _headerItem = (HeaderListItem)item;
                    view = inflater.Inflate(Resource.Layout.ListViewHeaderItem, null);
                    view.Clickable = false;

                    var headerName = view.FindViewById<TextView>(Resource.Id.txtHeader);
                    headerName.Text = _headerItem.Text;

                }
                else if (item.GetListItemType() == ListItemType.DataItem)
                {
                    DataItem _contentItem = (DataItem)item;
                    view = inflater.Inflate(Resource.Layout.ListViewContentItem, null);

                    var _title = view.FindViewById<TextView>(Resource.Id.txtTitle);
                    var _subTitle = view.FindViewById<TextView>(Resource.Id.txtSubTitle);

                    _title.Text = _contentItem.Title;
                    _subTitle.Text = _contentItem.SubTitle;
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(context, ex.Message, ToastLength.Long);
            }
            return view;
        }
    }
}