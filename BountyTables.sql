DROP TABLE profiles;

CREATE TABLE IF NOT EXISTS profiles(
  id VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  name VARCHAR(255),
  picture VARCHAR(255),

  PRIMARY KEY (id)
);

INSERT INTO profiles(id, email, name, picture)
VALUES("test", "test@test.com", "Jim Test", "Smiley.jpg");

SELECT * FROM profiles;