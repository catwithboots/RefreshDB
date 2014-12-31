CREATE ROLE [sqlrefreshdb_owner];
GO

-- Instances
GRANT DELETE ON [dbo].[Instances] TO [sqlrefreshdb_owner];
GO

GRANT INSERT ON [dbo].[Instances] TO [sqlrefreshdb_owner];
GO

GRANT SELECT ON [dbo].[Instances] TO [sqlrefreshdb_owner];
GO

GRANT UPDATE ON [dbo].[Instances] TO [sqlrefreshdb_owner];
GO

-- Environments
GRANT DELETE ON [dbo].[Environments] TO [sqlrefreshdb_owner];
GO

GRANT INSERT ON [dbo].[Environments] TO [sqlrefreshdb_owner];
GO

GRANT SELECT ON [dbo].[Environments] TO [sqlrefreshdb_owner];
GO

GRANT UPDATE ON [dbo].[Environments] TO [sqlrefreshdb_owner];
GO


