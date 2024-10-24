IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'GamesAsArt')
BEGIN
	CREATE DATABASE GamesAsArt;
END