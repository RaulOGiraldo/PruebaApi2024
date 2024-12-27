SELECT tra_id, tra_pro_id, tra_date, tra_units, "tra_isDeleted", tra_use_id FROM public."Transactions";

INSERT INTO public."Transactions"(tra_id, tra_pro_id, tra_date, tra_units, "tra_isDeleted", tra_use_id)
	VALUES (1, 1, '19/12/2024', 1, false, 1);

-- UPDATE 	public."Transactions" SET "tra_isDeleted" = false WHERE tra_id = 12;