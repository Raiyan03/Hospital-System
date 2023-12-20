# Hospital System

## About
This .NET MAUI BLAZOR hybrid application seamlessly integrates with an Oracle 21c database to persist data in a relational structure, leveraging Foreign Keys to establish relationships across various tables. The primary functionality enables users, assumed to be system administrators, to schedule appointments with doctors. The process involves entering a patient ID. If the patient is not yet registered in the system, users can create a new patient profile by providing relevant details. A unique patient ID is automatically generated, facilitating the subsequent appointment booking process.

## Database ER Diagram

![Sample Image](https://i.ibb.co/NjjhcKz/Hospital-DB-modified.png)

## Video demo

[![Video Preview](https://i.ibb.co/HxcLVN9/Screenshot-2023-12-20-011705.png)](https://clipchamp.com/watch/YY1saFqDp7m)

## Future iteration

* Focusing on creating a more visually appealing user interface.
* Augmenting the database with additional pertinent information.
* Introducing extra features like bill management and inventory control.

## How to use it

### Prerequisite

* Install Oracle 21c
* Visual studio(Recomended)

### Instructions

* Clone the repository to your local machine.
* Navigate to the repository using your file explorer.
* Access the "DatabaseScripts" folder within the repository.
* Locate a SQL file named "Build" in the folder.
* Execute the SQL file in your SQL*Plus terminal while logged in as "SYSDBA.
* Open the solution file "HospitalSystem.sln" found in the root directory of the repository.
* In the "DBroker.cs" class, modify the server name to match your Oracle 21c server.
    *TIP: If you're unsure of your server name, run the following command in your SQLPlus terminal:-
        select sys_context('USERENV','SERVER_HOST') from dual;
* After completing all the steps, click the run button to execute the application.