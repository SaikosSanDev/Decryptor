using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Decryptor.Utils;

namespace Decryptor.Forms
{
    public partial class Themesmenu : Form
    {
        public ThemeResult result = ThemeResult.ABORTED_ACTION;
        List<Theme> localThemes = Program.ThemeT.registeredThemes;

        public Themesmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                Program.usingTheme = Program.ThemeT.getThemeByName(treeView1.SelectedNode.Text);
                result = ThemeResult.CHANGE_THEME;
                this.Close();
                return;
            }
            MessageBox.Show("Wähle vorher ein Theme aus !", "Unausgewähltes Theme", MessageBoxButtons.OK);
        }

        private void treeView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if(treeView2.SelectedNode != null)
                {
                    if(!(treeView2.SelectedNode.Text.Equals("White") || treeView2.SelectedNode.Text.Equals("Dark")))
                    {
                        TreeNode selected = treeView2.SelectedNode;
                        localThemes.Remove(Program.ThemeT.getThemeByName(selected.Text));
                        treeView2.Nodes.Remove(selected);
                        return;
                    }
                    MessageBox.Show("Du kannst nicht die Standart Themes entfernen !", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.KeyCode == Keys.Oemplus)
            {
                NewTheme newTheme = new NewTheme();
                newTheme.ShowDialog();
                if(newTheme.result == DialogResult.OK)
                {
                    Theme t = new Theme()
                    {
                        FontForeColor = newTheme.FontForeColor,
                        textBoxBackcolor = newTheme.textBoxBackcolor,
                        FormBackColor = newTheme.FormBackColor,
                        name = newTheme.name
                    };
                    localThemes.Add(t);
                    TreeNode node = new TreeNode(t.name);
                    treeView2.Nodes.Add(node);
                }
            }
        }

        private void Themesmenu_Load(object sender, EventArgs e)
        {
            foreach(Theme t in localThemes)
            {
                TreeNode node = new TreeNode(t.name);
                treeView1.Nodes.Add(node);
                treeView2.Nodes.Add((TreeNode) node.Clone());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = ThemeResult.EDITED_THEME;
            Program.ThemeT.registeredThemes = localThemes;
            this.Close();
        }
    }

    public enum ThemeResult
    {
        CHANGE_THEME,
        EDITED_THEME,
        ABORTED_ACTION
    }
}
