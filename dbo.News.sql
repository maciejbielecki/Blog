CREATE TABLE [dbo].[News] (
    [NewsID]    INT             IDENTITY (1, 1) NOT NULL,
    [Intro]     NVARCHAR (200)  NOT NULL,
    [Text]      NVARCHAR (2000) NOT NULL,
    [Category]  NVARCHAR (50)   NOT NULL,
    [NewsTitle] NVARCHAR (50)   NOT NULL,
	[Date] NVARCHAR (50)   NOT NULL,
	[Writer] NVARCHAR (50)   NOT NULL,
	[Visible] BIT, 
    PRIMARY KEY CLUSTERED ([NewsID] ASC)
);

