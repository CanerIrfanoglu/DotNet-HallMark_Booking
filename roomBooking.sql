if not exists(select * from sys.databases where name = 'roomBooking')
    create database roomBooking ;

use roomBooking;

Drop TABLE if exists bookings;

Drop TABLE if exists rooms;



CREATE TABLE rooms (
	roomID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	roomName varchar(15) Not Null,
	roomSize int NOT NULL,
	roomLocation varchar(100)
);

CREATE TABLE bookings (
	eventID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	eventName varchar(30) NOT NULL,
	startDate DATETIME NOT NULL,
	endDate DATETIME NOT NULL,
	userID nvarchar(128) FOREIGN KEY REFERENCES AspNetUsers(Id),
	roomID int FOREIGN KEY REFERENCES rooms(roomID)
);


INSERT INTO AspNetRoles(Id, Name) values ('1','User');
INSERT INTO AspNetRoles(Id, Name) values ('2','Admin');
INSERT INTO rooms(roomName, roomSize, roomLocation) values ('S126 - A','10','Science Building');
INSERT INTO rooms(roomName, roomSize, roomLocation) values ('S126 - B','20','Science Building');






  