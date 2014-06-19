INSERT [services] ([codeService], [libelle]) VALUES (N'COMPT', N'Comptabilité')
INSERT [services] ([codeService], [libelle]) VALUES (N'INFOR', N'Informatique')
INSERT [services] ([codeService], [libelle]) VALUES (N'RESHU', N'Ressources humaines')


INSERT [employes] ([codeEmp], [nom], [prenom], [dateNaissance], [dateEmbauche], [dateModif], [salaire], [photo], [codeService], [codeChef]) VALUES (N'a40a6693-f807-40a7-93dd-338730f5c72a', N'PATRON', N'Quentin', CAST(0x000050EA00000000 AS DateTime), CAST(0x000079A300000000 AS DateTime), NULL, CAST(67200.00 AS Numeric(8, 2)), NULL, N'RESHU', NULL)
INSERT [employes] ([codeEmp], [nom], [prenom], [dateNaissance], [dateEmbauche], [dateModif], [salaire], [photo], [codeService], [codeChef]) VALUES (N'cc53ac6d-0988-49ca-8444-7d45a398fb0c', N'DUPONT', N'Henri', CAST(0x000061E200000000 AS DateTime), CAST(0x0000812B00000000 AS DateTime), NULL, CAST(42000.00 AS Numeric(8, 2)), NULL, N'INFOR', N'a40a6693-f807-40a7-93dd-338730f5c72a')
INSERT [employes] ([codeEmp], [nom], [prenom], [dateNaissance], [dateEmbauche], [dateModif], [salaire], [photo], [codeService], [codeChef]) VALUES (N'4cebbd4b-29b6-41f0-a44f-5ffda9fec066', N'DURAND', N'Jean', CAST(0x000062BA00000000 AS DateTime), CAST(0x000081F900000000 AS DateTime), NULL, CAST(36000.00 AS Numeric(8, 2)), NULL, N'INFOR', N'cc53ac6d-0988-49ca-8444-7d45a398fb0c')
INSERT [employes] ([codeEmp], [nom], [prenom], [dateNaissance], [dateEmbauche], [dateModif], [salaire], [photo], [codeService], [codeChef]) VALUES (N'74829015-badd-4e06-a3b4-224b26584491', N'MARTIN', N'Alban', CAST(0x00006BAA00000000 AS DateTime), CAST(0x000091BE00000000 AS DateTime), NULL, CAST(23462.76 AS Numeric(8, 2)), NULL, N'COMPT', N'a40a6693-f807-40a7-93dd-338730f5c72a')
