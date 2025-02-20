using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace mtuliwindo
{
    public partial class CreateContact : Form
    {
        public CreateContact()
        {
            InitializeComponent();
        }

        public Contact contact = new Contact();
        public delegate void SubmitData(Contact contact);
        public event SubmitData OnSubmit;
        public void LoadEdit(Contact toEdit)
        {
            contact = toEdit;
            txtPhone.Text = contact.PhoneNum;
            txtEmail.Text = contact.Email;
            txtName.Text = contact.Name;
        } 
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string nums = "";
            for (int i = 0; i < txtPhone.Text.Length; i++)
                if (txtPhone.Text[i] <= '9' && txtPhone.Text[i] >= '0')
                    nums += txtPhone.Text[i];
            if (nums.Length != 10)
            {
                MessageBox.Show($"Invalid phone number {txtPhone.Text} ({nums}), phone numbers must be ten digits in length", "Invalid Phone Number",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            contact.PhoneNum = nums;
            contact.Email = txtEmail.Text;
            contact.Name = txtName.Text;
            OnSubmit(contact);
            LoadEdit(new Contact());
            Hide();
        }
    }
}
