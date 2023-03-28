using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab2_OOP
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }

        void DisplayMessage(string message) => Win32.MessageBox(IntPtr.Zero, message, "Уведомление!", 0);

        int POSITION = 0;
        
        void ClearLabels()
        {
            label9.Text = "";
            label13.Text = "";
            label15.Text = "";
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                bool check = true;
                string nameOfTheOperator = "";
                if (Regex.IsMatch(NameOperatorTextBox.Text, "^[А-Яа-я]+$"))
                    nameOfTheOperator = NameOperatorTextBox.Text;
                else
                {
                    label9.Text = "Имя состоит только из русских букв";
                    check = false;
                }

                double theCostOfTariff = (int)CostNumericUpDaown.Value;

                int numberOfUsers = (int)NumberUserNumericUpDown.Value;

                double internetSpeed = (int)SpeedInternetnumericUpDown.Value;

                int score = (int)ScorenumericUpDown.Value;

                string phoneNumberOffice = "";
                if (Regex.IsMatch(PhonetextBox.Text, "^[8][0-9]{10}$"))
                    phoneNumberOffice = PhonetextBox.Text;
                else
                {
                    check = false;
                    label13.Text = "Номер состоит из 11 цифр - первая 8";
                }

                string countryCoverage="";
                if (Regex.IsMatch(CountrytextBox.Text, "^[А-Яа-я]{1,}$"))
                    countryCoverage = CountrytextBox.Text;
                else
                {
                    check = false;
                    label15.Text = "Страна состоит только из русских букв";
                }

                if (check)
                {  
                    InternetOperator f =  new InternetOperator(nameOfTheOperator, theCostOfTariff, numberOfUsers, 
                        internetSpeed, phoneNumberOffice, score, countryCoverage);
                    label16.Text = "Объект создан!";
                    label35.Text = "Количество объектов: " + InternetOperator.counterObject;
                    ClearLabels();
                    PrintMyObjects();
                }
            }
            catch (InternetOperatorException ex)
            {
                
                Win32.MessageBox(IntPtr.Zero, ex.Message, "Ошибка!",0);
            }
            catch (DuplicateObjectException ex)
            {
                Win32.MessageBox(IntPtr.Zero, ex.Message + "\nИмя: " + ex.Name, "Ошибка",0);
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = true;
                string nameOfTheOperator = "";
                if (Regex.IsMatch(NameOperatorTextBox2.Text, "^[А-Яа-я]+$"))
                    nameOfTheOperator = NameOperatorTextBox2.Text;
                else
                {
                    label24.Text = "Имя состоит только из русских букв";
                    check = false;
                }

                double theCostOfTariff = (int)CostNumericUpDaown2.Value;

                int numberOfUsers = (int)NumberUsernumericUpDown1.Value;

                double internetSpeed = (int)InternetSpeednumericUpDown1.Value;

                int score = (int)ScorenumericUpDown1.Value;

                string phoneNumberOffice = "";
                if (Regex.IsMatch(PhoneNumberTextBox1.Text, "^[8][0-9]{10}$"))
                    phoneNumberOffice = PhoneNumberTextBox1.Text;
                else
                {
                    check = false;
                    label19.Text = "Номер состоит из 11 цифр - первая 8";
                }

                string countryCoverage="";
                if (Regex.IsMatch(CountrytextBox1.Text, "^[А-Яа-я]{1,}$"))
                    countryCoverage = CountrytextBox1.Text;
                else
                {
                    check = false;
                    label18.Text = "Страна состоит только из русских букв";
                }

                if (check)
                {
                    label17.Text = "Изменения сохранены!";
                    InternetOperator.MyOperators.Objects[POSITION].NameOfTheOperator = nameOfTheOperator;
                    InternetOperator.MyOperators.Objects[POSITION].NumberOfUsers = numberOfUsers;
                    InternetOperator.MyOperators.Objects[POSITION].Score = score;
                    InternetOperator.MyOperators.Objects[POSITION].TheCostOfTariff = theCostOfTariff;
                    InternetOperator.MyOperators.Objects[POSITION].PhoneNumberOffice = phoneNumberOffice;
                    InternetOperator.MyOperators.Objects[POSITION].InternetSpeed = internetSpeed;
                    InternetOperator.MyOperators.Objects[POSITION].CountryCoverage = countryCoverage;
                    label18.Text = "";
                    label19.Text = "";
                    label24.Text = "";
                    PrintMyObjects();
                }
            }
            catch (InternetOperatorException ex)
            {

                Win32.MessageBox(IntPtr.Zero, ex.Message, "Ошибка!", 0);
            }
            catch (DuplicateObjectException ex)
            {
                Win32.MessageBox(IntPtr.Zero, ex.Message + "\nИмя: " + ex.Name, "Ошибка", 0);
            }
        }

        private void Table_Click(object sender, EventArgs e)
        {
            InternetOperator.MyOperators.Notify -= DisplayMessage;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            this.Size = new System.Drawing.Size(839, 502);
        }

        private void Main_Click(object sender, EventArgs e)
        {
            InternetOperator.MyOperators.Notify += DisplayMessage;
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
            this.Size = new System.Drawing.Size(1522, 678);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (POSITION > 0)
                POSITION--;
            PrintMyObjects();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (POSITION < InternetOperator.MyOperators.Objects.Count - 1)
                POSITION++;
            PrintMyObjects();
        }
        void PrintMyObjects()
        {
            if (InternetOperator.MyOperators.Objects.Count == 0)
            {
                NameOperatorTextBox2.Text = "";
                CostNumericUpDaown2.Value = 0;
                NumberUsernumericUpDown1.Value = 0;
                InternetSpeednumericUpDown1.Value = 0;
                ScorenumericUpDown1.Value = 0;
                PhoneNumberTextBox1.Text = "";
                CountrytextBox1.Text = "";
                KoeftextBox1.Text = "";
                KoeftextBox1.ReadOnly = true;
                return;
            }
            NameOperatorTextBox2.Text = InternetOperator.MyOperators.Objects[POSITION].NameOfTheOperator;
            CostNumericUpDaown2.Value = (int)InternetOperator.MyOperators.Objects[POSITION].TheCostOfTariff;
            NumberUsernumericUpDown1.Value = (int)InternetOperator.MyOperators.Objects[POSITION].NumberOfUsers;
            InternetSpeednumericUpDown1.Value = (int)InternetOperator.MyOperators.Objects[POSITION].InternetSpeed;
            ScorenumericUpDown1.Value = (int)InternetOperator.MyOperators.Objects[POSITION].Score;
            PhoneNumberTextBox1.Text = InternetOperator.MyOperators.Objects[POSITION].PhoneNumberOffice;
            CountrytextBox1.Text = InternetOperator.MyOperators.Objects[POSITION].CountryCoverage;
            KoeftextBox1.Text = InternetOperator.MyOperators.Objects[POSITION].SpeedPriceRatio.ToString();
            KoeftextBox1.ReadOnly = true;
        }
       
        private void button7_Click(object sender, EventArgs e)
        {
            if (InternetOperator.MyOperators.Objects.Count == 0) return;
            InternetOperator.MyOperators.Delete(POSITION);
            if (InternetOperator.MyOperators.Objects.Count == POSITION)
                POSITION--;
            PrintMyObjects();
           
        }

        private void UI_Load(object sender, EventArgs e)
        {
            InternetOperator.MyOperators.Notify += DisplayMessage;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InternetOperator.MyOperators.Objects.Clear();
            Stopwatch stopwatch1 = new Stopwatch();
            //засекаем время начала операции
            stopwatch1.Start();
            for (int i = 0; i < 100000; ++i)
            {
                 new InternetOperator("Operator" + i.ToString());
            }
            stopwatch1.Stop();
            InternetOperator[] internetOperators = new InternetOperator[100000];
            Stopwatch stopwatch2 = new Stopwatch();
            for (int i = 0; i < 100000; ++i)
            {
                internetOperators[i] = new InternetOperator(1, 1);
            }
            stopwatch2.Stop();

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Rows.Add("Создание списка объектов", stopwatch1.ElapsedMilliseconds.ToString());
            dataGridView1.Rows.Add("Создание массива объектов", stopwatch2.ElapsedMilliseconds.ToString());


        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Width = 340;
            Stopwatch stopwatch1 = new Stopwatch();
            //засекаем время начала операции
            stopwatch1.Start();
            List<InternetOperator> selection = new List<InternetOperator>();
            foreach(InternetOperator internetOperator in InternetOperator.MyOperators.Objects)
            {
                selection.Add(internetOperator);
            }
            stopwatch1.Stop();

            InternetOperator[] internetOperators = new InternetOperator[100000];
            Stopwatch stopwatch2 = new Stopwatch();
            for (int i = 0; i < 100000; ++i)
            {
                internetOperators[i] = InternetOperator.MyOperators.Objects[i];
            }
            stopwatch2.Stop();

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Rows.Add("Выборка объектов из списка", stopwatch1.ElapsedMilliseconds.ToString());
            dataGridView1.Rows.Add("Выборка объектов из массва", stopwatch2.ElapsedMilliseconds.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Width = 340;
            List<InternetOperator> selection = new List<InternetOperator>();
            InternetOperator[] internetOperators = new InternetOperator[100000];
            Random random = new Random();
            List<int> values = new List<int>();
            for (int i = 0; i < 100000; ++i)
                values.Add(i);
            Stopwatch stopwatch1 = new Stopwatch();
            //засекаем время начала операции
            stopwatch1.Start();
            for (int i = 0; i < 100000; ++i)
            {
                int rnd = random.Next(0, values.Count);
                selection.Add(InternetOperator.MyOperators.Objects[rnd]);
            }
            stopwatch1.Stop();

            for (int i = 0; i < 100000; ++i)
                values.Add(i);

            Stopwatch stopwatch2 = new Stopwatch();
            //засекаем время начала операции
            stopwatch2.Start();
            for (int i = 0; i < 100000; ++i)
            {
                int rnd = random.Next(0, values.Count);
                internetOperators[i] = InternetOperator.MyOperators.Objects[values[rnd]];
            }
            stopwatch2.Stop();
            dataGridView1.Rows.Add("Случайная выборка\n объектов из списка", stopwatch1.ElapsedMilliseconds.ToString());
            dataGridView1.Rows.Add("Случайная выборка\n объектов из массва", stopwatch2.ElapsedMilliseconds.ToString());
        }
    }
}
