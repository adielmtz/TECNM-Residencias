CREATE TRIGGER tgg_itcm_company_insert
AFTER INSERT ON itcm_company
BEGIN
    INSERT INTO itcm_company_search (rowid, rfc, name)
    VALUES (NEW.id, NEW.rfc, NEW.name);
END;

CREATE TRIGGER tgg_itcm_company_update
AFTER UPDATE ON itcm_company
WHEN NEW.rfc != OLD.rfc OR NEW.name != OLD.name
BEGIN
    UPDATE itcm_company_search
    SET rfc = NEW.rfc, name = NEW.name
    WHERE rowid = NEW.id;
END;

CREATE TRIGGER tgg_itcm_company_delete
AFTER DELETE ON itcm_company
BEGIN
    DELETE FROM itcm_company_search
    WHERE rowid = OLD.id;
END;

CREATE TRIGGER tgg_itcm_student_insert
AFTER INSERT ON itcm_student
BEGIN
    INSERT INTO itcm_student_search (rowid, first_name, last_name)
    VALUES (NEW.id, NEW.first_name, NEW.last_name);
END;

CREATE TRIGGER tgg_itcm_student_update
AFTER UPDATE ON itcm_student
WHEN NEW.first_name != OLD.first_name OR NEW.last_name != OLD.last_name
BEGIN
    UPDATE itcm_student_search
    SET first_name = NEW.first_name, last_name = NEW.last_name
    WHERE rowid = NEW.id;
END;

CREATE TRIGGER tgg_itcm_student_delete
AFTER DELETE ON itcm_student
BEGIN
    DELETE FROM itcm_student_search
    WHERE rowid = OLD.id;
END;
