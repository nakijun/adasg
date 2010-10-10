-- Dropping the merge articles
use [ADA]
exec sp_dropmergearticle @publication = N'Schedule', @article = N'UserLevel', @force_invalidate_snapshot = 1, @force_reinit_subscription = 1
GO
use [ADA]
exec sp_dropmergearticle @publication = N'Schedule', @article = N'Schedule', @force_invalidate_snapshot = 1, @force_reinit_subscription = 1
GO
use [ADA]
exec sp_dropmergearticle @publication = N'Schedule', @article = N'User', @force_invalidate_snapshot = 1, @force_reinit_subscription = 1
GO
use [ADA]
exec sp_dropmergearticle @publication = N'Schedule', @article = N'Device', @force_invalidate_snapshot = 1, @force_reinit_subscription = 1
GO
use [ADA]
exec sp_dropmergearticle @publication = N'Schedule', @article = N'Reminder', @force_invalidate_snapshot = 1, @force_reinit_subscription = 1
GO
use [ADA]
exec sp_dropmergearticle @publication = N'Schedule', @article = N'Activity', @force_invalidate_snapshot = 1, @force_reinit_subscription = 1
GO
use [ADA]
exec sp_dropmergearticle @publication = N'Schedule', @article = N'Activity_Reminder', @force_invalidate_snapshot = 1, @force_reinit_subscription = 1
GO

-- Dropping the merge publication
use [ADA]
exec sp_dropmergepublication @publication = N'Schedule'
GO

