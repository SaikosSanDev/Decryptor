using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decryptor.Forms
{
    public partial class Choose : Form
    {
        public int choosed = 0;
        private string[] cryptingTypes = {"Intern", "Caeser"};

        public Choose(string last)
        {
            InitializeComponent();
            this.last.Text = last;
        }

        private void continue2_Click(object sender, EventArgs e)
        {
            if (!(comboBox1.SelectedItem == null))
            {
                choosed = cryptingTypes.ToList().IndexOf((string) comboBox1.SelectedItem) + 1;
                this.Close();
            }
            else MessageBox.Show("Wähle eine Verschlüsselungsart aus !", "Fehler", MessageBoxButtons.OK);
        }
    }
}
