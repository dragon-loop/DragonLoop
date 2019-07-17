-- Table: public.routes

-- DROP TABLE public.routes;

CREATE TABLE public.routes
(
    route_id integer NOT NULL DEFAULT nextval('route_route_id_seq'::regclass),
    name text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT route_pkey PRIMARY KEY (route_id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.routes
    OWNER to postgres;