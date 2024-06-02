using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Film_Arsivim
{
    public partial class TamEkran : Form
    {

        private string _link;

        public TamEkran(string link)
        {
            InitializeComponent();
            _link = link;
        }

        private void TamEkran_Load(object sender, EventArgs e)
        {
            // _link'i kullanarak webBrowser1'e linki yükle
            webBrowser1.Navigate(_link);
        }
    }
}
