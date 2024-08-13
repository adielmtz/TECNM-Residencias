CREATE TABLE loc_country (
    id   INTEGER PRIMARY KEY
                 NOT NULL,
    name TEXT    UNIQUE
                 NOT NULL
)
STRICT;

CREATE TABLE loc_state (
    id         INTEGER PRIMARY KEY
                       NOT NULL,
    country_id INTEGER REFERENCES loc_country (id) ON DELETE RESTRICT
                       NOT NULL,
    name       TEXT    NOT NULL,
    CONSTRAINT ak_loc_state_identity UNIQUE (
        country_id,
        name
    )
)
STRICT;

CREATE TABLE loc_city (
    id       INTEGER PRIMARY KEY
                     NOT NULL,
    state_id INTEGER REFERENCES loc_state (id) ON DELETE RESTRICT
                     NOT NULL,
    name     TEXT    NOT NULL,
    CONSTRAINT ak_loc_city_identity UNIQUE (
        state_id,
        name
    )
)
STRICT;

CREATE TABLE itcm_career (
    id         INTEGER PRIMARY KEY
                       NOT NULL,
    name       TEXT    UNIQUE
                       NOT NULL,
    enabled    INTEGER NOT NULL,
    updated_on TEXT    NOT NULL,
    created_on TEXT    NOT NULL
                       DEFAULT (CURRENT_TIMESTAMP)
)
STRICT;

CREATE TABLE itcm_specialty (
    id         INTEGER PRIMARY KEY
                       NOT NULL,
    career_id  INTEGER REFERENCES itcm_career (id) ON DELETE RESTRICT
                       NOT NULL,
    name       TEXT    NOT NULL,
    enabled    INTEGER NOT NULL,
    updated_on TEXT    NOT NULL,
    created_on TEXT    NOT NULL
                       DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT ak_itcm_specialty_identity UNIQUE (
        career_id,
        name
    )
)
STRICT;

CREATE TABLE itcm_company (
    id          INTEGER PRIMARY KEY
                        NOT NULL,
    rfc         TEXT    UNIQUE
                        NOT NULL,
    type        TEXT    NOT NULL,
    name        TEXT    NOT NULL,
    email       TEXT    NOT NULL,
    phone       TEXT    NOT NULL,
    address     TEXT    NOT NULL,
    locality    TEXT    NOT NULL,
    postal_code TEXT    NOT NULL,
    city_id     INTEGER REFERENCES loc_city (id) ON DELETE RESTRICT
                        NOT NULL,
    enabled     INTEGER NOT NULL,
    updated_on  TEXT    NOT NULL,
    created_on  TEXT    NOT NULL
                        DEFAULT (CURRENT_TIMESTAMP)
)
STRICT;

CREATE TABLE itcm_advisor (
    id         INTEGER PRIMARY KEY
                       NOT NULL,
    company_id INTEGER REFERENCES itcm_company (id) ON DELETE RESTRICT
                       NOT NULL,
    type       TEXT    NOT NULL,
    name       TEXT    NOT NULL,
    section    TEXT    NOT NULL,
    role       TEXT    NOT NULL,
    email      TEXT    NOT NULL,
    phone      TEXT    NOT NULL,
    enabled    INTEGER NOT NULL,
    updated_on TEXT    NOT NULL,
    created_on TEXT    NOT NULL
                       DEFAULT (CURRENT_TIMESTAMP)
)
STRICT;

CREATE TABLE itcm_student (
    id                  INTEGER PRIMARY KEY
                                NOT NULL,
    specialty_id        INTEGER REFERENCES itcm_specialty (id) ON DELETE RESTRICT
                                NOT NULL,
    first_name          TEXT    NOT NULL,
    last_name           TEXT    NOT NULL,
    email               TEXT    UNIQUE
                                NOT NULL,
    phone               TEXT    NOT NULL,
    gender              TEXT    NOT NULL,
    semester            TEXT    NOT NULL,
    start_date          TEXT    NOT NULL,
    end_date            TEXT    NOT NULL,
    internal_advisor_id INTEGER REFERENCES itcm_advisor (id) ON DELETE RESTRICT,
    external_advisor_id INTEGER REFERENCES itcm_advisor (id) ON DELETE RESTRICT,
    reviewer_advisor_id INTEGER REFERENCES itcm_advisor (id) ON DELETE RESTRICT,
    company_id          INTEGER REFERENCES itcm_company (id) ON DELETE RESTRICT
                                NOT NULL,
    department          TEXT    NOT NULL,
    schedule            TEXT    NOT NULL,
    closed              INTEGER NOT NULL,
    notes               TEXT    NOT NULL,
    updated_on          TEXT    NOT NULL,
    created_on          TEXT    NOT NULL
                                DEFAULT (CURRENT_TIMESTAMP)
)
STRICT;

CREATE VIRTUAL TABLE itcm_company_search USING fts5 (
    rfc,
    name,
    content = '',
    contentless_delete = 1,
    tokenize = 'unicode61 remove_diacritics 2'
);

CREATE VIRTUAL TABLE itcm_student_search USING fts5 (
    first_name,
    last_name,
    content = '',
    contentless_delete = 1,
    tokenize = 'unicode61 remove_diacritics 2'
);
