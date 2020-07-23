# SQL Test Assignment

Attached is a mysqldump of a database to be used during the test.

Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.

**Example:**

_Q. Select all users_

- Please return at least first_name and last_name

SELECT first_name, last_name FROM users;


------

**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields
Query: select * from users where id in (2,3,4);
2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium
Query: There is no premium listing column

3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium
Query: There is no premium listing column

4. How much revenue has each active vendor made in 2013(consider active=1)
- Please return at least: first_name, last_name, currency, revenue

Query: select first_name,last_name,currency,sum(price) from users U left join listings L on U.id=L.user_id left join clicks C on L.id=C.listing_id where year(C.created)='2013 'and U.status=1 group by first_name;

5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id
Query: insert into `clicks`(`listing_id`,`price`,`currency`,`created`) values(3,4,'USD','2020-09-15 16:18:43')

6. Show listings that have not received a click in 2013
- Please return at least: listing_name
Query: select name from listings where id not in(select listing_id from clicks where year(created)='2013');

7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected


8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names
Query: 
select GROUP_CONCAT(A.name,',',B.first_name,B.last_name,',') from listings A JOin users B on A.user_id=B.id where user_id in(select id from users where status=1);