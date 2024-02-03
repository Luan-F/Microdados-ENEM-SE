-- Table: microdados.usuario

-- DROP TABLE IF EXISTS microdados.usuario;

CREATE TABLE IF NOT EXISTS microdados.usuario
(
    "idUsuario" integer NOT NULL DEFAULT nextval('microdados."participante_idUsuario_seq"'::regclass),
    "isAdministrador" boolean NOT NULL,
    nome character varying(45) COLLATE pg_catalog."default" NOT NULL,
    email character varying(45) COLLATE pg_catalog."default" NOT NULL,
    senha character varying(45) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT participante_pkey PRIMARY KEY ("idUsuario")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS microdados.usuario
    OWNER to postgres;