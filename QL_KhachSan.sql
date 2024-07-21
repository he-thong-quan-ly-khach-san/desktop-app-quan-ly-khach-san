USE master
CREATE DATABASE QL_KHACHSAN
GO
USE QL_KHACHSAN
GO
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DATPHONG') and o.name = 'FK_DATPHONG_RELATIONS_SANPHAM')
alter table DATPHONG
   drop constraint FK_DATPHONG_RELATIONS_SANPHAM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DATPHONG') and o.name = 'FK_DATPHONG_RELATIONS_PHONG')
alter table DATPHONG
   drop constraint FK_DATPHONG_RELATIONS_PHONG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DATPHONG') and o.name = 'FK_DATPHONG_RELATIONS_KHACHHAN')
alter table DATPHONG
   drop constraint FK_DATPHONG_RELATIONS_KHACHHAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DATPHONG') and o.name = 'FK_DATPHONG_RELATIONS_QL_NGUOI')
alter table DATPHONG
   drop constraint FK_DATPHONG_RELATIONS_QL_NGUOI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHONG') and o.name = 'FK_PHONG_RELATIONS_TANG')
alter table PHONG
   drop constraint FK_PHONG_RELATIONS_TANG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PHONG') and o.name = 'FK_PHONG_RELATIONS_LOAIPHON')
alter table PHONG
   drop constraint FK_PHONG_RELATIONS_LOAIPHON
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QL_NGUOIDUNG_NHOMNGUOIDUNG') and o.name = 'FK_QL_NGUOI_RELATIONS_QL_NGUOI')
alter table QL_NGUOIDUNG_NHOMNGUOIDUNG
   drop constraint FK_QL_NGUOI_RELATIONS_QL_NGUOI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QL_NGUOIDUNG_NHOMNGUOIDUNG') and o.name = 'FK_QL_NGUOI_RELATIONS_QL_NHOMN')
alter table QL_NGUOIDUNG_NHOMNGUOIDUNG
   drop constraint FK_QL_NGUOI_RELATIONS_QL_NHOMN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QL_PHANQUYEN') and o.name = 'FK_QL_PHANQ_REFERENCE_DM_MANHI')
alter table QL_PHANQUYEN
   drop constraint FK_QL_PHANQ_REFERENCE_DM_MANHI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('QL_PHANQUYEN') and o.name = 'FK_QL_PHANQ_REFERENCE_QL_NHOMN')
alter table QL_PHANQUYEN
   drop constraint FK_QL_PHANQ_REFERENCE_QL_NHOMN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('THIETBI_PHONG') and o.name = 'FK_THIETBI__RELATIONS_THIETBI')
alter table THIETBI_PHONG
   drop constraint FK_THIETBI__RELATIONS_THIETBI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('THIETBI_PHONG') and o.name = 'FK_THIETBI__RELATIONS_PHONG')
alter table THIETBI_PHONG
   drop constraint FK_THIETBI__RELATIONS_PHONG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DATPHONG')
            and   name  = 'RELATIONSHIP_12_FK'
            and   indid > 0
            and   indid < 255)
   drop index DATPHONG.RELATIONSHIP_12_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DATPHONG')
            and   name  = 'RELATIONSHIP_4_FK'
            and   indid > 0
            and   indid < 255)
   drop index DATPHONG.RELATIONSHIP_4_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DATPHONG')
            and   name  = 'RELATIONSHIP_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index DATPHONG.RELATIONSHIP_3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DATPHONG')
            and   name  = 'RELATIONSHIP_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index DATPHONG.RELATIONSHIP_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DATPHONG')
            and   type = 'U')
   drop table DATPHONG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DM_MANHINH')
            and   type = 'U')
   drop table DM_MANHINH
go

if exists (select 1
            from  sysobjects
           where  id = object_id('KHACHHANG')
            and   type = 'U')
   drop table KHACHHANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LOAIPHONG')
            and   type = 'U')
   drop table LOAIPHONG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHONG')
            and   name  = 'RELATIONSHIP_7_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHONG.RELATIONSHIP_7_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PHONG')
            and   name  = 'RELATIONSHIP_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index PHONG.RELATIONSHIP_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PHONG')
            and   type = 'U')
   drop table PHONG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QL_NGUOIDUNG')
            and   type = 'U')
   drop table QL_NGUOIDUNG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QL_NGUOIDUNG_NHOMNGUOIDUNG')
            and   name  = 'RELATIONSHIP_9_FK'
            and   indid > 0
            and   indid < 255)
   drop index QL_NGUOIDUNG_NHOMNGUOIDUNG.RELATIONSHIP_9_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('QL_NGUOIDUNG_NHOMNGUOIDUNG')
            and   name  = 'RELATIONSHIP_8_FK'
            and   indid > 0
            and   indid < 255)
   drop index QL_NGUOIDUNG_NHOMNGUOIDUNG.RELATIONSHIP_8_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QL_NGUOIDUNG_NHOMNGUOIDUNG')
            and   type = 'U')
   drop table QL_NGUOIDUNG_NHOMNGUOIDUNG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QL_NHOMNGUOIDUNG')
            and   type = 'U')
   drop table QL_NHOMNGUOIDUNG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('QL_PHANQUYEN')
            and   type = 'U')
   drop table QL_PHANQUYEN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SANPHAM')
            and   type = 'U')
   drop table SANPHAM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TANG')
            and   type = 'U')
   drop table TANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('THIETBI')
            and   type = 'U')
   drop table THIETBI
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('THIETBI_PHONG')
            and   name  = 'RELATIONSHIP_6_FK'
            and   indid > 0
            and   indid < 255)
   drop index THIETBI_PHONG.RELATIONSHIP_6_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('THIETBI_PHONG')
            and   name  = 'RELATIONSHIP_5_FK'
            and   indid > 0
            and   indid < 255)
   drop index THIETBI_PHONG.RELATIONSHIP_5_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('THIETBI_PHONG')
            and   type = 'U')
   drop table THIETBI_PHONG
go

/*==============================================================*/
/* Table: DATPHONG                                              */
/*==============================================================*/
create table DATPHONG (
   MADATPHONG           char(10)             not null,
   TENDANGNHAP          varchar(40)          null,
   MAPHONG              char(5)              null,
   MASP                 char(5)              null,
   MAKH                 char(10)             null,
   NGAYDAT              datetime             null,
   NGAYTRA              datetime             null,
   SONGAYO              smallint             null,
   constraint PK_DATPHONG primary key nonclustered (MADATPHONG)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_2_FK on DATPHONG (
MAPHONG ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_3_FK on DATPHONG (
MAKH ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_4_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_4_FK on DATPHONG (
TENDANGNHAP ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_12_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_12_FK on DATPHONG (
MASP ASC
)
go

/*==============================================================*/
/* Table: DM_MANHINH                                            */
/*==============================================================*/
create table DM_MANHINH (
   MAMH                 char(5)              not null,
   TENMH                nvarchar(100)        null,
   constraint PK_DM_MANHINH primary key nonclustered (MAMH)
)
go

/*==============================================================*/
/* Table: KHACHHANG                                             */
/*==============================================================*/
create table KHACHHANG (
   MAKH                 char(10)             not null,
   HOTENKH              nvarchar(50)         null,
   CCCD                 varchar(12)          null,
   DIENTHOAI            varchar(12)          null,
   EMAIL                varchar(100)         null,
   DIACHI               nvarchar(200)        null,
   constraint PK_KHACHHANG primary key nonclustered (MAKH)
)
go

/*==============================================================*/
/* Table: LOAIPHONG                                             */
/*==============================================================*/
create table LOAIPHONG (
   MALOAIPHONG          char(5)              not null,
   TENLOAIPHONG         nvarchar(100)        null,
   DONGIA               money                null,
   SONGUOI              smallint             null,
   SOGIUONG             smallint             null,
   constraint PK_LOAIPHONG primary key nonclustered (MALOAIPHONG)
)
go

/*==============================================================*/
/* Table: PHONG                                                 */
/*==============================================================*/
create table PHONG (
   MAPHONG              char(5)              not null,
   MALOAIPHONG          char(5)              null,
   MATANG               char(3)              null,
   TENPHONG             nvarchar(15)         null,
   HOATDONG             bit                  null,
   constraint PK_PHONG primary key nonclustered (MAPHONG)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_1_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_1_FK on PHONG (
MATANG ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_7_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_7_FK on PHONG (
MALOAIPHONG ASC
)
go

/*==============================================================*/
/* Table: QL_NGUOIDUNG                                          */
/*==============================================================*/
create table QL_NGUOIDUNG (
   TENDANGNHAP          varchar(40)          not null,
   MATKHAU              varchar(40)          null,
   HOATDONG             bit                  null,
   constraint PK_QL_NGUOIDUNG primary key nonclustered (TENDANGNHAP)
)
go

/*==============================================================*/
/* Table: QL_NGUOIDUNG_NHOMNGUOIDUNG                            */
/*==============================================================*/
create table QL_NGUOIDUNG_NHOMNGUOIDUNG (
   MANHOMND             char(5)              not null,
   TENDANGNHAP          varchar(40)          not null,
   GHICHU               nvarchar(100)        null,
   constraint PK_QL_NGUOIDUNG_NHOMNGUOIDUNG primary key (MANHOMND, TENDANGNHAP)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_8_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_8_FK on QL_NGUOIDUNG_NHOMNGUOIDUNG (
TENDANGNHAP ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_9_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_9_FK on QL_NGUOIDUNG_NHOMNGUOIDUNG (
MANHOMND ASC
)
go

/*==============================================================*/
/* Table: QL_NHOMNGUOIDUNG                                      */
/*==============================================================*/
create table QL_NHOMNGUOIDUNG (
   MANHOMND             char(5)              not null,
   TENNHOMND            varchar(30)          null,
   GHICHU               varchar(200)         null,
   constraint PK_QL_NHOMNGUOIDUNG primary key nonclustered (MANHOMND)
)
go

/*==============================================================*/
/* Table: QL_PHANQUYEN                                          */
/*==============================================================*/
create table QL_PHANQUYEN (
   MAMH                 char(5)              not null,
   MANHOMND             char(5)              not null,
   COQUYEN              bit                  null,
   constraint PK_QL_PHANQUYEN primary key nonclustered (MAMH, MANHOMND)
)
go

/*==============================================================*/
/* Table: SANPHAM                                               */
/*==============================================================*/
create table SANPHAM (
   MASP                 char(5)              not null,
   TENSP                nvarchar(100)        null,
   constraint PK_SANPHAM primary key nonclustered (MASP)
)
go

/*==============================================================*/
/* Table: TANG                                                  */
/*==============================================================*/
create table TANG (
   MATANG               char(3)              not null,
   TENTANG              nvarchar(50)         null,
   constraint PK_TANG primary key nonclustered (MATANG)
)
go

/*==============================================================*/
/* Table: THIETBI                                               */
/*==============================================================*/
create table THIETBI (
   MATHIETBI            char(5)              not null,
   TENTHIETBI           nvarchar(100)        null,
   DONGIA               money                null,
   constraint PK_THIETBI primary key nonclustered (MATHIETBI)
)
go

/*==============================================================*/
/* Table: THIETBI_PHONG                                         */
/*==============================================================*/
create table THIETBI_PHONG (
   MATHIETBI            char(5)              null,
   MAPHONG              char(5)              null,
   SOLUONG              smallint             null
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_5_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_5_FK on THIETBI_PHONG (
MATHIETBI ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_6_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_6_FK on THIETBI_PHONG (
MAPHONG ASC
)
go

alter table DATPHONG
   add constraint FK_DATPHONG_RELATIONS_SANPHAM foreign key (MASP)
      references SANPHAM (MASP)
go

alter table DATPHONG
   add constraint FK_DATPHONG_RELATIONS_PHONG foreign key (MAPHONG)
      references PHONG (MAPHONG)
go

alter table DATPHONG
   add constraint FK_DATPHONG_RELATIONS_KHACHHAN foreign key (MAKH)
      references KHACHHANG (MAKH)
go

alter table DATPHONG
   add constraint FK_DATPHONG_RELATIONS_QL_NGUOI foreign key (TENDANGNHAP)
      references QL_NGUOIDUNG (TENDANGNHAP)
go

alter table PHONG
   add constraint FK_PHONG_RELATIONS_TANG foreign key (MATANG)
      references TANG (MATANG)
go

alter table PHONG
   add constraint FK_PHONG_RELATIONS_LOAIPHON foreign key (MALOAIPHONG)
      references LOAIPHONG (MALOAIPHONG)
go

alter table QL_NGUOIDUNG_NHOMNGUOIDUNG
   add constraint FK_QL_NGUOI_RELATIONS_QL_NGUOI foreign key (TENDANGNHAP)
      references QL_NGUOIDUNG (TENDANGNHAP)
go

alter table QL_NGUOIDUNG_NHOMNGUOIDUNG
   add constraint FK_QL_NGUOI_RELATIONS_QL_NHOMN foreign key (MANHOMND)
      references QL_NHOMNGUOIDUNG (MANHOMND)
go

alter table QL_PHANQUYEN
   add constraint FK_QL_PHANQ_REFERENCE_DM_MANHI foreign key (MAMH)
      references DM_MANHINH (MAMH)
go

alter table QL_PHANQUYEN
   add constraint FK_QL_PHANQ_REFERENCE_QL_NHOMN foreign key (MANHOMND)
      references QL_NHOMNGUOIDUNG (MANHOMND)
go

alter table THIETBI_PHONG
   add constraint FK_THIETBI__RELATIONS_THIETBI foreign key (MATHIETBI)
      references THIETBI (MATHIETBI)
go

alter table THIETBI_PHONG
   add constraint FK_THIETBI__RELATIONS_PHONG foreign key (MAPHONG)
      references PHONG (MAPHONG)
go
