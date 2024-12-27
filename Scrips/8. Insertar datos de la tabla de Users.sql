SELECT use_id, use_name, use_document FROM public."Users";

SELECT A.use_id, A.use_name, A.use_document, B.usurol_usu_id, B.usurol_rol_id 
FROM public."Users" A
LEFT JOIN public."UsersInRoles" B ON A.use_id = B.usurol_usu_id
ORDER BY A.use_id, B.usurol_rol_id 


INSERT INTO	public."Users" (use_id, use_name, use_document) VALUES (3, 'Maria Luisa', '42030820');
INSERT INTO public."UsersInRoles" (usurol_usu_id, usurol_rol_id) VALUES (3, 1);
INSERT INTO public."UsersInRoles" (usurol_usu_id, usurol_rol_id) VALUES (3, 4);

INSERT INTO public."UsersInRoles" (usurol_usu_id, usurol_rol_id) VALUES (2, 1);
INSERT INTO public."UsersInRoles" (usurol_usu_id, usurol_rol_id) VALUES (2, 2);

INSERT INTO public."UsersInRoles" (usurol_usu_id, usurol_rol_id) VALUES (1, 3);


-- DELETE FROM public."Users" WHERE use_id = 7;
