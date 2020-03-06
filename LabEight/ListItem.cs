using System;
namespace LabEight
{
    public class ListItem
    {
        public int index { get; set; }
        public String value { get; set; }

        public ListItem()
        {

        }
        public ListItem(int _index, String _value)
        {
            this.index = _index;
            this.value = _value;
        }
    }
}
