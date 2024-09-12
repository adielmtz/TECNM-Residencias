CREATE TRIGGER TGG_Company_After_Insert
AFTER INSERT ON Company
BEGIN
    INSERT INTO CompanySearch (rowid, Rfc, Name)
    VALUES (NEW.Id, NEW.Rfc, NEW.Name);
END;


CREATE TRIGGER TGG_Company_After_Update
AFTER UPDATE ON Company
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


CREATE TRIGGER TGG_Advisor_After_Insert
AFTER INSERT ON Advisor
BEGIN
    INSERT INTO AdvisorSearch (rowid, FirstName, LastName)
    VALUES (NEW.Id, NEW.FirstName, NEW.LastName);
END;


CREATE TRIGGER TGG_Advisor_After_Update
AFTER UPDATE ON Advisor
BEGIN
    UPDATE AdvisorSearch
    SET FirstName = NEW.FirstName, LastName = NEW.LastName
    WHERE rowid = NEW.Id;
END;


CREATE TRIGGER TGG_Advisor_After_Delete
AFTER DELETE ON Advisor
BEGIN
    DELETE FROM AdvisorSearch
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
