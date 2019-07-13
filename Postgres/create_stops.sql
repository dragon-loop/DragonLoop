-- Table: public."Stops"

-- DROP TABLE public."Stops";

CREATE TABLE public."Stops"
(
    stop_id integer NOT NULL DEFAULT nextval('stop_stop_id_seq'::regclass),
    x_coordinate numeric NOT NULL,
    y_coordinate numeric NOT NULL,
    name text COLLATE pg_catalog."default" NOT NULL,
    route_id integer NOT NULL,
    next_stop_id integer,
    CONSTRAINT stop_pkey PRIMARY KEY (stop_id),
    CONSTRAINT next_stop_id_fkey FOREIGN KEY (next_stop_id)
        REFERENCES public."Stops" (stop_id) MATCH SIMPLE
        ON UPDATE CASCADE
        ON DELETE SET NULL,
    CONSTRAINT route_id_fkey FOREIGN KEY (route_id)
        REFERENCES public."Routes" (route_id) MATCH SIMPLE
        ON UPDATE CASCADE
        ON DELETE RESTRICT
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Stops"
    OWNER to postgres;