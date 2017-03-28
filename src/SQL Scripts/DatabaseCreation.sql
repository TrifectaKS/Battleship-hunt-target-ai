--	Database
	--Clean up
	DROP DATABASE	[BattleshipDB];
	GO

	--Creation
	CREATE DATABASE	[BattleshipDB];
	GO

	USE [BattleshipDB];
	GO

--	Tables
	--Clean up
	DROP TABLE	[dbo].[Shots];
	DROP TABLE	[dbo].[Games];
	DROP TABLE	[dbo].[Simulation];
	DROP TABLE	[dbo].[Directions];
	DROP TABLE	[dbo].[Orientations];
	DROP TABLE	[dbo].[ShotTypes];
	DROP TABLE	[dbo].[AIStates];
	DROP TABLE	[dbo].[ShipTypes];
	DROP TABLE	[dbo].[AIType];
	GO

	-- Directions Table
	CREATE TABLE	[dbo].[Directions](
		DirectionId INT NOT NULL PRIMARY KEY,
		Direction	VARCHAR(40) NOT NULL CONSTRAINT UN_Direction UNIQUE
	);
	GO

	-- Orientations Table
	CREATE TABLE	[dbo].[Orientations](
		OrientationId	INT NOT NULL PRIMARY KEY,
		Orientation		VARCHAR(40) NOT NULL CONSTRAINT UN_Orientation UNIQUE
	);
	GO

	-- ShotTypes Table
	CREATE TABLE	[dbo].[ShotTypes](
		ShotTypeId	INT NOT NULL PRIMARY KEY,
		ShotType	VARCHAR(40) NOT NULL CONSTRAINT UN_ShotType UNIQUE
	);
	GO

	-- AIStates Table
	CREATE TABLE	[dbo].[AIStates](
		StateId	INT NOT NULL PRIMARY KEY,
		[State]	VARCHAR(40) NOT NULL CONSTRAINT UN_State UNIQUE
	);
	GO

	-- ShipTypes Table
	CREATE TABLE	[dbo].[ShipTypes](
		ShipTypesId	INT NOT NULL PRIMARY KEY,
		Ship		VARCHAR(40) NOT NULL CONSTRAINT UN_Ship UNIQUE,
		ShipAbbrv	VARCHAR(3)
	);
	GO

	--AIType Table
	CREATE TABLE	[dbo].[AIType](
		AITypeId	INT NOT NULL PRIMARY KEY,
		AIType	VARCHAR(40) NOT NULL CONSTRAINT UN_AIType UNIQUE
	);
	GO

	--Simulation Table
	CREATE TABLE	[dbo].[Simulation](
		SimulationId	UNIQUEIDENTIFIER PRIMARY KEY NONCLUSTERED NOT NULL,
		[Description]	TEXT,
		SimulationDate	DATETIME DEFAULT GETDATE(),
		TimeTakenMS		INT,
		AIType			INT CONSTRAINT FK_AIType REFERENCES [dbo].[AIType](AITypeId)
	);
	GO

	-- Game Table
	CREATE TABLE	[dbo].[Games](
		GameId			UNIQUEIDENTIFIER PRIMARY KEY NONCLUSTERED NOT NULL,
		GameNumber		INT NOT NULL,
		SimulationId	UNIQUEIDENTIFIER NOT NULL CONSTRAINT FK_Simulation REFERENCES [dbo].[Simulation](SimulationId),
		TimeTakenMS		INT,
	);
	GO

	-- Shots Table
	CREATE TABLE	[dbo].[Shots](
		ShotId			UNIQUEIDENTIFIER PRIMARY KEY DEFAULT newsequentialid() NOT NULL,
		GameId			UNIQUEIDENTIFIER NOT NULL CONSTRAINT FK_Game REFERENCES [dbo].[Games](GameId),
		ShipTypeId		INT NOT NULL CONSTRAINT FK_ShipType REFERENCES [dbo].[ShipTypes](ShipTypesId),
		ShotTypeId		INT NOT NULL CONSTRAINT FK_ShotType REFERENCES [dbo].[ShotTypes](ShotTypeId),
		OrientationId	INT CONSTRAINT FK_Orientation REFERENCES [dbo].[Orientations](OrientationId),
		DirectionId		INT CONSTRAINT FK_Direction REFERENCES [dbo].[Directions](DirectionId),
		X				INT NOT NULL,
		Y				INT NOT NULL,
		InitialTargetX	INT,
		InitialTargetY	INT,
		ShotNumber		INT NOT NULL,
		TimeTakenMS		INT,
		AIState			INT NOT NULL CONSTRAINT FK_AIState REFERENCES [dbo].[AIStates](StateId)
	);
	GO

--Inserts

	---Directions Table
	INSERT INTO	[dbo].[Directions](DirectionId, Direction)
		VALUES	(8, 'UP'),
				(2, 'DOWN'),
				(4, 'LEFT'),
				(6, 'RIGHT'),
				(5, 'RANDOM');
	GO

	---Orientations Table
	INSERT INTO	[dbo].[Orientations](OrientationId, Orientation)
		VALUES	(1, 'HORIZONTAL'),
				(2, 'VERTICAL'),
				(3, 'RANDOM');
	GO

	---ShotTypes Table
	INSERT INTO	[dbo].[ShotTypes](ShotTypeId, ShotType)
		VALUES	(0, 'MISSED'),
				(1, 'HIT'),
				(2, 'DESTROYED');
	GO

	--AIStates Table
	INSERT INTO	[dbo].[AIStates](StateId, [State])
		VALUES	(1, 'HUNT'),
				(2, 'TARGET'),
				(3, 'RANDOM');
	GO

	--ShipTypes Table
	INSERT INTO	[dbo].[ShipTypes](ShipTypesId, Ship, ShipAbbrv)
		VALUES	(1, 'Carrier', 'CV'),
				(2, 'Battleship', 'BB'),
				(3, 'Cruiser', 'CL'),
				(4, 'Submarine', 'SS'),
				(5, 'Destroyer', 'DD'),
				(0, 'SEA', 'SEA');
	GO


	select * 
	from dbo.Simulation

	select	*
	from	dbo.Games
	ORDER BY 2
	
	select	*
	from	[dbo].Shots
