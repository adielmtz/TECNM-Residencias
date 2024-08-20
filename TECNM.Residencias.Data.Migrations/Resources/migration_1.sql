CREATE TABLE Country (
    Id   INTEGER PRIMARY KEY
                 NOT NULL,
    Name TEXT    UNIQUE
                 NOT NULL
)
STRICT;


CREATE TABLE State (
    Id        INTEGER PRIMARY KEY
                      NOT NULL,
    CountryId INTEGER REFERENCES Country (Id) ON DELETE RESTRICT
                      NOT NULL,
    Name      TEXT    NOT NULL,
    CONSTRAINT AK_State_CountryId UNIQUE (
        CountryId,
        Name
    )
)
STRICT;


CREATE TABLE City (
    Id      INTEGER PRIMARY KEY
                    NOT NULL,
    StateId INTEGER REFERENCES State (Id) ON DELETE RESTRICT
                    NOT NULL,
    Name    TEXT    NOT NULL,
    CONSTRAINT AK_City_StateId UNIQUE (
        StateId,
        Name
    )
)
STRICT;


CREATE TABLE Career (
    Id        INTEGER PRIMARY KEY
                      NOT NULL,
    Name      TEXT    UNIQUE
                      NOT NULL,
    Enabled   INTEGER NOT NULL,
    UpdatedOn TEXT    NOT NULL,
    CreatedOn TEXT    NOT NULL
                      DEFAULT (CURRENT_TIMESTAMP)
)
STRICT;


CREATE TABLE Specialty (
    Id        INTEGER PRIMARY KEY
                      NOT NULL,
    CareerId  INTEGER REFERENCES Career (Id) ON DELETE RESTRICT
                      NOT NULL,
    Name      TEXT    NOT NULL,
    Enabled   INTEGER NOT NULL,
    UpdatedOn TEXT    NOT NULL,
    CreatedOn TEXT    NOT NULL
                      DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT AK_Specialty_Identity UNIQUE (
        CareerId,
        Name
    )
)
STRICT;


CREATE TABLE Company (
    Id         INTEGER PRIMARY KEY
                       NOT NULL,
    Rfc        TEXT    UNIQUE
                       NOT NULL,
    Type       TEXT    NOT NULL,
    Name       TEXT    NOT NULL,
    Email      TEXT    NOT NULL,
    Phone      TEXT    NOT NULL,
    Address    TEXT    NOT NULL,
    Locality   TEXT    NOT NULL,
    PostalCode TEXT    NOT NULL,
    CityId     INTEGER REFERENCES City (Id) ON DELETE RESTRICT
                       NOT NULL,
    Enabled    INTEGER NOT NULL,
    UpdatedOn  TEXT    NOT NULL,
    CreatedOn  TEXT    NOT NULL
                       DEFAULT (CURRENT_TIMESTAMP)
)
STRICT;


CREATE TABLE Advisor (
    Id        INTEGER PRIMARY KEY
                      NOT NULL,
    CompanyId INTEGER REFERENCES Company (Id) ON DELETE RESTRICT
                      NOT NULL,
    Type      TEXT    NOT NULL,
    Name      TEXT    NOT NULL,
    Section   TEXT    NOT NULL,
    Role      TEXT    NOT NULL,
    Email     TEXT    NOT NULL,
    Phone     TEXT    NOT NULL,
    Enabled   INTEGER NOT NULL,
    UpdatedOn TEXT    NOT NULL,
    CreatedOn TEXT    NOT NULL
                      DEFAULT (CURRENT_TIMESTAMP)
)
STRICT;


CREATE TABLE Student (
    Id                          INTEGER PRIMARY KEY
                                        NOT NULL,
    SpecialtyId                 INTEGER REFERENCES Specialty (Id) ON DELETE RESTRICT
                                        NOT NULL,
    FirstName                   TEXT    NOT NULL,
    LastName                    TEXT    NOT NULL,
    Email                       TEXT    UNIQUE
                                        NOT NULL,
    Phone                       TEXT    NOT NULL,
    Gender                      TEXT    NOT NULL,
    Semester                    TEXT    NOT NULL,
    StartDate                   TEXT    NOT NULL,
    EndDate                     TEXT    NOT NULL,
    InternalAdvisorId           INTEGER REFERENCES Advisor (Id) ON DELETE RESTRICT,
    ExternalAdvisorId           INTEGER REFERENCES Advisor (Id) ON DELETE RESTRICT,
    ReviewerAdvisorId           INTEGER REFERENCES Advisor (Id) ON DELETE RESTRICT,
    CompanyId                   INTEGER REFERENCES Company (Id) ON DELETE RESTRICT
                                        NOT NULL,
    Department                  TEXT    NOT NULL,
    Schedule                    TEXT    NOT NULL,
    Notes                       TEXT    NOT NULL,
    HasSocialServiceCertificate INTEGER NOT NULL,
    HasInternshipApplication    INTEGER NOT NULL,
    HasPresentationLetter       INTEGER NOT NULL,
    HasAcceptanceLetter         INTEGER NOT NULL,
    HasProjectDocument          INTEGER NOT NULL,
    Enabled                     INTEGER NOT NULL,
    UpdatedOn                   TEXT    NOT NULL,
    CreatedOn                   TEXT    NOT NULL
                                DEFAULT (CURRENT_TIMESTAMP)
)
STRICT;


CREATE VIRTUAL TABLE CompanySearch USING fts5 (
    Rfc,
    Name,
    content = '',
    contentless_delete = 1,
    tokenize = 'unicode61 remove_diacritics 2'
);


CREATE VIRTUAL TABLE StudentSearch USING fts5 (
    FirstName,
    LastName,
    content = '',
    contentless_delete = 1,
    tokenize = 'unicode61 remove_diacritics 2'
);


CREATE INDEX IX_Advisor_By_Company_Lookup ON Advisor (
    CompanyId,
    Name
);


CREATE INDEX IX_Company_Sort ON Company (
    Name
);


CREATE INDEX IX_Student_Lookup_By_Semester_Expr ON Student (
    Semester,
    strftime('%Y', StartDate)
);


CREATE TRIGGER TGG_Company_After_Insert
AFTER INSERT ON Company
BEGIN
    INSERT INTO CompanySearch (rowid, Rfc, Name)
    VALUES (NEW.Id, NEW.Rfc, NEW.Name);
END;


CREATE TRIGGER TGG_Company_After_Update
AFTER UPDATE ON Company
WHEN NEW.Rfc != OLD.Rfc OR NEW.Name != OLD.Name
BEGIN
    UPDATE CompanySearch
    SET Rfc = NEW.Rfc, Name = NEW.Name
    WHERE rowid = NEW.Id;
END;


CREATE TRIGGER TGG_Company_After_Delete
AFTER DELETE ON Company
BEGIN
    DELETE FROM CompanySearch
    WHERE rowid = OLD.Id;
END;


CREATE TRIGGER TGG_Student_After_Insert
AFTER INSERT ON Student
BEGIN
    INSERT INTO StudentSearch (rowid, FirstName, LastName)
    VALUES (NEW.Id, NEW.FirstName, NEW.LastName);
END;


CREATE TRIGGER TGG_Student_After_Update
AFTER UPDATE ON Student
WHEN NEW.FirstName != OLD.FirstName OR NEW.LastName != OLD.LastName
BEGIN
    UPDATE StudentSearch
    SET FirstName = NEW.FirstName, LastName = NEW.LastName
    WHERE rowid = NEW.Id;
END;


CREATE TRIGGER TGG_Student_After_Delete
AFTER DELETE ON Student
BEGIN
    DELETE FROM StudentSearch
    WHERE rowid = OLD.Id;
END;
