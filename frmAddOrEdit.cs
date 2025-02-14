using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Contacts
{
    public partial class frmAddOrEdit : Form
    {
        Contact_DBEntities db = new Contact_DBEntities();
        public int contactId = 0;
        public frmAddOrEdit()
        {
            InitializeComponent();
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (contactId == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش شخص";
                MyContact contact = db.MyContacts.Find(contactId);
                txtName.Text = contact.Name;
                txtFamily.Text = contact.Family;
                txtMobile.Text = contact.Mobile;
                txtEmail.Text = contact.Email;
                txtAge.Text = contact.Age.ToString();
                txtAddress.Text = contact.Address;
                btnSubmit.Text = "ویرایش";
            }
        }

        bool ValidateInpute()
        {

            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید","هشدار", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            if (txtFamily.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("لطفا شماره تلفن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("لطفا ایمیل را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInpute())
            {
                
                if (contactId == 0)
                {
                    MyContact contact = new MyContact();
                    contact.Name = txtName.Text;
                    contact.Email = txtEmail.Text;
                    contact.Family = txtFamily.Text;
                    contact.Mobile = txtMobile.Text;
                    contact.Age = (int)txtAge.Value;
                    contact.Address = txtAddress.Text;
                    db.MyContacts.Add(contact);
                }
                else
                {
                    var contact = db.MyContacts.Find(contactId);
                    contact.Name = txtName.Text;
                    contact.Email = txtEmail.Text;
                    contact.Family = txtFamily.Text;
                    contact.Mobile = txtMobile.Text;
                    contact.Age = (int)txtAge.Value;
                    contact.Address = txtAddress.Text;
                }
                db.SaveChanges();
                
                    MessageBox.Show("عملیات با موفقیت انجام شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                
               
            }
        }
    }
}
