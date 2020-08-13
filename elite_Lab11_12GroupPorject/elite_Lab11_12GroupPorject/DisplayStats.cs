/* Elite Group Project *
 * Erin Merrill        *
 * La'Ray Bush         *
 * Rob McKibben        *
 * Lab 11_12           *
 * ECET 164            *
 * December 7, 2018    */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elite_Lab11_12GroupPorject
{
    public partial class DisplayStats : Form
    {
        public DisplayStats()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); //close form
        }
    }
}
