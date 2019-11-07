-- SEQUENCE: public.stop_stop_id_seq

-- DROP SEQUENCE public.stop_stop_id_seq;

CREATE SEQUENCE public.stop_stop_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1;

ALTER SEQUENCE public.stop_stop_id_seq
    OWNER TO postgres;

-- Table: public.stops

-- DROP TABLE public.stops;

CREATE TABLE public.stops
(
    stop_id integer NOT NULL DEFAULT nextval('stop_stop_id_seq'::regclass),
    x_coordinate numeric NOT NULL,
    y_coordinate numeric NOT NULL,
    name text COLLATE pg_catalog."default" NOT NULL,
    route_id integer NOT NULL,
    first_stop_flg boolean NOT NULL,
    CONSTRAINT stop_pkey PRIMARY KEY (stop_id),
    CONSTRAINT route_id_fkey FOREIGN KEY (route_id)
        REFERENCES public.routes (route_id) MATCH SIMPLE
        ON UPDATE CASCADE
        ON DELETE RESTRICT
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.stops
    OWNER to postgres;