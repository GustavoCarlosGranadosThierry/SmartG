# SmartG

SmartG was an ERP developed for XL Catlin. Its main functions were:

- Issuance of insurance policies (5 lines of business) in Word format (restricted for editing) and PDF.
- It created reports for the Mexican Insurance and Bond Commission.
- Issuance and control of invoices.
- Reports and other functions.

# Project Technologies and date of creation

It was developed from March 2018 to July 2021, some of its features are:

- Desktop App (NET Framework)
- Developed in C#
- Database SQL Server 2019
- Infragistics.
- Used API’s to generate and download invoices from the Tax Administration Service
- AES 256 Encryption, and custom security mechanisms to ensure data privacy and protection.

# Contents of the Repo

This repo is an partial view of that project, I wanted to share some of the functionalities that we developed, such as:

- We had a full integration with the Net.Office library to generate custom Office files (the issued insurance policies), these files were password protected to avoid modification, and, even if someone managed to modify them, we stored the original inside the database.
- Use of both linq and datasets to contact the SQL server database, this was probably a solution we could have dwelve more into it, but, at that moment, we used both solution for two main purposes: if we were working with large ammounts of data, we used the datasets since they were faster; if we were creating or updating anything else, we used linq because it was easier to fill all the required fields and let linq do the database operations based on the models we established in the .dbml file.
- Like mentioned previously, this system had to contact the Mexican taxes adminstration service to issue invoices and other documents related to these. We used a custom API and libraries provided by the agency that helped us reach the taxes administration, since you can't do that directly, even now. All data related to the invoices was encripted and stored inside the database.
- The database had a "two-factor" authentication, when a new user was created inside the system, a new user was registered in the SQL database, mapped as a "user" and having access to the SQL engine, limited by its user role, after that, the same registration service created a new login inside the SmartG database, mapping them with the specific roles we established, according to the user role inside SmartG. Both passwords (the one to access the engine and the one that grants access to the database) were encripted with a custom cypher algorithm. This was to prevent anyone to try and use their plain passwords to gain access to the database from another source (like SSMS).
- It was required to be a desktop app by the business to keep maximum security, since all the computers had to connect to a secure VPN in order to reach the SQL server that was inside an AWS instance.
- Infragistics was a set of tools that improved the UI/UX of all the system.
