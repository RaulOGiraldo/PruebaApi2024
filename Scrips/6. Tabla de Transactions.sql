CREATE TABLE public."Transactions"
(
    tra_id integer NOT NULL,
    tra_pro_id integer NOT NULL,
    tra_date date NOT NULL,
    tra_units numeric NOT NULL,
    "tra_isDeleted" boolean NOT NULL,
	tra_use_id integer NOT NUll,
    CONSTRAINT pk_trans_id PRIMARY KEY (tra_id),
    CONSTRAINT fk_tra_pro_id FOREIGN KEY (tra_pro_id)
        REFERENCES public."Products" (pro_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
	CONSTRAINT fk_tra_use_id FOREIGN KEY (tra_use_id)
        REFERENCES public."Users" (use_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Transactions"
    OWNER to postgres;