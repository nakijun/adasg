-- Dropping the merge articles
use [ADA]
exec sp_dropmergearticle @publication = N'Symbol', @article = N'Category', @force_invalidate_snapshot = 1, @force_reinit_subscription = 1
GO
use [ADA]
exec sp_dropmergearticle @publication = N'Symbol', @article = N'Culture', @force_invalidate_snapshot = 1, @force_reinit_subscription = 1
GO
use [ADA]
exec sp_dropmergearticle @publication = N'Symbol', @article = N'Resource', @force_invalidate_snapshot = 1, @force_reinit_subscription = 1
GO
use [ADA]
exec sp_dropmergearticle @publication = N'Symbol', @article = N'Symbol', @force_invalidate_snapshot = 1, @force_reinit_subscription = 1
GO

-- Dropping the merge publication
use [ADA]
exec sp_dropmergepublication @publication = N'Symbol'
GO

