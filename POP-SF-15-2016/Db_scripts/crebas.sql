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

CREATE TABLE DodatneUsluga(
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
	Namestaj VARCHAR(200),
	DodatneUsluge VARCHAR(100),
	ImeKupca VARCHAR(50),
	UkupnaCena NUMERIC(9,2),
	Obrisan BIT
	FOREIGN KEY (KorisnikId) REFERENCES Korisnik(Id)
)
Go