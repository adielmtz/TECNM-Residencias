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


CREATE TABLE Setting (
    Id        INTEGER PRIMARY KEY
                      NOT NULL,
    Name      TEXT    UNIQUE
                      NOT NULL,
    Value     TEXT    NOT NULL,
    UpdatedOn TEXT    NOT NULL,
    CreatedOn TEXT    NOT NULL
                      DEFAULT (CURRENT_TIMESTAMP) 
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
    Rfc        TEXT    UNIQUE,
    Type       TEXT    NOT NULL,
    Name       TEXT    NOT NULL,
    Email      TEXT    NOT NULL,
    Phone      TEXT    NOT NULL,
    Extension  TEXT    NOT NULL,
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
    FirstName TEXT    NOT NULL,
    LastName  TEXT    NOT NULL,
    Section   TEXT    NOT NULL,
    Role      TEXT    NOT NULL,
    Email     TEXT    NOT NULL,
    Phone     TEXT    NOT NULL,
    Extension TEXT    NOT NULL,
    Enabled   INTEGER NOT NULL,
    UpdatedOn TEXT    NOT NULL,
    CreatedOn TEXT    NOT NULL
                      DEFAULT (CURRENT_TIMESTAMP) 
)
STRICT;


CREATE TABLE Student (
    Id                INTEGER PRIMARY KEY
                              NOT NULL,
    SpecialtyId       INTEGER REFERENCES Specialty (Id) ON DELETE RESTRICT
                              NOT NULL,
    FirstName         TEXT    NOT NULL,
    LastName          TEXT    NOT NULL,
    Email             TEXT    UNIQUE
                              NOT NULL,
    Phone             TEXT    NOT NULL,
    Gender            TEXT    NOT NULL,
    Semester          TEXT    NOT NULL,
    StartDate         TEXT    NOT NULL,
    EndDate           TEXT    NOT NULL,
    Project           TEXT    NOT NULL,
    InternalAdvisorId INTEGER REFERENCES Advisor (Id) ON DELETE RESTRICT,
    ExternalAdvisorId INTEGER REFERENCES Advisor (Id) ON DELETE RESTRICT,
    ReviewerAdvisorId INTEGER REFERENCES Advisor (Id) ON DELETE RESTRICT,
    CompanyId         INTEGER REFERENCES Company (Id) ON DELETE RESTRICT
                              NOT NULL,
    Department        TEXT    NOT NULL,
    Schedule          TEXT    NOT NULL,
    Notes             TEXT    NOT NULL,
    Enabled           INTEGER NOT NULL,
    UpdatedOn         TEXT    NOT NULL,
    CreatedOn         TEXT    NOT NULL
                              DEFAULT (CURRENT_TIMESTAMP) 
)
STRICT;


CREATE TABLE Document (
    Id           INTEGER PRIMARY KEY
                         NOT NULL,
    StudentId    INTEGER REFERENCES Student (Id) ON DELETE CASCADE
                         NOT NULL,
    Type         INTEGER NOT NULL,
    FullPath     TEXT    UNIQUE
                         NOT NULL,
    OriginalName TEXT    NOT NULL,
    Size         INTEGER NOT NULL,
    Hash         TEXT    NOT NULL,
    Enabled      INTEGER NOT NULL,
    UpdatedOn    TEXT    NOT NULL,
    CreatedOn    TEXT    NOT NULL
                         DEFAULT (CURRENT_TIMESTAMP) 
)
STRICT;


CREATE TABLE Extra (
    Id        INTEGER PRIMARY KEY
                      NOT NULL,
    Type      TEXT    NOT NULL,
    Value     TEXT    NOT NULL,
    UpdatedOn TEXT    NOT NULL,
    CreatedOn TEXT    NOT NULL
                      DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT AK_Extra_Identity UNIQUE (
        Type,
        Value
    )
)
STRICT;


CREATE TABLE StudentExtras (
    StudentId INTEGER REFERENCES Student (Id) ON DELETE CASCADE
                      NOT NULL,
    ExtraId   INTEGER REFERENCES Extra (Id) ON DELETE CASCADE
                      NOT NULL,
    CONSTRAINT PK_StudentExtras PRIMARY KEY (
        StudentId,
        ExtraId
    )
)
WITHOUT ROWID,
STRICT;


CREATE VIRTUAL TABLE CompanySearch USING fts5 (
    Rfc,
    Name,
    content = '',
    contentless_delete = 1,
    tokenize = 'unicode61 remove_diacritics 2'
);


CREATE VIRTUAL TABLE AdvisorSearch USING fts5 (
    FirstName,
    LastName,
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
