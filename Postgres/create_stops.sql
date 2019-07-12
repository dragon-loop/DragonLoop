-- Table: drexelbus.route

-- DROP TABLE drexelbus.route;

CREATE TABLE drexelbus.route
(
    route_id integer NOT NULL DEFAULT nextval('drexelbus.route_route_id_seq'::regclass),
    name text COLLATE pg_catalog."default" NOT NULL,
    initial_stop integer NOT NULL,
    final_stop integer NOT NULL,
    stops integer[] NOT NULL,
    CONSTRAINT route_pkey PRIMARY KEY (route_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE drexelbus.route
    OWNER to postgres;