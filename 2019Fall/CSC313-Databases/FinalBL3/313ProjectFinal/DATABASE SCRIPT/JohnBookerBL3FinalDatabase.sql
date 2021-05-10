/*
John Booker
Borderlands 3 Weapons database for Final Project
CSC313
12/9/19
*/


CREATE DATABASE bl3weapons; 

USE bl3weapons;

/*Table structure for table `weapons` */

DROP TABLE IF EXISTS weapons;
#Surround some of the names with ` so they wont mess with internal SQL commands/syntax
CREATE TABLE weapons (
	`wepid` INT AUTO_INCREMENT,
  `name`  varchar(100) NOT NULL,#Long, just in case they get crazy with a name
  `type` VARCHAR(30) NOT NULL,
  `ele` VARCHAR(15) NOT NULL,
  `pre` VARCHAR(30),
  `alien` CHAR(1) NOT NULL,#Y on N for yes or no
  PRIMARY KEY (`wepid`)
);



/*Sample Data for the table `weapons` */
/*Real data and repeat data so searches can yield some results.
I would eventually want to have a submission acceptance process, so the same
gun name isn't spelled 14 differemt ways and repeats wouldn't be an  issue.*/
insert  into `weapons`(`name`,`type`,`ele`,`pre`, `alien`) 
	VALUES ('Infinity', 'Pistol', 'None', NULL, 'N'),
	('Infinity', 'Pistol', 'Shock', NULL, 'N'),
	('Infinity', 'Pistol', 'Corrosive', 'Rapid', 'N'),
	('Infinity', 'Pistol', 'None', NULL, 'N'),
	('Infinity', 'Pistol', 'Cryo', NULL, 'N'),
	('Damned', 'Assault Rifle', 'None', NULL, 'Y'),
	('Infinity', 'Pistol', 'None', NULL, 'N'),
	('Infinity', 'Pistol', 'Radiation', NULL, 'N'),
	('Tsunami', 'SMG', 'None', NULL, 'N'),
	('Phebert', 'Shotgun', 'Radiation', NULL, 'N'),
	('The Lob', 'Shotgun', 'None', NULL, 'Y'),
	('Lyuda', 'Sniper', 'Fire', NULL, 'N'),
	('Hive', 'Rocket Launcher', 'Radiation', NULL, 'N'),
	('Infinity', 'Pistol', 'Shock', NULL, 'N'),
	('Infinity', 'Pistol', 'Corrosive', 'Rapid', 'N'),
	('Infinity', 'Pistol', 'None', NULL, 'N'),
	('Infinity', 'Pistol', 'Cryo', NULL, 'N'),
	('Damned', 'Assault Rifle', 'None', NULL, 'Y'),
	('Infinity', 'Pistol', 'None', NULL, 'N'),
	('Infinity', 'Pistol', 'Radiation', NULL, 'N'),
	('Tsunami', 'SMG', 'None', NULL, 'N'),
	('Phebert', 'Shotgun', 'Radiation', NULL, 'N'),
	('The Lob', 'Shotgun', 'None', NULL, 'Y'),
	('Lyuda', 'Sniper', 'Fire', NULL, 'N'),
	('Hive', 'Rocket Launcher', 'Radiation', NULL, 'N'),
	('Infinity', 'Pistol', 'Fire', NULL, 'N');



