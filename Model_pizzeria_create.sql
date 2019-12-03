-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2019-11-20 16:12:56.74

-- tables
-- Table: Administrator
CREATE TABLE Administrator (
    id_Admin int  NOT NULL,
    Imie varchar(20)  NOT NULL,
    Nazwisko varchar(20)  NOT NULL,
    Login varchar(20)  NOT NULL,
    Haslo varchar(20)  NOT NULL,
    adres_email varchar(20)  NOT NULL,
    CONSTRAINT Administrator_pk PRIMARY KEY  (id_Admin)
);

-- Table: Ciasto
CREATE TABLE Ciasto (
    id_Ciasta int  NOT NULL,
    nazwa varchar(20)  NOT NULL,
    cena_Ciasta int  NOT NULL,
    CONSTRAINT Ciasto_pk PRIMARY KEY  (id_Ciasta)
);

-- Table: Dostawca
CREATE TABLE Dostawca (
    id_Dostawcy int  NOT NULL,
    adres varchar(20)  NOT NULL,
    CONSTRAINT Dostawca_pk PRIMARY KEY  (id_Dostawcy)
);

-- Table: Pizza
CREATE TABLE Pizza (
    id_Pizza int  NOT NULL,
    Ciasto_id_Ciasta int  NOT NULL,
    nazwa varchar(20)  NOT NULL,
    cena_Pizza int  NOT NULL,
    rodzaj_Pizzy varchar(20)  NOT NULL,
    CONSTRAINT Pizza_pk PRIMARY KEY  (id_Pizza)
);

-- Table: Pizza_skladnik
CREATE TABLE Pizza_skladnik (
    Skladnik_id_Skladnik int  NOT NULL,
    Pizza_id_Pizza int  NOT NULL,
    CONSTRAINT Pizza_skladnik_pk PRIMARY KEY  (Skladnik_id_Skladnik,Pizza_id_Pizza)
);

-- Table: Promocja
CREATE TABLE Promocja (
    id_Promocja int  NOT NULL,
    nazwa varchar(20)  NOT NULL,
    procent_rabatu int  NOT NULL,
    CONSTRAINT Promocja_pk PRIMARY KEY  (id_Promocja)
);

-- Table: Skladnik
CREATE TABLE Skladnik (
    id_Skladnik int  NOT NULL,
    nazwa varchar(20)  NOT NULL,
    cena_Skladnika int  NOT NULL,
    CONSTRAINT Skladnik_pk PRIMARY KEY  (id_Skladnik)
);

-- Table: Stan
CREATE TABLE Stan (
    id_Stan int  NOT NULL,
    nazwa varchar(20)  NOT NULL,
    pozostaly_Czas time(100)  NOT NULL,
    CONSTRAINT Stan_pk PRIMARY KEY  (id_Stan)
);

-- Table: Zamowienie
CREATE TABLE Zamowienie (
    id_Zamowienie int  NOT NULL,
    Stan_id_Stan int  NOT NULL,
    Dostawca_id_Dostawcy int  NOT NULL,
    Promocja_id_Promocja int  NOT NULL,
    Pizza_id_Pizza int  NOT NULL,
    cena_Zamownienia int  NOT NULL,
    nr_tel int  NOT NULL,
    adres_email varchar(20)  NOT NULL,
    CONSTRAINT Zamowienie_pk PRIMARY KEY  (id_Zamowienie)
);

-- foreign keys
-- Reference: Pizza_Ciasto (table: Pizza)
ALTER TABLE Pizza ADD CONSTRAINT Pizza_Ciasto
    FOREIGN KEY (Ciasto_id_Ciasta)
    REFERENCES Ciasto (id_Ciasta);

-- Reference: Pizza_skladnik_Pizza (table: Pizza_skladnik)
ALTER TABLE Pizza_skladnik ADD CONSTRAINT Pizza_skladnik_Pizza
    FOREIGN KEY (Pizza_id_Pizza)
    REFERENCES Pizza (id_Pizza);

-- Reference: Pizza_skladnik_Skladnik (table: Pizza_skladnik)
ALTER TABLE Pizza_skladnik ADD CONSTRAINT Pizza_skladnik_Skladnik
    FOREIGN KEY (Skladnik_id_Skladnik)
    REFERENCES Skladnik (id_Skladnik);

-- Reference: Zamowienie_Dostawca (table: Zamowienie)
ALTER TABLE Zamowienie ADD CONSTRAINT Zamowienie_Dostawca
    FOREIGN KEY (Dostawca_id_Dostawcy)
    REFERENCES Dostawca (id_Dostawcy);

-- Reference: Zamowienie_Pizza (table: Zamowienie)
ALTER TABLE Zamowienie ADD CONSTRAINT Zamowienie_Pizza
    FOREIGN KEY (Pizza_id_Pizza)
    REFERENCES Pizza (id_Pizza);

-- Reference: Zamowienie_Promocja (table: Zamowienie)
ALTER TABLE Zamowienie ADD CONSTRAINT Zamowienie_Promocja
    FOREIGN KEY (Promocja_id_Promocja)
    REFERENCES Promocja (id_Promocja);

-- Reference: Zamowienie_Stan_Zamowienia (table: Zamowienie)
ALTER TABLE Zamowienie ADD CONSTRAINT Zamowienie_Stan_Zamowienia
    FOREIGN KEY (Stan_id_Stan)
    REFERENCES Stan (id_Stan);

-- End of file.

