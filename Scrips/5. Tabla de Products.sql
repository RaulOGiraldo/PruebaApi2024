CREATE TABLE public."Products"
(
    pro_id integer NOT NULL,
    pro_name character varying(100) NOT NULL,
    pro_stock numeric NOT NULL,
    pro_isDeleted boolean NOT NULL,	
    PRIMARY KEY (pro_id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Products"
    OWNER to postgres;