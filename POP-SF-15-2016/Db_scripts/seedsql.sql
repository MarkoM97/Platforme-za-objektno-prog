INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Krevet', 0);
INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Sto', 0);
INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Police', 0);
INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Regali', 0);
INSERT INTO TipNamestaja(Naziv, Obrisan) VALUES ('Ugaona', 0);

INSERT INTO Akcija(Naziv, PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan) VALUES ('', '0001-01-01', '0001-01-01', 0, 1);
INSERT INTO Akcija(Naziv, PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan) VALUES ('Prolecna', '2018-04-01', '2017-05-02', 15, 0);
INSERT INTO Akcija(Naziv, PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan) VALUES ('Letnja', '2017-04-01', '2017-05-02', 15, 0);
INSERT INTO Akcija(Naziv, PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan) VALUES ('Zimska', '2018-01-01', '2018-02-26', 15, 0);
INSERT INTO Akcija(Naziv, PocetakAkcije, ZavrsetakAkcije, Popust, Obrisan) VALUES ('Jesenja', '2017-04-01', '2017-05-02', 15, 0);


INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv,Sifra, JedinicnaCena, Kolicina, Obrisan) VALUES (1,1, 'Francuski krevet','sf84', 123.5, 22, 0);
INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv,Sifra, JedinicnaCena, Kolicina, Obrisan) VALUES (2,2 ,'Sofija ugaona','sf84', 223.5, 4, 0);
INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv,Sifra, JedinicnaCena, Kolicina, Obrisan) VALUES (3, 3,'Ivan polica','sf84', 850.5, 13, 0);

