/*==============================================================*/
/* DBMS name:      Sybase SQL Anywhere 11                       */
/* Created on:     2/10/2015 9:58:01 AM                         */
/*==============================================================*/


/*==============================================================*/
/* Table: MUCDO                                                 */
/*==============================================================*/
create table MUCDO 
(
   SODIA                smallint                       not null,
   MOTA					NVARCHAR(30)					NULL,
   constraint PK_MUCDO primary key (SODIA)
);



/*==============================================================*/
/* Table: NGUOICHOI                                             */
/*==============================================================*/
create table NGUOICHOI 
(
   TAIKHOAN             VARCHAR(30)                       not null,
   MATKHAU              VARCHAR(50)                       null,
   constraint PK_NGUOICHOI primary key (TAIKHOAN)
);


/*==============================================================*/
/* Table: NGUOICHOI_PHONGCHOI                                   */
/*==============================================================*/
create table NGUOICHOI_PHONGCHOI 
(
   MAPHONG              smallint                       not null,
   TAIKHOAN             VARCHAR(30)                       not null,
   constraint PK_NGUOICHOI_PHONGCHOI primary key (MAPHONG, TAIKHOAN)
);



/*==============================================================*/
/* Table: PHONGCHOI                                             */
/*==============================================================*/
create table PHONGCHOI 
(
   MAPHONG              smallint                       not null,
   SODIA                smallint                       not null,
   TENPHONG             NVARCHAR(50)                    null,
   SOLUONG              smallint                       null,
   TINHTRANG            NVARCHAR(30)                       null,
   MATKHAU              VARCHAR(32)                       null,
   NGUOITHANG           VARCHAR(50)                    null,
   constraint PK_PHONGCHOI primary key (MAPHONG)
);


/*==============================================================*/
/* Table: THANHTICH                                             */
/*==============================================================*/
create table THANHTICH 
(
   TAIKHOAN             VARCHAR(30)                       not null,
   SODIA                smallint                       not null,
   THOIGIAN             time                           null,
   SOBUOCCHUYEN         SMALLINT                     null,
   constraint PK_THANHTICH primary key (TAIKHOAN, SODIA)
);


alter table NGUOICHOI_PHONGCHOI
   add constraint FK_NGUOICHO_NGUOICHOI foreign key (MAPHONG)
      references PHONGCHOI (MAPHONG)

alter table NGUOICHOI_PHONGCHOI
   add constraint FK_NGUOICHO_NGUOICHOI foreign key (TAIKHOAN)
      references NGUOICHOI (TAIKHOAN)


alter table PHONGCHOI
   add constraint FK_PHONGCHO_MUCDO foreign key (SODIA)
      references MUCDO (SODIA)


alter table THANHTICH
   add constraint FK_THANHTICH foreign key (SODIA)
      references MUCDO (SODIA)


alter table THANHTICH
   add constraint FK_THANHTICH foreign key (TAIKHOAN)
      references NGUOICHOI (TAIKHOAN)


