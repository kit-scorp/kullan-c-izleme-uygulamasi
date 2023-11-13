using System;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;

namespace kullanıcı_girişi_izleme_uygulaması
{
    public partial class Form1 : Form
    {
        private object smtp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            string username = richTextBox1.Text;
            string password = richTextBox2.Text;

            if (username == "admin" && password == "1234")
            {
                label3.Text = "Giriş başarılı!";
                button1.BackColor = Color.White;

                try
                {
                    button1.BackColor = Color.White;
                    MailMessage mail = new MailMessage();
                    SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com");

                    // SMTP kimlik doğrulama bilgileri
                    smtp.Credentials = new System.Net.NetworkCredential("GÖNDEREN OUTLOOK ADRESİNİ GİRİNİZ", "HESAP ŞİFRESİ GİRİNİZ");


                    mail.From = new MailAddress("GÖNDEREN OUTLOOK ADRESİNİ GİRİNİZ");
                    mail.To.Add("GÖNDERİLECEK E POSTA ADRESİNİ GİRİNİZ");
                    mail.Subject = "Hesaba giriş yapıldı";
                    mail.Body = "Hesaba giriş yapıldı.";

                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    smtp.Send(mail);                   
                    MessageBox.Show("E-posta gönderildi.");
                }
                catch (Exception ex)
                {
                    button1.BackColor = Color.White;
                    MessageBox.Show("E-posta gönderme hatası: " + ex.Message);
                }
            }
            else
            {
                
                MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
                button1.BackColor = Color.White;
            }
        }
    }
}
