CREATE DATABASE [WebApiAssignment]
GO
USE [WEBAPIASSIGNMENT]
GO
--==========================================================================
-----------------------------Hotel Table------------------------------------
--==========================================================================
CREATE TABLE Hotel ([HotelId] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
					[Name] NVARCHAR(56) NOT NULL,
					[Address] NVARCHAR(256) NOT NULL,
					[City] NVARCHAR(56) NOT NULL,
					[PinCode] NVARCHAR(12) NOT NULL,
					[ContactNo] NVARCHAR(12) NOT NULL,
					[ContactPerson] NVARCHAR(56) NOT NULL,
					[Website] NVARCHAR(126) NULL,
					[Facebook] NVARCHAR(126) NULL,
					[Twitter] NVARCHAR(126) NULL,
					[isActive] BIT DEFAULT 1 NOT NULL,
					[CreatedDate] DATE DEFAULT SYSDATETIME() NOT NULL,
					[UpdatedDate] DATE NULL,
					[UploadedBy] INT DEFAULT 1 NOT NULL)
GO
--==========================================================================
-----------------------------Room Table-------------------------------------
--==========================================================================
CREATE TABLE Room ([RoomId] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
					[HotelId] INT FOREIGN KEY REFERENCES [Hotel]([HotelId]),
					[Name] NVARCHAR(56) NOT NULL,
					[Category] INT NOT NULL CHECK ([Category]>0 AND [Category]<4) DEFAULT 1,
					[Price] INT NOT NULL,
					[isActive] BIT DEFAULT 1 NOT NULL,
					[CreatedDate] DATE DEFAULT SYSDATETIME() NOT NULL,
					[UpdatedDate] DATE NULL,
					[UploadedBy] INT DEFAULT 1 NOT NULL)
GO
--==========================================================================
-----------------------------Booking Table----------------------------------
--==========================================================================
CREATE TABLE Booking ([BookingId] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
						[RoomId] INT FOREIGN KEY REFERENCES [Room]([RoomId]) NOT NULL,
						[BookingDate] DATE NOT NULL,
						[Status] INT CHECK ([Status]>0 AND [Status]<5) DEFAULT 1 NOT NULL)
GO
--===============================================
------------------Hotel 1------------------------
--===============================================
INSERT INTO Hotel VALUES('The Grand Bhagwati',
							'S.G. Road, Ahmedabad, India',
							'Ahmedabad','380054','1234567890',
							'Chaman Bhai',
							'http://thegrandbhagwati.com/',
							'http://thegrandbhagwati.com/',
							'http://thegrandbhagwati.com/',1,SYSDATETIME(),NULL,1)
--======================================================================
---------------------------Hotel 1 Rooms--------------------------------
--======================================================================
INSERT INTO ROOM VALUES(1,'Room-404',2,1500,1,SYSDATETIME(),NULL,1),
						(1,'Room-304',2,1500,1,SYSDATETIME(),NULL,1),
						(1,'Room-704',1,1500,1,SYSDATETIME(),NULL,1),
						(1,'Room-504',1,500,1,SYSDATETIME(),NULL,1),
						(1,'Room-604',3,5500,1,SYSDATETIME(),NULL,1),
						(1,'Room-302',2,3500,1,SYSDATETIME(),NULL,1),
						(1,'Room-202',2,1500,1,SYSDATETIME(),NULL,1),
						(1,'Room-101',1,500,1,SYSDATETIME(),NULL,1),
						(1,'Room-404',3,5500,1,SYSDATETIME(),NULL,1),
						(1,'Room-506',2,3500,1,SYSDATETIME(),NULL,1)
--===============================================
------------------Hotel 2------------------------
--===============================================
INSERT INTO Hotel VALUES('Hotel Cambay Grand',
							'Near PERD Centre, Sola Over Bridge, Thaltej, Ahmedabad, India',
							'Ahmedabad','380054','1234567890',
							'Chaman Bhai',
							'https://www.cambayhotels.com/cambay-grand-ahmedabad.htm',
							'https://www.cambayhotels.com/cambay-grand-ahmedabad.htm',
							'https://www.cambayhotels.com/cambay-grand-ahmedabad.htm',1,SYSDATETIME(),NULL,1)
--======================================================================
---------------------------Hotel 2 Rooms--------------------------------
--======================================================================
INSERT INTO ROOM VALUES(2,'Room-404',2,1500,1,SYSDATETIME(),NULL,1),
						(2,'Room-304',2,1500,1,SYSDATETIME(),NULL,1),
						(2,'Room-704',1,1500,1,SYSDATETIME(),NULL,1),
						(2,'Room-504',1,500,1,SYSDATETIME(),NULL,1),
						(2,'Room-604',3,5500,1,SYSDATETIME(),NULL,1),
						(2,'Room-302',2,3500,1,SYSDATETIME(),NULL,1),
						(2,'Room-202',2,1500,1,SYSDATETIME(),NULL,1),
						(2,'Room-101',1,500,1,SYSDATETIME(),NULL,1),
						(2,'Room-404',3,5500,1,SYSDATETIME(),NULL,1),
						(2,'Room-506',2,3500,1,SYSDATETIME(),NULL,1)
--===============================================
------------------Hotel 3------------------------
--===============================================
INSERT INTO Hotel VALUES('Hyatt Regency Ahmedabad',
							'17/A, Ashram Road, Ahmedabad, India',
							'Ahmedabad','380014','1234567890',
							'Chaman Bhai',
							'https://www.hyatt.com/en-US/hotel/india/hyatt-regency-ahmedabad/amdhr',
							'https://www.hyatt.com/en-US/hotel/india/hyatt-regency-ahmedabad/amdhr',
							'https://www.hyatt.com/en-US/hotel/india/hyatt-regency-ahmedabad/amdhr',1,SYSDATETIME(),NULL,1)
--======================================================================
---------------------------Hotel 3 Rooms--------------------------------
--======================================================================
INSERT INTO ROOM VALUES(3,'Room-404',2,1500,1,SYSDATETIME(),NULL,1),
						(3,'Room-304',2,1500,1,SYSDATETIME(),NULL,1),
						(3,'Room-704',1,1500,1,SYSDATETIME(),NULL,1),
						(3,'Room-504',1,500,1,SYSDATETIME(),NULL,1),
						(3,'Room-604',3,5500,1,SYSDATETIME(),NULL,1),
						(3,'Room-302',2,3500,1,SYSDATETIME(),NULL,1),
						(3,'Room-202',2,1500,1,SYSDATETIME(),NULL,1),
						(3,'Room-101',1,500,1,SYSDATETIME(),NULL,1),
						(3,'Room-404',3,5500,1,SYSDATETIME(),NULL,1),
						(3,'Room-506',2,3500,1,SYSDATETIME(),NULL,1)
--===============================================
------------------Hotel 4------------------------
--===============================================
INSERT INTO Hotel VALUES('Central Excellency',
							'Opp. Surat Railway Station, Near Alankar Cinema, Surat, India',
							'Surat','395003','1234567890',
							'Chaman Bhai',
							'https://www.beaconhotels.com/central-beacon-hotel-surat/',
							'https://www.beaconhotels.com/central-beacon-hotel-surat/',
							'https://www.beaconhotels.com/central-beacon-hotel-surat/',1,SYSDATETIME(),NULL,1)
--======================================================================
---------------------------Hotel 4 Rooms--------------------------------
--======================================================================
INSERT INTO ROOM VALUES(4,'Room-404',2,1500,1,SYSDATETIME(),NULL,1),
						(4,'Room-304',2,1500,1,SYSDATETIME(),NULL,1),
						(4,'Room-704',1,1500,1,SYSDATETIME(),NULL,1),
						(4,'Room-504',1,500,1,SYSDATETIME(),NULL,1),
						(4,'Room-604',3,5500,1,SYSDATETIME(),NULL,1),
						(4,'Room-302',2,3500,1,SYSDATETIME(),NULL,1),
						(4,'Room-202',2,1500,1,SYSDATETIME(),NULL,1),
						(4,'Room-101',1,500,1,SYSDATETIME(),NULL,1),
						(4,'Room-404',3,5500,1,SYSDATETIME(),NULL,1),
						(4,'Room-506',2,3500,1,SYSDATETIME(),NULL,1)
--===============================================
------------------Hotel 5------------------------
--===============================================
INSERT INTO Hotel VALUES('Sifat International',
							'Opp. Surat Railway Station, Gujarat, 395003, Surat, India',
							'Surat','395003','1234567890',
							'Chaman Bhai',
							'https://sifatinternational.hotvel.com/',
							'https://sifatinternational.hotvel.com/',
							'https://sifatinternational.hotvel.com/',1,SYSDATETIME(),NULL,1)
--======================================================================
---------------------------Hotel 5 Rooms--------------------------------
--======================================================================
INSERT INTO ROOM VALUES(5,'Room-404',2,1500,1,SYSDATETIME(),NULL,1),
						(5,'Room-304',2,1500,1,SYSDATETIME(),NULL,1),
						(5,'Room-704',1,1500,1,SYSDATETIME(),NULL,1),
						(5,'Room-504',1,500,1,SYSDATETIME(),NULL,1),
						(5,'Room-604',3,5500,1,SYSDATETIME(),NULL,1),
						(5,'Room-302',2,3500,1,SYSDATETIME(),NULL,1),
						(5,'Room-202',2,1500,1,SYSDATETIME(),NULL,1),
						(5,'Room-101',1,500,1,SYSDATETIME(),NULL,1),
						(5,'Room-404',3,5500,1,SYSDATETIME(),NULL,1),
						(5,'Room-506',2,3500,1,SYSDATETIME(),NULL,1)
--===============================================
------------------Hotel 6------------------------
--===============================================
INSERT INTO Hotel VALUES('Budget Inn Bellevue',
							'Sumul Dairy Road,, 395004, Surat, India',
							'Surat','395004','1234567890',
							'Chaman Bhai',
							'https://www.hotelbellevuesurat.com/',
							'https://www.hotelbellevuesurat.com/',
							'https://www.hotelbellevuesurat.com/',1,SYSDATETIME(),NULL,1)
--======================================================================
---------------------------Hotel 6 Rooms--------------------------------
--======================================================================
INSERT INTO ROOM VALUES(6,'Room-404',2,1500,1,SYSDATETIME(),NULL,1),
						(6,'Room-304',2,1500,1,SYSDATETIME(),NULL,1),
						(6,'Room-704',1,1500,1,SYSDATETIME(),NULL,1),
						(6,'Room-504',1,500,1,SYSDATETIME(),NULL,1),
						(6,'Room-604',3,5500,1,SYSDATETIME(),NULL,1),
						(6,'Room-302',2,3500,1,SYSDATETIME(),NULL,1),
						(6,'Room-202',2,1500,1,SYSDATETIME(),NULL,1),
						(6,'Room-101',1,500,1,SYSDATETIME(),NULL,1),
						(6,'Room-404',3,5500,1,SYSDATETIME(),NULL,1),
						(6,'Room-506',2,3500,1,SYSDATETIME(),NULL,1)