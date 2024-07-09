using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUI
{
    public class Service1
    {
        private readonly Repo1 _repo1;

        public Service1(Repo1 repo1)
        {
            _repo1 = repo1;
        }

        public Service1()
        {
            _repo1 = new Repo1();
        }

        public List<Sanpham> AllSanPham()
        {
            return _repo1.GetSanphams();
        }
        public bool SanPhamAdd(Sanpham sanpham)
        {
            return _repo1.AddSanPham(sanpham);
        }
        public bool SanPhamUpdate(Sanpham sanpham)
        {
            return _repo1.UpdateSanPham(sanpham);
        }
        public bool SanPhamDelete(int id)
        {
            return _repo1.DeleteSanPham(id);
        }
        public List<Sanpham> TimSanPham(string ten)
        {
            return _repo1.TimSanPham(ten);
        }
        public List<Nhacungcap> Nhacungcaps()
        {
            return _repo1.GetNhacungcaps();
        }
        public List<Sanpham> TimSanPhamTheoGia(int gia)
        {
            if(gia == null)
            {
                return _repo1.GetSanphams();
            }
            return _repo1.TimSanPhamTheoGia(gia);
        }
        public List<Sanpham> TimSanPhamTheoSoLuong(int soLuong)
        {
            if (soLuong == null)
            {
                return _repo1.GetSanphams();
            }
            return _repo1.TimSanPhamTheoSoLuong(soLuong);
        }
    }
}
