using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MenuItemDefinition
{
    public String Title { get; set; }
    public String Description { get; set; }

    public MenuItemDefinition(String title, String description)
    {
        this.Title = title;
        this.Description = description;
    }
}
