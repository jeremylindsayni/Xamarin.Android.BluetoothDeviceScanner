using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Bluetooth_Device_Scanner.ListView
{
    public class ListViewAdapter : ArrayAdapter<IListItem>
    {
        private readonly Context _context;

        private readonly LayoutInflater _inflater;

        public IList<IListItem> Items {
            get;
            set;
        }

        public ListViewAdapter(Context context, IList<IListItem> items) : base(context, 0, items)
        {
            _context = context;
            Items = items;
            _inflater = (LayoutInflater) _context.GetSystemService(Context.LayoutInflaterService);
        }

        public override int Count => Items.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            try
            {
                var item = Items[position];
                if (item.GetListItemType() == ListItemType.Header)
                {
                    var headerItem = (HeaderListItem)item;
                    view = _inflater.Inflate(Resource.Layout.ListViewHeaderItem, null);
                    view.Clickable = false;

                    var headerName = view.FindViewById<TextView>(Resource.Id.txtHeader);
                    headerName.Text = headerItem.Text;
                } 
                else if (item.GetListItemType() == ListItemType.Status)
                {
                    var statusItem = (StatusHeaderListItem)item;
                    view = _inflater.Inflate(Resource.Layout.ListViewStatusItem, null);
                    view.Clickable = false;

                    var statusText = view.FindViewById<TextView>(Resource.Id.txtStatus);
                    statusText.Text = statusItem.Text;
                }
                else if (item.GetListItemType() == ListItemType.DataItem)
                {
                    var contentItem = (DataItem)item;
                    view = _inflater.Inflate(Resource.Layout.ListViewContentItem, null);

                    var title = view.FindViewById<TextView>(Resource.Id.txtTitle);
                    var subTitle = view.FindViewById<TextView>(Resource.Id.txtSubTitle);

                    title.Text = contentItem.Text;
                    subTitle.Text = contentItem.SubTitle;
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(_context, ex.Message, ToastLength.Long);
            }

            return view;
        }
    }
}