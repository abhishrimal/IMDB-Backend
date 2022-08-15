CREATE TABLE [Gender]
(
	GenderId int not null identity(1,1),
	Gender nvarchar(10) not null,
	Primary Key(GenderId)
)

CREATE TABLE [Actor]
(
	ActorId int not null identity(1,1),
	ActorName varchar(100) not null,
	Bio nvarchar(100) null,
	DateOfBirth Date null,
	GenderId int not null,
	CreatedOn DateTime not null default GetDate(),
	UpdatedOn DateTime not null default GetDate(),
	Foreign Key(GenderId) References Gender(GenderId),
	Primary Key(ActorId)
)

CREATE TABLE [Poster]
(
	PosterId int not null identity(1,1),
	Poster varbinary(max) null,
	Primary Key(PosterId)
)

CREATE TABLE [Producer]
(
	ProducerId int not null identity(1,1),
	ProducerName varchar(100) not null,
	Bio nvarchar(100) null,
	DateOfBirth Date null,
	CompanyName nvarchar(100) null,
	GenderId int not null,
	CreatedOn DateTime not null default GetDate(),
	UpdatedOn DateTime not null default GetDate(),
	Primary Key(ProducerId)
)

CREATE TABLE [Movie]
(
	MovieId int not null identity(1,1),
	MovieName nvarchar(100) not null,
	Plot nvarchar(max) null,
	DateOfRelease date null,
	ProducerId int not null,
	PosterId int not null,
	Foreign Key(ProducerId) References Producer(ProducerId),
	Foreign Key(PosterId) References Poster(PosterId),
	Primary Key(MovieId)	
)

Create Table [ActorMovieMappings]
(
	ActorMovieMappingId int not null identity(1,1),
	MovieId int not null,
	ActorId int not null,
	CreatedOn datetime not null default GetDate(),
	UpdatedOn datetime not null default GetDate(),
	Foreign Key(MovieId) References Movie(MovieId),
	Foreign key(ActorId) References Actor(ActorId),
	Primary Key(ActorMovieMappingId)
)