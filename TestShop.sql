CREATE TABLE Userweb (
  UserId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  UserName NVARCHAR(100) NOT NULL,
  UserPass NVARCHAR(100) NOT NULL,
  UserMail NVARCHAR(100) NOT NULL,
  UserImg NVARCHAR(200) NOT NULL,
  UserRole VARCHAR(100) NOT NULL,
  UserStatus INT NOT NULL
);

CREATE TABLE admin (
  AdminId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  AdminName NVARCHAR(100) NOT NULL,
  AdminTel NVARCHAR(100) UNIQUE NOT NULL,
  UserId INT NOT NULL,
  FOREIGN KEY (UserId) REFERENCES Userweb(UserId)
);



CREATE TABLE customer (
  CustomId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  CustomName NVARCHAR(100) NOT NULL,
  CustomTel NVARCHAR(100) NOT NULL,
  CustAddress NVARCHAR(100) NOT NULL,
  CustBirthday DATETIME NOT NULL,
  UserId INT NOT NULL,
  FOREIGN KEY (UserId) REFERENCES Userweb(UserId)
);

CREATE TABLE Channel (
  ChannelId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  ChannelName NVARCHAR(100) NOT NULL,
  Channelstatus INT NOT NULL,
  CustomId INT NOT NULL,
  FOREIGN KEY (CustomId) REFERENCES customer(CustomId)
);


CREATE TABLE Category (
  CategoryId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  CategoryName NVARCHAR(100) NOT NULL,
  CateStatus INT NOT NULL
);

CREATE TABLE Clip (
  ClipId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  ClipName NVARCHAR(100) NOT NULL,
  ClipDecs TEXT NOT NULL,
  Thumbail NVARCHAR(100) NOT NULL,
  DateUpload DATETIME NOT NULL,
  Filesize INT NOT NULL,
  Filepath VARCHAR(100) NOT NULL,
  ClipStatus INT NOT NULL,
  ChannelId INT DEFAULT(0) NOT NULL,
  FOREIGN KEY (ChannelId) REFERENCES Channel(ChannelId)
);



CREATE TABLE categoryclip (
  CaclipId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  CategoryId INT NOT NULL,
  ClipId INT NOT NULL,
  FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId),
  FOREIGN KEY (ClipId) REFERENCES Clip(ClipId)
);

INSERT INTO Userweb (username , userpass  , usermail , userimg  , role , status
) VALUES ('Admin1','123456','admin@gmail.com','noimage.png','admin',1),('Customer1','123456','Customer@gmail.com','noimage.png','Customer',1);
INSERT INTO Category (CategoryName,CateStatus) 
VALUES ('Kinh dị', 1),('Trinh thám', 1), ('Hài',1),('16+',1)('Âm nhạc',1)('Viễn tưởng',1)('thần thoại',1)('lịch sử',1);