namespace WinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // Inicjalizacja innych komponentów

            // Dodanie obs³ugi zdarzenia dla LinkLabel
            registerLabel.LinkClicked += RegisterLabel_LinkClicked;
            passForgetLabel.LinkClicked += PassForgetLabel_LinkClicked;
            loginButton.Click += loginButton_Click;
        }
        private void RegisterLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Obs³uga klikniêcia na LinkLabel
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            // Mo¿esz u¿yæ Show() zamiast ShowDialog(), jeœli chcesz, aby nowe okno nie by³o blokuj¹ce
        }
        private void PassForgetLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Obs³uga klikniêcia na LinkLabel
            ForgetPassForm forgetPassForm = new ForgetPassForm();
            forgetPassForm.ShowDialog();
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            // Obs³uga klikniêcia na przycisk loginButton
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
