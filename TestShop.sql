CREATE TABLE Userweb (
  userid INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  username NVARCHAR(100) NOT NULL,
  userpass NVARCHAR(100) NOT NULL,
  usermail NVARCHAR(100) NOT NULL,
  userimg NVARCHAR(200) NOT NULL,
  role VARCHAR(100) NOT NULL,
  status INT NOT NULL
);

CREATE TABLE admin (
  adminid INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  adminname NVARCHAR(100) NOT NULL,
  admintel NVARCHAR(100) UNIQUE NOT NULL,
  userid INT NOT NULL,
  FOREIGN KEY (userid) REFERENCES Userweb(userid)
);



CREATE TABLE customer (
  customid INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  customname NVARCHAR(100) NOT NULL,
  customtel NVARCHAR(100) NOT NULL,
  custaddress NVARCHAR(100) NOT NULL,
  custbirthday DATETIME NOT NULL,
  userid INT NOT NULL,
  FOREIGN KEY (userid) REFERENCES Userweb(userid)
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
VALUES ('Kinh dị', 1),('Trinh thám', 1), ('Hài',1),('16+',1),('Âm nhạc',1),('Viễn tưởng',1),('thần thoại',1),('lịch sử',1);