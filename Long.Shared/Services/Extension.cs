using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Long.Shared.Services
{
    public static class Extension
    {
        /// <summary>
        /// Chuyển số bất kỳ về kiểu <see cref="int"/> trả về lỗi nếu <paramref name="input"/> = <see cref="null"/> hoặc chuỗi không chứa bất kỳ số nào.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ToInt<T>(this T input)
        {
            if (input == null)
                throw new Exception("Giá trị nhập vào không được phép Null");
            string input2 = input.ToString();
            string str = string.Empty;
            for (int i = 0; i < input2.Length; i++)
            {
                if (char.IsDigit(input2[i]))
                    str += input2[i];
            }
            if (string.IsNullOrEmpty(str))
                throw new Exception("Giá trị nhập vào không chứa bất kỳ số nguyên nào");
            return Convert.ToInt32(str);
        }
    }
    public static class UI
    {
        /// <summary>
        /// Xác nhận có thực hiện <paramref name="action"/> hay không?
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool Quesion(string msg)
        {
            return MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
        }
        /// <summary>
        /// Hàm mở Folder và trả về đường dẫn được chọn
        /// </summary>
        /// <returns></returns>
        public static string OpenFolder()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    return fbd.SelectedPath;
                return null;
            }
        }
    }
}
