-- Table: microdados.localDeAplicacao

-- DROP TABLE IF EXISTS microdados."localDeAplicacao";

CREATE TABLE IF NOT EXISTS microdados."localDeAplicacao"
(
    "numeroInscricao" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    "nomeMunicipio" character varying(250) COLLATE pg_catalog."default" NOT NULL,
    "codigoMunicipio" integer NOT NULL,
    "codigoUF" integer NOT NULL,
    "siglaUF" character varying(2) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT localdeaplicacao_pkey PRIMARY KEY ("numeroInscricao")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS microdados."localDeAplicacao"
    OWNER to postgres;