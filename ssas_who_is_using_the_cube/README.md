# SSAS who is using the cube

## Description
Description {PL}
http://pl.seequality.net/ssas-kto-korzysta-z-kostki/

Description {EN}
Not avaliable yet. Will be added soon.

## Installation
1. Create database objects. Execute the scripts from the "database" folder
2. Open the "ssis_get_ssas_sessions_and_connections" solution and adjust the parameter. Set up the connection string to SSAS and destination database
3. Deploy the project to the SSIS catalog
4. Open the script from the "job" folder. Adjust the script to use your SSIS catalog project and execute.
5. Open the report from "ssis_get_ssas_sessions_and_connections" and set up the connection to your database.

Please check the post from the description to see details.
