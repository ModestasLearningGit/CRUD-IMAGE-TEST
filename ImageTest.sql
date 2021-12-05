create database ImageTest;
use ImageTest;

create table MemberInfo
(
	MID  int NOT NULL IDENTITY(1,1) primary key,
	PicuteName varchar(250) NOT NULL,
	Fname varchar(50) NOT NULL UNIQUE,
	Lname varchar(50) NOT NULL,
	Email varchar(150) NOT NULL,
);
