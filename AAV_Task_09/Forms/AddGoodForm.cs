using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AAV_Task_09.Models;
using Microsoft.EntityFrameworkCore;

namespace AAV_Task_09
{
    public partial class AddGoodForm : Form
    {
        private AdminForm _adminForm;
        public AddGoodForm(AdminForm adminForm)
        {
            _adminForm = adminForm;
            InitializeComponent();
            LoadCategoryInComboBox();
        }

        private async void LoadCategoryInComboBox()
        {
            using var context = new ShopDbContext();
            var categoryList = await context.Categorys.ToArrayAsync();
            comboBox1.Items.AddRange(categoryList);
            comboBox1.SelectedIndex = 0;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var imageData = SelectImage();
            if (imageData != null)
            {
                pictureBox1.Image = ConvertByteArrayToImage(imageData);
            }
        }

        private byte[]? SelectImage()
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Выберите изображение"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return File.ReadAllBytes(openFileDialog.FileName);
            }
            return null;
        }

        public byte[] ImageToByteArray(System.Drawing.Image image)
        {
            try
            {
                if (image == null)
                    return null;

                using (var ms = new MemoryStream())
                {
                    using (var bitmap = new Bitmap(image))
                    {
                        bitmap.Save(ms, image.RawFormat);
                    }
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return null;
            }
        }

        private void SaveImageToDatabase(ShopDbContext db, Good good)
        {
            var image = pictureBox1.Image;
            good.Picture = ImageToByteArray(image);

        }


        private System.Drawing.Image? ConvertByteArrayToImage(byte[]? byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                throw new ArgumentException("Массив байтов пуст или null.");
            }

            try
            {
                using var ms = new MemoryStream(byteArray);
                return System.Drawing.Image.FromStream(ms);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Ошибка: массив байтов не содержит корректное изображение." + ex.ToString());
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using ShopDbContext dbContext = new ShopDbContext();
            var currentCategory = dbContext.Categorys.FirstOrDefault(c => c.CategoryName == comboBox1.Text);
            if (currentCategory == null)
                MessageBox.Show("sdfd");

            var newGood = new Good
            {
                GoodName = textBox1.Text,
                Price = Convert.ToDouble(numericUpDown1.Value),
                Picture = ImageToByteArray(pictureBox1.Image),
                Description = textBox3.Text,
                CategoryId = currentCategory.Id,
                CountGood = Convert.ToInt32(numericUpDownCount.Value),
            };

            dbContext.Goods.Add(newGood);
            dbContext.SaveChanges();
            _adminForm.UpdateData();
            this.Hide();

        }
    }
}
