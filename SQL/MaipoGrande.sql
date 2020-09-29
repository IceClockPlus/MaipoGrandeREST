CREATE TABLE Rol(
Id_Rol INTEGER PRIMARY KEY,
Nombre_Rol VARCHAR2(15) NOT NULL
);

CREATE TABLE Usuario(
Id_Usuario INTEGER PRIMARY KEY,
Nombre_Usuario VARCHAR2(30) NOT NULL,
Contrasenia VARCHAR2(99) NOT NULL,
Is_Habilitado CHAR(1) NOT NULL,
Id_Rol INTEGER NOT NULL
);

CREATE TABLE Pais(
Id_Pais INTEGER PRIMARY KEY,
Nombre_Pais VARCHAR2(50)
);


--Llave foranea de columna Id_Rol Usuario
ALTER TABLE Usuario ADD CONSTRAINT fk_id_rol_usuario 
FOREIGN KEY(Id_Rol) REFERENCES Rol(Id_Rol);

--Limitar valores que adquiere IS_HABILITADO
ALTER TABLE Usuario ADD CONSTRAINT chk_habilitado_usuario
CHECK(Is_Habilitado IN('0','1'));

--Inserción de los roles del sistema--
INSERT ALL
INTO ROL VALUES(1,'Administrador')
INTO ROL VALUES(2,'Cliente Interno')
INTO ROL VALUES(3,'Cliente Externo')
INTO ROL VALUES(4,'Productor')
INTO ROL VALUES(5,'Transportista')
INTO ROL VALUES(6,'Consultor')
SELECT 1 FROM DUAL;

--SECUENCIA PARA LAS ID DE USUARIO
CREATE SEQUENCE SEQ_USUARIO
INCREMENT BY 1
START WITH 1
NOCYCLE
NOCACHE;


INSERT INTO USUARIO VALUES(seq_usuario.nextval,'AleAravenam','supergrenade','1',1);
INSERT INTO USUARIO VALUES(seq_usuario.nextval,'MatPacheco','hollowknight','1',3);
--Insercion de Paises


INSERT ALL 
INTO PAIS VALUES(1, 'Australia')
INTO PAIS VALUES(2, 'Austria')
INTO PAIS VALUES(3, 'Azerbaiyán')
INTO PAIS VALUES(4, 'Anguilla')
INTO PAIS VALUES(5, 'Argentina')
INTO PAIS VALUES(6, 'Armenia')
INTO PAIS VALUES(7, 'Bielorrusia')
INTO PAIS VALUES(8, 'Belice')
INTO PAIS VALUES(9, 'Bélgica')
INTO PAIS VALUES(10, 'Bermudas')
INTO PAIS VALUES(11, 'Bulgaria')
INTO PAIS VALUES(12, 'Brasil')
INTO PAIS VALUES(13, 'Reino Unido')
INTO PAIS VALUES(14, 'Hungría')
INTO PAIS VALUES(15, 'Vietnam')
INTO PAIS VALUES(16, 'Haiti')
/*INTO PAIS VALUES(17, 'Guadalupe')*/--Ultramar
INTO PAIS VALUES(18, 'Alemania')
INTO PAIS VALUES(19, 'Países Bajos, Holanda')
INTO PAIS VALUES(20, 'Grecia')
INTO PAIS VALUES(21, 'Georgia')
INTO PAIS VALUES(22, 'Dinamarca')
INTO PAIS VALUES(23, 'Egipto')
INTO PAIS VALUES(24, 'Israel')
INTO PAIS VALUES(25, 'India')
INTO PAIS VALUES(26, 'Irán')
INTO PAIS VALUES(27, 'Irlanda')
INTO PAIS VALUES(28, 'España')
INTO PAIS VALUES(29, 'Italia')
INTO PAIS VALUES(30, 'Kazajstán')
INTO PAIS VALUES(31, 'Camerún')
INTO PAIS VALUES(32, 'Canadá')
INTO PAIS VALUES(33, 'Chipre')
INTO PAIS VALUES(34, 'Kirguistán')
INTO PAIS VALUES(35, 'China')
INTO PAIS VALUES(36, 'Costa Rica')
INTO PAIS VALUES(37, 'Kuwait')
INTO PAIS VALUES(38, 'Letonia')
INTO PAIS VALUES(39, 'Libia')
INTO PAIS VALUES(40, 'Lituania')
INTO PAIS VALUES(41, 'Luxemburgo')
INTO PAIS VALUES(42, 'México')
INTO PAIS VALUES(43, 'Moldavia')
INTO PAIS VALUES(44, 'Mónaco')
INTO PAIS VALUES(45, 'Nueva Zelanda')
INTO PAIS VALUES(46, 'Noruega')
INTO PAIS VALUES(47, 'Polonia')
INTO PAIS VALUES(48, 'Portugal')
/*INTO PAIS VALUES(49, 'Reunión')*/--Territorio Ultramar
INTO PAIS VALUES(50, 'Rusia')
INTO PAIS VALUES(51, 'El Salvador')
INTO PAIS VALUES(52, 'Eslovaquia')
INTO PAIS VALUES(53, 'Eslovenia')
INTO PAIS VALUES(54, 'Surinam')
INTO PAIS VALUES(55, 'Estados Unidos')
INTO PAIS VALUES(56, 'Tadjikistan')
INTO PAIS VALUES(57, 'Turkmenistan')
/*INTO PAIS VALUES(58, 'Islas Turcas y Caicos')*/--Territorio Ultramar
INTO PAIS VALUES(59, 'Turquía')
INTO PAIS VALUES(60, 'Uganda')
INTO PAIS VALUES(61, 'Uzbekistán')
INTO PAIS VALUES(62, 'Ucrania')
INTO PAIS VALUES(63, 'Finlandia')
INTO PAIS VALUES(64, 'Francia')
INTO PAIS VALUES(65, 'República Checa')
INTO PAIS VALUES(66, 'Suiza')
INTO PAIS VALUES(67, 'Suecia')
INTO PAIS VALUES(68, 'Estonia')
INTO PAIS VALUES(69, 'Corea del Sur')
INTO PAIS VALUES(70, 'Japón')
INTO PAIS VALUES(71, 'Croacia')
INTO PAIS VALUES(72, 'Rumanía')
INTO PAIS VALUES(73, 'Hong Kong')--Zona Administrativa Especial China
INTO PAIS VALUES(74, 'Indonesia')
INTO PAIS VALUES(75, 'Jordania')
INTO PAIS VALUES(76, 'Malasia')
INTO PAIS VALUES(77, 'Singapur')
INTO PAIS VALUES(78, 'Taiwan')
INTO PAIS VALUES(79, 'Bosnia y Herzegovina')
INTO PAIS VALUES(80, 'Bahamas')
INTO PAIS VALUES(81, 'Chile')
INTO PAIS VALUES(82, 'Colombia')
INTO PAIS VALUES(83, 'Islandia')
INTO PAIS VALUES(84, 'Corea del Norte')
INTO PAIS VALUES(85, 'Macedonia')
INTO PAIS VALUES(86, 'Malta')
INTO PAIS VALUES(87, 'Pakistán')
INTO PAIS VALUES(88, 'Papúa-Nueva Guinea')
INTO PAIS VALUES(89, 'Perú')
INTO PAIS VALUES(90, 'Filipinas')
INTO PAIS VALUES(91, 'Arabia Saudita')
INTO PAIS VALUES(92, 'Tailandia')
INTO PAIS VALUES(93, 'Emiratos árabes Unidos')
INTO PAIS VALUES(94, 'Groenlandia')
INTO PAIS VALUES(95, 'Venezuela')
INTO PAIS VALUES(96, 'Zimbabwe')
INTO PAIS VALUES(97, 'Kenia')
INTO PAIS VALUES(98, 'Algeria')
INTO PAIS VALUES(99, 'Líbano')
INTO PAIS VALUES(100, 'Botsuana')
INTO PAIS VALUES(101, 'Tanzania')
INTO PAIS VALUES(102, 'Namibia')
INTO PAIS VALUES(103, 'Ecuador')
INTO PAIS VALUES(104, 'Marruecos')
INTO PAIS VALUES(105, 'Ghana')
INTO PAIS VALUES(106, 'Siria')
INTO PAIS VALUES(107, 'Nepal')
INTO PAIS VALUES(108, 'Mauritania')
/*INTO PAIS VALUES(109, 'Seychelles')*/--Irrelevante
INTO PAIS VALUES(110, 'Paraguay')
INTO PAIS VALUES(111, 'Uruguay')
INTO PAIS VALUES(112, 'Congo')
INTO PAIS VALUES(113, 'Cuba')
INTO PAIS VALUES(114, 'Albania')
INTO PAIS VALUES(115, 'Nigeria')
INTO PAIS VALUES(116, 'Zambia')
INTO PAIS VALUES(117, 'Mozambique')
INTO PAIS VALUES(119, 'Angola')
INTO PAIS VALUES(120, 'Sri Lanka')
INTO PAIS VALUES(121, 'Etiopía')
INTO PAIS VALUES(122, 'Túnez')
INTO PAIS VALUES(123, 'Bolivia')
INTO PAIS VALUES(124, 'Panamá')
INTO PAIS VALUES(125, 'Malawi')
INTO PAIS VALUES(126, 'Liechtenstein')
INTO PAIS VALUES(127, 'Bahrein')
INTO PAIS VALUES(128, 'Barbados')
INTO PAIS VALUES(130, 'Chad')
INTO PAIS VALUES(131, 'Man, Isla de')
INTO PAIS VALUES(132, 'Jamaica')
INTO PAIS VALUES(133, 'Malí')
INTO PAIS VALUES(134, 'Madagascar')
INTO PAIS VALUES(135, 'Senegal')
INTO PAIS VALUES(136, 'Togo')
INTO PAIS VALUES(137, 'Honduras')
INTO PAIS VALUES(138, 'República Dominicana')
INTO PAIS VALUES(139, 'Mongolia')
INTO PAIS VALUES(140, 'Irak')
INTO PAIS VALUES(141, 'Sudáfrica')
INTO PAIS VALUES(142, 'Aruba')
/*INTO PAIS VALUES(143, 'Gibraltar')*/--Ultramar
INTO PAIS VALUES(144, 'Afganistán')
INTO PAIS VALUES(145, 'Andorra')
INTO PAIS VALUES(147, 'Antigua y Barbuda')
INTO PAIS VALUES(149, 'Bangladesh')
INTO PAIS VALUES(151, 'Benín')
INTO PAIS VALUES(152, 'Bután')
/*INTO PAIS VALUES(154, 'Islas Virgenes Británicas')*/--Ultramar
INTO PAIS VALUES(155, 'Brunéi')
INTO PAIS VALUES(156, 'Burkina Faso')
INTO PAIS VALUES(157, 'Burundi')
INTO PAIS VALUES(158, 'Camboya')
INTO PAIS VALUES(159, 'Cabo Verde')
INTO PAIS VALUES(164, 'Comores')
INTO PAIS VALUES(165, 'Republica Democratica del Congo)')
/*INTO PAIS VALUES(166, 'Cook, Islas')*/
INTO PAIS VALUES(168, 'Costa de Marfil')
/*INTO PAIS VALUES(169, 'Djibouti, Yibuti')*/
INTO PAIS VALUES(171, 'Timor Oriental')
INTO PAIS VALUES(172, 'Guinea Ecuatorial')
INTO PAIS VALUES(173, 'Eritrea')
/*INTO PAIS VALUES(175, 'Feroe, Islas')*/
INTO PAIS VALUES(176, 'Fiyi')
/*INTO PAIS VALUES(178, 'Polinesia Francesa')*/--Ultramar
INTO PAIS VALUES(180, 'Gabón')
INTO PAIS VALUES(181, 'Gambia')
INTO PAIS VALUES(184, 'Granada')
INTO PAIS VALUES(185, 'Guatemala')
/*INTO PAIS VALUES(186, 'Guernsey')*/
INTO PAIS VALUES(187, 'Guinea')
INTO PAIS VALUES(188, 'Guinea-Bissau')
INTO PAIS VALUES(189, 'Guyana')
/*INTO PAIS VALUES(193, 'Jersey')*/
INTO PAIS VALUES(195, 'Kiribati')
INTO PAIS VALUES(196, 'Laos')
INTO PAIS VALUES(197, 'Lesotho')
INTO PAIS VALUES(198, 'Liberia')
INTO PAIS VALUES(200, 'Maldivas')
/*INTO PAIS VALUES(201, 'Martinica')*/
/*INTO PAIS VALUES(202, 'Mauricio')/*
INTO PAIS VALUES(205, 'Myanmar')
INTO PAIS VALUES(206, 'Nauru')
/*INTO PAIS VALUES(207, 'Antillas Holandesas')*/
/*INTO PAIS VALUES(208, 'Nueva Caledonia')*/
INTO PAIS VALUES(209, 'Nicaragua')
INTO PAIS VALUES(210, 'Níger')
/*INTO PAIS VALUES(212, 'Norfolk Island')*/
INTO PAIS VALUES(213, 'Omán')
/*INTO PAIS VALUES(215, 'Isla Pitcairn')*/
INTO PAIS VALUES(216, 'Qatar')
INTO PAIS VALUES(217, 'Ruanda')
INTO PAIS VALUES(219, 'San Cristobal y Nevis')
INTO PAIS VALUES(220, 'Santa Lucía')
INTO PAIS VALUES(222, 'San Vincente y las Granadinas')
INTO PAIS VALUES(223, 'Samoa')
INTO PAIS VALUES(224, 'San Marino')
INTO PAIS VALUES(225, 'San Tomé y Príncipe')
INTO PAIS VALUES(227, 'Sierra Leona')
INTO PAIS VALUES(228, 'Islas Salomón')
INTO PAIS VALUES(229, 'Somalia')
INTO PAIS VALUES(232, 'Sudán')
INTO PAIS VALUES(234, 'Swazilandia')
INTO PAIS VALUES(236, 'Tonga')
INTO PAIS VALUES(237, 'Trinidad y Tobago')
INTO PAIS VALUES(239, 'Tuvalu')
INTO PAIS VALUES(240, 'Vanuatu')
INTO PAIS VALUES(242, 'Sáhara Occidental')
INTO PAIS VALUES(243, 'Yemen')
INTO PAIS VALUES(246, 'Puerto Rico')
SELECT 1 FROM DUAL;
