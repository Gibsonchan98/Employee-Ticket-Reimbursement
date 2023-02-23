
--table creation
CREATE TABLE USERS(
    EID int PRIMARY KEY, 
    First_Name VARCHAR(100) NOT NULL,
    Last_Name VARCHAR(100) NOT NULL, 
    WorkerType CHAR NOT NULL, 
    EPassword VARCHAR(100) NOT NULL
);

CREATE TABLE TICKETS(
    ID int PRIMARY KEY,
    Submission DATETIME, 
    TDescription varchar(250),
    Amount DECIMAL NOT NULL, 
    SStatus CHAR, 
    Submittedby int FOREIGN KEY REFERENCES USERS(EID),
    Approvedby int
);

--populating tables
INSERT INTO USERS(EID, First_Name, Last_Name, WorkerType, EPassword) VALUES (00001,'Jane', 'Doe', 'M', '123456');
INSERT INTO USERS(EID, First_Name, Last_Name, WorkerType, EPassword) VALUES (00002,'Joe', 'Doe', 'M', '123457');


--queries to test tables
SELECT * FROM USERS; 
