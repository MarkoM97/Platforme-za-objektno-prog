INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Krevet', 0);
INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Sto', 0);
INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Police', 0);
INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Regali', 0);
INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Ugaona', 0);

INSERT INTO Akcija(Naziv, PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan) VALUES ('Prolecna', '2017-04-01', '2017-05-02', 15, 0);
INSERT INTO Akcija(Naziv, PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan) VALUES ('Letnja', '2017-04-01', '2017-05-02', 15, 0);
INSERT INTO Akcija(Naziv, PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan) VALUES ('Zimska', '2017-04-01', '2017-05-02', 15, 0);
INSERT INTO Akcija(Naziv, PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan) VALUES ('Jesenja', '2017-04-01', '2017-05-02', 15, 0);

INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv, JedinicnaCena, Kolicina, Obrisan) VALUES (1,1, 'Francuski krevet', 123.5, 22, 0);
INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv, JedinicnaCena, Kolicina, Obrisan) VALUES (2,2 ,'Sofija ugaona', 223.5, 4, 0);
INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv, JedinicnaCena, Kolicina, Obrisan) VALUES (3, 3,'Ivan polica', 850.5, 13, 0);

