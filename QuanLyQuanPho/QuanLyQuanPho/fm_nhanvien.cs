using QuanLyQuanPho.DAO;
using QuanLyQuanPho.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanPho
{
    public partial class fm_nhanvien : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        public fm_nhanvien(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }

        void UpdateAccount()
        {
            string displayName = textBox2.Text;
            string password = textBox3.Text;
            string newpass = textBox4.Text;
            string reenterPass = textBox5.Text;
            string userName = textBox1.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    //if (updateAccount != null)
                    //    updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Sai mật khấu");
                }
            }
        }


        void ChangeAccount(Account acc)
        {
            textBox1.Text = LoginAccount.UserName;
            textBox2.Text = LoginAccount.DisplayName;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void fm_nhanvien_FormClosing(object sender, FormClosingEventArgs e)
        {
            //thôngToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }
    }
}
