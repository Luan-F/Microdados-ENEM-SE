-- Table: microdados.provaAreaConhecimento

-- DROP TABLE IF EXISTS microdados."provaAreaConhecimento";

CREATE TABLE IF NOT EXISTS microdados."provaAreaConhecimento"
(
    "numeroInscricao" character varying(20) COLLATE pg_catalog."default" NOT NULL,
    "presencaCN" boolean NOT NULL,
    "presencaCH" boolean NOT NULL,
    "presencaLC" boolean NOT NULL,
    "presencaMT" boolean NOT NULL,
    "codTipoProvaCN" integer,
    "codTipoProvaCH" integer,
    "codTipoProvaLC" integer,
    "codTipoProvaMT" integer,
    "notaCN" real,
    "notaCH" real,
    "notaLC" real,
    "notaMT" real,
    "vetRespCN" character varying(45) COLLATE pg_catalog."default",
    "vetRespCH" character varying(45) COLLATE pg_catalog."default",
    "vetRespLC" character varying(45) COLLATE pg_catalog."default",
    "vetRespMT" character varying(45) COLLATE pg_catalog."default",
    "vetGabCN" character varying(45) COLLATE pg_catalog."default",
    "vetGabCH" character varying(45) COLLATE pg_catalog."default",
    "vetGabLC" character varying(45) COLLATE pg_catalog."default",
    "vetGabMT" character varying(45) COLLATE pg_catalog."default",
    "linguaEstrangeira" character varying(45) COLLATE pg_catalog."default",
    CONSTRAINT "provaAreaConhecimento_pkey" PRIMARY KEY ("numeroInscricao")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS microdados."provaAreaConhecimento"
    OWNER to postgres;