 CREATE VIEW dbo.xpGrid_View
AS
SELECT TOP 100 PERCENT dbo.xpGrid_User.UserName, dbo.Bl_Personnel_All.name, 
      dbo.xpGrid_User.Online, dbo.xpGrid_User.LoginTimes, 
      dbo.xpGrid_User.LastOnlineTime, dbo.xpGrid_User.AllOnlineTime, 
      dbo.xpGrid_User.LastOprtnDateTime
FROM dbo.Bl_Personnel_All INNER JOIN
      dbo.xpGrid_User ON 
      dbo.Bl_Personnel_All.nameno = dbo.xpGrid_User.UserName
ORDER BY dbo.xpGrid_User.Online DESC, dbo.xpGrid_User.LastOprtnDateTime DESC

