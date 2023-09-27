--Task 6 
--#1
CREATE DATABASE DB6
USE DB6;
--Teacher table
CREATE TABLE Teacher (
	TId int identity(1,1) primary key, --Teacher ID
	nm varchar(20),
	surnm varchar(20),
	gender char,
	subjct varchar(50)
);

--Pupil Table
CREATE TABLE Pupil (
	PId int identity(1,1) primary key, --Pupil ID
	nm varchar(20),
	surnm varchar(20),
	gender char,
	Class varchar(50)
);
--Junction Teacher-Pupil table for many-to-many relationship
CREATE TABLE TP(
    TId INT,
    PId INT,
    PRIMARY KEY (TId, PId),
    FOREIGN KEY (TId) REFERENCES Teacher(TId),
    FOREIGN KEY (PId) REFERENCES Pupil(PId)
);


--I am gonna add some values to test the query for the subtask #2
--pupils
INSERT INTO Pupil (nm, surnm, gender, Class)
VALUES ('Anna', 'Grayson', 'F', '10th');
INSERT INTO Pupil (nm, surnm, gender, Class)
VALUES ('Maka', 'Sanaya', 'F', '7th');
INSERT INTO Pupil (nm, surnm, gender, Class)
VALUES ('Giorgi', 'Kikolashvili', 'M', '12th');
INSERT INTO Pupil (nm, surnm, gender, Class)
VALUES ('Giorgi', 'Wayne', 'M', '10th');
INSERT INTO Pupil (nm, surnm, gender, Class)
VALUES ('Jason', 'Todd', 'M', '11th');
--teachers
INSERT INTO Teacher(nm, surnm, gender, subjct)
VALUES ('Monnie', 'Tetttern', 'F', 'Mathematics');
INSERT INTO Teacher (nm, surnm, gender, subjct)
VALUES ('Caleb', 'Lourson', 'M', 'Physics');
--connections
INSERT INTO TP(TId, PId)
VALUES (1,1);
INSERT INTO TP(TId, PId)
VALUES (1,2);
INSERT INTO TP(TId, PId)
VALUES (1,3);
INSERT INTO TP(TId, PId)
VALUES (1,4);
INSERT INTO TP(TId, PId)
VALUES (1,5);
INSERT INTO TP(TId, PId)
VALUES (2,5);
INSERT INTO TP(TId, PId)
VALUES (2,1);
INSERT INTO TP(TId, PId)
VALUES (2,3);

--#2
SELECT DISTINCT Teacher.nm as Name, Teacher.surnm as Surname
FROM Teacher 
JOIN TP TP ON Teacher.TId = TP.TId
JOIN Pupil ON TP.PId = Pupil.PId
WHERE Pupil.nm = 'Giorgi';