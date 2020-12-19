using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decryptor.Utils.Themes;
using System.IO;

namespace Decryptor.Utils
{

    class ThemeTool
    {
        public List<Theme> registeredThemes = new List<Theme>();

        //Hier werden alle Themes registriert
        public ThemeTool()
        {
            registeredThemes.Add(new WhiteTheme());
            registeredThemes.Add(new DarkTheme());
        }

        public Theme getThemeByName(string name)
        {
            Theme theme = null;
            foreach(Theme t in registeredThemes)
            {
                if (t.name.Equals(name)) theme = t;
            }
            return theme;
        }

    }

}
