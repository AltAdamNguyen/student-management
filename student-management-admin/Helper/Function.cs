using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace student_management_admin.Helper
{
    class Function
    {
        public static bool validateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
            bool isValid = regex.IsMatch(email);

            return isValid;
        }

        public static string convertName(string name)
        {
            string[] words = name.Split(' ');

            int lenght = words.Length - 1;
            string initials = "";

            for (int i = 0; i < lenght; i++)
            {
                initials += words[i].Substring(0, 1);
            }
            
            return ConvertVNtoENG(words[lenght] + initials);
        }

        public static string ConvertVNtoENG(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };

        public static string convertToDateOfWeek(DateTime date)
        {
            CultureInfo vietnameseCulture = new CultureInfo("vi-VN");
            string dayOfWeekVietnamese = vietnameseCulture.DateTimeFormat.GetDayName(date.DayOfWeek);

            return dayOfWeekVietnamese;
        }
    }
}
