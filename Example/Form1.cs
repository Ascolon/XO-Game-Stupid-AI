using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    public partial class Form1 : Form
    {
        Random random;
        int Null = 0;
        bool Winner = false;
        CheckTenField Check = new CheckTenField();
        public int X = 0;
        public int O = 0;
        public bool UserCanMove = false;
        bool isNew = true;
        public Form1()
        {
            InitializeComponent();
            One.Checked = true;
            Clear();
            //timer1.Start();
        }
        /// <summary>
        /// Условия проверки победы для 3х3 и 5х5 и 10х10
        /// </summary>
        #region
        private void B3X3Click(object sender, EventArgs e)
        {
            var item = (Button)sender;
            if (item.BackgroundImage != null)
            {
                return;
            }
            //item.Enabled = false;
            item.Text = UserCanMove ? "X" : "O";
            item.BackgroundImage = UserCanMove  ? images.Images[2] : images.Images[1];
            ////
            UserCanMove = !UserCanMove;
            if (VsPC.Checked)
                PcMove(field.SelectedTab.Name);
            ///
            ///Горизонталь
            ///
            if (B3_00.Text == B3_01.Text && B3_00.Text == B3_02.Text && B3_00.Text != "")
            {
                MessageBox.Show("Победители " + B3_00.Text + "!", "Победа");
                IncreaseScoreGame(B3_00.Text);
                Winner = true;
                Clear();
            }
            if (B3_10.Text == B3_11.Text && B3_10.Text == B3_12.Text && B3_10.Text != "")
            {
                MessageBox.Show("Победители " + B3_10.Text + "!");
                IncreaseScoreGame(B3_10.Text);
                Winner = true;
                Clear();
            }
            if (B3_20.Text == B3_21.Text && B3_20.Text == B3_22.Text && B3_20.Text != "")
            {
                MessageBox.Show("Победители " + B3_20.Text + "!");
                IncreaseScoreGame(B3_20.Text);
                Winner = true;
                Clear();
            }
            ///
            ///Вертикаль
            /// 
            if (B3_00.Text == B3_10.Text && B3_00.Text == B3_20.Text && B3_00.Text != "")
            {
                MessageBox.Show("Победители " + B3_00.Text + "!");
                IncreaseScoreGame(B3_00.Text);
                Winner = true;
                Clear();
            }
            if (B3_01.Text == B3_11.Text && B3_01.Text == B3_21.Text && B3_01.Text != "")
            {
                MessageBox.Show("Победители " + B3_01.Text + "!");
                IncreaseScoreGame(B3_01.Text);
                Winner = true;
                Clear();
            }
            if (B3_02.Text == B3_12.Text && B3_02.Text == B3_22.Text && B3_02.Text != "")
            {
                MessageBox.Show("Победители " + B3_02.Text + "!");
                IncreaseScoreGame(B3_02.Text);
                Winner = true;
                Clear();
            }
            ///
            ///Диагональ
            ///
            if (B3_00.Text == B3_11.Text && B3_00.Text == B3_22.Text && B3_00.Text != "")
            {
                MessageBox.Show("Победители " + B3_00.Text + "!");
                IncreaseScoreGame(B3_00.Text);
                Winner = true;
                Clear();
            }
            if (B3_02.Text == B3_11.Text && B3_02.Text == B3_20.Text && B3_02.Text != "")
            {
                MessageBox.Show("Победители " + B3_02.Text + "!");
                IncreaseScoreGame(B3_02.Text);
                Winner = true;
                Clear();
            }
            CheckDraw(field);
        }
        #endregion

        /// <summary>
        /// 10X10
        /// </summary>
        #region
        private void B10X10Click(object sender, EventArgs e)
        {
            Null = 0;
            var T = ten.Controls;
            for (int i = 0; i < T.Count; i++)
            {
                if (T[i].BackgroundImage != null)
                {
                    Null++;
                }
            }
            if (Null > 0)
            {
                isNew = false;
                Null = 0;
            }
            else
            {
                isNew = true;
            }
            //MessageBox.Show(isNew + " : " + Null);
            var item = (Button)sender;
            if (item.BackgroundImage != null)
            {
                return;
            }
            item.Text = UserCanMove ? "X" : "O";
            string Value = UserCanMove ? "X" : "O";
            item.BackgroundImage = UserCanMove ? images.Images[2] : images.Images[1];
            UserCanMove = !UserCanMove;
            if (Check.isWin(item.Name, Value, isNew))
            {
                MessageBox.Show("Победители " + Value + "!", "Победа");
                IncreaseScoreGame(Value);
                Clear();
                return;
            }
            if (VsPC.Checked)
                PcMove(field.SelectedTab.Name);
            
        }

        private void EnterFromField(object sender, EventArgs e)
        {
            //UserCanMove = true;
        }

        private void SelectTab(object sender, TabControlCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show
                (
                    "Вы уверены что хотите перейти?",
                    "Внимание",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                if (result == DialogResult.Yes)
                {
                    Clear();
                }
        }

        private void CancelGame(object sender, EventArgs e)
        {
            Clear();
        }
        /// <summary>
        /// Задает стандартные настройки игрового поля.
        /// </summary>
        void Clear()
        {
            
            foreach (var i in field.SelectedTab.Controls)
            {
                var btn = i as Button;
                btn.BackgroundImage = null;
                btn.Text = null;
                btn.Enabled = true;
            }
            Winner = false;
            DarkSide();
        }
    
        /// <summary>
        /// Увеличение счета выигравшей команды
        /// </summary>
        /// <param name="check">Имя победившей стороны</param>
        void IncreaseScoreGame(string check)
        {
            if (X >=2 || O >= 2)
            {
                Clear();
                MessageBox.Show("Игра окончена");
                X = 0;
                O = 0;
                ScoreX.Text = X.ToString();
                ScoreO.Text = O.ToString();
                return;
            }
            if (check == "X")
            {
                X++;
                ScoreX.Text = X.ToString();
            }
            if (check == "O")
            {
                O++;
                ScoreO.Text = O.ToString();
            }
        }

        private void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Логика компьютера
        /// </summary>
        /// <param name="name">Имя клетки</param>
        void PcMove(string name)
        {
            var T = field.SelectedTab.Controls;

            for (int p = 0; p < T.Count; p++)
            {
                if (T[p].BackgroundImage != null)
                {
                    Null++;
                }
            }
            if (Null > 0)
            {
                isNew = false;
                Null = 0;
            }
            else
            {
                isNew = true;
            }

            if (T == null)
                return;
            int i = 1;
            if (name == "three")
                i = 3;
            if (name == "five")
                i = 5;
            if (name == "ten")
                i = 10;
            random = new Random();
            int number = random.Next(0, i * i);
            if (T[number].BackgroundImage == null)
            {
                T[number].Text = UserCanMove ? "X" : "O";
                T[number].BackgroundImage = UserCanMove ? images.Images[2] : images.Images[1];
                UserCanMove = !UserCanMove;
                if (name == "ten")
                {
                    if (Check.isWin(T[number].Name, T[number].Text, isNew))
                    {
                        MessageBox.Show("Победители " + T[number].Text + "!", "Победа");
                        IncreaseScoreGame(T[number].Text);
                        Clear();
                    }
                }
            }
            else //if (T[number].BackgroundImage != null)
            {
                for (int j = 0; j < T.Count - 1; j++)
                {
                    if (T[j].BackgroundImage == null)
                    {
                        T[j].Text = UserCanMove ? "X" : "O";
                        T[j].BackgroundImage = UserCanMove ? images.Images[2] : images.Images[1];
                        UserCanMove = !UserCanMove;
                        if (name == "ten")
                        {
                            if (Check.isWin(T[j].Name, T[j].Text, isNew))
                            {
                                MessageBox.Show("Победители " + T[j].Text + "!", "Победа");
                                IncreaseScoreGame(T[j].Text);
                                Clear();
                            }
                        }
                        return;

                    }
                }
            }
            CheckDraw(field);
        }
        #endregion
        /// <summary>
        /// Проверка ничьей
        /// </summary>
        /// <param name="tab"></param>
        void CheckDraw(TabControl tab)
        {
            var items = tab.SelectedTab.Controls;
            var count = tab.SelectedTab.Controls.Count;
            foreach (var item in items)
            {
                var i = item as Button;
                if (i.BackgroundImage != null)
                {
                    count--;
                    if (count <= 0 && Winner == false)
                    {
                        MessageBox.Show("Ничья");
                        Clear();
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Выбор Х или 0
        /// </summary>
        void DarkSide()
        {
            if (SetCircle.Checked == true)
            {
                UserCanMove = false;
            }
            else
            {
                UserCanMove = true;
            }
        }

        private void SetSide(object sender, EventArgs e)
        {
            DarkSide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = UserCanMove.ToString();
        }
    }
}
