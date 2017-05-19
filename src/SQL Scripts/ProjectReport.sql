use [BattleshipDB]

delete from [dbo].[Shots]
delete from [dbo].[Games]
delete from [dbo].[Simulations]

select	*
from	[dbo].[Simulations]

select	*
from	[dbo].[Games]

select	*
from	[dbo].[Shots]

select	*
from	[dbo].[AIType]

--All simulations + games + shots
select  sim.SimulationId
		--,sim.[Description] as 'Simulation Description'
		, gme.GameNumber as 'Game Number'
		, sht.ShotNumber as 'Shot Number'
		--, sty.ShotType as 'Shot Type'
from	[dbo].[Games] gme
		join [dbo].[Simulations] sim
		on (sim.SimulationId = gme.SimulationId)
		join [dbo].[AIType] ait
		on (ait.AITypeId = sim.AIType)
		join [dbo].[Shots] sht
		on (sht.GameId = gme.GameId)
		join [dbo].[ShotTypes] sty
		on (sty.ShotTypeId = sht.ShotTypeId)
where	sht.ShotTypeId = 1
order by sim.SimulationId, gme.GameNumber, sht.ShotNumber

-- Number of shots per game per simulation
select sim.SimulationId, gme.GameNumber, Count(sht.GameId)
from	[dbo].[Simulations] sim
		join [dbo].[Games] gme
		on (gme.SimulationId = sim.SimulationId)
		join [dbo].[Shots] sht
		on (sht.GameId = gme.GameId)
group by sht.GameId, gme.GameNumber, sim.SimulationId
order by sim.SimulationId, gme.GameNumber

-- Average number of shots per simulation
select shotCount.SimID, Cast(sim.[Description] as varchar(100)) as 'sim desc',  Avg(shotCount.[Count]) as 'avg shots per game'
from(
	select sim.SimulationId as SimID, gme.GameNumber as GameNum, Count(sht.GameId) as [Count]
	from	[dbo].[Simulations] sim
			join [dbo].[Games] gme
			on (gme.SimulationId = sim.SimulationId)
			join [dbo].[Shots] sht
			on (sht.GameId = gme.GameId)
	group by sht.GameId, gme.GameNumber, sim.SimulationId
) shotCount
join [dbo].[Simulations] sim
on (shotCount.SimID = sim.SimulationId)
group by cast(sim.[Description] as varchar(100)), shotCount.SimID
order by 3 desc

--Total shots per simulation
select	Cast(sim.[Description] as varchar(100)) as 'Sim Name', count(sht.GameId) as 'Shot Count'
from	dbo.Simulations sim
		join dbo.Games gme
		on(gme.SimulationId = sim.SimulationId)
		join dbo.Shots sht
		on(sht.GameId = gme.GameId)
group by cast(sim.[Description] as varchar(100))


--Median
select tbl.simid, tbl.simdesc, tbl.shotsnum, Count(tbl.shotsnum) as 'occurances'
from(
select sim.SimulationId as simid, cast(sim.[Description] as varchar(100)) as simdesc, gme.GameNumber as gamenum, Count(sht.GameId) as shotsnum
from	[dbo].[Simulations] sim
		join [dbo].[Games] gme
		on (gme.SimulationId = sim.SimulationId)
		join [dbo].[Shots] sht
		on (sht.GameId = gme.GameId)
group by sht.GameId, gme.GameNumber, sim.SimulationId, cast(sim.[Description] as varchar(100))
--order by sim.SimulationId, gme.GameNumber
) tbl
group by tbl.shotsnum, tbl.simdesc, tbl.simid
order by 1,4