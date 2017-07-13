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
	DROP TABLE	[dbo].[Simulations];
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
	CREATE TABLE	[dbo].[Simulations](
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
		SimulationId	UNIQUEIDENTIFIER NOT NULL CONSTRAINT FK_Simulation REFERENCES [dbo].[Simulations](SimulationId),
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
		Val				INT	NOT NULL,
		InitialTargetX	INT,
		InitialTargetY	INT,
		InitialVal		INT,
		ShotNumber		INT NOT NULL,
		TimeTakenMS		INT,
		AIState			INT NOT NULL CONSTRAINT FK_AIState REFERENCES [dbo].[AIStates](StateId)
	);
	GO

--Inserts

	---Directions Table
	INSERT INTO	[dbo].[Directions](DirectionId, Direction)
		VALUES	(1, 'UP'),
				(2, 'DOWN'),
				(3, 'LEFT'),
				(4, 'RIGHT'),
				(0, 'RANDOM');
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

	--AIType Table
	INSERT INTO	[dbo].[AIType]( AITypeId, AIType)
	VALUES	(1, 'RandomAI'),
			(2, 'HuntTargetAI'),
			(3, 'ParityHuntTargetAI')	
	GO


	select * 
	from dbo.Simulations

	select	*
	from	dbo.Games
	ORDER BY 3,2
	
	select	*
	from	[dbo].Shots
	order by 2, shotnumber

	select	gme.GameId,
			gme.GameNumber,
			sht.ShotNumber,
			sty.ShotType,
			ship.Ship
	from	dbo.Simulations sim join
			dbo.games gme on(gme.SimulationId = sim.SimulationId) join
			dbo.Shots sht on (sht.GameId = gme.GameId) join
			dbo.ShotTypes sty on (sht.ShotTypeId = sty.ShotTypeId) join
			dbo.ShipTypes ship on (sht.ShipTypeId = ship.ShipTypesId)
	where sim.AIType = 1 and gme.gamenumber = 50
	order by gameid, shotnumber asc
	
	delete from [dbo].[simulations]
	delete from [dbo].[shots]
	delete from [dbo].[games]