INSERT INTO public.stops (x_coordinate, y_coordinate, name, route_id) VALUES
(39.955619, -75.189475,'33rd and Market Streets',1),
(39.956458, -75.164471,'15th & Race Streets',1),
(39.955415, -75.171137,'19th & Arch Streets',1),
(39.954014, -75.176679,'22nd & Market Streets',1),
(39.955619, -75.189475,'33rd & Market Streets',2),
(39.962607, -75.194290,'36th & Spring Garden Streets',2),
(39.958828, -75.206270,'42nd & Powelton Avenue',2),
(39.962607, -75.194290,'36th & Spring Garden Streets',2),
(39.955619, -75.189475,'33rd & Market Streets',2),
(39.956458, -75.164472,'15th and Race Streets',3),
(40.019915, -75.181201,'Queen Lane',3);
UPDATE public."Stops" SET next_stop_id = 2 WHERE stop_id = 1;
UPDATE public."Stops" SET next_stop_id = 3 WHERE stop_id = 2;
UPDATE public."Stops" SET next_stop_id = 4 WHERE stop_id = 3;
UPDATE public."Stops" SET next_stop_id = 1 WHERE stop_id = 4;
UPDATE public."Stops" SET next_stop_id = 6 WHERE stop_id = 5;
UPDATE public."Stops" SET next_stop_id = 7 WHERE stop_id = 6;
UPDATE public."Stops" SET next_stop_id = 8 WHERE stop_id = 7;
UPDATE public."Stops" SET next_stop_id = 9 WHERE stop_id = 8;
UPDATE public."Stops" SET next_stop_id = 5 WHERE stop_id = 9;
UPDATE public."Stops" SET next_stop_id = 11 WHERE stop_id = 10;
UPDATE public."Stops" SET next_stop_id = 10 WHERE stop_id = 11;