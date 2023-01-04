using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _120822_AracSiparisUygulaması
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRenk_Click(object sender, EventArgs e)//event yanlış yaptım.ekle yaptım hata verdi
        {
            DialogResult sonuc = colorDialog1.ShowDialog();//renkleri açar
            if (sonuc == DialogResult.OK)
            {
                btnRenk.BackColor = colorDialog1.Color;

            }

        }
        

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbModel.Items.Clear();
            switch(cmbMarka.Text)
            {
                case "VOLKSWAGEN":
                    cmbModel.Items.Add("JETTA");
                    cmbModel.Items.Add("JETTA");
                    cmbModel.Items.Add("PASSAT");
                    cmbModel.Items.Add("GOLF");
                        break;
                case "AUDI":
                    cmbModel.Items.Add("A7");
                    cmbModel.Items.Add("Q7");
                    cmbModel.Items.Add("R8");
                        break;
                    
                case "RENAULT":
                    cmbModel.Items.Add("CLIO");
                    cmbModel.Items.Add("LAGUNA");
                    cmbModel.Items.Add("SYMBOL");
                        break;
                case "HYUNDAI":
                    cmbModel.Items.Add("ACCENT");
                    cmbModel.Items.Add("İ30");
                    cmbModel.Items.Add("İX35");
                        break;
                case "HONDA":
                    cmbModel.Items.Add("CIVIC");
                    cmbModel.Items.Add("CITY");
                    cmbModel.Items.Add("CR-V");
                        break;
                case "BMW":
                    cmbModel.Items.Add("M60 COUPE");
                    cmbModel.Items.Add("X6");
                    cmbModel.Items.Add("5.25");
                        break;
                case "MERCEDES":
                    cmbModel.Items.Add("200 AMG");
                    cmbModel.Items.Add("E 250");
                    cmbModel.Items.Add("CLA 200");
                        break;
                case "FİAT":
                    cmbModel.Items.Add("ŞAHİN");
                    cmbModel.Items.Add("DOĞAN");
                    cmbModel.Items.Add("KARTAL");
                    break;

                default:
                       break;
            }
        }
        
       /* private void btnRenk_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = colorDialog1.ShowDialog();//renkleri açar
            if (sonuc == DialogResult.OK)
            {
                btnRenk.BackColor = colorDialog1.Color;

            }
        }*/

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.UseItemStyleForSubItems = false;//renk değiştirebilmek için özellikleri değiştirilebilir yapalım.listviewin satırları için
            lvi.Text=cmbMarka.Text;
            lvi.SubItems.Add(cmbModel.Text);
            lvi.SubItems.Add(cmbYakitTipi.Text);
            lvi.SubItems.Add(cmbKasaTipi.Text);
            lvi.SubItems.Add(cmbVitesTipi.Text);
            lvi.SubItems.Add(cmbMotorTipi.Text);
            lvi.SubItems.Add(string.Empty);//subıtem boş olmasın hata verir boş olsada ekledik önce
            lvi.SubItems[6].BackColor = btnRenk.BackColor;
            lvi.SubItems.Add(dtpYil.Text);

            listView1.Items.Add(lvi);

            //6 tane cmbMarka.SelectedIndex=-1; türü yazmamak için bunu yapıyoruz
            //seçim yaptıktan sonra comboboxta seçili elemanları sıfırladık.
            foreach (Control ctrl in this.Controls)
            {//bir değişkenideğerine göre sorgulamak için == kullanılır
                //tipine göre sorgulamak için is kullanılır.
                if(ctrl is ComboBox)// is komutu ctrl elemanı  combobox mı diye sormayı sağlar
                {
                    ((ComboBox)ctrl).SelectedIndex = -1;//toplu olarak comboxu temizlemek için yapıyoruz
                }
                else if (ctrl is Button)
                {
                    Button btn = (Button)ctrl; 
                    if(btn.Name=="btnRenk")
                    {
                        btn.BackColor = Color.LightGray;
                    }
                }
                
                else if (ctrl is DateTimePicker)
                {
                    //DateTime.Now sistem saat ve tarihini getirir.
                    ((DateTimePicker)ctrl).Value = DateTime.Now;
                }
            }



        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count>0)
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }
        //class düzeyinde tanımlama global değişkendir.
        ListViewItem secili;
        private void btnDüzenle_Click(object sender, EventArgs e)
        {
            //Hiç kayıt seçilmemiş ise
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen Düzenlemek İstediğiniz Kaydı Seçiniz!");
                return;//içerisinde bulunduğu metodu sonlandırır.Altında gelen hiçbir
                       //kodu çalıştırmaz.
                //btnDüzenle eventından çıkar
            }

            secili = listView1.SelectedItems[0];//kullanıcı kayıt seçti listviewden
            cmbMarka.Text=secili.Text;//ilk kolon text olarak adlandırılır.
            
            cmbModel.Text = secili.SubItems[1].Text;
            cmbYakitTipi.Text = secili.SubItems[2].Text;
            cmbKasaTipi.Text = secili.SubItems[3].Text;
            cmbVitesTipi.Text = secili.SubItems[4].Text;
            cmbMotorTipi.Text = secili.SubItems[5].Text;
            btnRenk.BackColor = secili.SubItems[6].BackColor;
            dtpYil.Value =Convert.ToDateTime(string.Format("01.01.{0}",
            secili.SubItems[7].Text));

        }
        
         private void btnKaydet_Click(object sender, EventArgs e)
         {

               secili.SubItems[0].Text = cmbMarka.Text;
               secili.SubItems[1].Text = cmbModel.Text;
               secili.SubItems[2].Text = cmbYakitTipi.Text;
               secili.SubItems[3].Text = cmbKasaTipi.Text;
               secili.SubItems[4].Text = cmbVitesTipi.Text;
               secili.SubItems[5].Text = cmbMotorTipi.Text;
               secili.SubItems[6].BackColor = btnRenk.BackColor;
               secili.SubItems[7].Text = dtpYil.Text;

           }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            //e.KeyCode:Basılan tuşun kodunu tutar.
            if (e.KeyCode==Keys.Delete)
            {
                if (listView1.SelectedItems.Count>0)//seçili eleman var mı diye bakıyoruz hata vermesin diye
                {
                    listView1.Items.Remove(listView1.SelectedItems[0]);//seçili elemanı siler
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)//seçili eleman var mı diye bakıyoruz hata vermesin diye
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);//seçili elemanı siler
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hiç kayıt seçilmemiş ise
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen Düzenlemek İstediğiniz Kaydı Seçiniz!");
                return;//içerisinde bulunduğu metodu sonlandırır.Altında gelen hiçbir
                       //kodu çalıştırmaz.
                       //btnDüzenle eventından çıkar
            }

            secili = listView1.SelectedItems[0];//kullanıcı kayıt seçti listviewden
            cmbMarka.Text = secili.Text;//ilk kolon text olarak adlandırılır.

            cmbModel.Text = secili.SubItems[1].Text;
            cmbYakitTipi.Text = secili.SubItems[2].Text;
            cmbKasaTipi.Text = secili.SubItems[3].Text;
            cmbVitesTipi.Text = secili.SubItems[4].Text;
            cmbMotorTipi.Text = secili.SubItems[5].Text;
            btnRenk.BackColor = secili.SubItems[6].BackColor;
            dtpYil.Value = Convert.ToDateTime(string.Format("01.01.{0}",
            secili.SubItems[7].Text));

        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {

            secili.SubItems[0].Text = cmbMarka.Text;
            secili.SubItems[1].Text = cmbModel.Text;
            secili.SubItems[2].Text = cmbYakitTipi.Text;
            secili.SubItems[3].Text = cmbKasaTipi.Text;
            secili.SubItems[4].Text = cmbVitesTipi.Text;
            secili.SubItems[5].Text = cmbMotorTipi.Text;
            secili.SubItems[6].BackColor = btnRenk.BackColor;
            secili.SubItems[7].Text = dtpYil.Text;
        }
    }
}
