using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Bitmap RemoveGreenAndMakeTransparent(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);


                    if (IsGreen(pixelColor))
                    {

                        result.SetPixel(x, y, Color.Transparent);
                    }
                    else
                    {

                        result.SetPixel(x, y, pixelColor);
                    }
                }
            }

            return result;
        }

        public static Bitmap RemoveRedAndMakeTransparent(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);


                    if (IsRed(pixelColor))
                    {

                        result.SetPixel(x, y, Color.Transparent);
                    }
                    else
                    {

                        result.SetPixel(x, y, pixelColor);
                    }
                }
            }

            return result;
        }

        public static Bitmap RemoveBlueAndMakeTransparent(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);


                    if (IsBlue(pixelColor))
                    {

                        result.SetPixel(x, y, Color.Transparent);
                    }
                    else
                    {

                        result.SetPixel(x, y, pixelColor);
                    }
                }
            }

            return result;
        }

        private static bool IsGreen(Color color)
        {

            int greenThreshold = 100;
            return color.G > greenThreshold && color.G > color.R && color.G > color.B;
        }

        private static bool IsRed(Color color)
        {

            int redThreshold = 100;
            return color.R > redThreshold && color.R > color.G && color.R > color.B;
        }

        private static bool IsBlue(Color color)
        {

            int blueThreshold = 100;
            return color.B > blueThreshold && color.B > color.R && color.B > color.G;
        }

        private Bitmap processedImage;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                processedImage = new Bitmap(openFileDialog1.FileName);

                pictureBox1.Image = processedImage;
            };
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processedImage != null)
            {
                processedImage.Save("OutputImg.png", ImageFormat.Png);
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processedImage != null)
            {
                processedImage = RemoveRedAndMakeTransparent(processedImage); // Сохраняем измененное изображение

                pictureBox1.Image = processedImage;
            }

        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processedImage != null)
            {
                processedImage = RemoveGreenAndMakeTransparent(processedImage); // Сохраняем измененное изображение

                pictureBox1.Image = processedImage;
            }

        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (processedImage != null)
            {
                processedImage = RemoveBlueAndMakeTransparent(processedImage); // Сохраняем измененное изображение

                pictureBox1.Image = processedImage;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
