using System;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Text;

namespace Microlab_keeper
{
    public partial class Form1 : Form
    {
        // WinAPI
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int LoadKeyboardLayout(string pwszKLID, uint Flags);


        const int WM_KEYDOWN = 0x100,
            ENTER = 0x0D, // Точка
            VIRGULE = 0xBC, // Запятая
            KeyDownDelay = 150, // Задержка после нажатия клавиши (если меньше 150 мс - есть сбои)
            startAdressDefault = 0x0100;


        string[] code = null; // Код
        bool isFileChoosen = false; // Загружен ли файл
        int startAdress = startAdressDefault;
        int lastAdress = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Int2Hex(startAdress);
            openFileDialog1.FileName = "";
        }

        /// <summary>
        /// Получить ид процесса microlab
        /// </summary>
        /// <returns></returns>
        private Process GetMicrolab()
        {
            Process microlabProccess;
            try
            {
                microlabProccess = Process.GetProcessesByName("microlab")[0];
            }
            catch
            {
                return null;
            }

            // Изменить раскладку в окне microlab на EN
            PostMessage(microlabProccess.MainWindowHandle, 0x50, 1, LoadKeyboardLayout("00000409", 1));

            return microlabProccess;
        }

        /// <summary>
        /// Загрузка кода из файла. Считывает первые 2 символа и заносит в массив, если символ: 0-9|A-F
        /// </summary>
        /// <returns></returns>
        private string[] LoadCode()
        {
            if (!File.Exists(openFileDialog1.FileName))
                return null;            
            var tmp = File.ReadAllLines(openFileDialog1.FileName).
                Where(n => 
                    !string.IsNullOrEmpty(n) && 
                    new Regex("^[A-F0-9/-]{2}", RegexOptions.IgnoreCase).IsMatch(n)).
                ToArray();
            for (int i = 0; i < tmp.Length; i++)
            {
                if(tmp[i][0] == '-' && tmp[i][1] == '-')
                {
                    Array.Resize<string>(ref tmp, i);
                    break;
                }
                else
                    tmp[i] = tmp[i].ToUpper();
            }
            return tmp;
        }

        /// <summary>
        /// Выбрать файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
                isFileChoosen = true;
            }
        }
       
        /// <summary>
        /// Перевести из string(hex) в int
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        private int Hex2Int(string hex)
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(hex, 16);
            }
            catch
            {
                return 0;
            }
            return num;
        }

        /// <summary>
        /// Загрузить код в microlab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_loadCode_Click(object sender, EventArgs e)
        {
            if (!isFileChoosen)
            {
                MessageBox.Show("Выберите файл с кодом программы!");
                return;
            }
            code = LoadCode();
            if (code == null)
            {
                MessageBox.Show("Код программы не найден!");
                return;
            }
            var microlabProccess = GetMicrolab();
            if (microlabProccess == null)
            {
                MessageBox.Show("microlab не запущен!");
                return;
            }

            startAdress = Hex2Int(textBox1.Text);
            if (startAdress == 0)
            {
                MessageBox.Show("Неверный адрес!");
                return;
            }

            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, ENTER, "");
            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, '0', "");

            //Start adress
            SendAdress(microlabProccess.MainWindowHandle, Int2Hex(startAdress));

            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, VIRGULE, "");

            int i;
            for (i = 0; i < code.Length; i++)
            {
                SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, code[i][0], "");
                SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, code[i][1], "");
                SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, VIRGULE, "");
            }
            SendMessage(microlabProccess.MainWindowHandle, WM_KEYDOWN, ENTER, "");
            lastAdress = startAdress + i - 1;

            label_status.Text = " - " + Int2Hex(lastAdress);

            MessageBox.Show("Код программы загружен. Адрес: " + Int2Hex(startAdress) + "h - " + Int2Hex(lastAdress) + "h");
        }

        /// <summary>
        /// Запустить код
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_start_Click(object sender, EventArgs e)
        {
            var microlabProccess = GetMicrolab();
            if (microlabProccess == null)
            {
                MessageBox.Show("microlab не запущен!");
                return;
            }
            else if (lastAdress == 0)
            {
                MessageBox.Show("Код программы не загружен!");
                return;
            }

            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, ENTER, "");
            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, '2', "");
            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, '0', "");

            SendAdress(microlabProccess.MainWindowHandle, Int2Hex(startAdress));
            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, VIRGULE, "");
            SendAdress(microlabProccess.MainWindowHandle, Int2Hex(lastAdress));

            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, ENTER, "");
        }

        /// <summary>
        /// Добавить новый код
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_addCode_Click(object sender, EventArgs e)
        {
            if (!isFileChoosen)
            {
                MessageBox.Show("Выберите файл с кодом программы!");
                return;
            }
            if (code == null)
            {
                MessageBox.Show("Загрузите исходный код (Load code)");
                return;
            }
            string[] newCode = LoadCode();
            if (newCode == null)
            {
                MessageBox.Show("Код программы не найден!");
                return;
            }
            var microlabProccess = GetMicrolab();
            if (microlabProccess == null)
            {
                MessageBox.Show("microlab не запущен!");
                return;
            }
            int oldStartAdress = startAdress;
            startAdress = Hex2Int(textBox1.Text);
            if (startAdress == 0)
            {
                MessageBox.Show("Неверный адрес!");
                return;
            }

            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, ENTER, "");
            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, '0', "");
            SendAdress(microlabProccess.MainWindowHandle, Int2Hex(startAdress));
            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, VIRGULE, "");

            int i = 0, changes = 0;
            for (int oldI; i < newCode.Length; i++)
            {
                oldI = i + startAdress - oldStartAdress;
                if (oldI >= code.Length || oldI < 0 || String.Compare(newCode[i], code[oldI], true) != 0)
                {
                    SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, newCode[i][0], "");
                    SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, newCode[i][1], "");
                    changes++;
                }

                SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, VIRGULE, "");
            }
            SendMessageWithDelay(microlabProccess.MainWindowHandle, WM_KEYDOWN, ENTER, "");
            code = newCode;

            lastAdress = startAdress + code.Length - 1;
            label_status.Text = " - " + Int2Hex(lastAdress);

            MessageBox.Show("Код программы обновлен. Строк изменено: " + changes + "\nАдрес: " + Int2Hex(startAdress) + "h - " + Int2Hex(lastAdress) + "h");
        }

        /// <summary>
        /// Переводит int в string(hex). Длина - 4 символа
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static string Int2Hex(int num)
        {
            byte[] data = BitConverter.GetBytes(num);
            Array.Reverse(data);
            return new Regex("-").Replace(BitConverter.ToString(data), "").Remove(0, 4);
        }

        /// <summary>
        /// Ввести начальный адрес
        /// </summary>
        /// <param name="prog"></param>
        /// <param name="adress"></param>
        private void SendAdress(IntPtr prog, string adress)
        {
            for (int i = 0; i < adress.Length; i++)
            {
                SendMessageWithDelay(prog, WM_KEYDOWN, adress[i], "");
            }
        }

        /// <summary>
        /// SendMessage с задержкой
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        private void SendMessageWithDelay(IntPtr hWnd, int uMsg, int wParam, string lParam)
        {
            SendMessage(hWnd, uMsg, wParam, lParam);
            Thread.Sleep(KeyDownDelay);
        }
    }
}
