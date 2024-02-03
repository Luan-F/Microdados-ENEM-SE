-- Table: microdados.participante

-- DROP TABLE IF EXISTS microdados.participante;

CREATE TABLE IF NOT EXISTS microdados.participante
(
    "numeroInscrica" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    "anoEnem" integer NOT NULL,
    "faixaEtaria" character varying(45) COLLATE pg_catalog."default" NOT NULL,
    sexo character varying(45) COLLATE pg_catalog."default" NOT NULL,
    "estadoCivil" character varying(45) COLLATE pg_catalog."default" NOT NULL,
    raca character varying(45) COLLATE pg_catalog."default" NOT NULL,
    nacionalidade character varying(45) COLLATE pg_catalog."default" NOT NULL,
    treineiro boolean NOT NULL
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS microdados.participante
    OWNER to postgres;