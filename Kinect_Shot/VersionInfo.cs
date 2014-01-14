using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Samples.Kinect.ColorBasics
{
    public partial class VersionInfo : Form
    {
        public VersionInfo()
        {
            InitializeComponent();

            string[] acname = new string[] { "神奈川工科大学", " 情報学部", " 情報メディア学科" };
            string[] name = new string[] { "・1123043　石田悠 - メインプログラマー\n", 
                                           "・1123109　古谷政人 - プログラムサポート\n",
                                           "・1123033　小島健太郎 - Wiki担当"};

            label2.Text = acname[0] + acname[1] + acname[2] + "\n\n" + name[0] + name[1] + name[2];
        }

        // OKをおした時の動作
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
