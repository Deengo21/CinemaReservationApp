﻿ALTER TABLE dbo.Reservations
ADD CONSTRAINT FK_Reservations_Screening_screening_id FOREIGN KEY (screening_id) 
REFERENCES dbo.Screening(screening_id)
ON DELETE NO ACTION;