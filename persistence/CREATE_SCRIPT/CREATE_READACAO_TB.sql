-- Table: microdados.redacao

-- DROP TABLE IF EXISTS microdados.redacao;

CREATE TABLE IF NOT EXISTS microdados.redacao
(
    "numeroInscricao" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    "statusRedacao" character varying(45) COLLATE pg_catalog."default" NOT NULL,
    "notaComp1" real,
    "notaComp2" real,
    "notaComp3" real,
    "notaComp4" real,
    "notaComp5" real,
    "notaRedacao" real,
    CONSTRAINT redacao_pkey PRIMARY KEY ("numeroInscricao")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS microdados.redacao
    OWNER to postgres;