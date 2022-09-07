SET DATEFORMAT ymd
-- File name: D:\010_work\Personal\Website\C#\Projects\ASP-hotel-api\Data\migration_v2.sql\n-- Created by MSSQL Library http://www.dbconvert.com\n

---- Table structure for table `customer_type` 
----

CREATE TABLE [customer_type] ([id] INT IDENTITY(1,1)  ,[name] VARCHAR(38) NOT NULL  ,CONSTRAINT [customer_type_customer_type_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([id])); 

---- Table structure for table `customer` 
----

CREATE TABLE [customer] ([id] INT IDENTITY(1,1)  ,[name] VARCHAR(38) NOT NULL  ,[phone] DECIMAL(38,0) NULL  ,[idCard] VARCHAR(38) NULL  ,[address] VARCHAR(255) NULL  ,[type_id] INT NULL  ,CONSTRAINT [customer_customer_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([id]), CONSTRAINT [customer_customer_ibfk_1] FOREIGN KEY ("type_id") REFERENCES "customer_type" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION); 
 CREATE  NONCLUSTERED  INDEX [customer_type_id] ON [customer] ([type_id]);
ALTER TABLE [customer] CHECK CONSTRAINT [customer_customer_ibfk_1];

---- Table structure for table `room_type` 
----

CREATE TABLE [room_type] ([id] INT IDENTITY(1,1)  ,[name] VARCHAR(38) NOT NULL  ,CONSTRAINT [room_type_room_type_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([id])); 

---- Table structure for table `room` 
----

CREATE TABLE [room] ([id] INT IDENTITY(1,1)  ,[name] VARCHAR(38) NOT NULL  ,[description] VARCHAR(255) NULL  ,[price] REAL NULL  ,[image] VARCHAR(255) NULL  ,[active] SMALLINT NULL  ,[quantity] INT NULL  ,[category_id] INT NOT NULL  ,CONSTRAINT [room_room_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([id]), CONSTRAINT [room_room_ibfk_1] FOREIGN KEY ("category_id") REFERENCES "room_type" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION); 
 CREATE  NONCLUSTERED  INDEX [room_category_id] ON [room] ([category_id]);
ALTER TABLE [room] NOCHECK CONSTRAINT [room_room_ibfk_1];

---- Table structure for table `registration` 
----

CREATE TABLE [registration] ([id] INT IDENTITY(1,1)  ,[checkInTime] DATETIME NULL  ,[checkOutTime] DATETIME NULL  ,[room_id] INT NOT NULL  ,CONSTRAINT [registration_registration_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([id]), CONSTRAINT [registration_registration_ibfk_1] FOREIGN KEY ("room_id") REFERENCES "room" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION); 
 CREATE  NONCLUSTERED  INDEX [registration_room_id] ON [registration] ([room_id]);
ALTER TABLE [registration] NOCHECK CONSTRAINT [registration_registration_ibfk_1];

---- Table structure for table `reservation` 
----

CREATE TABLE [reservation] ([id] INT IDENTITY(1,1)  ,[reserveBy] VARCHAR(38) NOT NULL  ,[phone] VARCHAR(38) NULL  ,[checkInTime] DATETIME NULL  ,[checkOutTime] DATETIME NULL  ,[room_id] INT NOT NULL  ,CONSTRAINT [reservation_reservation_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([id]), CONSTRAINT [reservation_reservation_ibfk_1] FOREIGN KEY ("room_id") REFERENCES "room" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION); 
 CREATE  NONCLUSTERED  INDEX [reservation_room_id] ON [reservation] ([room_id]);
ALTER TABLE [reservation] NOCHECK CONSTRAINT [reservation_reservation_ibfk_1];

---- Table structure for table `receipt` 
----

CREATE TABLE [receipt] ([id] INT IDENTITY(1,1)  ,[checkInTime] DATETIME NULL  ,[checkOutTime] DATETIME NULL  ,[unitPrice] REAL NULL  ,[customer_id] INT NOT NULL  ,[room_id] INT NOT NULL  ,[reservation_id] INT NULL  ,[registration_id] INT NULL  ,CONSTRAINT [receipt_receipt_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([id]), CONSTRAINT [receipt_receipt_ibfk_1] FOREIGN KEY ("customer_id") REFERENCES "customer" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION, CONSTRAINT [receipt_receipt_ibfk_2] FOREIGN KEY ("room_id") REFERENCES "room" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION, CONSTRAINT [receipt_receipt_ibfk_3] FOREIGN KEY ("reservation_id") REFERENCES "reservation" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION, CONSTRAINT [receipt_receipt_ibfk_4] FOREIGN KEY ("registration_id") REFERENCES "registration" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION); 
 CREATE  NONCLUSTERED  INDEX [receipt_customer_id] ON [receipt] ([customer_id]);
 CREATE  NONCLUSTERED  INDEX [receipt_room_id] ON [receipt] ([room_id]);
 CREATE  NONCLUSTERED  INDEX [receipt_reservation_id] ON [receipt] ([reservation_id]);
 CREATE  NONCLUSTERED  INDEX [receipt_registration_id] ON [receipt] ([registration_id]);
ALTER TABLE [receipt] NOCHECK CONSTRAINT [receipt_receipt_ibfk_1];
ALTER TABLE [receipt] NOCHECK CONSTRAINT [receipt_receipt_ibfk_2];
ALTER TABLE [receipt] NOCHECK CONSTRAINT [receipt_receipt_ibfk_3];
ALTER TABLE [receipt] NOCHECK CONSTRAINT [receipt_receipt_ibfk_4];

---- Table structure for table `surcharge` 
----

CREATE TABLE [surcharge] ([id] INT IDENTITY(1,1)  ,[description] NTEXT NOT NULL  ,[ratio] REAL NULL  ,CONSTRAINT [surcharge_surcharge_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([id])); 

---- Table structure for table `customer_registration` 
----

CREATE TABLE [customer_registration] ([registration_id] INT NOT NULL  ,[customer_id] INT NOT NULL  ,CONSTRAINT [customer_registration_customer_registration_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([registration_id],[customer_id]), CONSTRAINT [customer_registration_customer_registration_ibfk_1] FOREIGN KEY ("registration_id") REFERENCES "registration" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION, CONSTRAINT [customer_registration_customer_registration_ibfk_2] FOREIGN KEY ("customer_id") REFERENCES "customer" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION); 
 CREATE  NONCLUSTERED  INDEX [customer_registration_customer_id] ON [customer_registration] ([customer_id]);
ALTER TABLE [customer_registration] NOCHECK CONSTRAINT [customer_registration_customer_registration_ibfk_1];
ALTER TABLE [customer_registration] NOCHECK CONSTRAINT [customer_registration_customer_registration_ibfk_2];

---- Table structure for table `customer_reservation` 
----

CREATE TABLE [customer_reservation] ([reservation_id] INT NOT NULL  ,[customer_id] INT NOT NULL  ,CONSTRAINT [customer_reservation_customer_reservation_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([reservation_id],[customer_id]), CONSTRAINT [customer_reservation_customer_reservation_ibfk_1] FOREIGN KEY ("reservation_id") REFERENCES "reservation" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION, CONSTRAINT [customer_reservation_customer_reservation_ibfk_2] FOREIGN KEY ("customer_id") REFERENCES "customer" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION); 
 CREATE  NONCLUSTERED  INDEX [customer_reservation_customer_id] ON [customer_reservation] ([customer_id]);
ALTER TABLE [customer_reservation] CHECK CONSTRAINT [customer_reservation_customer_reservation_ibfk_1];
ALTER TABLE [customer_reservation] NOCHECK CONSTRAINT [customer_reservation_customer_reservation_ibfk_2];

---- Table structure for table `receipt_surcharge` 
----

CREATE TABLE [receipt_surcharge] ([id] INT IDENTITY(1,1)  ,[receipt_id] INT NOT NULL  ,[surcharge_id] INT NOT NULL  ,CONSTRAINT [receipt_surcharge_receipt_surcharge_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([id],[receipt_id],[surcharge_id]), CONSTRAINT [receipt_surcharge_receipt_surcharge_ibfk_1] FOREIGN KEY ("receipt_id") REFERENCES "receipt" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION, CONSTRAINT [receipt_surcharge_receipt_surcharge_ibfk_2] FOREIGN KEY ("surcharge_id") REFERENCES "surcharge" ( "id" ) ON UPDATE NO ACTION ON DELETE NO ACTION); 
 CREATE  NONCLUSTERED  INDEX [receipt_surcharge_receipt_id] ON [receipt_surcharge] ([receipt_id]);
 CREATE  NONCLUSTERED  INDEX [receipt_surcharge_surcharge_id] ON [receipt_surcharge] ([surcharge_id]);
ALTER TABLE [receipt_surcharge] NOCHECK CONSTRAINT [receipt_surcharge_receipt_surcharge_ibfk_1];
ALTER TABLE [receipt_surcharge] NOCHECK CONSTRAINT [receipt_surcharge_receipt_surcharge_ibfk_2];

---- Table structure for table `user` 
----

CREATE TABLE [user] ([id] INT IDENTITY(1,1)  ,[name] VARCHAR(38) NOT NULL  ,[username] VARCHAR(38) NOT NULL  ,[password] VARCHAR(38) NOT NULL  ,[email] VARCHAR(38) NULL  ,[active] SMALLINT NULL  ,[joined_date] DATETIME NULL  ,[user_role] NVARCHAR(4000) NULL  ,CONSTRAINT [user_user_PRIMARY]  PRIMARY KEY  NONCLUSTERED  ([id])); 
 CREATE  UNIQUE  NONCLUSTERED  INDEX [user_username] ON [user] ([username]);

---- Dumping data for table `customer_type`
---- 


 SET IDENTITY_INSERT [customer_type] ON 
 GO

INSERT INTO [customer_type] ([id],[name])( select 1,N'Quốc Tế') union all ( select 2,N'Trong Nước')

 SET IDENTITY_INSERT [customer_type] OFF 
 GO


---- Dumping data for table `room_type`
---- 


 SET IDENTITY_INSERT [room_type] ON 
 GO

INSERT INTO [room_type] ([id],[name])( select 1,N'Phòng đơn') union all ( select 2,N'Phòng đôi') union all ( select 3,N'Phòng ba') union all ( select 4,N'Phòng gia đình') union all ( select 5,N'Homestay')

 SET IDENTITY_INSERT [room_type] OFF 
 GO


---- Dumping data for table `room`
---- 


 SET IDENTITY_INSERT [room] ON 
 GO

INSERT INTO [room] ([id],[name],[description],[price],[image],[active],[quantity],[category_id])( select 1,N'Deluxe giường đơn',N'Wifi miễn phí\n1 giường nhỏ\nDiện tích phòng: 32 m²\nHướng phòng: Thành phố\nPhòng tắm vòi sen & bồn tắm',400000,N'images/p1.png',1,2,1) union all ( select 2,N'Phòng hai giường thường',N'Wifi miễn phí\n1 giường lớn,1 giường nhỏ\nDiện tích phòng: 32 m²\nHướng phòng: Thành phố\nPhòng tắm vòi sen & bồn tắm',700000,N'images/p2.png',1,4,2) union all ( select 3,N'Phòng ba giường thường',N'Wifi miễn phí\n1 giường lớn, 2 giường nhỏ\nDiện tích phòng: 38 m²\nHướng phòng: Thành phố\nPhòng tắm vòi sen & bồn tắm',1000000,N'images/p3.png',1,6,3) union all ( select 4,N'Phòng gia đình thường',N'Wifi miễn phí\n2 giường lớn, 1 giường nhỏ\nDiện tích phòng: 60 m²\nHướng phòng: Thành phố\nPhòng tắm vòi sen & bồn tắm',1200000,N'images/p4.png',1,6,4) union all ( select 5,N'Homestay',N'Wifi miễn phí\n2 phòng lớn, 2 phòng nhỏ\nDiện tích nhà: 100 m²\nHướng phòng: Thành phố\nPhòng tắm vòi sen & bồn tắm',3000000,N'images/p5.png',1,8,5) union all ( select 6,N'phong mot giuong vip',N'Wifi miễn phí\n1 giường nhỏ\nDiện tích phòng: 32 m²\nHướng phòng: Thành phố\nPhòng tắm vòi sen & bồn tắm',1000000,N'images/p1.png',1,1,1)

 SET IDENTITY_INSERT [room] OFF 
 GO


---- Dumping data for table `surcharge`
---- 


 SET IDENTITY_INSERT [surcharge] ON 
 GO

INSERT INTO [surcharge] ([id],[description],[ratio])( select 1,N'Khách hàng >= 3',1.25) union all ( select 2,N'Có khách quốc tế',1.5)

 SET IDENTITY_INSERT [surcharge] OFF 
 GO


---- Dumping data for table `user`
---- 


 SET IDENTITY_INSERT [user] ON 
 GO

INSERT INTO [user] ([id],[name],[username],[password],[email],[active],[joined_date],[user_role])( select 1,N'admin2',N'admin2',N'202cb962ac59075b964b07152d234b70',N'123',1,N'2022-09-05 10:59:39',N'ADMIN')

 SET IDENTITY_INSERT [user] OFF 
 GO

