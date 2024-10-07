CREATE TRIGGER TGG_Company_After_Insert
AFTER INSERT ON Company
WHEN NEW.Enabled = 1
BEGIN
    INSERT INTO CompanySearch (rowid, Rfc, Name)
    VALUES (NEW.Id, NEW.Rfc, NEW.Name);
END;

CREATE TRIGGER TGG_Company_After_Delete
AFTER DELETE ON Company
BEGIN
    DELETE FROM CompanySearch
    WHERE rowid = OLD.Id;
END;

CREATE TRIGGER TGG_Company_After_Update
AFTER UPDATE ON Company
WHEN OLD.Enabled = 1 AND NEW.Enabled = 1
BEGIN
    UPDATE CompanySearch
    SET Rfc = NEW.Rfc,
        Name = NEW.Name
    WHERE rowid = NEW.Id;
END;

CREATE TRIGGER TGG_Company_After_Update_Remove
AFTER UPDATE ON Company
WHEN NEW.Enabled = 0
BEGIN
    DELETE FROM CompanySearch
    WHERE rowid = NEW.Id;
END;

CREATE TRIGGER TGG_Company_After_Update_Add
AFTER UPDATE ON Company
WHEN OLD.Enabled = 0 AND NEW.Enabled = 1
BEGIN
    INSERT INTO CompanySearch (rowid, Rfc, Name)
    VALUES (NEW.Id, NEW.Rfc, NEW.Name);
END;

CREATE TRIGGER TGG_Advisor_After_Insert
AFTER INSERT ON Advisor
WHEN NEW.Enabled = 1
BEGIN
    INSERT INTO AdvisorSearch (rowid, Internal, FirstName, LastName)
    VALUES (NEW.Id, NEW.Internal, NEW.FirstName, NEW.LastName);
END;

CREATE TRIGGER TGG_Advisor_After_Delete
AFTER DELETE ON Advisor
BEGIN
    DELETE FROM AdvisorSearch
    WHERE rowid = OLD.Id;
END;

CREATE TRIGGER TGG_Advisor_After_Update
AFTER UPDATE ON Advisor
WHEN OLD.Enabled = 1 AND NEW.Enabled = 1
BEGIN
    UPDATE AdvisorSearch
    SET Internal = NEW.Internal,
        FirstName = NEW.FirstName,
        LastName = NEW.LastName
    WHERE rowid = NEW.Id;
END;

CREATE TRIGGER TGG_Advisor_After_Update_Remove
AFTER UPDATE ON Advisor
WHEN NEW.Enabled = 0
BEGIN
    DELETE FROM AdvisorSearch
    WHERE rowid = OLD.Id;
END;

CREATE TRIGGER TGG_Advisor_After_Update_Add
AFTER UPDATE ON Advisor
WHEN OLD.Enabled = 0 AND NEW.Enabled = 1
BEGIN
    INSERT INTO AdvisorSearch (rowid, Internal, FirstName, LastName)
    VALUES (NEW.Id, NEW.Internal, NEW.FirstName, NEW.LastName);
END;

CREATE TRIGGER TGG_Student_After_Insert
AFTER INSERT ON Student
BEGIN
    INSERT INTO StudentSearch (rowid, FirstName, LastName)
    VALUES (NEW.Id, NEW.FirstName, NEW.LastName);
END;

CREATE TRIGGER TGG_Student_After_Update
AFTER UPDATE ON Student
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
