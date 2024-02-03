-- Table: microdados.escolaridade

-- DROP TABLE IF EXISTS microdados.escolaridade;

CREATE TABLE IF NOT EXISTS microdados.escolaridade
(
    "numeroInscricao" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    "situacaiConclusao" character varying(45) COLLATE pg_catalog."default" NOT NULL,
    "tipoConclusao" character varying(45) COLLATE pg_catalog."default" NOT NULL,
    "nomeMunicipio" character varying(250) COLLATE pg_catalog."default" NOT NULL,
    "codigoMunicipio" integer NOT NULL,
    "codigoUF" integer NOT NULL,
    "siglaUF" character varying(2) COLLATE pg_catalog."default" NOT NULL,
    "dependenciaAdministrativa" character varying(45) COLLATE pg_catalog."default" NOT NULL,
    "zonaLocalizacao" character varying(45) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT escolaridade_pkey PRIMARY KEY ("numeroInscricao")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS microdados.escolaridade
    OWNER to postgres;