/*

USE [awards];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[awards] ON;

BEGIN TRANSACTION;

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 1, N'A1', N'JR Eisener Contracting Limited Award', N'DESC1', 1, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', NULL, NULL, 1, 1


INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 2, N'A2', N'PCL Constructors Canada Inc. Award', N'DESC2', 1, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', NULL, N'HIGHSCHOOLTRANSCRIPT', 2, 1


INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 3, N'A3', N'Rogers Radio & Broadcasting Award', N'DESC3', 1, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', NULL, N'REFQUESTION1', 3, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 4, N'A4', N'Allan R. Fleming Applied Arts Award', N'DESC4', 1, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', NULL, N'REFQUESTION1,REFQUESTION2', 4, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 5, N'A5', N'Atlantic Credit Unions Bursary', N'DESC5', 1, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', NULL, N'REFLETTER', 5, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 6, N'A6', N'Bird Construction Award', N'DESC6', 1, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', NULL, N'REFLETTER,HIGHSCHOOLTRANSCRIPT', 6, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 7, N'A7', N'C Vanessa Hammock Award', N'DESC7', 1, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', NULL, N'REFLETTER,REFQUESTION1,REFQUESTION2', 7, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 8, N'A8', N'Dr. Jack Buckley Scholarship', N'DESC8', 1, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', NULL, N'REFLETTER,REFQUESTION1', 8, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 9, N'A9', N'Halifax Port Authority Bursary', N'DESC9', 1, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', NULL, N'REFLETTER,REFQUESTION1,REFQUESTION2,HIGHSCHOOLTRANSCRIPT', 9, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 10, N'A10', N'RBC Award', N'DESC10', 1, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', N'QUESTION2', N'REFLETTER,REFQUESTION1,REFQUESTION2,HIGHSCHOOLTRANSCRIPT', 10, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 11, N'A11', N'Scotiabank Award', N'DESC11', 0, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', NULL, N'REFLETTER,REFQUESTION1,REFQUESTION2,HIGHSCHOOLTRANSCRIPT', 11, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 12, N'A12', N'Stevens Group Award', N'DESC12', 0, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', N'QUESTION3', NULL, 12, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 13, N'A13', N'Saxton Family Award', N'DESC13', 1, N'AKERL,BURRI', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', NULL, N'REFLETTER,REFQUESTION1,REFQUESTION2,HIGHSCHOOLTRANSCRIPT', 13, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 14, N'A14', N'Jeff Todd Memorial Award', N'DESC14', 1, N'AKERL', N'ADDICO,AGEOSEM1,AIRMAINAVS,AIRMAINENG,AIRMAINSTR,AMSIGNLANG,ARCHENGTCN,ARTMUSBUS,AUTOCOLREP,AUTOSERVRE,BAKPASTART,BEHAVINTER,BLDSYSTCN,BOULANGER,BRICKLAYIN,BUSADM-YR1,CABCARP,CARPENTDIP,CERTWELD,CIVENGTECH,COMDISABSP,COMELECTCN,CONSTMGTD,CONTCARE,COOKING,COSMETOL,CULINARTS,DEAFSTDIES,DENTALASII,DIGIANIM,DIREPINMAR,DRAFTINGAR,DRAFTINGME,EARCHIEDUC,ELECONIN,ELECONINDI,ELEENGTCN,ELEENGTECH,ELEMECTCN,ELTRENTECH,ENERSUSENG,ENVENGTECH,ESTHETICS,GASINSSERV,GEOMENTECH,GEOSCIYR1,GEOTHERMAL,GRAPHICDES,GRAPROD,HDEQTTREP,HDTRUCKDIP,HEAVYEQOP,HEINFOMAN,HERCARPENT,HORTLANDTG,HUMRESMAN,HUSVNOCONC,INDENGTECH,INDINSTRU,INDMEC,INMOGRAPHS,INTERBUSIN,IT-NOCONC,LAWSECURIT,LIBINFTECH,MACSHOPDIP,MARENGTECH,MARGEOM,MARINDRIG,MARNAVTECH,MECENGTECH,MEDCOMARTS,MEDLABTECH,MEDOFFAS,MENTHEALTH,METALFAB,MOTOPOWER,MTRAN,MUSARTS,NATRESETD,OCHESAFETY,OFADSIMGT,OFFADMIN,OTAPTA,PARASERV,PHARMTECH,PHOTODIGI,PIPETRADES,PLUMBING,POWENGTECH,PRACNURDIP,PROCOPERAT,PUBRELAT,RADTELARTS,RECLEAD,RECORDARTS,REFAIRCOND,SCREENARTS,STEAMPIPE,SURVTECH,TMAN-Y1,UTILLINWRK,WELDINGDIP,WELDINSQUA', N'QUESTION4', N'REFLETTER,REFQUESTION1', 14, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 15, N'A15', N'Ryan MacAskill Memorial Award', N'DESC15', 1, N'KINGS', N'BAKPASTART', NULL, N'HIGHSCHOOLTRANSCRIPT', 15, 1

INSERT INTO [dbo].[awards]([id], [code], [displayname], [description], [requireincomeinfo], [eligiblecampuses], [eligibleprograms], [essayquestions], [attachments], [sortorder], [active])
SELECT 16, N'A16', N'Canadian Hospitality Foundation Culinary (1-year) Scholarship', N'DESC16', 1, N'AKERL,ANNAP,BURRI,CUMBE,INSTI,KINGS,LUNEN,MARCO,PICTO,SHELB,STRAT,TRURO,WATER', N'BAKPASTART,BOULANGER', N'QUESTION2', N'REFLETTER,REFQUESTION1,HIGHSCHOOLTRANSCRIPT', 16, 1


COMMIT;
RAISERROR (N'[dbo].[awards]: Insert Batch: .....Done!', 10, 1) WITH NOWAIT;
GO


SET IDENTITY_INSERT [dbo].[awards] OFF;

*/