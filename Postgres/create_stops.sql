-- Table: public."Stops"

-- DROP TABLE public."Stops";

CREATE TABLE public."Stops"
(
    stop_id integer NOT NULL DEFAULT nextval('stop_stop_id_seq'::regclass),
    x_coordinate numeric NOT NULL,
    y_coordinate numeric NOT NULL,
    name text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT stop_pkey PRIMARY KEY (stop_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Stops"
    OWNER to postgres;