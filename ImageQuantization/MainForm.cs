using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageQuantization
{
    public partial class MainForm : Form
    {
        public static double v=0;
        public MainForm()
        {
            InitializeComponent();
            txt_sumMST.Text = v.ToString();
        }
       

        RGBPixel[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }
            txtWidth.Text = ImageOperations.GetWidth(ImageMatrix).ToString();
            txtHeight.Text = ImageOperations.GetHeight(ImageMatrix).ToString();
        }

        private void btnGaussSmooth_Click(object sender, EventArgs e)
        {
           
            double sigma = double.Parse(txtGaussSigma.Text);
            int maskSize = (int)nudMaskSize.Value ;
            ImageMatrix = ImageOperations.GaussianFilter1D(ImageMatrix, maskSize, sigma);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
            txt_sumMST.Text = v.ToString();
        }
        
        public static void show_time(double x)
        {
            MessageBox.Show("Elapsed Time is { " +x.ToString() + " } in seconds");
        }


        private void txt_sumMST_TextChanged(object sender, EventArgs e)
        {
            txt_sumMST.Text = v.ToString();
        }
    }
}