namespace FrontEnd
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // Inicjalizacja innych komponent�w

            // Dodanie obs�ugi zdarzenia dla LinkLabel
            registerLabel.LinkClicked += RegisterLabel_LinkClicked;
            passForgetLabel.LinkClicked += PassForgetLabel_LinkClicked;
            loginButton.Click += loginButton_Click;
        }
        private void RegisterLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Obs�uga klikni�cia na LinkLabel
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            // Mo�esz u�y� Show() zamiast ShowDialog(), je�li chcesz, aby nowe okno nie by�o blokuj�ce
        }
        private void PassForgetLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Obs�uga klikni�cia na LinkLabel
            ForgetPassForm forgetPassForm = new ForgetPassForm();
            forgetPassForm.ShowDialog();
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            // Obs�uga klikni�cia na przycisk loginButton
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
