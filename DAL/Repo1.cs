using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repo1
    {
        private readonly Sof205FinalTestContext _context;
        public Repo1()
        {
            _context = new Sof205FinalTestContext();
        }
        public List<Sanpham> GetSanphams()
        {
            return _context.Sanphams.ToList();
        }
        public bool AddSanPham(Sanpham sanpham)
        {
            try
            {
                _context.Sanphams.Add(sanpham);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateSanPham(Sanpham sanpham)
        {
            try
            {
                var SanPhamSua = _context.Sanphams.Find(sanpham.Id);
                SanPhamSua.Ten = sanpham.Ten;
                SanPhamSua.Mota = sanpham.Mota;
                SanPhamSua.Soluongtonkho = sanpham.Soluongtonkho;
                SanPhamSua.Giatien = sanpham.Giatien;
                SanPhamSua.IdNcc = sanpham.IdNcc;

                _context.Sanphams.Update(SanPhamSua);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteSanPham(int id)
        {
            try
            {
                var sanphamxoa = _context.Sanphams.Find(id);

                _context.Sanphams.Remove(sanphamxoa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Sanpham> TimSanPham(string ten)
        {
            return _context.Sanphams.Where(x => x.Ten.Contains(ten)).ToList();
        }
        public List<Sanpham> TimSanPhamTheoGia(int gia)
        {
            return _context.Sanphams.Where(x => x.Giatien <  gia).ToList();
        }
        public List<Sanpham> TimSanPhamTheoSoLuong(int soluong)
        {
            return _context.Sanphams.Where(x => x.Soluongtonkho < soluong).ToList();
        }
        public List<Nhacungcap> GetNhacungcaps()
        {
            return _context.Nhacungcaps.ToList();
        }
    }
}
