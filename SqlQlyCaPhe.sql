CREATE TABLE [dbo].[tbl_CaLamViec](
	[PK_sMaCLV] [varchar](20) NOT NULL,
	[sTenCLV] [nvarchar](50) NOT NULL,
	[dGioBatDau] [datetime] NOT NULL,
	[dGioKetThuc] [datetime] NOT NULL,
	[fSoTien] [float] NOT NULL,
 CONSTRAINT [PK_tbl_CaLamViec] PRIMARY KEY CLUSTERED 
(
	[PK_sMaCLV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_CongThuc]    Script Date: 27/10/2024 02:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CongThuc](
	[PK_sMaCT] [varchar](20) NOT NULL,
	[FK_sMaSP] [varchar](20) NOT NULL,
	[FK_sMaNL] [varchar](20) NOT NULL,
	[fKhoiLuong] [float] NOT NULL,
 CONSTRAINT [PK_tbl_CongThuc] PRIMARY KEY CLUSTERED 
(
	[PK_sMaCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_HoaDon_SanPham]    Script Date: 27/10/2024 02:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_HoaDon_SanPham](
	[PK_sMaHDSP] [varchar](50) NOT NULL,
	[FK_sMaSP] [varchar](20) NOT NULL,
	[FK_sMaHD] [varchar](20) NOT NULL,
	[iSoLuong] [int] NOT NULL,
	[fDonGia] [float] NOT NULL,
	[fThanhTien] [float] NOT NULL,
 CONSTRAINT [PK_tbl_HoaDon_SanPham] PRIMARY KEY CLUSTERED 
(
	[PK_sMaHDSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_HoaDonBanHang]    Script Date: 27/10/2024 02:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_HoaDonBanHang](
	[FK_sMaKH] [varchar](20) NOT NULL,
	[PK_sMaHD] [varchar](20) NOT NULL,
	[dNgayXuatHD] [datetime] NOT NULL,
	[fTongTien] [float] NOT NULL,
	[fGiamGia] [float] NOT NULL,
	[fChiPhiKhac] [float] NULL,
	[iDiemTichLuy] [int] NOT NULL,
 CONSTRAINT [PK_tbl_HoaDonBanHang] PRIMARY KEY CLUSTERED 
(
	[PK_sMaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_KhachHang]    Script Date: 27/10/2024 02:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_KhachHang](
	[PK_sMaKH] [varchar](20) NOT NULL,
	[sTenKH] [nvarchar](50) NOT NULL,
	[sDiaChi] [nvarchar](50) NOT NULL,
	[sSDT] [char](12) NOT NULL,
	[iDiem] [int] NOT NULL,
 CONSTRAINT [PK_tbl_KhachHang] PRIMARY KEY CLUSTERED 
(
	[PK_sMaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_LoaiSanPham]    Script Date: 27/10/2024 02:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_LoaiSanPham](
	[PK_sMaLSP] [varchar](20) NOT NULL,
	[sTenLoaiSanPham] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[PK_sMaLSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_NguyenLieu]    Script Date: 27/10/2024 02:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NguyenLieu](
	[PK_sMaNL] [varchar](20) NOT NULL,
	[sTenNL] [nvarchar](50) NOT NULL,
	[sDonVi] [nvarchar](50) NOT NULL,
	[fConLai] [float] NOT NULL,
	[FK_sMaNCC] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tbl_NguyenLieu] PRIMARY KEY CLUSTERED 
(
	[PK_sMaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_NhaCungCap]    Script Date: 27/10/2024 02:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NhaCungCap](
	[PK_sMaNCC] [varchar](20) NOT NULL,
	[sTenNCC] [nvarchar](50) NOT NULL,
	[sDiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[PK_sMaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_NhanVien]    Script Date: 27/10/2024 02:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NhanVien](
	[PK_sMaNV] [varchar](20) NOT NULL,
	[sTenNV] [nvarchar](255) NOT NULL,
	[dNgaySinh] [date] NOT NULL,
	[sGioiTinh] [nvarchar](4) NOT NULL,
	[sCCCD] [varchar](12) NOT NULL,
	[sDiaChi] [nvarchar](MAX) NULL,
	[sSDT] [varchar](10) NULL,
	[sEmail] [varchar](255) NULL,
	[dNgayVaoLam] [date] NOT NULL,
	[fLuongcb] [double] NOT NULL,
	[sTinhTrang] [nvarchar](255) NULL,
 CONSTRAINT [PK_tbl_NhanVien] PRIMARY KEY CLUSTERED 
(
	[PK_sMaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Quyen]    Script Date: 27/10/2024 02:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Quyen](
	[PK_sMaquyen] [varchar](20) NOT NULL,
	[sTenQuyen] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Quyen] PRIMARY KEY CLUSTERED 
(
	[PK_sMaquyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_SanPham]    Script Date: 27/10/2024 02:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SanPham](
	[PK_sMaSP] [varchar](20) NOT NULL,
	[sTenSP] [nvarchar](50) NOT NULL,
	[FK_sMaNCC] [varchar](20) NOT NULL,
	[FK_sMaLSP] [varchar](20) NOT NULL,
	[iSoLuong] [int] NOT NULL,
	[sIMG] [varchar](500) NOT NULL,
	[fGiaSP] [float] NOT NULL,
 CONSTRAINT [PK_tbl_SanPham] PRIMARY KEY CLUSTERED 
(
	[PK_sMaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TaiKhoan]    Script Date: 27/10/2024 02:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TaiKhoan](
	[FK_sMaNV] [varchar](20) NOT NULL,
	[PK_sMaTK] [varchar](20) NOT NULL,
	[sTaiKhoan] [varchar](20) NOT NULL,
	[sMatKhau] [varchar](20) NOT NULL,
	[sTinhTrang] [nvarchar](20) NOT NULL,
	[FK_sMaquyen] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tbl_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[PK_sMaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_CongThuc] ([PK_sMaCT], [FK_sMaSP], [FK_sMaNL], [fKhoiLuong]) VALUES (N'CT20241024224739', N'2                   ', N'NL01                ', 100)
GO
INSERT [dbo].[tbl_CongThuc] ([PK_sMaCT], [FK_sMaSP], [FK_sMaNL], [fKhoiLuong]) VALUES (N'CT20241024224745', N'2                   ', N'NL03                ', 20)
GO
INSERT [dbo].[tbl_CongThuc] ([PK_sMaCT], [FK_sMaSP], [FK_sMaNL], [fKhoiLuong]) VALUES (N'CT20241024224750', N'2                   ', N'NL05                ', 10)
GO
INSERT [dbo].[tbl_HoaDon_SanPham] ([PK_sMaHDSP], [FK_sMaSP], [FK_sMaHD], [iSoLuong], [fDonGia], [fThanhTien]) VALUES (N'HD202410270140082   ', N'2                   ', N'HD20241027014008', 1, 25000, 25000)
GO
INSERT [dbo].[tbl_HoaDon_SanPham] ([PK_sMaHDSP], [FK_sMaSP], [FK_sMaHD], [iSoLuong], [fDonGia], [fThanhTien]) VALUES (N'HD202410270143162   ', N'2                   ', N'HD20241027014316', 3, 25000, 75000)
GO
INSERT [dbo].[tbl_HoaDon_SanPham] ([PK_sMaHDSP], [FK_sMaSP], [FK_sMaHD], [iSoLuong], [fDonGia], [fThanhTien]) VALUES (N'HD202410270214322                   ', N'2                   ', N'HD20241027021432', 2, 25000, 50000)
GO
INSERT [dbo].[tbl_HoaDon_SanPham] ([PK_sMaHDSP], [FK_sMaSP], [FK_sMaHD], [iSoLuong], [fDonGia], [fThanhTien]) VALUES (N'HD20241027021432SP00010101          ', N'SP00010101          ', N'HD20241027021432', 3, 22000, 66000)
GO
INSERT [dbo].[tbl_HoaDon_SanPham] ([PK_sMaHDSP], [FK_sMaSP], [FK_sMaHD], [iSoLuong], [fDonGia], [fThanhTien]) VALUES (N'HD20241027021432SP20241025234007', N'SP20241025234007', N'HD20241027021432', 1, 20000, 20000)
GO
INSERT [dbo].[tbl_HoaDonBanHang] ([FK_sMaKH], [PK_sMaHD], [dNgayXuatHD], [fTongTien], [fGiamGia], [fChiPhiKhac], [iDiemTichLuy]) VALUES (N'KH20241027014008', N'HD20241027014008', CAST(N'2024-10-27T01:40:08.507' AS DateTime), 25000, 0, 0, 250)
GO
INSERT [dbo].[tbl_HoaDonBanHang] ([FK_sMaKH], [PK_sMaHD], [dNgayXuatHD], [fTongTien], [fGiamGia], [fChiPhiKhac], [iDiemTichLuy]) VALUES (N'KH20241026205151', N'HD20241027014316', CAST(N'2024-10-27T01:43:16.463' AS DateTime), 75000, 0, 0, 750)
GO
INSERT [dbo].[tbl_HoaDonBanHang] ([FK_sMaKH], [PK_sMaHD], [dNgayXuatHD], [fTongTien], [fGiamGia], [fChiPhiKhac], [iDiemTichLuy]) VALUES (N'KH20241026205151', N'HD20241027021432', CAST(N'2024-10-27T02:14:32.730' AS DateTime), 136000, 0, 0, 1360)
GO
INSERT [dbo].[tbl_KhachHang] ([PK_sMaKH], [sTenKH], [sDiaChi], [sSDT], [iDiem]) VALUES (N'KH20241026205151', N'Xuân Điệp', N'129, Nguyễn Trãi, Thanh Xuân, Hà Nội', N'0962263806  ', 0)
GO
INSERT [dbo].[tbl_KhachHang] ([PK_sMaKH], [sTenKH], [sDiaChi], [sSDT], [iDiem]) VALUES (N'KH20241026225503', N'Hoàng Minh Thái', N'96 Định Công, Thanh Xuân, Hà Nội', N'0945811516  ', 0)
GO
INSERT [dbo].[tbl_KhachHang] ([PK_sMaKH], [sTenKH], [sDiaChi], [sSDT], [iDiem]) VALUES (N'KH20241027014008', N'Hoàng Minh', N'Thanh Xuân Hà Nội', N'0594568915  ', 0)
GO
INSERT [dbo].[tbl_LoaiSanPham] ([PK_sMaLSP], [sTenLoaiSanPham]) VALUES (N'LSP01               ', N'Đồ uống')
GO
INSERT [dbo].[tbl_LoaiSanPham] ([PK_sMaLSP], [sTenLoaiSanPham]) VALUES (N'LSP02               ', N'Đồ uống có cồn')
GO
INSERT [dbo].[tbl_LoaiSanPham] ([PK_sMaLSP], [sTenLoaiSanPham]) VALUES (N'LSP03               ', N'Bánh ngọt')
GO
INSERT [dbo].[tbl_LoaiSanPham] ([PK_sMaLSP], [sTenLoaiSanPham]) VALUES (N'LSP04               ', N'Bánh mặn')
GO
INSERT [dbo].[tbl_NguyenLieu] ([PK_sMaNL], [sTenNL], [sDonVi], [fConLai], [FK_sMaNCC]) VALUES (N'NL01                ', N'Sữa tươi', N'ml', 5000, N'NCC03               ')
GO
INSERT [dbo].[tbl_NguyenLieu] ([PK_sMaNL], [sTenNL], [sDonVi], [fConLai], [FK_sMaNCC]) VALUES (N'NL02                ', N'Bột cà phê', N'gam', 5000, N'NCC03               ')
GO
INSERT [dbo].[tbl_NguyenLieu] ([PK_sMaNL], [sTenNL], [sDonVi], [fConLai], [FK_sMaNCC]) VALUES (N'NL03                ', N'Bột sữa', N'gam', 5000, N'NCC03               ')
GO
INSERT [dbo].[tbl_NguyenLieu] ([PK_sMaNL], [sTenNL], [sDonVi], [fConLai], [FK_sMaNCC]) VALUES (N'NL04                ', N'Trà xanh', N'gam', 5000, N'NCC03               ')
GO
INSERT [dbo].[tbl_NguyenLieu] ([PK_sMaNL], [sTenNL], [sDonVi], [fConLai], [FK_sMaNCC]) VALUES (N'NL05                ', N'Hồng trà', N'gam', 5000, N'NCC03               ')
GO
INSERT [dbo].[tbl_NguyenLieu] ([PK_sMaNL], [sTenNL], [sDonVi], [fConLai], [FK_sMaNCC]) VALUES (N'NL06                ', N'Đường', N'gam', 10000, N'NCC03               ')
GO
INSERT [dbo].[tbl_NhaCungCap] ([PK_sMaNCC], [sTenNCC], [sDiaChi]) VALUES (N'NCC01               ', N'Tiệm cà phê Cateen', N'129 Nguyễn Trãi')
GO
INSERT [dbo].[tbl_NhaCungCap] ([PK_sMaNCC], [sTenNCC], [sDiaChi]) VALUES (N'NCC02               ', N'Bánh Ngọt Mỹ Hạnh', N'159 Nguyễn Tuân')
GO
INSERT [dbo].[tbl_NhaCungCap] ([PK_sMaNCC], [sTenNCC], [sDiaChi]) VALUES (N'NCC03               ', N'Nguyên liệu pha chế Hoàng Minh', N'559 Đường Láng')
GO
INSERT [dbo].[tbl_SanPham] ([PK_sMaSP], [sTenSP], [FK_sMaNCC], [FK_sMaLSP], [iSoLuong], [sIMG], [fGiaSP]) VALUES (N'2                   ', N'Trà sữa', N'NCC01               ', N'LSP01               ', 10, N'uploads\traSua.jpg', 25000)
GO
INSERT [dbo].[tbl_SanPham] ([PK_sMaSP], [sTenSP], [FK_sMaNCC], [FK_sMaLSP], [iSoLuong], [sIMG], [fGiaSP]) VALUES (N'SP00010101          ', N'Bánh socala sữa dừa', N'NCC01               ', N'LSP01               ', 6, N'uploads\anhBanhSocola.png', 22000)
GO
INSERT [dbo].[tbl_SanPham] ([PK_sMaSP], [sTenSP], [FK_sMaNCC], [FK_sMaLSP], [iSoLuong], [sIMG], [fGiaSP]) VALUES (N'SP20241021          ', N'Latte', N'NCC01               ', N'LSP01               ', 8, N'uploads\latte.jpg', 25000)
GO
INSERT [dbo].[tbl_SanPham] ([PK_sMaSP], [sTenSP], [FK_sMaNCC], [FK_sMaLSP], [iSoLuong], [sIMG], [fGiaSP]) VALUES (N'SP20241025230116', N'Cà phê đen', N'NCC01               ', N'LSP01               ', 12, N'uploads\capheden.jpg', 15000)
GO
INSERT [dbo].[tbl_SanPham] ([PK_sMaSP], [sTenSP], [FK_sMaNCC], [FK_sMaLSP], [iSoLuong], [sIMG], [fGiaSP]) VALUES (N'SP20241025234007', N'Cà phê sữa', N'NCC01               ', N'LSP01               ', 12, N'uploads\caphe-sua.jpg', 20000)
GO
ALTER TABLE [dbo].[tbl_CongThuc]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CongThuc_tbl_NguyenLieu] FOREIGN KEY([FK_sMaNL])
REFERENCES [dbo].[tbl_NguyenLieu] ([PK_sMaNL])
GO
ALTER TABLE [dbo].[tbl_CongThuc] CHECK CONSTRAINT [FK_tbl_CongThuc_tbl_NguyenLieu]
GO
ALTER TABLE [dbo].[tbl_CongThuc]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CongThuc_tbl_SanPham] FOREIGN KEY([FK_sMaSP])
REFERENCES [dbo].[tbl_SanPham] ([PK_sMaSP])
GO
ALTER TABLE [dbo].[tbl_CongThuc] CHECK CONSTRAINT [FK_tbl_CongThuc_tbl_SanPham]
GO
ALTER TABLE [dbo].[tbl_HoaDon_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_tbl_HoaDon_SanPham_tbl_HoaDonBanHang] FOREIGN KEY([FK_sMaHD])
REFERENCES [dbo].[tbl_HoaDonBanHang] ([PK_sMaHD])
GO
ALTER TABLE [dbo].[tbl_HoaDon_SanPham] CHECK CONSTRAINT [FK_tbl_HoaDon_SanPham_tbl_HoaDonBanHang]
GO
ALTER TABLE [dbo].[tbl_HoaDon_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_tbl_HoaDon_SanPham_tbl_SanPham] FOREIGN KEY([FK_sMaSP])
REFERENCES [dbo].[tbl_SanPham] ([PK_sMaSP])
GO
ALTER TABLE [dbo].[tbl_HoaDon_SanPham] CHECK CONSTRAINT [FK_tbl_HoaDon_SanPham_tbl_SanPham]
GO
ALTER TABLE [dbo].[tbl_HoaDonBanHang]  WITH CHECK ADD  CONSTRAINT [FK_tbl_HoaDonBanHang_tbl_KhachHang] FOREIGN KEY([FK_sMaKH])
REFERENCES [dbo].[tbl_KhachHang] ([PK_sMaKH])
GO
ALTER TABLE [dbo].[tbl_HoaDonBanHang] CHECK CONSTRAINT [FK_tbl_HoaDonBanHang_tbl_KhachHang]
GO
ALTER TABLE [dbo].[tbl_NguyenLieu]  WITH CHECK ADD  CONSTRAINT [FK_tbl_NguyenLieu_tbl_NhaCungCap] FOREIGN KEY([FK_sMaNCC])
REFERENCES [dbo].[tbl_NhaCungCap] ([PK_sMaNCC])
GO
ALTER TABLE [dbo].[tbl_NguyenLieu] CHECK CONSTRAINT [FK_tbl_NguyenLieu_tbl_NhaCungCap]
GO
ALTER TABLE [dbo].[tbl_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SanPham_tbl_LoaiSanPham] FOREIGN KEY([FK_sMaLSP])
REFERENCES [dbo].[tbl_LoaiSanPham] ([PK_sMaLSP])
GO
ALTER TABLE [dbo].[tbl_SanPham] CHECK CONSTRAINT [FK_tbl_SanPham_tbl_LoaiSanPham]
GO
ALTER TABLE [dbo].[tbl_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_tbl_SanPham_tbl_NCC] FOREIGN KEY([FK_sMaNCC])
REFERENCES [dbo].[tbl_NhaCungCap] ([PK_sMaNCC])
GO
ALTER TABLE [dbo].[tbl_SanPham] CHECK CONSTRAINT [FK_tbl_SanPham_tbl_NCC]
GO
ALTER TABLE [dbo].[tbl_TaiKhoan]  WITH NOCHECK ADD  CONSTRAINT [FK_tbl_TaiKhoan_tbl_NhanVien] FOREIGN KEY([FK_sMaNV])
REFERENCES [dbo].[tbl_NhanVien] ([PK_sMaNV])
GO
ALTER TABLE [dbo].[tbl_TaiKhoan] CHECK CONSTRAINT [FK_tbl_TaiKhoan_tbl_NhanVien]
GO
ALTER TABLE [dbo].[tbl_TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TaiKhoan_tbl_Quyen] FOREIGN KEY([FK_sMaquyen])
REFERENCES [dbo].[tbl_Quyen] ([PK_sMaquyen])
GO
ALTER TABLE [dbo].[tbl_TaiKhoan] CHECK CONSTRAINT [FK_tbl_TaiKhoan_tbl_Quyen]
GO
USE [master]
GO
ALTER DATABASE [QLySanPham] SET  READ_WRITE 
GO
