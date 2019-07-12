-- Table: drexelbus.buses

-- DROP TABLE drexelbus.buses;

CREATE TABLE drexelbus.buses
(
    bus_id integer NOT NULL DEFAULT nextval('drexelbus.bus_bus_id_seq'::regclass),
    x_coordinate numeric NOT NULL,
    y_coordinate numeric NOT NULL,
    route_id integer NOT NULL,
    CONSTRAINT bus_pkey PRIMARY KEY (bus_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE drexelbus.buses
    OWNER to postgres;