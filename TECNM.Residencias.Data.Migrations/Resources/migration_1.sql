CREATE TABLE Country (
    Id   INTEGER PRIMARY KEY AUTOINCREMENT
                 NOT NULL,
    Name TEXT    UNIQUE
                 NOT NULL
)
STRICT;

CREATE TABLE State (
    Id        INTEGER PRIMARY KEY AUTOINCREMENT
                      NOT NULL,
    CountryId INTEGER REFERENCES Country (Id) ON DELETE RESTRICT
                      NOT NULL,
    Name      TEXT    NOT NULL,
    CONSTRAINT AK_State_Identity UNIQUE (
        CountryId,
        Name
    )
)
STRICT;

CREATE TABLE City (
    Id      INTEGER PRIMARY KEY AUTOINCREMENT
                    NOT NULL,
    StateId INTEGER REFERENCES State (Id) ON DELETE RESTRICT
                    NOT NULL,
    Name    TEXT    NOT NULL,
    CONSTRAINT AK_City_Identity UNIQUE (
        StateId,
        Name
    )
)
STRICT;

CREATE TABLE Setting (
    Name      TEXT PRIMARY KEY
                   NOT NULL,
    Value     TEXT NOT NULL,
    UpdatedOn TEXT NOT NULL,
    CreatedOn TEXT NOT NULL
                   DEFAULT (CURRENT_TIMESTAMP) 
)
WITHOUT ROWID,
STRICT;

CREATE TABLE Career (
    Id        INTEGER PRIMARY KEY AUTOINCREMENT
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
    Id        INTEGER PRIMARY KEY AUTOINCREMENT
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

CREATE TABLE CompanyType (
    Id    INTEGER PRIMARY KEY AUTOINCREMENT
                  NOT NULL,
    Label TEXT    UNIQUE
                  NOT NULL
)
STRICT;

CREATE TABLE Company (
    Id         INTEGER PRIMARY KEY AUTOINCREMENT
                       NOT NULL,
    TypeId     INTEGER REFERENCES CompanyType (Id) ON DELETE RESTRICT
                       NOT NULL,
    Rfc        TEXT    UNIQUE,
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
    Id        INTEGER PRIMARY KEY AUTOINCREMENT
                      NOT NULL,
    CompanyId INTEGER REFERENCES Company (Id) ON DELETE RESTRICT
                      NOT NULL,
    Internal  INTEGER NOT NULL,
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

CREATE TABLE Gender (
    Id    INTEGER PRIMARY KEY AUTOINCREMENT
                  NOT NULL,
    Label TEXT    UNIQUE
                  NOT NULL
)
STRICT;

CREATE TABLE Student (
    Id                INTEGER PRIMARY KEY AUTOINCREMENT
                              NOT NULL,
    SpecialtyId       INTEGER REFERENCES Specialty (Id) ON DELETE RESTRICT
                              NOT NULL,
    FirstName         TEXT    NOT NULL,
    LastName          TEXT    NOT NULL,
    Email             TEXT    UNIQUE
                              NOT NULL,
    Phone             TEXT    NOT NULL,
    GenderId          INTEGER REFERENCES Gender (Id) ON DELETE RESTRICT
                              NOT NULL,
    Semester          TEXT    NOT NULL,
    StartDate         TEXT    NOT NULL,
    EndDate           TEXT    NOT NULL,
    Project           TEXT    NOT NULL,
    CompanyId         INTEGER REFERENCES Company (Id) ON DELETE RESTRICT
                              NOT NULL,
    InternalAdvisorId INTEGER REFERENCES Advisor (Id) ON DELETE RESTRICT,
    ExternalAdvisorId INTEGER REFERENCES Advisor (Id) ON DELETE RESTRICT,
    ReviewerAdvisorId INTEGER REFERENCES Advisor (Id) ON DELETE RESTRICT,
    Section           TEXT    NOT NULL,
    Schedule          TEXT    NOT NULL,
    Notes             TEXT    NOT NULL,
    Closed            INTEGER NOT NULL,
    UpdatedOn         TEXT    NOT NULL,
    CreatedOn         TEXT    NOT NULL
                              DEFAULT (CURRENT_TIMESTAMP) 
)
STRICT;

CREATE TABLE DocumentType (
    Id       INTEGER PRIMARY KEY AUTOINCREMENT
                     NOT NULL,
    Label    TEXT    UNIQUE
                     NOT NULL,
    Tag      TEXT    NOT NULL,
    Keywords TEXT    NOT NULL
)
STRICT;

CREATE TABLE Document (
    Id           INTEGER PRIMARY KEY AUTOINCREMENT
                         NOT NULL,
    StudentId    INTEGER REFERENCES Student (Id) ON DELETE RESTRICT
                         NOT NULL,
    TypeId       INTEGER REFERENCES DocumentType (Id) ON DELETE RESTRICT
                         NOT NULL,
    FullPath     TEXT    NOT NULL,
    OriginalName TEXT    NOT NULL,
    Size         INTEGER NOT NULL,
    Hash         TEXT    NOT NULL,
    CreatedOn    TEXT    NOT NULL
                         DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT AK_Document_Identity UNIQUE (
        StudentId,
        TypeId,
        FullPath
    )
)
STRICT;

CREATE TABLE ExtraType (
    Id    INTEGER PRIMARY KEY AUTOINCREMENT
                  NOT NULL,
    Label TEXT    UNIQUE
                  NOT NULL
)
STRICT;

CREATE TABLE Extra (
    Id     INTEGER PRIMARY KEY AUTOINCREMENT
                   NOT NULL,
    TypeId INTEGER REFERENCES ExtraType (Id) ON DELETE RESTRICT
                   NOT NULL,
    Value  TEXT    NOT NULL,
    CONSTRAINT AK_Extra_Identity UNIQUE (
        TypeId,
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
    CompanyId,
    Internal,
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
