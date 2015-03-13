using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using System.Windows.Media;


namespace ThapHaNoi_NguyenThanhPhi
{
    public partial class DiskControl : UserControl
    {

        private TranslateTransform move = new TranslateTransform();
        private TransformGroup rectangleTransforms = new TransformGroup();

       // public int Number { get; set; }

        public DiskControl()
        {
            InitializeComponent();
            //NumberDisk.Text = Number.ToString();
        }


        public DiskControl(int num)
        {
            InitializeComponent();
            //Number = num;
            NumberDisk.Text = num.ToString();
        }

        //public override string ToString()
        //{
            //return Number.ToString();
        //}

        /*
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            DiskControl disk = obj as DiskControl;
            if ((System.Object)disk == null)
            {
                return false;
            }
            return disk.Number == Number;
        }
         * */

        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(String), typeof(TextBlock), null);

        //This dependency property defined above will wrap the TextBlock's Text property
        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public delegate void _Tap(DiskControl disk);
        public _Tap OnTap;

        private void user_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {

        }

       

    }
}
