-- Table: public.schedules

-- DROP TABLE public.schedules;

CREATE TABLE public.schedules
(
    route_id integer NOT NULL,
    trip_id integer NOT NULL,
    stop_id integer NOT NULL,
    expected_time time without time zone NOT NULL,
    CONSTRAINT schedules_pkey PRIMARY KEY (route_id, trip_id, stop_id),
    CONSTRAINT route_id_fkey FOREIGN KEY (route_id)
        REFERENCES public.routes (route_id) MATCH SIMPLE
        ON UPDATE CASCADE
        ON DELETE RESTRICT,
    CONSTRAINT stop_id_fkey FOREIGN KEY (stop_id)
        REFERENCES public.stops (stop_id) MATCH SIMPLE
        ON UPDATE CASCADE
        ON DELETE RESTRICT
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.schedules
    OWNER to postgres;