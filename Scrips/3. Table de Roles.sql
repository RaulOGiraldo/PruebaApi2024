CREATE TABLE public."Roles"
(
    rol_id integer NOT NULL,
    rol_name character varying(100) NOT NULL,
    PRIMARY KEY (rol_id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Roles"
    OWNER to postgres;