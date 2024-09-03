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


CREATE INDEX IX_Document_Lookup ON Document (
    StudentId,
    Type
);


CREATE INDEX IX_Document_Hash ON Document (
    Hash
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
