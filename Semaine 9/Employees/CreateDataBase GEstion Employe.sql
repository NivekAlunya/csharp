use GestionEmployes
go

CREATE TABLE Services(
	CodeService		CHAR(5)				CONSTRAINT pk_services PRIMARY KEY,
	Libelle			VARCHAR(30)			NOT NULL
										CONSTRAINT un_services_libelle UNIQUE
)

CREATE TABLE Employes(
	CodeEmp			UNIQUEIDENTIFIER	CONSTRAINT pk_employes PRIMARY KEY,
	Nom				VARCHAR(20)			NOT NULL,
	Prenom			CHAR(20)			NULL,
	DateNaissance   DATETIME            NOT NULL,
	DateEmbauche	DATETIME			NOT NULL DEFAULT GETDATE(),
	DateModif		DATETIME			NULL,
	Salaire			NUMERIC(8,2)		NOT NULL
										CONSTRAINT ck_employes_salaire CHECK (Salaire>=0),
	Photo			IMAGE				NULL,
	CodeService		CHAR(5)				NOT NULL,
	CodeChef		UNIQUEIDENTIFIER	NULL,
	CONSTRAINT ck_employes_dates CHECK (dateNaissance < dateEmbauche),
	CONSTRAINT fk_employes_services FOREIGN KEY (codeService) REFERENCES Services(codeService),
	CONSTRAINT fk_employes_employes FOREIGN KEY (codeChef) REFERENCES Employes(codeEmp)
)

