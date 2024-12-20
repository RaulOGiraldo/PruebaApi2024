CREATE TABLE public."UsersInRoles"
(
    usurol_usu_id integer NOT NULL,
    usurol_rol_id integer NOT NULL,
    CONSTRAINT pk_usurol PRIMARY KEY (usurol_usu_id, usurol_rol_id),
    CONSTRAINT fk_usurol_rol FOREIGN KEY (usurol_rol_id)
        REFERENCES public."Roles" (rol_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT fk_usurol_usu FOREIGN KEY (usurol_usu_id)
        REFERENCES public."Users" (use_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."UsersInRoles"
    OWNER to postgres;