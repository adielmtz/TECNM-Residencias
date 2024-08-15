ALTER TABLE itcm_student RENAME COLUMN closed TO enabled;

CREATE INDEX ix_itcm_advisor_by_company_lookup ON itcm_advisor (
    company_id,
    name
);

CREATE INDEX ix_itcm_company_sort ON itcm_company (
    name
);
