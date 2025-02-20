using System.Windows.Forms;

namespace mtuliwindo
{
    public partial class ContactsControl : Form
    {
        private CreateContact createContact = new CreateContact();
        private List<Contact> contacts = new List<Contact>();
        public ContactsControl()
        {
            InitializeComponent();
            createContact.OnSubmit += CreateContact_OnSubmit;
            ReflowList();
        }

        private void ReflowList()
        {
            dgvContacts.DataSource = null;
            dgvContacts.DataSource = contacts;
        }

        private void CreateContact_OnSubmit(Contact contact)
        {
            int idx = contacts.IndexOf(contact);
            if (idx != -1) {
                ReflowList();
                return; 
            }
            contacts.Add(contact);
            ReflowList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            createContact.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Contact toEdit = dgvContacts.CurrentRow.DataBoundItem as Contact;
            if (toEdit == null) return;
            createContact.LoadEdit(toEdit);
            createContact.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Contact toEdit = dgvContacts.CurrentRow.DataBoundItem as Contact;
            int idx = contacts.IndexOf(toEdit);
            if (idx == -1) return;
            contacts.RemoveAt(idx);
            ReflowList();
        }
    }
}
