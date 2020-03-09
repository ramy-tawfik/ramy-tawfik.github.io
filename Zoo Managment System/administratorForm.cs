using System.Windows.Forms;

namespace Zoo_Managment_System
{
    public partial class administratorForm : Form
    {
        public administratorForm()
        {
            InitializeComponent();
        }

        private void taskOneBtn_Click(object sender, System.EventArgs e)
        {
            tabPanel.Height = taskOneBtn.Height;
            tabPanel.Top = taskOneBtn.Top;
        }

        private void taskTwoBtn_Click(object sender, System.EventArgs e)
        {
            tabPanel.Height = taskTwoBtn.Height;
            tabPanel.Top = taskTwoBtn.Top;
        }

        private void taskThreeBtn_Click(object sender, System.EventArgs e)
        {
            tabPanel.Height = taskThreeBtn.Height;
            tabPanel.Top = taskThreeBtn.Top;
        }
    }
}