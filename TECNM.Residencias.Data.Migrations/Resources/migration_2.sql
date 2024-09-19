CREATE INDEX IX_Company_Sort ON Company (
    Name
);


CREATE INDEX IX_Advisor_By_Company_Lookup ON Advisor (
    CompanyId,
    Type,
    FirstName,
    LastName
);


CREATE INDEX IX_Student_Last_Modified ON Student (
    UpdatedOn
);


CREATE INDEX IX_Student_Internship_Period ON Student (
    StartDate,
    EndDate
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


CREATE INDEX IX_StudentExtras_ExtraId ON StudentExtras (
    ExtraId
);
