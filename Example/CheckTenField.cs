using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    class CheckTenField
    {
        public string[,] Ren;
        public string[,] Ten =
        {
            { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
            { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" }
        };
        void F()
        {
            Ren = new string[,]
            {
                { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" }
            };
            Ten = Ren;
        }

        public bool isWin(string index, string value, bool isNew)
        {
            if (isNew == true)
                F();
            ///Переменные
            int counter = 0;
            int ColOther = 9;
            //Листы со значениями
            var vertical = new List<string>();
            var horizontal = new List<string>();
            var di = new List<string>();
            var diOther = new List<string>();
            ///
            ///Очитска листов перед каждой проверкой
            vertical.Clear();
            horizontal.Clear();
            di.Clear();
            diOther.Clear();
            string name = null;
            bool win = false;
            ///
            int j = index.IndexOf("_");
            for (int i = j + 1; i < index.Length; i++)
            {
                name += index[i];
            }
            int row = int.Parse(name[0].ToString());
            int col = int.Parse(name[1].ToString());

            Ten[row, col] = value;

            ///Добавление в Листы для проверки условия победы
            for (int i = 0; i < 10; i++)
            {
                vertical.Add(Ten[i, col]);
            }
            ///Заполение горизонатли
            for (int i = 0; i < 10; i++)
            {
                horizontal.Add(Ten[row, i]);
            }
            ///Заполнение по диагонали
            for (int i = 0; i < 10; i++)
            {
                di.Add(Ten[i, i]);
            }
            for (int i = 0; i < 10; i++)
            {
                diOther.Add(Ten[i, ColOther]);
                ColOther--;
            }
            //string R = null;
            //foreach (var item in di)
            //{
            //    R += item + " ";
            //}
            //MessageBox.Show(R);
            ///Проверка  для горизонатали и вертикали
            for (int i = 0; i < vertical.Count() - 1; i++)
            {
                if (vertical[i] == vertical[i + 1] && vertical[i] == value)
                {
                    counter++;
                    if (counter == 4)
                    {
                        return true;
                    }
                }
                else
                    counter = 0;
            }
            counter = 0;
            for (int i = 0; i < horizontal.Count() - 1; i++)
            {
                if (horizontal[i] == horizontal[i + 1] && horizontal[i] == value)
                {
                    counter++;
                    if (counter == 4)
                    {
                        return true;
                    }
                }
                else
                    counter = 0;
            }
            counter = 0;
            ///Проверка  для главной диагонали и побочной диагонали
            for (int i = 0; i < di.Count() - 1; i++)
            {
                if (di[i] == di[i + 1] && di[i] == value)
                {
                    counter++;
                    if (counter == 4)
                    {
                        return true;
                    }
                }
                else
                    counter = 0;
            }
            counter = 0;
            for (int i = 0; i < diOther.Count() - 1; i++)
            {
                if (diOther[i] == diOther[i + 1] && diOther[i] == value)
                {
                    counter++;
                    if (counter == 4)
                    {
                        return true;
                    }
                }
                else
                    counter = 0;
            }
            #region
            ///Проверка по диагоналям
            if (Ten[0, 4] == Ten[1, 3] && Ten[0, 4] == Ten[2, 2] && Ten[0, 4] == Ten[3, 1] && Ten[0, 4] == Ten[4, 0] && Ten[0, 4] == value
             || Ten[0, 5] == Ten[1, 4] && Ten[0, 5] == Ten[2, 3] && Ten[0, 5] == Ten[3, 2] && Ten[0, 5] == Ten[4, 1] && Ten[0, 5] == value
             || Ten[1, 4] == Ten[2, 3] && Ten[1, 4] == Ten[3, 2] && Ten[1, 4] == Ten[4, 1] && Ten[1, 4] == Ten[5, 0] && Ten[1, 4] == value
             || Ten[0, 6] == Ten[1, 5] && Ten[0, 6] == Ten[2, 4] && Ten[0, 6] == Ten[3, 3] && Ten[0, 6] == Ten[4, 2] && Ten[0, 6] == value
             || Ten[1, 5] == Ten[2, 4] && Ten[1, 5] == Ten[3, 3] && Ten[1, 5] == Ten[4, 2] && Ten[1, 5] == Ten[5, 1] && Ten[1, 5] == value
             || Ten[2, 4] == Ten[3, 3] && Ten[2, 4] == Ten[4, 2] && Ten[2, 4] == Ten[5, 1] && Ten[2, 4] == Ten[6, 0] && Ten[2, 4] == value
             || Ten[0, 7] == Ten[1, 6] && Ten[0, 7] == Ten[2, 5] && Ten[0, 7] == Ten[3, 4] && Ten[0, 7] == Ten[4, 3] && Ten[0, 7] == value
             || Ten[1, 6] == Ten[2, 5] && Ten[1, 6] == Ten[3, 4] && Ten[1, 6] == Ten[4, 3] && Ten[1, 6] == Ten[5, 2] && Ten[1, 6] == value
             || Ten[2, 5] == Ten[3, 4] && Ten[2, 5] == Ten[4, 3] && Ten[2, 5] == Ten[5, 2] && Ten[2, 5] == Ten[6, 1] && Ten[2, 5] == value
             || Ten[3, 4] == Ten[4, 3] && Ten[3, 4] == Ten[5, 2] && Ten[3, 4] == Ten[6, 1] && Ten[3, 4] == Ten[7, 0] && Ten[3, 4] == value
             || Ten[0, 8] == Ten[1, 7] && Ten[0, 8] == Ten[2, 6] && Ten[0, 8] == Ten[3, 5] && Ten[0, 8] == Ten[4, 4] && Ten[0, 8] == value
             || Ten[1, 7] == Ten[2, 6] && Ten[1, 7] == Ten[3, 5] && Ten[1, 7] == Ten[4, 4] && Ten[1, 7] == Ten[5, 3] && Ten[1, 7] == value
             || Ten[2, 6] == Ten[3, 5] && Ten[2, 6] == Ten[4, 4] && Ten[2, 6] == Ten[5, 3] && Ten[2, 6] == Ten[6, 2] && Ten[2, 6] == value
             || Ten[3, 5] == Ten[4, 4] && Ten[3, 5] == Ten[5, 3] && Ten[3, 5] == Ten[6, 2] && Ten[3, 5] == Ten[7, 1] && Ten[3, 5] == value
             || Ten[4, 4] == Ten[5, 3] && Ten[4, 4] == Ten[6, 2] && Ten[4, 4] == Ten[7, 1] && Ten[4, 4] == Ten[8, 0] && Ten[4, 4] == value
             || Ten[1, 9] == Ten[2, 8] && Ten[1, 9] == Ten[3, 7] && Ten[1, 9] == Ten[4, 6] && Ten[1, 9] == Ten[5, 5] && Ten[1, 9] == value
             || Ten[2, 8] == Ten[3, 7] && Ten[2, 8] == Ten[4, 6] && Ten[2, 8] == Ten[5, 5] && Ten[2, 8] == Ten[6, 4] && Ten[2, 8] == value
             || Ten[3, 7] == Ten[4, 6] && Ten[3, 7] == Ten[5, 5] && Ten[3, 7] == Ten[6, 4] && Ten[3, 7] == Ten[7, 3] && Ten[3, 7] == value
             || Ten[4, 6] == Ten[5, 5] && Ten[4, 6] == Ten[6, 4] && Ten[4, 6] == Ten[7, 3] && Ten[4, 6] == Ten[8, 2] && Ten[4, 6] == value
             || Ten[5, 5] == Ten[6, 4] && Ten[5, 5] == Ten[7, 3] && Ten[5, 5] == Ten[8, 2] && Ten[5, 5] == Ten[9, 1] && Ten[5, 5] == value
             || Ten[2, 9] == Ten[3, 8] && Ten[2, 9] == Ten[4, 7] && Ten[2, 9] == Ten[5, 6] && Ten[2, 9] == Ten[6, 5] && Ten[2, 9] == value
             || Ten[3, 8] == Ten[4, 7] && Ten[3, 8] == Ten[5, 6] && Ten[3, 8] == Ten[6, 5] && Ten[3, 8] == Ten[7, 4] && Ten[3, 8] == value
             || Ten[4, 7] == Ten[5, 6] && Ten[4, 7] == Ten[6, 5] && Ten[4, 7] == Ten[7, 4] && Ten[4, 7] == Ten[8, 3] && Ten[4, 7] == value
             || Ten[5, 6] == Ten[6, 5] && Ten[5, 6] == Ten[7, 4] && Ten[5, 6] == Ten[8, 3] && Ten[5, 6] == Ten[9, 2] && Ten[5, 6] == value
             || Ten[3, 9] == Ten[4, 8] && Ten[3, 9] == Ten[5, 7] && Ten[3, 9] == Ten[6, 6] && Ten[3, 9] == Ten[7, 5] && Ten[3, 9] == value
             || Ten[4, 8] == Ten[5, 7] && Ten[4, 8] == Ten[6, 6] && Ten[4, 8] == Ten[7, 5] && Ten[4, 8] == Ten[8, 4] && Ten[4, 8] == value
             || Ten[5, 7] == Ten[6, 6] && Ten[5, 7] == Ten[7, 5] && Ten[5, 7] == Ten[8, 4] && Ten[5, 7] == Ten[9, 3] && Ten[5, 7] == value
             || Ten[4, 9] == Ten[5, 8] && Ten[4, 9] == Ten[6, 7] && Ten[4, 9] == Ten[7, 6] && Ten[4, 9] == Ten[8, 5] && Ten[4, 9] == value
             || Ten[5, 8] == Ten[6, 7] && Ten[5, 8] == Ten[7, 6] && Ten[5, 8] == Ten[8, 5] && Ten[5, 8] == Ten[9, 4] && Ten[5, 8] == value
             || Ten[5, 9] == Ten[6, 8] && Ten[5, 9] == Ten[7, 7] && Ten[5, 9] == Ten[8, 6] && Ten[5, 9] == Ten[9, 5] && Ten[5, 9] == value
             || Ten[5, 0] == Ten[6, 1] && Ten[5, 0] == Ten[7, 2] && Ten[5, 0] == Ten[8, 3] && Ten[5, 0] == Ten[9, 4] && Ten[5, 0] == value
             || Ten[4, 0] == Ten[5, 1] && Ten[4, 0] == Ten[6, 2] && Ten[4, 0] == Ten[7, 3] && Ten[4, 0] == Ten[8, 4] && Ten[4, 0] == value
             || Ten[5, 1] == Ten[6, 2] && Ten[5, 1] == Ten[7, 3] && Ten[5, 1] == Ten[8, 4] && Ten[5, 1] == Ten[9, 5] && Ten[5, 1] == value
             || Ten[3, 0] == Ten[4, 1] && Ten[3, 0] == Ten[5, 2] && Ten[3, 0] == Ten[6, 3] && Ten[3, 0] == Ten[7, 4] && Ten[3, 0] == value
             || Ten[4, 1] == Ten[5, 2] && Ten[4, 1] == Ten[6, 3] && Ten[4, 1] == Ten[7, 4] && Ten[4, 1] == Ten[8, 5] && Ten[4, 1] == value
             || Ten[5, 2] == Ten[6, 3] && Ten[5, 2] == Ten[7, 4] && Ten[5, 2] == Ten[8, 5] && Ten[5, 2] == Ten[9, 6] && Ten[5, 2] == value
             || Ten[2, 0] == Ten[3, 1] && Ten[2, 0] == Ten[4, 2] && Ten[2, 0] == Ten[5, 3] && Ten[2, 0] == Ten[6, 4] && Ten[2, 0] == value
             || Ten[3, 1] == Ten[4, 2] && Ten[3, 1] == Ten[5, 3] && Ten[3, 1] == Ten[6, 4] && Ten[3, 1] == Ten[7, 5] && Ten[3, 1] == value
             || Ten[4, 2] == Ten[5, 3] && Ten[4, 2] == Ten[6, 4] && Ten[4, 2] == Ten[7, 5] && Ten[4, 2] == Ten[8, 6] && Ten[4, 2] == value
             || Ten[5, 3] == Ten[6, 4] && Ten[5, 3] == Ten[7, 5] && Ten[5, 3] == Ten[8, 6] && Ten[5, 3] == Ten[9, 7] && Ten[5, 3] == value
             || Ten[1, 0] == Ten[2, 1] && Ten[1, 0] == Ten[3, 2] && Ten[1, 0] == Ten[4, 3] && Ten[1, 0] == Ten[5, 4] && Ten[1, 0] == value
             || Ten[2, 1] == Ten[3, 2] && Ten[2, 1] == Ten[4, 3] && Ten[2, 1] == Ten[5, 4] && Ten[2, 1] == Ten[6, 5] && Ten[2, 1] == value
             || Ten[3, 2] == Ten[4, 3] && Ten[3, 2] == Ten[5, 4] && Ten[3, 2] == Ten[6, 5] && Ten[3, 2] == Ten[7, 6] && Ten[3, 2] == value
             || Ten[4, 3] == Ten[5, 4] && Ten[4, 3] == Ten[6, 5] && Ten[4, 3] == Ten[7, 6] && Ten[4, 3] == Ten[8, 7] && Ten[4, 3] == value
             || Ten[5, 4] == Ten[6, 5] && Ten[5, 4] == Ten[7, 6] && Ten[5, 4] == Ten[8, 7] && Ten[5, 4] == Ten[9, 8] && Ten[5, 4] == value
             || Ten[0, 1] == Ten[1, 2] && Ten[0, 1] == Ten[2, 3] && Ten[0, 1] == Ten[3, 4] && Ten[0, 1] == Ten[4, 5] && Ten[0, 1] == value
             || Ten[1, 2] == Ten[2, 3] && Ten[1, 2] == Ten[3, 4] && Ten[1, 2] == Ten[4, 5] && Ten[1, 2] == Ten[5, 6] && Ten[1, 2] == value
             || Ten[2, 3] == Ten[3, 4] && Ten[2, 3] == Ten[4, 5] && Ten[2, 3] == Ten[5, 6] && Ten[2, 3] == Ten[6, 7] && Ten[2, 3] == value
             || Ten[3, 4] == Ten[4, 5] && Ten[3, 4] == Ten[5, 6] && Ten[3, 4] == Ten[6, 7] && Ten[3, 4] == Ten[7, 8] && Ten[3, 4] == value
             || Ten[4, 5] == Ten[5, 6] && Ten[4, 5] == Ten[6, 7] && Ten[4, 5] == Ten[7, 8] && Ten[4, 5] == Ten[8, 9] && Ten[4, 5] == value
             || Ten[0, 2] == Ten[1, 3] && Ten[0, 2] == Ten[2, 4] && Ten[0, 2] == Ten[3, 5] && Ten[0, 2] == Ten[4, 6] && Ten[0, 2] == value
             || Ten[1, 3] == Ten[2, 4] && Ten[1, 3] == Ten[3, 5] && Ten[1, 3] == Ten[4, 6] && Ten[1, 3] == Ten[5, 7] && Ten[1, 3] == value
             || Ten[2, 4] == Ten[3, 5] && Ten[2, 4] == Ten[4, 6] && Ten[2, 4] == Ten[5, 7] && Ten[2, 4] == Ten[6, 8] && Ten[2, 4] == value
             || Ten[3, 5] == Ten[4, 6] && Ten[3, 5] == Ten[5, 7] && Ten[3, 5] == Ten[6, 8] && Ten[3, 5] == Ten[7, 9] && Ten[3, 5] == value
             || Ten[0, 3] == Ten[1, 4] && Ten[0, 3] == Ten[2, 5] && Ten[0, 3] == Ten[3, 6] && Ten[0, 3] == Ten[4, 7] && Ten[0, 3] == value
             || Ten[1, 4] == Ten[2, 5] && Ten[1, 4] == Ten[3, 6] && Ten[1, 4] == Ten[4, 7] && Ten[1, 4] == Ten[5, 8] && Ten[1, 4] == value
             || Ten[2, 5] == Ten[3, 6] && Ten[2, 5] == Ten[4, 7] && Ten[2, 5] == Ten[5, 8] && Ten[2, 5] == Ten[6, 9] && Ten[2, 5] == value
             || Ten[0, 4] == Ten[1, 5] && Ten[0, 4] == Ten[2, 6] && Ten[0, 4] == Ten[3, 7] && Ten[0, 4] == Ten[4, 8] && Ten[0, 4] == value
             || Ten[1, 5] == Ten[2, 6] && Ten[1, 5] == Ten[3, 7] && Ten[1, 5] == Ten[4, 8] && Ten[1, 5] == Ten[5, 9] && Ten[1, 5] == value
             || Ten[0, 5] == Ten[1, 6] && Ten[0, 5] == Ten[2, 7] && Ten[0, 5] == Ten[3, 8] && Ten[0, 5] == Ten[4, 9] && Ten[0, 5] == value
             )
            {
                return true;
            }
#endregion
            return win;
        }
    }
}
