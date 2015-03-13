/*==============================================================*/
/* DBMS name:      Sybase SQL Anywhere 11                       */
/* Created on:     2/10/2015 9:58:01 AM                         */
/*==============================================================*/


if exists(select 1 from sys.sysforeignkey where role='FK_NGUOICHO_NGUOICHOI_PHONGCHO') then
    alter table NGUOICHOI_PHONGCHOI
       delete foreign key FK_NGUOICHO_NGUOICHOI_PHONGCHO
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_NGUOICHO_NGUOICHOI_NGUOICHO') then
    alter table NGUOICHOI_PHONGCHOI
       delete foreign key FK_NGUOICHO_NGUOICHOI_NGUOICHO
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PHONGCHO_MUCDO_PHO_MUCDO') then
    alter table PHONGCHOI
       delete foreign key FK_PHONGCHO_MUCDO_PHO_MUCDO
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_THANHTIC_THANHTICH_MUCDO') then
    alter table THANHTICH
       delete foreign key FK_THANHTIC_THANHTICH_MUCDO
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_THANHTIC_THANHTICH_NGUOICHO') then
    alter table THANHTICH
       delete foreign key FK_THANHTIC_THANHTICH_NGUOICHO
end if;

if exists(
   select 1 from sys.sysindex i, sys.systable t
   where i.table_id=t.table_id 
     and i.index_name='MUCDO_PK'
     and t.table_name='MUCDO'
) then
   drop index MUCDO.MUCDO_PK
end if;

if exists(
   select 1 from sys.systable 
   where table_name='MUCDO'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table MUCDO
end if;

if exists(
   select 1 from sys.sysindex i, sys.systable t
   where i.table_id=t.table_id 
     and i.index_name='NGUOICHOI_PK'
     and t.table_name='NGUOICHOI'
) then
   drop index NGUOICHOI.NGUOICHOI_PK
end if;

if exists(
   select 1 from sys.systable 
   where table_name='NGUOICHOI'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table NGUOICHOI
end if;

if exists(
   select 1 from sys.sysindex i, sys.systable t
   where i.table_id=t.table_id 
     and i.index_name='NGUOICHOI_PHONGCHOI2_FK'
     and t.table_name='NGUOICHOI_PHONGCHOI'
) then
   drop index NGUOICHOI_PHONGCHOI.NGUOICHOI_PHONGCHOI2_FK
end if;

if exists(
   select 1 from sys.sysindex i, sys.systable t
   where i.table_id=t.table_id 
     and i.index_name='NGUOICHOI_PHONGCHOI_FK'
     and t.table_name='NGUOICHOI_PHONGCHOI'
) then
   drop index NGUOICHOI_PHONGCHOI.NGUOICHOI_PHONGCHOI_FK
end if;

if exists(
   select 1 from sys.sysindex i, sys.systable t
   where i.table_id=t.table_id 
     and i.index_name='NGUOICHOI_PHONGCHOI_PK'
     and t.table_name='NGUOICHOI_PHONGCHOI'
) then
   drop index NGUOICHOI_PHONGCHOI.NGUOICHOI_PHONGCHOI_PK
end if;

if exists(
   select 1 from sys.systable 
   where table_name='NGUOICHOI_PHONGCHOI'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table NGUOICHOI_PHONGCHOI
end if;

if exists(
   select 1 from sys.sysindex i, sys.systable t
   where i.table_id=t.table_id 
     and i.index_name='MUCDO_PHONGCHOI_FK'
     and t.table_name='PHONGCHOI'
) then
   drop index PHONGCHOI.MUCDO_PHONGCHOI_FK
end if;

if exists(
   select 1 from sys.sysindex i, sys.systable t
   where i.table_id=t.table_id 
     and i.index_name='PHONGCHOI_PK'
     and t.table_name='PHONGCHOI'
) then
   drop index PHONGCHOI.PHONGCHOI_PK
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PHONGCHOI'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PHONGCHOI
end if;

if exists(
   select 1 from sys.sysindex i, sys.systable t
   where i.table_id=t.table_id 
     and i.index_name='THANHTICH_MUCDO_FK'
     and t.table_name='THANHTICH'
) then
   drop index THANHTICH.THANHTICH_MUCDO_FK
end if;

if exists(
   select 1 from sys.sysindex i, sys.systable t
   where i.table_id=t.table_id 
     and i.index_name='THANHTICH_NGUOICHOI_FK'
     and t.table_name='THANHTICH'
) then
   drop index THANHTICH.THANHTICH_NGUOICHOI_FK
end if;

if exists(
   select 1 from sys.sysindex i, sys.systable t
   where i.table_id=t.table_id 
     and i.index_name='THANHTICH_PK'
     and t.table_name='THANHTICH'
) then
   drop index THANHTICH.THANHTICH_PK
end if;

if exists(
   select 1 from sys.systable 
   where table_name='THANHTICH'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table THANHTICH
end if;

/*==============================================================*/
/* Table: MUCDO                                                 */
/*==============================================================*/
create table MUCDO 
(
   SODIA                smallint                       not null,
   constraint PK_MUCDO primary key (SODIA)
);

/*==============================================================*/
/* Index: MUCDO_PK                                              */
/*==============================================================*/
create unique index MUCDO_PK on MUCDO (
SODIA ASC
);

/*==============================================================*/
/* Table: NGUOICHOI                                             */
/*==============================================================*/
create table NGUOICHOI 
(
   TAIKHOAN             char(15)                       not null,
   MATKHAU              char(30)                       null,
   constraint PK_NGUOICHOI primary key (TAIKHOAN)
);

/*==============================================================*/
/* Index: NGUOICHOI_PK                                          */
/*==============================================================*/
create unique index NGUOICHOI_PK on NGUOICHOI (
TAIKHOAN ASC
);

/*==============================================================*/
/* Table: NGUOICHOI_PHONGCHOI                                   */
/*==============================================================*/
create table NGUOICHOI_PHONGCHOI 
(
   MAPHONG              smallint                       not null,
   TAIKHOAN             char(15)                       not null,
   constraint PK_NGUOICHOI_PHONGCHOI primary key clustered (MAPHONG, TAIKHOAN)
);

/*==============================================================*/
/* Index: NGUOICHOI_PHONGCHOI_PK                                */
/*==============================================================*/
create unique clustered index NGUOICHOI_PHONGCHOI_PK on NGUOICHOI_PHONGCHOI (
MAPHONG ASC,
TAIKHOAN ASC
);

/*==============================================================*/
/* Index: NGUOICHOI_PHONGCHOI_FK                                */
/*==============================================================*/
create index NGUOICHOI_PHONGCHOI_FK on NGUOICHOI_PHONGCHOI (
MAPHONG ASC
);

/*==============================================================*/
/* Index: NGUOICHOI_PHONGCHOI2_FK                               */
/*==============================================================*/
create index NGUOICHOI_PHONGCHOI2_FK on NGUOICHOI_PHONGCHOI (
TAIKHOAN ASC
);

/*==============================================================*/
/* Table: PHONGCHOI                                             */
/*==============================================================*/
create table PHONGCHOI 
(
   MAPHONG              smallint                       not null,
   SODIA                smallint                       not null,
   TENPHONG             varchar(50)                    null,
   SOLUONG              smallint                       null,
   TINHTRANG            char(30)                       null,
   MATKHAU              char(30)                       null,
   NGUOITHANG           varchar(50)                    null,
   constraint PK_PHONGCHOI primary key (MAPHONG)
);

/*==============================================================*/
/* Index: PHONGCHOI_PK                                          */
/*==============================================================*/
create unique index PHONGCHOI_PK on PHONGCHOI (
MAPHONG ASC
);

/*==============================================================*/
/* Index: MUCDO_PHONGCHOI_FK                                    */
/*==============================================================*/
create index MUCDO_PHONGCHOI_FK on PHONGCHOI (
SODIA ASC
);

/*==============================================================*/
/* Table: THANHTICH                                             */
/*==============================================================*/
create table THANHTICH 
(
   TAIKHOAN             char(15)                       not null,
   SODIA                smallint                       not null,
   THOIGIAN             time                           null,
   SOBUOCCHUYEN         numeric(5)                     null,
   constraint PK_THANHTICH primary key clustered (TAIKHOAN, SODIA)
);

/*==============================================================*/
/* Index: THANHTICH_PK                                          */
/*==============================================================*/
create unique clustered index THANHTICH_PK on THANHTICH (
TAIKHOAN ASC,
SODIA ASC
);

/*==============================================================*/
/* Index: THANHTICH_NGUOICHOI_FK                                */
/*==============================================================*/
create index THANHTICH_NGUOICHOI_FK on THANHTICH (
TAIKHOAN ASC
);

/*==============================================================*/
/* Index: THANHTICH_MUCDO_FK                                    */
/*==============================================================*/
create index THANHTICH_MUCDO_FK on THANHTICH (
SODIA ASC
);

alter table NGUOICHOI_PHONGCHOI
   add constraint FK_NGUOICHO_NGUOICHOI_PHONGCHO foreign key (MAPHONG)
      references PHONGCHOI (MAPHONG)
      on update restrict
      on delete restrict;

alter table NGUOICHOI_PHONGCHOI
   add constraint FK_NGUOICHO_NGUOICHOI_NGUOICHO foreign key (TAIKHOAN)
      references NGUOICHOI (TAIKHOAN)
      on update restrict
      on delete restrict;

alter table PHONGCHOI
   add constraint FK_PHONGCHO_MUCDO_PHO_MUCDO foreign key (SODIA)
      references MUCDO (SODIA)
      on update restrict
      on delete restrict;

alter table THANHTICH
   add constraint FK_THANHTIC_THANHTICH_MUCDO foreign key (SODIA)
      references MUCDO (SODIA)
      on update restrict
      on delete restrict;

alter table THANHTICH
   add constraint FK_THANHTIC_THANHTICH_NGUOICHO foreign key (TAIKHOAN)
      references NGUOICHOI (TAIKHOAN)
      on update restrict
      on delete restrict;

