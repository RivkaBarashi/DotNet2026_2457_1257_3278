using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace UI
{
    public partial class Form1 : Form
    {
        private Button? customerButton;
        private Button? productButton;
        private Button? salesButton;
        private DataGridView? _dgv;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            // פתיחת החלון של התפריט של המנהל
            var manager=new Manager();
            // כאשר סוגרים את החלון של המנהל, להראות שוב את החלון הראשי
            manager.FormClosed+= (s, args) => this.Show();
            manager.Show();

        }
       
    }

}
