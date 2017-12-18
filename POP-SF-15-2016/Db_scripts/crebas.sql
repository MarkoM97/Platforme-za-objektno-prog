CREATE TABLE TipNamestaja(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(80) NOT NULL,
	Obrisan BIT 
)
Go

CREATE TABLE Akcija(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(30),
	PocetakAkcije DATE ,
	ZavrsetakAkcije DATE,
	Popust INT,
	Obrisan BIT

)

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