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

CREATE TABLE Category (
  categoryid INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  categoryname NVARCHAR(100) NOT NULL,
  status INT NOT NULL
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
  Channelid INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  ChannelName NVARCHAR(100) NOT NULL,
  status INT NOT NULL,
  userid INT NOT NULL,
  FOREIGN KEY (userid) REFERENCES customer(customid)
);


CREATE TABLE Clip (
  clipid INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  clipname NVARCHAR(100) NOT NULL,
  clipdecs TEXT NOT NULL,
  thumbail NVARCHAR(100) NOT NULL,
  dateupload DATETIME NOT NULL,
  Filesize INT NOT NULL,
  Filepath VARCHAR(100) NOT NULL,
  status INT NOT NULL,
  Channelid INT,
  FOREIGN KEY (Channelid) REFERENCES Channel(Channelid)
);



CREATE TABLE categoryclip (
  caclipid INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  categoryid INT NOT NULL,
  clipid INT NOT NULL,
  FOREIGN KEY (categoryid) REFERENCES Category(categoryid),
  FOREIGN KEY (clipid) REFERENCES Clip(clipid)
);