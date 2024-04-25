create database Quanlyquanan
go
use Quanlyquanan
go

--Đồ ăn 
-- Bàn
--Tài khoản   Nhân viên(lên hóa đơn , đặt món ăn ) || Quản lý( có những chức năng nhân viên , thêm được thống kê )
-- Danh sách list món ăn (menu)
--Hóa đơn
--Thông tin hóa đơn 
--thống kê hóa đơn


--Những công việc thao tác là 
--Nhập tài khoản được từ bàn phím
--Nhập được các thông tin bảng bất kì từ bàn phím và có thể xóa được thông tin theo mã
-- Tìm kiếm những thông tin theo mã ....
-- Làm giống btl SQL những mk sẽ thao tác trên CONSOLE của c#
-- Mọi người có thêm ý tưởng và làm được j mới thì bao h họp phổ biến thêm nha


Create table tblTaiKhoan
(	
	sTendangnhap nvarchar(50) primary key,
	sMatkhau nvarchar(1000),
	sChucvu nvarchar(50),  --Admin||Nhân Viên
	sCheckxoa bit default 0
)
alter table tblTaiKhoan add sSDT nvarchar(50)
alter table tblTaiKhoan add sTenhienthi nvarchar(50)
alter table tblTaiKhoan drop column sTenhienthi 
alter table tblTaiKhoan drop column sSDT 

alter table tblTaiKhoan add dNgaybatdau datetime
alter table tblTaiKhoan add sNam int
select * from tblTaiKhoan

create table tblBan
(
	sMaban nvarchar(20) primary key,
	sTrangthai nvarchar(50) ,   --Trống || Có người
	sCheckxoa bit default 0

)
go

create table tblHoadon
(
	sMahoadon nvarchar(20) primary key ,
	sTrangthai nvarchar(50),
	dThoigianvao datetime,
	dThoigianra datetime,
	iGiamgia int,
	fTongtien float,
	sMaban nvarchar(20),
	sCheckxoa bit default 0,
	sTendangnhap nvarchar(50),

	foreign key(sTendangnhap) references tblTaikhoan(sTendangnhap),
	foreign key(sMaban) references tblBan(sMaban)
)
go

create table tblMonan
(
	sMamon nvarchar(20) primary key,
	sTenmon nvarchar(50),
	iGiamon int ,
	sCheckxoa bit default 0


)
go

create table tblDatmon
(
	sMahoadon nvarchar(20),
	sMamon nvarchar(20) ,
	iSoluong int ,
	sCheckxoa bit default 0

	constraint sMahoadon_sMamon primary key(sMahoadon,sMamon),
	foreign key (sMahoadon) references tblHoadon(sMahoadon),
	foreign key (sMamon) references tblMonan(sMamon),

)
go







--Nhập dữ liệu



insert into tblTaiKhoan(sTendangnhap, sMatkhau, sChucvu) 
values	(N'Vũ Việt Trung',  '12345','Admin'),--1.Quản lý    0.Nhân viên
		(N'Nguyễn Thanh Hà', '12345','Admin'),
		(N'Trần Văn Khải','98765','Nhân viên'),
		(N'Hoàng Thị Thu','98765','Nhân viên'),
		(N'Phạm Ánh Tuyết','98765','Nhân viên'),
		(N'Tung', '1','Nhân viên'),
		(N'Hoang', '1','Admin');



		
insert into tblBan(sMaban,sTrangthai)
values (N'Bàn 1',N'Trống'),
       (N'Bàn 2', N'Trống'),
	   (N'Bàn 3', N'Có Người'),
	   (N'Bàn 4', N'Có Người'),
	   (N'Bàn 5', N'Trống')



insert into tblMonan(sMamon, sTenmon, iGiamon)
values (N'M1', N'Gà Kho ', 400 ),
       (N'M2', N'Vịt Quay', 100),
	   (N'M3', N'Lẩu', 120),
	   (N'M4', N'Cua Cà mau', 150),
	   (N'M5', N'Mực', 250)

insert into tblHoadon(sMahoadon, dThoigianvao, dThoigianra, sTrangthai,iGiamgia, fTongtien, sMaban, sTendangnhap)
values 
	   (N'HD1','2023-11-20 19:25:00','2023-11-20 20:12:29', N'Chưa thanh toán',10, 1100000,N'Bàn 3', N'Phạm Ánh Tuyết'),
	   (N'HD2','2023-11-28 18:50:01','2023-11-28 21:00:19', N'Chưa thanh toán',10, 900000,N'Bàn 4', N'Vũ Việt Trung'),
	   (N'HD3','2024-4-11 19:25:00','2024-4-11 19:25:00', N'Chưa thanh toán',10, 1600000,N'Bàn 3', N'Phạm Ánh Tuyết'),
	   (N'HD4','2024-4-14 19:25:00','2024-4-14 19:25:00', N'Chưa thanh toán',10, 500000,N'Bàn 4', N'Vũ Việt Trung'),
	   (N'HD5','2024-4-15 19:25:00','2024-4-15 19:25:00', N'Chưa thanh toán',10, 700000,N'Bàn 3', N'Phạm Ánh Tuyết'),
	   (N'HD6','2024-4-11 19:25:00','2024-4-11 19:25:00', N'Chưa thanh toán',10, 1000000,N'Bàn 4', N'Vũ Việt Trung')

insert into tblDatmon(sMahoadon, sMamon, iSoluong)
values (N'HD1', N'M1', 6),
       (N'HD2', N'M1', 2),	
	   (N'HD1', N'M3', 3),
	   (N'HD2', N'M5', 4),
	   (N'HD2', N'M4',2),
	   (N'HD1', N'M2', 3)


select * from tblNhacungcap

delete from tblDatmon
delete from tblHoadon
delete from tblMonan
delete from tblBan
delete from tblTaiKhoan


--DatMon
create proc sp_ChonBan
(@sMaban nvarchar(20))
as
begin
	select sMaban as[Mã bàn],sTrangthai as[Trạng thái] 
	from tblBan
	where sMaban=@sMaban and tblBan.sCheckxoa=0
end
go

select * from tblHoadon

create proc sp_Suatrangthaiban
(@sTrangthai nvarchar(50),@sMaban nvarchar(20))
as
begin
	update tblBan set sTrangthai=@sTrangthai where sMaban=@sMaban
end
go

--Lấy món
create proc sp_Laymon
(@sTenmon nvarchar(50))
as
begin 
	select * from tblMonan where sTenmon = @sTenmon and sCheckxoa=0
end
go

create proc sp_Laytaikhoan
(@sTendangnhap nvarchar(50))
as
begin
	select * from tblTaiKhoan where sTendangnhap = @sTendangnhap and sCheckxoa=0
end
go





--View hien


create view vw_HienTaikhoan2
as
select sTendangnhap as[Tên đăng nhập], sMatkhau as[Mật khẩu],dNgaybatdau as[Ngày bắt đầu],sNam[Năm], sChucvu as[Chức vụ]
from tblTaiKhoan where sCheckxoa=0
go


create view vw_HienTaikhoan
as
select sTendangnhap as[Tên đăng nhập], sMatkhau as[Mật khẩu], sChucvu as[Chức vụ]
from tblTaiKhoan where sCheckxoa=0
go

drop view vw_HienTaikhoan

create view vw_HienBan
as
select sMaban as[Mã bàn],sTrangthai as[Trạng thái] 
from tblBan
where  tblBan.sCheckxoa=0
go

select * from tblBan

drop view vw_HienBan

create view vw_HienHoadon
as
select sMahoadon as[Mã hóa đơn], dThoigianvao as[Thời gian vào] , dThoigianra as[Thời gian ra] , tblHoadon.sTrangthai as[Trạng thái thanh toán],iGiamgia as[Giảm giá theo %] , fTongtien as[Tổng tiền],tblBan.sMaban as[Bàn],tblTaiKhoan.sTendangnhap as[Tên đăng nhập]
from tblHoadon,tblBan,tblTaiKhoan 
where tblHoadon.sMaban= tblBan.sMaban and tblHoadon.sTendangnhap=tblTaiKhoan.sTendangnhap and tblHoadon.sCheckxoa=0
go

drop view vw_HienHoadon
go


/*
select * from tblBan

drop view vw_HienHoadon

*/
create view vw_HienMonan
as
select sTenmon as[Tên món], iGiamon as[Giá món]
from tblMonan where tblMonan.sCheckxoa=0
go

drop view vw_HienMonan

create proc sp_HienDatmon
(@sMahoadon nvarchar(20))
as
begin
	select tblMonan.sTenmon as[Tên món],iSoluong as[Số lượng],tblMonan.iGiamon as[Đơn giá món]
	from tblDatmon,tblHoadon,tblMonan
	where tblDatmon.sMahoadon=@sMahoadon and tblDatmon.sMahoadon=tblHoadon.sMahoadon and tblDatmon.sMamon=tblMonan.sMamon
	and tblDatmon.sCheckxoa=0
end
go
/*
drop proc sp_HienDatmon
*/
create proc sp_LayMonan
(@sTenmon nvarchar(50))
as
begin
	select * from tblMonan where sTenmon=@sTenmon and sCheckxoa=0
end

create proc sp_LayHoadon
(@sMaban nvarchar(20))
as
begin
select * from tblHoadon where sMaban=@sMaban and sTrangthai =N'Chưa thanh toán'
end

select * from tblHoadon where sMaban='Bàn 3' and sTrangthai =N'Chưa thanh toán'


create view vw_HienDatmon
as
select tblBan.sMaban as [Bàn],tblMonan.sTenmon as[Tên món],tblDatmon.iSoluong as[Số lượng món]
from tblDatmon,tblHoadon join tblBan on tblHoadon.sMaban=tblBan.sMaban,tblMonan 
where tblDatmon.sMamon= tblMonan.sMamon and tblDatmon.sMahoadon=tblHoadon.sMahoadon and tblDatmon.sCheckxoa=0
go
drop view vw_HienHoadon 
/*


*/
--Thủ tục đăng nhập

create proc sp_Dangnhap
(@sTendangnhap nvarchar(50) ,
	@sMatkhau nvarchar(1000))
as
begin
	select * from tblTaiKhoan where sTendangnhap=@sTendangnhap or sMatkhau=@sMatkhau and sCheckxoa=0
end
go



/*
drop proc sp_Dangnhap

create proc sp_Hienchucvu
(@sTendangnhap nvarchar(50))
as
begin
	select sChucvu from tblTaiKhoan where sTendangnhap =@sTendangnhap
end
go
*/

/*create proc sp_NhapTaikhoan1
(	@sTendangnhap nvarchar(50) ,
	@sMatkhau nvarchar(1000),
	@sSDT nvarchar(50),
	@sChucvu nvarchar(50))
as
begin
	insert into tblTaiKhoan(sTendangnhap, sMatkhau, sChucvu,sSDT) 
values(@sTendangnhap,@sMatkhau,@sChucvu,@sSDT)
end
go
*/

create proc sp_NhapTaikhoan2
(	@sTendangnhap nvarchar(50) ,
	@sMatkhau nvarchar(1000),
	@sChucvu nvarchar(50),
	@sNam int,
	@dNgaybatdau datetime)
as
begin
	insert into tblTaiKhoan(sTendangnhap, sMatkhau,dNgaybatdau,sNam, sChucvu) 
values(@sTendangnhap,@sMatkhau,@dNgaybatdau,@sNam,@sChucvu)
end
go



create proc sp_NhapTaikhoan
(	@sTendangnhap nvarchar(50) ,
	@sMatkhau nvarchar(1000),
	@sChucvu nvarchar(50))
as
begin
	insert into tblTaiKhoan(sTendangnhap, sMatkhau, sChucvu) 
values(@sTendangnhap,@sMatkhau,@sChucvu)
end
go


create proc sp_NhapBan
(	@sMaban nvarchar(20) ,
	@sTrangthai nvarchar(50) )   --Trống || Có người
as
begin
	
	insert into tblBan(sMaban, sTrangthai)
values(@sMaban  ,@sTrangthai)
end
go


create proc sp_ThemMonan
(@sMamon nvarchar(20),
	@sTenmon nvarchar(50),
	@iGiamon int)
as
begin
	insert into tblMonan(sMamon,sTenmon,iGiamon)
	values(@sMamon,@sTenmon,@iGiamon)
end
/*
*/
create proc sp_NhapHoadon
(@sMahoadon nvarchar(20),
	@dThoigianvao datetime ,
	@sTrangthai nvarchar(50),
	@sMaban nvarchar(20),
	@sTendangnhap nvarchar(50))

as
begin
	insert into tblHoadon(sMahoadon, dThoigianvao,sMaban,sTrangthai,sTendangnhap)
values (@sMahoadon,@dThoigianvao,@sMaban,@sTrangthai,@sTendangnhap)
end
go

drop proc sp_NhapHoadon

create proc sp_ThemDatmon
(@sMahoadon nvarchar(20),
	@sMamon nvarchar(20) ,
	@iSoluong int )
as
begin
insert into tblDatmon(sMahoadon, sMamon, iSoluong)
values (@sMahoadon ,@sMamon,@iSoluong)
end
go
/*
/*

--Thủ tục Sửa bảng
*/*/

create proc sp_SuaTaikhoan2
(	@sTendangnhap nvarchar(50) ,
	@sMatkhau nvarchar(1000),
	@sChucvu nvarchar(50),
	@sNam int,
	@dNgaybatdau datetime)
as
begin
	update tblTaiKhoan set sMatkhau=@sMatkhau,@dNgaybatdau=@dNgaybatdau,sNam=@sNam,sChucvu=@sChucvu where sTendangnhap = @sTendangnhap
end
go

create proc sp_SuaTaikhoan
(@sTendangnhap nvarchar(50) ,
	
	@sMatkhau nvarchar(1000),
	@sChucvu nvarchar(50))
as
begin
	update tblTaiKhoan set sMatkhau=@sMatkhau,sChucvu=@sChucvu where sTendangnhap = @sTendangnhap
end
go
/*

create proc sp_SuaBan
(	@sMaban nvarchar(20) ,
	@iSoluong int,
	@sTrangthai nvarchar(50) ,   --Trống || Có người
	@sTendangnhap nvarchar(50))
as
begin
	
	update tblBan set sTrangthai=@sTendangnhap,sTendangnhap=@sTendangnhap where sMaban=@sMaban
end
go
*/

create proc sp_SuaHoadon
(@sMahoadon nvarchar(20),
	@dThoigianra datetime ,
	@sTrangthai nvarchar(50),     --1.Đã thanh toán || 0. Chưa thanh toán
	@iGiamgia int,
	@fTongtien float ,
	@sTendangnhap nvarchar(50))
as
begin
	update tblHoadon set dThoigianra = @dThoigianra,sTrangthai=@sTrangthai,iGiamgia=@iGiamgia,fTongtien=@fTongtien,sTendangnhap=@sTendangnhap where sMahoadon=@sMahoadon
end
go

create proc sp_SuaMonan
(@sMamon nvarchar(20) ,
	@sTenmon nvarchar(50),
	@iGiamon int )
as
begin
	update tblMonan set sTenmon=@sTenmon,iGiamon=@iGiamon where sMamon=@sMamon
end
drop proc sp_SuaMonan
/*
drop proc sp_SuaHoadon
create proc sp_SuaMon
(@sMamon nvarchar(20),
	@sTenmon nvarchar(50),
	@iGiamon int ,
	@sTendangnhap nvarchar(50))
as
begin
	update tblMonan set sTenmon=@sTenmon,iGiamon=@iGiamon,sTendangnhap=@sTendangnhap where sMamon=@sMamon
end
go
*/
create proc sp_SuaDatmon
(@sMahoadon nvarchar(20),
	@sMamon nvarchar(20) ,
	@iSoluong int )
as
begin
	update tblDatmon set iSoluong=@iSoluong where sMahoadon=@sMahoadon and sMamon =@sMamon
end
go
/*
drop proc sp_SuaDatmon


--Thủ tục xóa dữ liệu
*/*/
create proc sp_XoaTaikhoan
(@sTendangnhap nvarchar(50),
@sCheckxoa bit)
as
begin
	update tblTaiKhoan set sCheckxoa = @sCheckxoa where sTendangnhap=@sTendangnhap;
end
go

select * from tblTaiKhoan

create proc sp_XoaBan
(@sMaban nvarchar(20),
@sCheckxoa bit)
as
begin
	update tblBan set sCheckxoa=@sCheckxoa where sMaban=@sMaban
end
go
/*
drop proc sp_XoaBan
go

create proc sp_XoaHoadon
(@sMahoadon nvarchar(20))
as
begin
	delete from tblHoadon where sMahoadon=@sMahoadon
end
go
*/
create proc sp_XoaMon
(@sMamon nvarchar(20))
as
begin
	update tblMonan set sCheckxoa=1 where sMamon=@sMamon
end
go

select * from tblMonan

/*
create proc sp_XoaDatmon
(@sMahoadon nvarchar(20),
	@sMamon nvarchar(20))
as
begin
	delete from tblDatmon where sMahoadon=@sMahoadon and sMamon=@sMamon
end
go
-- @sTendangnhap ='%'+t+'%'
*/
--thủ tục Tìm kiếm tương đối
create proc sp_TimTaikhoan
(@sTendangnhap nvarchar(50))
as
begin
	select @sTendangnhap = '%'+RTRIM(@sTendangnhap) +'%';
	select sTendangnhap as[Tên đăng nhập], sMatkhau as[Mật khẩu], sChucvu as[Chức vụ]
	from tblTaiKhoan where sTendangnhap like @sTendangnhap
end
go
/*
create proc sp_TimBan
(
	@iSoluongcho int)
as
begin
	select sMaban as[Mã bàn],iSoluongcho as[Số lương] ,sTrangthai as[Trạng thái]
	from tblBan,tblTaiKhoan
	where tblBan.sTendangnhap=tblTaiKhoan.sTendangnhap and iSoluongcho=@iSoluongcho
end
go
*/

create proc sp_TimMonan
(@sTenmon nvarchar(50))
as
begin
	select @sTenmon = '%'+RTRIM(@sTenmon)+'%';
	select sTenmon as[Tên món ăn], iGiamon as[Giá món]
	from tblMonan where tblMonan.sCheckxoa=0 and sTenmon like @sTenmon
end
drop proc sp_TimMonan
/*
drop proc sp_TimTaikhoan
select sTendangnhap,sMatkhau from tblTaiKhoan where sTendangnhap='Tung' and sMatkhau='1'

 select * from vw_HienDatmon
 drop view vw_HienDatmon
 select * from tblHoadon
 
 sMahoadon nvarchar(20) primary key ,
	sTrangthai nvarchar(50),
	dThoigianvao datetime,
	dThoigianra datetime,
	fTongtien float,
	sMaban nvarchar(20),
	sCheckxoa bit default 0,
	sTendangnhap nvarchar(50),
 */

 --Thống kê
create proc sp_Thongkehdtheongay
(@dThoigianvao datetime,
@dThoigianra datetime)
as
begin
	select sMahoadon as[Mã hóa đơn], dThoigianvao as[Thời gian vào] , dThoigianra as[Thời gian ra] , tblHoadon.sTrangthai as[Trạng thái thanh toán] , fTongtien as[Tổng tiền],tblBan.sMaban as[Bàn],tblTaiKhoan.sTendangnhap as[Tên đăng nhập]
from tblHoadon,tblBan,tblTaiKhoan 
where tblHoadon.sMaban= tblBan.sMaban and tblHoadon.sTendangnhap=tblTaiKhoan.sTendangnhap and tblHoadon.sCheckxoa=0 and dThoigianvao>@dThoigianvao and dThoigianra<@dThoigianra
end
go

create proc sp_Thongketheongayban
(@dThoigianvao datetime,
@dThoigianra datetime,
@sMaban nvarchar(20))
as
begin
	select sMahoadon as[Mã hóa đơn], dThoigianvao as[Thời gian vào] , dThoigianra as[Thời gian ra] , tblHoadon.sTrangthai as[Trạng thái thanh toán] , fTongtien as[Tổng tiền],tblBan.sMaban as[Bàn],tblTaiKhoan.sTendangnhap as[Tên đăng nhập]
from tblHoadon,tblBan,tblTaiKhoan 
where  tblBan.sMaban=tblHoadon.sMaban and tblHoadon.sTendangnhap=tblTaiKhoan.sTendangnhap 
and tblHoadon.sCheckxoa=0 and tblHoadon.sMaban=@sMaban and dThoigianvao>@dThoigianvao and dThoigianra<@dThoigianra
end
go

create proc sp_Thongkehoadontheotien
(@fTongtiensau float,
@fTongtientruoc float)
as
begin
	select sMahoadon as[Mã hóa đơn], dThoigianvao as[Thời gian vào] , dThoigianra as[Thời gian ra] , tblHoadon.sTrangthai as[Trạng thái thanh toán] , fTongtien as[Tổng tiền],tblBan.sMaban as[Bàn],tblTaiKhoan.sTendangnhap as[Tên đăng nhập]
from tblHoadon,tblBan,tblTaiKhoan 
where  tblBan.sMaban=tblHoadon.sMaban and tblHoadon.sTendangnhap=tblTaiKhoan.sTendangnhap 
and tblHoadon.sCheckxoa=0 and fTongtien>@fTongtientruoc and fTongtien<@fTongtiensau 
end
go

select sMahoadon as[Mã hóa đơn], dThoigianvao as[Thời gian vào] , dThoigianra as[Thời gian ra] , tblHoadon.sTrangthai as[Trạng thái thanh toán] , fTongtien as[Tổng tiền],tblBan.sMaban as[Bàn],tblTaiKhoan.sTendangnhap as[Tên đăng nhập]
from tblHoadon,tblBan,tblTaiKhoan 
where  tblBan.sMaban=tblHoadon.sMaban and tblHoadon.sTendangnhap=tblTaiKhoan.sTendangnhap 

select * from tblHoadon where YEAR(dThoigianra)=2024
/*
Create table tblTaiKhoan
(	
	sTendangnhap nvarchar(50) primary key,
	sMatkhau nvarchar(1000),
	sChucvu nvarchar(50),  --Admin||Nhân Viên
	sCheckxoa bit default 0
)

alter table tblTaiKhoan add sSDT nvarchar(50)
alter table tblTaiKhoan add sTenhienthi nvarchar(50)
alter table tblTaiKhoan drop column sTenhienthi 
alter table tblTaiKhoan drop column sSDT 

*/
create proc sp_Thongketaikhoan
(
	@sNamset int
)
as
begin
	select sTendangnhap as[Tên đăng nhập], sMatkhau as[Mật khẩu],dNgaybatdau as[Ngày bắt đầu],sNam[Năm], sChucvu as[Chức vụ]
from tblTaiKhoan where sCheckxoa=0 and sNam=@sNamset
end
drop proc sp_Thongketaikhoan
select* from tblHoadon

