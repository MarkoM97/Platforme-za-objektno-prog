CREATE TABLE TipNamestaja(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(80) NOT NULL,
	Obrisan BIT 
)
Go

CREATE TABLE Akcija(
	Id INT PRIMARY KEY IDENTITY(0,1),
	Naziv VARCHAR(30),
	PocetakAkcije DATE ,
	ZavrsetakAkcije DATE,
	Popust INT,
	Obrisan BIT
)
Go

CREATE TABLE Namestaj (
	Id INT PRIMARY KEY IDENTITY(1,1),
	TipNamestajaId INT,
	AkcijaId INT,
	Naziv VARCHAR(80),
	Sifra VARCHAR(50),
	JedinicnaCena NUMERIC(9,2),
	Kolicina INT,
	Obrisan BIT,
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id),
	FOREIGN KEY (AkcijaId) REFERENCES Akcija(Id)
)
Go

CREATE TABLE DodatnaUsluga(
	Id INT PRIMARY KEY  IDENTITY(1,1),
	Naziv VARCHAR(50),
	Cena NUMERIC(9,2),
	Obrisan BIT
)
Go

CREATE TABLE Korisnik (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Ime VARCHAR(50),
	Prezime VARCHAR(50),
	KorisnickoIme VARCHAR(50),
	Lozinka VARCHAR(50),
	TipKorisnika BIT,
	Obrisan BIT
)
Go

CREATE TABLE Racun(
	Id INT PRIMARY KEY IDENTITY(1,1),
	KorisnikId INT,
	ImeKupca VARCHAR(50),
	UkupnaCena NUMERIC(9,2),
	DatumProdaje DATE,
	Obrisan BIT
	FOREIGN KEY (KorisnikId) REFERENCES Korisnik(Id)
)
Go

CREATE TABLE StavkeRacuna(
	Id INT PRIMARY KEY IDENTITY(1,1),
	RacunId INT,
	NamestajId INT,
	BrojKomada INT,
	FOREIGN KEY (RacunId) REFERENCES Racun(Id),
	FOREIGN KEY (NamestajId) REFERENCES Namestaj(Id)
)
Go

CREATE TABLE UslugeRacuna(
	RacunId INT,
	UslugaId INT,
	FOREIGN KEY (RacunId) REFERENCES Racun(Id),
	FOREIGN KEY (UslugaId) REFERENCES DodatnaUsluga(Id),
	PRIMARY KEY (RacunId, UslugaId)
)
Go