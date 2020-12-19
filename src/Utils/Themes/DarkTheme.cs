using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Decryptor.Utils.Themes
{

    class DarkTheme : Theme
    {
        
        public DarkTheme()
        {
            FontForeColor = Color.FromArgb(153, 170, 181);
            textBoxBackcolor = Color.FromArgb(44, 47, 51);
            FormBackColor = Color.FromArgb(35, 39, 42);
            name = "Dark";
        }

    }

}
