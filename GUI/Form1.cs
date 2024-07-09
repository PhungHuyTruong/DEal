using BUI;
using DAL.Models;
using System.Drawing;

namespace GUI
{
    public partial class Form1 : Form
    {
        private readonly Service1 ser;
        int IDChon = -1;
        public Form1(Service1 bui)
        {
            ser = bui;
            InitializeComponent();
            Loadcombobox();
        }
        public void Loaddata(List<Sanpham> sp, List<Nhacungcap> ncc)
        {
            dataGridView1.Rows.Clear();

            int stt = 1;
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "stt";
            dataGridView1.Columns[1].Name = "ten";
            dataGridView1.Columns[2].Name = "mo ta";
            dataGridView1.Columns[3].Name = " so luong";
            dataGridView1.Columns[4].Name = "gia tien";
            dataGridView1.Columns[5].Name = "idcn";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Name = "id";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Name = "Ten Nha Cung Cap";

            foreach (Sanpham s in sp)
            {
                Nhacungcap nncten = ncc.FirstOrDefault(a => a.Id == s.Id);
                var tenncc = nncten != null ? nncten.Ten : "ko co";
                dataGridView1.Rows.Add(stt++, s.Ten, s.Mota, s.Soluongtonkho, s.Giatien, s.IdNcc, s.Id, tenncc);
            }
        }
        public void Loadcombobox()
        {
            var nhacungcap = ser.Nhacungcaps();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = nhacungcap.ToList();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            Loaddata(ser.AllSanPham(), ser.Nhacungcaps());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = e.RowIndex;

            var sanphamchon = dataGridView1.Rows[index];

            textBox1.Text = sanphamchon.Cells[1].Value.ToString();
            textBox2.Text = sanphamchon.Cells[2].Value.ToString();
            textBox3.Text = sanphamchon.Cells[3].Value.ToString();
            textBox4.Text = sanphamchon.Cells[4].Value.ToString();
            comboBox1.SelectedValue = sanphamchon.Cells[5].Value;
            IDChon = Convert.ToInt32(sanphamchon.Cells[6].Value.ToString());
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            var sanpham = new Sanpham
            {
                Ten = textBox1.Text,
                Mota = textBox2.Text,
                Soluongtonkho = Convert.ToInt32(textBox3.Text),
                Giatien = Convert.ToInt32(textBox4.Text),
                IdNcc = Convert.ToInt32(comboBox1.SelectedValue),
            };

            ser.SanPhamAdd(sanpham);
            Loaddata(ser.AllSanPham(), ser.Nhacungcaps());
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            ser.SanPhamDelete(IDChon);
            Loaddata(ser.AllSanPham(), ser.Nhacungcaps());
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            var sanpham = new Sanpham
            {
                Id = IDChon,
                Ten = textBox1.Text,
                Mota = textBox2.Text,
                Soluongtonkho = Convert.ToInt32(textBox3.Text),
                Giatien = Convert.ToInt32(textBox4.Text),
                IdNcc = Convert.ToInt32(comboBox1.SelectedValue),
            };
            ser.SanPhamUpdate(sanpham);
            Loaddata(ser.AllSanPham(), ser.Nhacungcaps());
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
