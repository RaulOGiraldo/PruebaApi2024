SELECT pro_id, pro_name, pro_stock, pro_isdeleted FROM public."Products" ORDER BY pro_id;

INSERT INTO public."Products"(pro_id, pro_name, pro_stock, pro_isdeleted)
	VALUES (1, 'Computador de Escritorio', 10, false);
INSERT INTO public."Products"(pro_id, pro_name, pro_stock, pro_isdeleted)
	VALUES (2, 'Laptop', 5, false);	
INSERT INTO public."Products"(pro_id, pro_name, pro_stock, pro_isdeleted)
	VALUES (3 'camara de Video', 5, false);	
	