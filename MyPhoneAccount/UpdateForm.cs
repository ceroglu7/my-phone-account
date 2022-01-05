using FluentValidation.Results;
using MyPhoneAccount.Validators;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MyPhoneAccount
{
    public partial class UpdateForm : Form
    {
        public PersonDto.Person ReturnPerson { get; set; }
        CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        OpenFileDialog file = new OpenFileDialog();
        string DefaultPhotoWay = @"\Default.png";
        public UpdateForm()
        {
            InitializeComponent();
        }
        public string fullName;
        public string companyName;
        public string gsm;
        public string email;
        public string phone;
        public string BeforePhotoWay, BeforePhotoName;
        public string GoalFolder = @"ProfilePictures";
        //public string UpdatePhotoWay, UpdatePhotoName;
        public string PhotoWay, PhotoName;
        bool UpdatePhoto;

        private void Update_Load(object sender, EventArgs e)
        {
            txtNameSurname.Text = fullName;
            txtGSM.Text = gsm;
            txtMail.Text = email;
            txtPhone.Text=phone;
            txtCompany.Text = companyName;
            BeforePhotoWay = PhotoWay;
            BeforePhotoName = PhotoName;
            pcbProfilePic.ImageLocation = BeforePhotoWay;
            btnSelectPhoto.Text ="Fotoğraf Seç";
        }
        public void update()
        {
            try
            {
                PersonDto.Person person = new PersonDto.Person
                {
                    Fullname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNameSurname.Text),
                    GSM = txtGSM.Text,
                    Email = txtMail.Text,
                    Phone = txtPhone.Text,
                    IsCompany = false,
                    CompanyName = String.Empty
                };
                if (UpdatePhoto)
                {
                    if (pcbProfilePic.Image.Width != pcbProfilePic.Image.Height)
                    {
                        MessageBox.Show("Lütfen eni ve boyu aynı olan fotoğraf seçiniz!");
                        return;
                    }
                    else
                    {
                        File.Copy(PhotoWay, GoalFolder + "\\" + person.Id + PhotoName);
                        person.AddedPhoto = true;
                        person.Photo = GoalFolder + "\\" + person.Id + PhotoName;
                        person.PhotoName = PhotoName;
                        if (BeforePhotoWay != DefaultPhotoWay)
                        {
                            File.Delete(BeforePhotoWay);
                        }    
                    }
                }
                else
                {
                    person.Photo = BeforePhotoWay;
                    person.PhotoName = BeforePhotoName;
                }
                PersonDtoValidator validation = new PersonDtoValidator();
                ValidationResult result = validation.Validate(person);
                if (!result.IsValid)
                {
                    string errorMessage = "";
                    foreach (var error in result.Errors)
                    {
                        errorMessage += $"{error}  \n";
                    }
                    MessageBox.Show(errorMessage, "Hatalar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                


                //Validation

                ReturnPerson = person;

                this.DialogResult = DialogResult.OK;

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            update();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                update();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            file.Filter = "PNG Dosyası |*.png| JPEG Dosyası |*.jpg";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.CheckFileExists = true;
            file.Title = "Dosya Seçiniz..";
            if (file.ShowDialog() == DialogResult.OK)
            {
                PhotoWay = file.FileName.ToString();
                PhotoName = file.SafeFileName.ToString();
                btnSelectPhoto.Text = PhotoName;
                pcbProfilePic.ImageLocation = PhotoWay;
                UpdatePhoto = true;
            }
            else
            {
                UpdatePhoto = false;
            }
        }
        private void Update_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
