-- SEQUENCE: public.bus_bus_id_seq

-- DROP SEQUENCE public.bus_bus_id_seq;

CREATE SEQUENCE public.bus_bus_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1;

ALTER SEQUENCE public.bus_bus_id_seq
    OWNER TO postgres;

-- Table: public.buses

-- DROP TABLE public.buses;

CREATE TABLE public.buses
(
    bus_id integer NOT NULL DEFAULT nextval('bus_bus_id_seq'::regclass),
    x_coordinate numeric NOT NULL,
    y_coordinate numeric NOT NULL,
    route_id integer NOT NULL,
    trip_id integer NOT NULL,
    CONSTRAINT bus_pkey PRIMARY KEY (bus_id),
    CONSTRAINT route_id_fkey FOREIGN KEY (route_id)
        REFERENCES public.routes (route_id) MATCH SIMPLE
        ON UPDATE CASCADE
        ON DELETE RESTRICT
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.buses
    OWNER to postgres;