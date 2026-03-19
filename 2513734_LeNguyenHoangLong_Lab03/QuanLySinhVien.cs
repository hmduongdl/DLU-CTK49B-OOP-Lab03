using _2513734_LeNguyenHoangLong_Lab03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2513734_LeNguyenHoangLong_Lab03
{
    class QLSinhVien
    {
        private SinhVien[] dsSinhVien;
        private int soSV;

        public QLSinhVien()
        {
            this.dsSinhVien = new SinhVien[100];
            this.soSV = 0;
        }

        public enum MenuCT
        {
            Thoat,
            ThemSVvaoDS,
            NhapDSSV,
            NhapCD,
            XuatDSSV,
            TinhDTB,
            TimDSSVTheoTen,
            TimDSSVCoDTBMax,
            TimDSSVCoTenX,
            ThongKeSVKhongDat,
            SapXepTheoTen,
            SapXepTheoChieuDaiHoTen,
            SapXepDSTheoDTB,
            ChenSV,
            XoaSV,
            XoaSVDauTienCoTenX,
            XoaTatCaSVCoTenX,
        }

        // ham xuat ke Ngang voi so lan n
        static void XuatKeNgang(char kt, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(kt);

            }
            Console.WriteLine();
        }


        // Ham xuat menu

        static void XuatMenu()
        {
            XuatKeNgang('-', 40);
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.Thoat, "Thoat Chuong Trinh");
                   Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.ThemSVvaoDS, "Them sinh vien vao danh sach");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.NhapDSSV, "Nhap DS Sinh Vien");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.NhapCD, "Nhap danh sach co dinh gom 10 sinh vien");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.XuatDSSV, "Xuat danh sach sinh vien");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.TinhDTB, "Tinh diem trung binh cong.");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.TimDSSVTheoTen, "Tim danh sach sinh vien theo ten");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.TimDSSVCoDTBMax, "Tim danh sach sinh vien co diem trung binh max.");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.TimDSSVCoTenX, "Tim danh sach sinh vien co diem trung binh max");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.ThongKeSVKhongDat, "Thong ke so luong sinh vien co khong dat");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.SapXepTheoTen, "Sap xep danh sach sinh vien tang theo ten");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.SapXepTheoChieuDaiHoTen, "Sap xep danh sach sinh vien giam dan theo chieu dai cua ho ten.");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.SapXepDSTheoDTB, "Sap xep danh sach giam theo diem trung binh");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.ChenSV, "Chen sinh vien sv sau khi vien co ma so x");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.XoaSV, "Xoa sinh vien theo ma so");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.XoaSVDauTienCoTenX, "Xoa sinh vien dau tien trong danh sach co ten x.");
            Console.WriteLine("Nhap {0} de {1}", (int)MenuCT.XoaTatCaSVCoTenX, "Xoa tat ca sinh vien co ten x.");
            XuatKeNgang('-', 40);

        }

        // Ham chon menu

        static MenuCT ChonMenu()
        {
            int chon;
            do
            {
                Console.Write("Nhap chon {0} den {1}: ", (int)MenuCT.Thoat, (int)MenuCT.XoaTatCaSVCoTenX);
                chon = int.Parse(Console.ReadLine());
                if ((int)MenuCT.Thoat <= chon && chon <= (int)MenuCT.XoaTatCaSVCoTenX)
                    break;
            } while (true);
            return (MenuCT)chon;
        }

        // ham xu ly menu
        static void XuLyMenu(MenuCT m, QLSinhVien ql)
        {
            switch (m)
            {
                case MenuCT.Thoat:
                    return;
                case MenuCT.ThemSVvaoDS:
                    ql.XuatDSSV();
                    Console.WriteLine("\nThem 1 Sinh Vien Vao Danh Sach:");
                    SinhVien sv = new SinhVien();
                    sv.Nhap();
                    if (ql.Them(sv))
                    {
                        Console.WriteLine("Them thanh cong!");
                        ql.XuatDSSV();
                    }
                    break;
                case MenuCT.NhapDSSV:
                    Console.WriteLine("\nNhap DS Sinh Vien:");
                    ql.NhapDSSV();
                    ql.XuatDSSV();
                    break;
                case MenuCT.NhapCD:
                    ql.NhapCD();
                    Console.WriteLine("Da nhap danh sach co dinh!");
                    ql.XuatDSSV();
                    break;
                case MenuCT.XuatDSSV:
                    Console.WriteLine("\nXuat Danh Sach Sinh Vien:");
                    ql.XuatDSSV();
                    break;
                case MenuCT.TinhDTB:
                    Console.WriteLine("\nTinh Diem Trung Binh Cong Cua Ca Lop:");
                    ql.XuatDSSV();
                    float dtb = ql.TinhDTB();
                    if (ql.soSV > 0)
                        Console.WriteLine("Diem trung binh cong cua ca lop: {0:0.0}", dtb);
                    else
                        Console.WriteLine("Danh sach rong!");
                    break;
                case MenuCT.TimDSSVTheoTen:
                    Console.WriteLine("\nTIm DS Sinh Vien Theo Ten:");
                    ql.XuatDSSV();
                    Console.Write("Nhap ten sinh vien can tim: ");
                    string ten = Console.ReadLine();
                    QLSinhVien tdt = ql.TimDSSVTheoTen(ten);
                    if (tdt.soSV > 0) tdt.XuatDSSV();
                    else Console.WriteLine("Khong tim thay!");
                    break;
                case MenuCT.TimDSSVCoDTBMax:
                    ql.XuatDSSV();
                    QLSinhVien dtbMax = ql.TimDSSVCoDTBMax();
                    if (dtbMax.soSV > 0) dtbMax.XuatDSSV();
                    else Console.WriteLine("Danh sach rong!");
                    break;
                case MenuCT.TimDSSVCoTenX:
                    ql.XuatDSSV();
                    Console.Write("Nhap chuoi ten x can tim: ");
                    string tenX = Console.ReadLine();
                    QLSinhVien tx = ql.TimDSSVCoTenX(tenX);
                    if (tx.soSV > 0) tx.XuatDSSV();
                    else Console.WriteLine("Khong tim thay!");
                    break;
                case MenuCT.ThongKeSVKhongDat:
                    Console.WriteLine("So luong sinh vien khong dat (DTB < 5.5): {0}", ql.ThongKeSVKhongDat());
                    break;
                case MenuCT.SapXepTheoTen:
                    ql.XuatDSSV();
                    ql.SapXepTheoTen();
                    Console.WriteLine("Da sap xep tang theo ten!");
                    ql.XuatDSSV();
                    break;
                case MenuCT.SapXepTheoChieuDaiHoTen:
                    ql.XuatDSSV();
                    ql.SapXepTheoChieuDaiHoTen();
                    Console.WriteLine("Da sap xep giam dan theo do dai ho ten!");
                    ql.XuatDSSV();
                    break;
                case MenuCT.SapXepDSTheoDTB:
                    ql.XuatDSSV();
                    ql.SapXepDSTheoDTB();
                    Console.WriteLine("Da sap xep giam theo DTB va ho!");
                    ql.XuatDSSV();
                    break;
                case MenuCT.ChenSV:
                    ql.XuatDSSV();
                    Console.Write("Nhap Ma SV can chen sau: ");
                    string maSVChen = Console.ReadLine();
                    SinhVien svc = new SinhVien();
                    Console.WriteLine("Nhap thong tin sinh vien can chen:");
                    svc.Nhap();
                    ql.ChenSV(svc, maSVChen);
                    Console.WriteLine("Da thuc hien chen!");
                    ql.XuatDSSV();
                    break;

            }
            Console.ReadKey();

        }
        public static void ChayChuongTrinh()
        {
            MenuCT chon;
            QLSinhVien ql = new QLSinhVien();
            do
            {
                Console.Clear();
                XuatMenu();
                chon = ChonMenu();
                if (chon == MenuCT.Thoat)
                    break;
                XuLyMenu(chon, ql);
                Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
                Console.ReadKey();
            } while (true);
        }

        #region Các hàm chức năng

        public bool KiemTraTrungMaSV(string maSV)
        {
            for (int i = 0; i < soSV; i++)
            {
                if (dsSinhVien[i].MaSV == maSV)
                    return true;
            }
            return false;
        }

        public bool Them(SinhVien sv)
        {
            if (this.soSV >= this.dsSinhVien.Length)
                return false;
            
            if (KiemTraTrungMaSV(sv.MaSV))
            {
                Console.WriteLine("Ma SV {0} da ton tai!", sv.MaSV);
                return false;
            }

            this.dsSinhVien[this.soSV++] = sv;
            return true;
        }

        public void NhapDSSV()
        {
            Console.Write("Nhap so luong sinh vien can them: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin sinh vien thu {0}:", i + 1);
                SinhVien sv = new SinhVien();
                sv.Nhap();
                if (!Them(sv))
                {
                    Console.WriteLine("Them that bai (vui long nhap lai)!");
                    i--;
                }
            }
        }

        public void NhapCD()
        {
            this.Them(new SinhVien("2544456", "Nguyen Lan Huong", new DateTime(2000, 10, 25), 5.6f));
            this.Them(new SinhVien("2664456", "Le Anh Tuan", new DateTime(2005, 1, 15), 8.3f));
            this.Them(new SinhVien("2566634", "Tran Anh Hung", new DateTime(2001, 10, 15), 6.6f));
            this.Them(new SinhVien("2578822", "Nguyen Van", new DateTime(2005, 11, 25), 4.3f));
            this.Them(new SinhVien("2533311", "Le Hoai Thuong", new DateTime(2005, 1, 5), 7.6f));
            this.Them(new SinhVien("2664457", "Nguyen Hong", new DateTime(2003, 7, 23), 8.0f));
            this.Them(new SinhVien("2566635", "Bui Ngoc Anh", new DateTime(2002, 12, 11), 7.5f));
            this.Them(new SinhVien("2578823", "Pham Thi Lan", new DateTime(2004, 4, 30), 9.0f));
            this.Them(new SinhVien("2533312", "Hoang Van Kien", new DateTime(2001, 2, 28), 6.8f));
            this.Them(new SinhVien("2664458", "Dang Tuan Minh", new DateTime(2003, 8, 19), 5.9f));
            this.Them(new SinhVien("2516458", "Hoang Van Minh", new DateTime(2003, 8, 19), 5.9f));
        }
        
        public void XuatDSSV()
        {
            if (this.soSV == 0)
            {
                Console.WriteLine("Danh sach hien tai rong!");
                return;
            }
            Console.WriteLine("".PadRight(74, '-'));
            Console.WriteLine("|{0, 10}|{1, -30}|{2, 10}|{3, 8}|", "Ma SV", "Ho va Ten", "Ngay Sinh", "Diem TB");
            Console.WriteLine("".PadRight(74, '-'));
            for (int i = 0; i < soSV; i++)
            {
                this.dsSinhVien[i].Xuat();
            }
            Console.WriteLine("".PadRight(74, '-'));
        }

        public float TinhDTB()
        {
            if (this.soSV == 0) return 0;
            float sum = 0;
            for (int i = 0; i < this.soSV; i++)
            {
                sum += this.dsSinhVien[i].DiemTB;
            }
            return sum / this.soSV;
        }

        public QLSinhVien TimDSSVTheoTen(string ten)
        {
            QLSinhVien kq = new QLSinhVien();
            for (int i = 0; i < this.soSV; i++)
            {
                if (this.dsSinhVien[i].LayTen.ToLower() == ten.ToLower())
                {
                    kq.Them(this.dsSinhVien[i]);
                }
            }
            return kq;
        }

        public QLSinhVien TimDSSVCoDTBMax()
        {
            QLSinhVien kq = new QLSinhVien();
            if (this.soSV == 0) return kq;

            float max = this.dsSinhVien[0].DiemTB;
            for (int i = 1; i < this.soSV; i++)
            {
                if (this.dsSinhVien[i].DiemTB > max)
                {
                    max = this.dsSinhVien[i].DiemTB;
                }
            }

            for (int i = 0; i < this.soSV; i++)
            {
                if (this.dsSinhVien[i].DiemTB == max)
                {
                    kq.Them(this.dsSinhVien[i]);
                }
            }
            return kq;
        }

        public QLSinhVien TimDSSVCoTenX(string x)
        {
            QLSinhVien kq = new QLSinhVien();
            for (int i = 0; i < this.soSV; i++)
            {
                if (this.dsSinhVien[i].HoTen.ToLower().Contains(x.ToLower()))
                {
                    kq.Them(this.dsSinhVien[i]);
                }
            }
            return kq;
        }

        public int ThongKeSVKhongDat()
        {
            int dem = 0;
            for (int i = 0; i < this.soSV; i++)
            {
                if (this.dsSinhVien[i].DiemTB < 5.5f)
                {
                    dem++;
                }
            }
            return dem;
        }

        public void SapXepTheoTen()
        {
            for (int i = 0; i < this.soSV - 1; i++)
            {
                for (int j = i + 1; j < this.soSV; j++)
                {
                    if (string.Compare(this.dsSinhVien[i].LayTen, this.dsSinhVien[j].LayTen, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        SinhVien temp = this.dsSinhVien[i];
                        this.dsSinhVien[i] = this.dsSinhVien[j];
                        this.dsSinhVien[j] = temp;
                    }
                }
            }
        }

        public void SapXepTheoChieuDaiHoTen()
        {
            for (int i = 0; i < this.soSV - 1; i++)
            {
                for (int j = i + 1; j < this.soSV; j++)
                {
                    if (this.dsSinhVien[i].HoTen.Length < this.dsSinhVien[j].HoTen.Length)
                    {
                        SinhVien temp = this.dsSinhVien[i];
                        this.dsSinhVien[i] = this.dsSinhVien[j];
                        this.dsSinhVien[j] = temp;
                    }
                }
            }
        }

        public void SapXepDSTheoDTB()
        {
            for (int i = 0; i < this.soSV - 1; i++)
            {
                for (int j = i + 1; j < this.soSV; j++)
                {
                    bool swap = false;
                    if (this.dsSinhVien[i].DiemTB < this.dsSinhVien[j].DiemTB)
                    {
                        swap = true;
                    }
                    else if (this.dsSinhVien[i].DiemTB == this.dsSinhVien[j].DiemTB)
                    {
                        if (string.Compare(this.dsSinhVien[i].LayHo, this.dsSinhVien[j].LayHo, StringComparison.OrdinalIgnoreCase) < 0)
                        {
                            swap = true;
                        }
                    }

                    if (swap)
                    {
                        SinhVien temp = this.dsSinhVien[i];
                        this.dsSinhVien[i] = this.dsSinhVien[j];
                        this.dsSinhVien[j] = temp;
                    }
                }
            }
        }

        public void ChenSV(SinhVien sv, string maSV)
        {
            if (this.soSV >= this.dsSinhVien.Length) return;

            int viTri = -1;
            for (int i = 0; i < this.soSV; i++)
            {
                if (this.dsSinhVien[i].MaSV == maSV)
                {
                    viTri = i;
                    break;
                }
            }

            if (viTri != -1)
            {
                for (int i = this.soSV; i > viTri + 1; i--)
                {
                    this.dsSinhVien[i] = this.dsSinhVien[i - 1];
                }
                this.dsSinhVien[viTri + 1] = sv;
                this.soSV++;
            }
        }

        #endregion
    }
}
