# UmbracoHomework
This repository contains my solution for the homework assignment. 

## Getting Started

Once the project is cloned you can open the 'AcmeCorporation.sln' found in the 'AcmeCorporation' project folder.

Once you have the solution up and running do the following:

- Migrate the database by writing 'Add-Migration InitialCreate' in the Package Manager Console. This will result in two tabels, "Submission" and "SerialNumber". These are both empty.
- Update the database by writing 'Update-Database' in PMC.
- Build the solution by pressing 'Ctrl'+'Shift'+'B'
- To run the application, simply press 'Ctrl'+'F5' (to run without debugging).
- Once the application is run, the 'Program.cs' will check if there are currently anything in the SerialNumber table, if nt, it will generate 100 Guids. 
- Go to 'SQL Server Object Explorer' by pressing 'Ctrl'+'½','Ctrl'+'S' or 'View' -> 'SQL Server Object Explorer'.
- Open 'SQL Server' -> 'Database' -> 'AcmeCorporation.Data' -> 'Tables'.
- Right click on "dbo.SerialNumber" and press "View Data".
- If the table is empty, is might need to be refreshed.
- Use one of the generated Guids to enter the draw.
