USE [BazaCRUD]
GO
/****** Object:  Table [dbo].[Zaposleni]    Script Date: 01.02.2021. 20:08:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[ZaposleniBrisiPoID]    Script Date: 01.02.2021. 20:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ZaposleniBrisiPoID]
	@ZaposleniID int
AS
	DELETE FROM Zaposleni
	WHERE ZaposleniID = @ZaposleniID;
GO
/****** Object:  StoredProcedure [dbo].[ZaposleniDodatiIzmeniti]    Script Date: 01.02.2021. 20:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[ZaposleniPregledPoID]    Script Date: 01.02.2021. 20:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ZaposleniPregledPoID]
	@ZaposleniID int
AS
	SELECT *
	FROM Zaposleni
	WHERE ZaposleniID = @ZaposleniID
GO
/****** Object:  StoredProcedure [dbo].[ZaposleniPregledSvih]    Script Date: 01.02.2021. 20:08:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ZaposleniPregledSvih]
AS
	SELECT *
	FROM Zaposleni;
GO
