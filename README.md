## Software Engineer Home Assignment

1. I have created one web api(.net core 2.0) that can contain multiple methods for any operation(called from angular web app for import data into database). As i am considering tha requirement , we have csv files from multiple client and have to upload the data into database.

2. We are considering to migrate from MSsql to Mongo DB in future.(I am considering this requirment as well.)

3. I have created one project for handling File data model and entities for database table model.
4. i have used EF core for connection with MS sql server.we can write wrapper for Mongo db and inject Mongo db services for moving from MS Sql to Mongo db.

5. I will create one angular web app for impoting csv data into database.That angular app will call to web api for inserting data into respecttive database.(due to time issue i have not create angular app, In angular app we have to import excel reader nodel module that will convert excel data into list type JSON)

6. We will post the list into web api and import into database.