CREATE DATABASE LibraryDb;

Use [LibraryDb];

/*Authors*/
CREATE TABLE [dbo].[authors] (
	[AuthorId]	int	IDENTITY(1,1) NOT NULL,
	[Name]		NVARCHAR (50)	NULL,
	[Surname]	NVARCHAR (70)	NULL,
	PRIMARY KEY CLUSTERED ([AuthorId] ASC)
);

/*Genres*/
CREATE TABLE [dbo].[genres] (
	[GenreId]	int	IDENTITY(1,1) NOT NULL,
	[GenreName] NVARCHAR (50) NOT NULL,
	PRIMARY KEY CLUSTERED ([GenreId] ASC)
);

/*Books*/
CREATE TABLE [dbo].[books](
	[BookId]	int	IDENTITY(1,1) NOT NULL,
	[ISBN]		NVARCHAR (13)  NOT NULL,
    [Title]		NVARCHAR (100)  NOT NULL,
	[Comment]	NVARCHAR (500)  NOT NULL,
	[Quantity]	int NOT NULL,
	[Pages]		int	NULL,
	[AuthorId]	int,
	[GenreId]	int,
	PRIMARY KEY CLUSTERED ([BookId] ASC),
	CONSTRAINT [FK_books_authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[authors] ([AuthorId]),
	CONSTRAINT [FK_books_genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[genres] ([GenreId]),
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_books_ISBN]
    ON [dbo].[books]([ISBN] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_books_AuthorId]
    ON [dbo].[books]([AuthorId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_genres_GenreId]
    ON [dbo].[genres]([GenreId] ASC);

/*Readers*/
CREATE TABLE [dbo].[readers](
	[ReaderId]	int	IDENTITY(1,1) NOT NULL,
	[FirstName]	NVARCHAR (50)	NULL,
	[LastName]	NVARCHAR (70)	NULL,
	PRIMARY KEY CLUSTERED ([ReaderId] ASC)
);

/*Borrows*/
CREATE TABLE [dbo].[borrows](
	[BorrowId]		int	IDENTITY(1,1) NOT NULL,
	[ReaderId]		int NOT NULL,
	[BookId]		int NOT NULL,
	[TakenDate]		DATETIME2 (7) NULL,
	[BroughtDate]	DATETIME2 (7) NULL,
	PRIMARY KEY CLUSTERED ([BorrowId] ASC),
	CONSTRAINT [FK_borrows_readers_ReaderId] FOREIGN KEY ([ReaderId]) REFERENCES [dbo].[readers] ([ReaderId]),
	CONSTRAINT [FK_borrows_books_BooksId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[books] ([BookId]),
);

GO
CREATE NONCLUSTERED INDEX [IX_borrows_ReaderId]
    ON [dbo].[borrows]([ReaderId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_borrows_BookId]
    ON [dbo].[borrows]([BookId] ASC);



/***Seed authors***/
GO
SET IDENTITY_INSERT [dbo].[authors] ON 
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (1, N'William Dean', N'Howells')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (2, N'Frederic', N'Brown')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (3, N'Jack', N'London')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (4, N'Albert', N'Blaisdell')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (5, N'Ellis', N'Butler')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (6, N'Arthur', N'Machen')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (7, N'Titus', N'Lucretius')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (8, N'Rabindranath', N'Tagore')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (9, N'Isaac', N'Asimov')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (10, N'Charles', N'Dickens')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (11, N'Ralph Waldo', N'Emerson')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (12, N'Dorothy', N'Canfield')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (13, N'Givoanni', N'Boccaccio')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (14, N'George', N'Orwell')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (15, N'Publius', N'Ovid')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (16, N'Robert Louis', N'Stevenson')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (17, N'Virginia', N'Woolf')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (18, N'George', N'Eliot')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (19, N'Amelia B.', N'Edwards')
INSERT [dbo].[authors] ([authorId], [name], [surname]) VALUES (20, N'Fyodor', N'Dostoevsky')
SET IDENTITY_INSERT [dbo].[authors] OFF

/***Seed Genres***/
GO
SET IDENTITY_INSERT [dbo].[genres] ON 
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (1, N'Science fiction')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (2, N'Satire')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (3, N'Drama')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (4, N'Action and Adventure')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (5, N'Romance')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (6, N'Mystery')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (7, N'Horror')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (8, N'Health')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (9, N'Guide')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (10, N'Diaries')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (11, N'Comics')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (12, N'Diaries')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (13, N'Journals')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (14, N'Biographies')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (15, N'Fantasy')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (16, N'History')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (17, N'Science')
INSERT [dbo].[genres] ([GenreId], [GenreName]) VALUES (18, N'Art')
SET IDENTITY_INSERT [dbo].[genres] OFF

/***Seed books***/

GO
SET IDENTITY_INSERT [dbo].[books] ON 
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (1, N'9783161484100' ,N'A Daughter of the Snows',N'', 40, 1034, 1, 15)
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (2, N'9783161484122' ,N' In Search of Lost Time',N'Swanns Way, the first part of A la recherche de temps perdu, Marcel Proust`s seven-part cycle, was published in 1913. In it, Proust introduces the themes that run through the entire work.', 20, 992, 2, 2)
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (3, N'9783261344123' ,N' Don Quixote',N'Alonso Quixano, a retired country gentleman in his fifties, lives in an unnamed section of La Mancha with his niece and a housekeeper. He has become obsessed with books of chivalry', 10, 500, 3, 1)
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (4, N'9783161444145' ,N'Ulysses',N'Ulysses chronicles the passage of Leopold Bloom through Dublin during an ordinary day, June 16, 1904. ', 31, 104, 3, 14)
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (5, N'9783161484278' ,N'The Great Gatsby',N'The novel chronicles an era that Fitzgerald himself dubbed the "Jazz Age". ', 6, 504, 4, 18)
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (6, N'9783161324091' ,N'Moby Dick',N'First published in 1851, Melvilles masterpiece is, in Elizabeth Hardwicks words,', 5, 612, 5, 11)
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (7, N'9783461484311' ,N'War and Peace',N'Epic in scale, War and Peace delineates in graphic detail events leading up to Napoleons invasion of Russia, and the impact of the Napoleonic era on Tsarist society', 1, 413, 6, 13)
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (8, N'9783141484122' ,N'Hamlet ',N'The Tragedy of Hamlet, Prince of Denmark, or more simply Hamlet, is a tragedy by William Shakespeare, ', 2, 239, 7, 12)
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (9, N'4567134561320' ,N'Lolita',N'The book is internationally famous for its innovative style and infamous for its controversial subject: the protagonist and unreliable narrator, middle aged Humbert Humbert, ', 14, 304, 8, 7)
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (10, N'6783564383121' ,N'The Odyssey',N'The Odyssey is one of two major ancient Greek epic poems attributed to Homer. It is, in part, a sequel to the Iliad, the other work traditionally ascribed to Homer. ', 11, 232, 9, 2)
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (11, N'3783131485100' ,N'Crime and Punishment ',N'It is a murder story, told from a murder;s point of view, that implicates even the most innocent reader in its enormities. ', 10, 804, 10, 5)
INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) 
VALUES (12, N'4524561484100' ,N' The Brothers Karamazov',N'Dostoevskys last and greatest novel, The Karamazov Brothers, is both a brilliantly told crime story and a passionate philosophical debate. ', 20, 504, 11, 3)
SET IDENTITY_INSERT [dbo].[books] OFF

/***Seed readers***/
GO
SET IDENTITY_INSERT [dbo].[readers] ON 
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (1, N'Hazel', N'Green')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (2, N'Ashley', N'Marshall')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (3, N'Ansley', N'Green')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (4, N'Alcock', N'Chapman')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (5, N'Meadow', N'Taylor')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (6, N'Green', N'Wright')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (7, N'Paxton', N'Foster')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (8, N'Gray', N'King')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (9, N'Jones', N'Collins')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (10, N'Leslie', N'Young')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (11, N'Hailey', N'Hill')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (12, N'Washington', N'Martin')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (13, N'Ramirez', N'Green')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (14, N'Morgan', N'Smith')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (15, N'Perez', N'Baker')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (16, N'Alfie', N'Watson')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (17, N'Madison', N'Jackson')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (18, N'Beverly', N'Moore')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (19, N'Kaden', N'Anderson')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (20, N'Carter', N'Adams')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (21, N'Ackland', N'Adams')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (22, N'Hadley', N'Parker')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (23, N'Henderson', N'Cook')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (24, N'Wright', N'Young')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (25, N'Lindsey', N'Wilkinson')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (26, N'Wren', N'Chapman')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (27, N'Love', N'Chapman')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (28, N'Wes', N'Bell')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (29, N'Tyler', N'Carter')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (30, N'Edwin', N'Cook')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (31, N'Sally', N'Wood')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (32, N'Nelson', N'Smith')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (33, N'Arabelle', N'Brown')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (34, N'Carter', N'Harrison')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (35, N'Baker', N'Bell')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (36, N'Cherish', N'Cooper')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (37, N'Remington', N'Wright')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (38, N'Edwards', N'King')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (39, N'Harleigh', N'Taylor')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (40, N'Ryleigh', N'Clark')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (41, N'Albert', N'Richardson')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (42, N'Lee', N'Ward')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (43, N'Kaylin', N'Bell')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (44, N'Agard', N'Young')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (45, N'Turner', N'Hall')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (46, N'Akes', N'White')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (47, N'Lewis', N'Lee')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (48, N'Karson', N'Cook')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (49, N'Hayden', N'Young')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (50, N'Sterling', N'Shaw')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (51, N'Rylan', N'Wright')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (52, N'Abbott', N'Hill')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (53, N'Alcock', N'Turner')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (54, N'Simmons', N'Davis')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (55, N'Jennifer', N'Moore')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (56, N'Reed', N'Ward')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (57, N'Adley', N'Adams')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (58, N'Ainley', N'Young')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (59, N'Ida', N'Gray')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (60, N'Alice', N'Wood')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (61, N'Kim', N'Marshall')
INSERT [dbo].[readers] ([ReaderId], [FirstName], [LastName]) VALUES (62, N'Ainsley', N'Cooper')
SET IDENTITY_INSERT [dbo].[readers] OFF
/***Seed borrows***/
GO
SET IDENTITY_INSERT [dbo].[borrows] ON 
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (1, 1, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (2, 2, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (3, 3, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (4, 4, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (5, 5, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (6, 5, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (7, 6, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (8, 3, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (9, 12, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (10, 44, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (11, 23, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (12, 14, 2, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (13, 61, 5, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (14, 34, 4, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))
INSERT [dbo].[borrows] ([borrowId], [ReaderId], [bookId], [takenDate], [broughtDate]) VALUES (15, 54, 3, CAST(N'2019-08-09 13:26:00.000' AS DateTime), CAST(N'2019-08-20 06:59:00.000' AS DateTime))


SET IDENTITY_INSERT [dbo].[borrows] OFF