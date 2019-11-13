-- SEQUENCE: public.route_segments_route_segment_id_seq

-- DROP SEQUENCE public.route_segments_route_segment_id_seq;

CREATE SEQUENCE public.route_segments_route_segment_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1;

ALTER SEQUENCE public.route_segments_route_segment_id_seq
    OWNER TO postgres;

-- Table: public.route_segments

-- DROP TABLE public.route_segments;

CREATE TABLE public.route_segments
(
    route_segment_id integer NOT NULL DEFAULT nextval('route_segments_route_segment_id_seq'::regclass),
    start_x_coordinate numeric NOT NULL,
    start_y_coordinate numeric NOT NULL,
    route_id integer NOT NULL,
    next_route_segment_id integer NOT NULL,
    from_stop_id integer,
    CONSTRAINT route_segments_pkey PRIMARY KEY (route_segment_id),
    CONSTRAINT next_route_segment_id_key UNIQUE (next_route_segment_id)
,
    CONSTRAINT from_stop_id_fkey FOREIGN KEY (from_stop_id)
        REFERENCES public.stops (stop_id) MATCH SIMPLE
        ON UPDATE CASCADE
        ON DELETE SET NULL,
    CONSTRAINT next_route_segment_id_fkey FOREIGN KEY (next_route_segment_id)
        REFERENCES public.route_segments (route_segment_id) MATCH SIMPLE
        ON UPDATE CASCADE
        ON DELETE SET NULL,
    CONSTRAINT route_id_fkey FOREIGN KEY (route_id)
        REFERENCES public.routes (route_id) MATCH SIMPLE
        ON UPDATE CASCADE
        ON DELETE RESTRICT
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.route_segments
    OWNER to postgres;