using System;
using System.Windows.Forms;

namespace SteamKeyDeveloper
{
    public partial class Form1 : Form
    {
        public Form1()
        { InitializeComponent(); }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the application?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.No)
                return;

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        { WindowState = FormWindowState.Minimized; }

        private void tryanotherkey_Click(object sender, EventArgs e)
        {
            int desition;
            string[] Abecedario = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] Numeros = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string output = "";
            Random rnd = new Random();


            
            //Letra y numero al azar
            for (int i = 1; i <= 15; i++)
            {
                desition = rnd.Next(0, 2);
                switch (desition)
                {
                    case 0:
                        output = output + Abecedario[rnd.Next(0, Abecedario.Length)];
                        break;

                    case 1:
                        output = output + Numeros[rnd.Next(0, Numeros.Length)];
                        break;
                }

                if (i == 5 || i == 10)
                {
                    output = output + "-";
                }
            }

            //Salida
            Key.Text = output;
            Clipboard.SetText(output);

            FeedbackOn();
        }

        private void hideFeedback_Tick(object sender, EventArgs e)
        { FeedbackOff(); }

        private void Form1_Load(object sender, EventArgs e)
        { FeedbackOff(); }

        private void FeedbackOn()
        {
            feedbackpannel.Visible = true;
            hideFeedback.Start();
            hideFeedback.Enabled = true;
        }

        private void FeedbackOff()
        {
            feedbackpannel.Visible = false;
            hideFeedback.Stop();
            hideFeedback.Enabled = false;
        }

        private void feedbackpannel_Click(object sender, EventArgs e)
        {
            FeedbackOff();
        }
    }
}
