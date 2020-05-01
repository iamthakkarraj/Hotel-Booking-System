CREATE DATABASE [WebApiAssignment]
GO

USE [WEBAPIASSIGNMENT]
GO

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

CREATE TABLE Booking ([BookingId] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
						[RoomId] INT FOREIGN KEY REFERENCES [Room]([RoomId]) NOT NULL,
						[BookingDate] DATE NOT NULL,
						[Status] INT CHECK ([Status]>0 AND [Status]<5) DEFAULT 1 NOT NULL)