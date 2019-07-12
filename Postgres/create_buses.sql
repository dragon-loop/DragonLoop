-- Table: public."Buses"

-- DROP TABLE public."Buses";

CREATE TABLE public."Buses"
(
    bus_id integer NOT NULL DEFAULT nextval('bus_bus_id_seq'::regclass),
    x_coordinate numeric NOT NULL,
    y_coordinate numeric NOT NULL,
    route_id integer NOT NULL,
    CONSTRAINT bus_pkey PRIMARY KEY (bus_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Buses"
    OWNER to postgres;