USE master;
GO

--Delete the MessageBox Database (IF EXISTS)
IF EXISTS (select * from sys.databases where name = 'MessageBox')
DROP DATABASE MessageBox;
GO

--Create a new MessageBox Database
CREATE DATABASE MessageBox;
GO

--Switch to the MessageBox Database
USE MessageBox
GO

--Create the schema
BEGIN TRANSACTION;

CREATE TABLE topics
(
	id			int				identity(1 , 1),
	display		nvarchar(100)	NOT NULL,
	topic_desc	nvarchar(600)	NOT NULL,
	
	constraint pk_topics primary key(id)
);
CREATE TABLE [messages]
(
	id			int				identity (1 , 1),
	topicId		int				NOT NULL,
	entry_date	datetime		NOT NULL,
	is_deleted	bit				default 0,

	constraint pk_messages primary key(id),
	constraint fk_topic_messages foreign key(topicId) references topics(id)
);

--Seed the database with a General topic to hold new messages.
INSERT INTO topics VALUES('General','This is the Message Box for General Information Topics!');

COMMIT TRANSACTION;