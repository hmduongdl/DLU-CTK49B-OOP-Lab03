using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2513734_LeNguyenHoangLong_Lab03
{
    class SinhVien
    {
        #region Trường dữ liệu
        private string maSV;
        private string hoTen;
        private DateTime ngaySinh;
        private float diemTB;
        #endregion

        #region Thuộc tính
        public string MaSV { get; set; }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = ChuanHoaTen(value); }
        }

        public float DiemTB //[0,10]
        {
            get
            {
                return this.diemTB;
            }
            set
            {
                if (value < 0)
                    value = 0;
                if (value > 10)
                    value = 10;
                this.diemTB = value;
            }
        }

        public string LayHo
        {
            get
            {
                string[] ss = hoTen.Trim().Split(' ');
                return ss[0];
            }
        }

        public string LayTen
        {
            get
            {
                string[] ss = hoTen.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                return ss[ss.Length - 1];
            }
        }
        #endregion
        #region Phuong thuc
        private string ChuanHoaTen(string hoten)
        {
            string[] ss = hoten.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string kq = "";
            for (int i = 0; i < ss.Length; i++)
            {
                string tu = ss[i].ToLower();
                tu = char.ToUpper(tu[0]) + tu.Substring(1);
                kq += tu;
                if (i < ss.Length - 1)
                    kq += " ";
            }
            return kq;
        }

        public void ChuanHoaHoTen()
        {
            this.hoTen = this.ChuanHoaTen(this.hoTen);
        }

        public SinhVien()
        {
            this.MaSV = "";
            this.HoTen = "";
            this.DiemTB = 0.0f;
            this.NgaySinh = new DateTime(2000, 1, 20);
        }
        public SinhVien(string maSV, string hoTen, DateTime ns, float dtb)
        {
            this.MaSV = maSV;
            this.HoTen = hoTen;
            this.NgaySinh = ns;
            this.DiemTB = dtb;
        }
        public override string ToString()
        {
            return string.Format("|{0, 10}|{1, -30}|{2, 10}|{3, 8}|",
                this.MaSV,
                this.HoTen,
                this.NgaySinh.ToString("dd/MM/yyyy"),
                this.DiemTB);
        }
        public void Xuat()
        {
            Console.WriteLine(this);      
        }

        public void Nhap()
        {
            Console.Write("Nhap ma so sinh vien: ");
            this.MaSV = Console.ReadLine();
            Console.Write("Nhap ho ten sinh vien: ");
            this.HoTen = Console.ReadLine();
            Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");
            this.NgaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Nhap diem trung binh: ");
            this.DiemTB = float.Parse(Console.ReadLine());
        }
        #endregion

    }
}
