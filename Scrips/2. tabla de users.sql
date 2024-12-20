CREATE TABLE public."Users"
(
    use_id integer NOT NULL,
    use_name character varying(100),
    use_document character varying(15) NOT NULL,
    PRIMARY KEY (use_id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Users"
    OWNER to postgres;