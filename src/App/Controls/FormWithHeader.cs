﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    public partial class FormWithHeader : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormWithHeader()
        {
            InitializeComponent();
        }

        protected void ConvertEnterKeyToTab()
        {
            this.KeyPress += (s, e) => { Helper.HandleEnterKey(this, e); };
        }
    }
}
