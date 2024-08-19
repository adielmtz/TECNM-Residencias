CREATE INDEX ix_itcm_student_lookup_semester_year ON itcm_student (
    semester,
    strftime('%Y', start_date)
);
