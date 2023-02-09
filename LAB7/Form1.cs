using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB7
{
    public partial class Form1 : Form
    {
        char[] alphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        char[] Cipher(char[] text, int n)
        {
            int nom; // Номер в алфавите
            int j; // Переменная для циклов
            int smesch = n;

            // Перебираем каждый символ сообщения
            for (int i = 0; i < text.Length; i++)
            {
                
                // Ищем индекс буквы
                for (j = 0; j < alphabet.Length; j++)
                {
                    if (text[i] == alphabet[j])
                    {
                        break;
                    }
                }

                if (j != 33) // Если j равно 33, значит символ не из алфавита
                {
                    nom = j; // Индекс буквы
                    smesch = nom + n; // Делаем смещение

                    // Проверяем, чтобы не вышли за пределы алфавита
                    if (smesch > 32)
                    {
                        smesch = smesch - 33;
                    }

                    text[i] = alphabet[smesch]; // Меняем букву
                }
            }
            return text;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void CipherButton_Click(object sender, EventArgs e)
        {
            char[] text = TextTB.Text.ToLower().ToCharArray();
            int n = Convert.ToInt32(NValueBox.Value);
            
            MessageBox.Show(new string(Cipher(text, n)));
        }

        private void DecipherButton_Click(object sender, EventArgs e)
        {
            char[] text = TextTB.Text.ToLower().ToCharArray();
            int n = 33 - Convert.ToInt32(NValueBox.Value);
            MessageBox.Show(new string(Cipher(text, n)));
        }
    }
}
