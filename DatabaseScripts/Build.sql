-- Hospital Management System
set echo on
set linesize 100
set pagesize 66


--Connect as system

ALTER SESSION SET "_ORACLE_SCRIPT"=true;

-- Drop existing schema user
DROP USER health_schema CASCADE;

-- Create a new Schema user
CREATE USER health_schema IDENTIFIED BY 0123456;

-- Grant permissions to the Schema user
GRANT all privileges to health_schema;
GRANT CONNECT, RESOURCE TO health_schema;

-- Drop existing tables
DROP TABLE health_schema.HPAppointment CASCADE CONSTRAINTS;
DROP TABLE health_schema.HPAdmission CASCADE CONSTRAINTS;
DROP TABLE health_schema.HPDoctor CASCADE CONSTRAINTS;
DROP TABLE health_schema.HPPatient CASCADE CONSTRAINTS;


-- Create HPPatient table
CREATE TABLE health_schema.HPPatient (
  patient# INT PRIMARY KEY,
  Fname VARCHAR2(25) NOT NULL,
  Lname VARCHAR2(25) NOT NULL,
  dob VARCHAR2(10) NOT NULL,
  gender CHAR(1) CHECK (gender IN ('M', 'F')),
  Disease VARCHAR2(50),
  Contact VARCHAR2(10) CHECK (REGEXP_LIKE(Contact, '^[0-9]{3}[0-9]{3}[0-9]{4}$'))
);

-- Create HPDoctor table
CREATE TABLE health_schema.HPDoctor (
  doctor# INT PRIMARY KEY,
  Fname VARCHAR2(25) NOT NULL,
  Lname VARCHAR2(25) NOT NULL,
  speciality VARCHAR2(25) NOT NULL
);

-- Create HPAppointment table
CREATE TABLE health_schema.HPAppointment(
  Appointment# INT PRIMARY KEY,
  apt_Date VARCHAR2(8),
  apt_Time VARCHAR2(8),
  Patient# INT,
  Doctor# INT,
  isActive INT CHECK (isActive IN (0, 1)),
  FOREIGN KEY (Patient#) REFERENCES health_schema.HPPatient(patient#),
  FOREIGN KEY (Doctor#) REFERENCES health_schema.HPDoctor(doctor#)
);


-- populate data


-- Insert data into HPDoctor table with three-digit doctor IDs starting with 2
INSERT INTO health_schema.HPDoctor (doctor#, Fname, Lname, speciality)
VALUES (201, 'John', 'Doe', 'Cardiologist');

INSERT INTO health_schema.HPDoctor (doctor#, Fname, Lname, speciality)
VALUES (202, 'Alice', 'Smith', 'Orthopedic Surgeon');

INSERT INTO health_schema.HPDoctor (doctor#, Fname, Lname, speciality)
VALUES (203, 'Bob', 'Johnson', 'Pediatrician');

INSERT INTO health_schema.HPDoctor (doctor#, Fname, Lname, speciality)
VALUES (204, 'Emily', 'Davis', 'Dermatologist');

INSERT INTO health_schema.HPDoctor (doctor#, Fname, Lname, speciality)
VALUES (205, 'Michael', 'Lee', 'Neurologist');



-- Insert data into HPPatient table with three-digit patient IDs
INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (101, 'Mary', 'Johnson', '15-05-90', 'F', 'Hypertension', '1234567890');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (102, 'James', 'Smith', '22-08-85', 'M', 'Diabetes', '4567890123');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (103, 'Emily', 'Brown', '10-02-77', 'F', 'Asthma', '7890123456');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (104, 'Daniel', 'Lee', '30-11-98', 'M', 'Migraine', '2345678901');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (105, 'Sophia', 'Jones', '25-06-82', 'F', 'Arthritis', '5678901234');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (106, 'Ethan', 'Garcia', '18-04-95', 'M', 'Allergies', '8901234567');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (107, 'Olivia', 'Rodriguez', '03-09-89', 'F', 'Chronic Pain', '3456789012');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (108, 'Liam', 'Martinez', '08-12-73', 'M', 'Depression', '6789012345');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (109, 'Emma', 'Lopez', '20-03-87', 'F', 'Obesity', '9012345678');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (110, 'Aiden', 'Perez', '05-01-92', 'M', 'Insomnia', '4321098765');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (111, 'Ava', 'Taylor', '12-07-80', 'F', 'Osteoporosis', '2109876543');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (112, 'Mia', 'Williams', '28-10-96', 'F', 'Anxiety', '9876543210');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (113, 'Noah', 'Smith', '03-04-75', 'M', 'Eczema', '8765432109');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (114, 'Isabella', 'Anderson', '15-11-83', 'F', 'High Cholesterol', '7654321098');

INSERT INTO health_schema.HPPatient (patient#, Fname, Lname, dob, gender, Disease, Contact)
VALUES (115, 'Lucas', 'Hernandez', '09-08-91', 'M', 'COPD', '6543210987');


-- Insert data into HPAppointment table with 10 records, isActive=1, apt_Date before '2023-12-05'
INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(401, '01-01-23', '08:00', 111, 201, 1);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(402, '15-01-23', '09:30', 112, 202, 1);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(403, '28-01-23', '11:00', 113, 203, 1);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(404, '10-02-23', '12:30', 114, 204, 1);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(405, '25-02-23', '14:00', 115, 205, 1);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(406, '05-03-23', '15:30', 101, 201, 1);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(407, '20-03-23', '09:00', 102, 202, 1);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(408, '02-04-23', '11:30', 103, 203, 1);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(409, '15-04-23', '13:00', 104, 204, 1);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(410, '30-04-23', '14:30', 105, 205, 1);



-- Insert data into HPAppointment table with 10 records, apt_Date after '2023-12-25',
INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(411, '26-12-23', '08:00', 106, 201, 0);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(412, '02-01-24', '09:30', 107, 202, 0);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(413, '15-01-24', '11:00', 108, 203, 0);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(414, '01-02-24', '12:30', 109, 204, 0);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(415, '15-02-24', '14:30', 110, 205, 0);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(416, '01-03-24', '15:30', 111, 201, 0);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(417, '15-03-24', '09:00', 112, 202, 0);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(418, '28-03-24', '11:30', 113, 203, 0);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(419, '10-04-24', '13:00', 114, 204, 0);

INSERT INTO health_schema.HPAppointment (Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive)
VALUES(420, '25-04-24', '14:30', 115, 205, 0);