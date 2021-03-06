use ReviefyDB;

GO
CREATE TABLE Users
(
	user_id uniqueidentifier NOT NULL,
	password NVARCHAR(255) NOT NULL,
	email NVARCHAR(255) NOT NULL,
	nickname NVARCHAR(255) NOT NULL,
	register_date DATE NOT NULL,
	avatar_path NVARCHAR(255),
	CONSTRAINT pk_user PRIMARY KEY(user_id)
)
GO

GO
CREATE TABLE Movies
(
	movie_id uniqueidentifier NOT NULL,
	title NVARCHAR(255) NOT NULL, 
	duration INT NOT NULL check(duration >= 0),
	genre NVARCHAR(255) NOT NULL,
	release_date DATE NOT NULL,
	rating FLOAT NOT NULL default(0),
	storyline TEXT NOT NULL,
	director NVARCHAR(255) NOT NULL default('unknown'),
	budget INT NOT NULL check(budget >= 0),
	country NVARCHAR(255) NOT NULL,
	[language] NVARCHAR(255) NOT NULL,
	company NVARCHAR(255) NOT NULL default('unknown'),
	poster_path NVARCHAR(255),
	trailer_path NVARCHAR(255)

	CONSTRAINT pk_movie PRIMARY KEY(movie_id)
)
GO

GO
CREATE TABLE MoviePhotos
(
	photos_id uniqueidentifier NOT NULL,
	movie_id uniqueidentifier NOT NULL,
	background NVARCHAR(255) NOT NULL default(''),
	photo1 NVARCHAR(255) NOT NULL default(''),
	photo2 NVARCHAR(255) NOT NULL default(''),
	photo3 NVARCHAR(255) NOT NULL default(''),
	photo4 NVARCHAR(255) NOT NULL default(''),
	photo5 NVARCHAR(255) NOT NULL default(''),
	photo6 NVARCHAR(255) NOT NULL default(''),
	photo7 NVARCHAR(255) NOT NULL default(''),
	photo8 NVARCHAR(255) NOT NULL default(''),
	photo9 NVARCHAR(255) NOT NULL default(''),
	CONSTRAINT pk_moviePhoto PRIMARY KEY(photos_id),
	CONSTRAINT fk_moviePhoto_movie FOREIGN KEY(movie_id)
		REFERENCES Movies(movie_id)
		on delete cascade on update cascade
)
GO

GO
CREATE TABLE Reviews
(
	review_id uniqueidentifier NOT NULL,
	user_id uniqueidentifier NOT NULL,
	movie_id uniqueidentifier NOT NULL,
	[text] TEXT NOT NULL,
	review_date DATE NOT NULL, 
	rating INT NOT NULL DEFAULT(0),
	helpfulness INT NOT NULL DEFAULT(0),

	CONSTRAINT pk_review PRIMARY KEY(review_id),
	CONSTRAINT fk_review_user FOREIGN KEY(user_id)
		REFERENCES Users(user_id)
		on delete cascade on update cascade,
	CONSTRAINT fk_review_movie FOREIGN KEY(movie_id)
		REFERENCES Movies(movie_id)
		on delete cascade on update cascade
)
GO

GO
CREATE TABLE News
(
	news_id uniqueidentifier NOT NULL,
	poster_path NVARCHAR(255),
	title NVARCHAR(255) NOT NULL, 
	news_date DATE NOT NULL,
	[text] TEXT NOT NULL

	CONSTRAINT pk_news PRIMARY KEY(news_id)
)
GO