# ASP.NET-MVC-DapperORM
ASP.NET Model-View-Controller and Dapper ORM, CRUD Operation Using SQL Server Database

#Table and stored procedures["skriptaBazeIProcedura.sql"]
--------------------------------------------
CREATE TABLE [dbo].[Zaposleni](
	[ZaposleniID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](50) NULL,
	[Prezime] [varchar](50) NULL,
	[Pozicija] [varchar](50) NULL,
	[Godine] [int] NULL,
	[Plata] [int] NULL,
 CONSTRAINT [PK_Zaposleni] PRIMARY KEY CLUSTERED 
(
	[ZaposleniID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
--------------------------------------------
CREATE PROCEDURE [dbo].[ZaposleniBrisiPoID]
	@ZaposleniID int
AS
	DELETE FROM Zaposleni
	WHERE ZaposleniID = @ZaposleniID;
============================================
CREATE PROCEDURE [dbo].[ZaposleniDodatiIzmeniti]
(
	@ZaposleniID int,
	@Ime VARCHAR(50),
	@Prezime VARCHAR(50),
	@Pozicija VARCHAR(50),
	@Godine int,
	@Plata int
)
AS

	IF @ZaposleniID = 0
		INSERT INTO Zaposleni(Ime,Prezime,Pozicija,Godine,Plata)
		VALUES (@Ime,@Prezime,@Pozicija,@Godine,@Plata)
	ELSE
		UPDATE Zaposleni
		SET
			Ime = @Ime,
			Prezime = @Prezime,
			Pozicija = @Pozicija,
			Godine = @Godine,
			Plata = @Plata
		WHERE ZaposleniID = @ZaposleniID;
==================================================
CREATE PROCEDURE [dbo].[ZaposleniPregledPoID]
	@ZaposleniID int
AS
	SELECT *
	FROM Zaposleni
	WHERE ZaposleniID = @ZaposleniID
==================================================
CREATE PROCEDURE [dbo].[ZaposleniPregledSvih]
AS
	SELECT *
	FROM Zaposleni;
