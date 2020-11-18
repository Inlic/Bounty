DROP TABLE cityprofiles;
DROP TABLE deputyprofiles;
DROP TABLE awardcities;
DROP TABLE awarddeputies;
DROP TABLE profiles;
DROP TABLE awards;
DROP TABLE cities;
DROP TABLE deputies;


CREATE TABLE IF NOT EXISTS profiles(
  id VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  name VARCHAR(255),
  picture VARCHAR(255),
  income DECIMAL(8,2),

  PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS awards(
  id int AUTO_INCREMENT NOT NULL,
  description VARCHAR(255),
  payout DECIMAL(8,2),

  PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS cities(
 id int AUTO_INCREMENT NOT NULL,
 name VARCHAR(255),

 PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS deputies(
 id int AUTO_INCREMENT NOT NULL,
 name VARCHAR(255),

 PRIMARY KEY (id)
);

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
  REFERENCES bounties(id)
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
  REFERENCES bounties(id)
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
