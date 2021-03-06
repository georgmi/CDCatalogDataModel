USE [CDCatalog]
GO
ALTER TABLE [dbo].[Song] DROP CONSTRAINT [FK_Song_Genre]
GO
ALTER TABLE [dbo].[Song] DROP CONSTRAINT [FK_Song_Artist]
GO
ALTER TABLE [dbo].[Song] DROP CONSTRAINT [FK_Song_Album]
GO
ALTER TABLE [dbo].[PlaylistSong] DROP CONSTRAINT [FK_PlaylistSong_Song]
GO
ALTER TABLE [dbo].[PlaylistSong] DROP CONSTRAINT [FK_PlaylistSong_Playlist]
GO
ALTER TABLE [dbo].[Album] DROP CONSTRAINT [FK_Album_Artist]
GO
/****** Object:  Table [dbo].[Song]    Script Date: 4/16/2015 7:21:07 PM ******/
DROP TABLE [dbo].[Song]
GO
/****** Object:  Table [dbo].[PlaylistSong]    Script Date: 4/16/2015 7:21:07 PM ******/
DROP TABLE [dbo].[PlaylistSong]
GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 4/16/2015 7:21:07 PM ******/
DROP TABLE [dbo].[Playlist]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 4/16/2015 7:21:07 PM ******/
DROP TABLE [dbo].[Genre]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 4/16/2015 7:21:07 PM ******/
DROP TABLE [dbo].[Artist]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 4/16/2015 7:21:07 PM ******/
DROP TABLE [dbo].[Album]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 4/16/2015 7:21:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[AlbumID] [int] IDENTITY(1,1) NOT NULL,
	[AlbumTitle] [nvarchar](50) NOT NULL,
	[Rating] [int] NULL,
	[Year] [int] NOT NULL,
	[ArtistID] [int] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Artist]    Script Date: 4/16/2015 7:21:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[ArtistID] [int] IDENTITY(1,1) NOT NULL,
	[ArtistName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
(
	[ArtistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Genre]    Script Date: 4/16/2015 7:21:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 4/16/2015 7:21:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[PlaylistID] [int] IDENTITY(1,1) NOT NULL,
	[PlaylistName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Playlist] PRIMARY KEY CLUSTERED 
(
	[PlaylistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlaylistSong]    Script Date: 4/16/2015 7:21:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistSong](
	[PlaylistID] [int] NOT NULL,
	[SongID] [int] NOT NULL,
	[SongOrder] [int] NULL,
 CONSTRAINT [PK_PlaylistSong] PRIMARY KEY CLUSTERED 
(
	[PlaylistID] ASC,
	[SongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Song]    Script Date: 4/16/2015 7:21:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Song](
	[SongID] [int] IDENTITY(1,1) NOT NULL,
	[SongTitle] [nvarchar](50) NOT NULL,
	[ArtistID] [int] NOT NULL,
	[AlbumID] [int] NULL,
	[TrackNumber] [int] NOT NULL,
	[GenreID] [int] NOT NULL,
	[TrackLength] [float] NOT NULL,
	[Rating] [int] NULL,
 CONSTRAINT [PK_Song] PRIMARY KEY CLUSTERED 
(
	[SongID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Artist] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([ArtistID])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Artist]
GO
ALTER TABLE [dbo].[PlaylistSong]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistSong_Playlist] FOREIGN KEY([PlaylistID])
REFERENCES [dbo].[Playlist] ([PlaylistID])
GO
ALTER TABLE [dbo].[PlaylistSong] CHECK CONSTRAINT [FK_PlaylistSong_Playlist]
GO
ALTER TABLE [dbo].[PlaylistSong]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistSong_Song] FOREIGN KEY([SongID])
REFERENCES [dbo].[Song] ([SongID])
GO
ALTER TABLE [dbo].[PlaylistSong] CHECK CONSTRAINT [FK_PlaylistSong_Song]
GO
ALTER TABLE [dbo].[Song]  WITH CHECK ADD  CONSTRAINT [FK_Song_Album] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Album] ([AlbumID])
GO
ALTER TABLE [dbo].[Song] CHECK CONSTRAINT [FK_Song_Album]
GO
ALTER TABLE [dbo].[Song]  WITH CHECK ADD  CONSTRAINT [FK_Song_Artist] FOREIGN KEY([ArtistID])
REFERENCES [dbo].[Artist] ([ArtistID])
GO
ALTER TABLE [dbo].[Song] CHECK CONSTRAINT [FK_Song_Artist]
GO
ALTER TABLE [dbo].[Song]  WITH CHECK ADD  CONSTRAINT [FK_Song_Genre] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([GenreID])
GO
ALTER TABLE [dbo].[Song] CHECK CONSTRAINT [FK_Song_Genre]
GO
