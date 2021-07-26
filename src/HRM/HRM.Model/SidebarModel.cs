using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model
{
    public class SidebarModel
    {
        public string Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }

        public string Href { get; set; }

        public List<SidebarModel> MenuItems { get; set; } = new List<SidebarModel>();

        public SidebarModel()
        {

        }

        public SidebarModel(string id, string title, string href, string icon)
        {
            Id = id;
            Title = title;
            Href = href;
            Icon = icon;
        }
    }
}
