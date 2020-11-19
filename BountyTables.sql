DROP TABLE cityprofiles;
DROP TABLE deputyprofiles;
DROP TABLE awardcities;
DROP TABLE awarddeputies;
DROP TABLE profiles;
DROP TABLE awards;
DROP TABLE cities;
DROP TABLE deputies;

CREATE TABLE IF NOT EXISTS cities(
 id int AUTO_INCREMENT NOT NULL,
 name VARCHAR(255),

 PRIMARY KEY (id)
);

INSERT INTO cities(name)
VALUES("Cactus Town");

SELECT * FROM cities;

CREATE TABLE IF NOT EXISTS profiles(
  id VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  name VARCHAR(255),
  picture VARCHAR(255),
  income DECIMAL(8,2),
  cityid int,

  PRIMARY KEY (id),

  FOREIGN KEY (cityid)
  REFERENCES cities(id)
  ON DELETE CASCADE
);

INSERT INTO profiles(id, email, name, picture)
VALUES("test", "test@test.com", "Jim Test", "Smiley.jpg");

SELECT * FROM profiles;


CREATE TABLE IF NOT EXISTS awards(
  id int AUTO_INCREMENT NOT NULL,
  description VARCHAR(255),
  payout DECIMAL(8,2),
  cityid int,

  PRIMARY KEY (id),

  FOREIGN KEY (cityid)
  REFERENCES cities(id)
  ON DELETE CASCADE
);

INSERT INTO awards(description, payout, cityid)
VALUES("Catch the Cactus Gang", 100, 1);

INSERT INTO awards(description, payout, cityid)
VALUES("Round up some Mustangs", 50, 1);

SELECT * FROM awards;

CREATE TABLE IF NOT EXISTS deputies(
 id int AUTO_INCREMENT NOT NULL,
 name VARCHAR(255),

 PRIMARY KEY (id)
);

INSERT INTO deputies(name)
VALUES("Pecos Bill");

INSERT INTO deputies(name)
VALUES("Doc Holliday");

INSERT INTO deputies(name)
VALUES("Clint Eastwood");

INSERT INTO deputies(name)
VALUES("John Wayne");

INSERT INTO deputies(name)
VALUES("Wyatt Earp");


CREATE TABLE IF NOT EXISTS awardcities(
  id int AUTO_INCREMENT NOT NULL,
  creatorid VARCHAR(255) NOT NULL,
  awardid int,
  cityid int,

  PRIMARY KEY (id),

  FOREIGN KEY (creatorid)
  REFERENCES profiles(id)
  ON DELETE CASCADE,

  FOREIGN KEY (awardid)
  REFERENCES awards(id)
  ON DELETE CASCADE,

  FOREIGN KEY (cityid)
  REFERENCES cities(id)
  ON DELETE CASCADE

);

CREATE TABLE IF NOT EXISTS awarddeputies(
  id int AUTO_INCREMENT NOT NULL,
  creatorid VARCHAR(255) NOT NULL,
  awardid int,
  deputyid int,

  PRIMARY KEY (id),

  FOREIGN KEY (creatorid)
  REFERENCES profiles(id)
  ON DELETE CASCADE,

  FOREIGN KEY (awardid)
  REFERENCES awards(id)
  ON DELETE CASCADE,

  FOREIGN KEY (deputyid)
  REFERENCES deputies(id)
  ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS deputyprofiles(
  id int AUTO_INCREMENT NOT NULL,
  creatorid VARCHAR(255) NOT NULL,
  deputyid int,

  PRIMARY KEY (id),

  FOREIGN KEY (creatorid)
  REFERENCES profiles(id)
  ON DELETE CASCADE,

  FOREIGN KEY (deputyid)
  REFERENCES deputies(id)
  ON DELETE CASCADE

);

CREATE TABLE IF NOT EXISTS cityprofiles(
  id int AUTO_INCREMENT NOT NULL,
  creatorid VARCHAR(255) NOT NULL,
  cityid int,

  PRIMARY KEY (id),

  FOREIGN KEY (creatorid)
  REFERENCES profiles(id)
  ON DELETE CASCADE,

  FOREIGN KEY (cityid)
  REFERENCES cities(id)
  ON DELETE CASCADE
);
