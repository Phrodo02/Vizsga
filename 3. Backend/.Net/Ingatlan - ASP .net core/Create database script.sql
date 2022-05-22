Create database ingatlan
    character set utf8
    collate utf8_hungarian_ci;

use ingatlan;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `kategoriak` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nev` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_kategoriak` PRIMARY KEY (`Id`)
);

CREATE TABLE `ingatlanok` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Leiras` longtext CHARACTER SET utf8mb4 NULL,
    `HirdetesDatuma` datetime(6) NOT NULL,
    `Tehermentes` tinyint(1) NOT NULL,
    `Ar` int unsigned NOT NULL,
    `KepUrl` longtext CHARACTER SET utf8mb4 NULL,
    `KategoriaId` int NOT NULL,
    CONSTRAINT `PK_ingatlanok` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_ingatlanok_kategoriak_KategoriaId` FOREIGN KEY (`KategoriaId`) REFERENCES `kategoriak` (`Id`) ON DELETE CASCADE
);

INSERT INTO `kategoriak` (`Id`, `Nev`)
VALUES (1, 'Ház');
INSERT INTO `kategoriak` (`Id`, `Nev`)
VALUES (2, 'Lakás');
INSERT INTO `kategoriak` (`Id`, `Nev`)
VALUES (3, 'Építési telek');
INSERT INTO `kategoriak` (`Id`, `Nev`)
VALUES (4, 'Garázs');
INSERT INTO `kategoriak` (`Id`, `Nev`)
VALUES (5, 'Mezőgazdasági terület');
INSERT INTO `kategoriak` (`Id`, `Nev`)
VALUES (6, 'Ipari ingatlan');

CREATE INDEX `IX_ingatlanok_KategoriaId` ON `ingatlanok` (`KategoriaId`);

CREATE UNIQUE INDEX `IX_kategoriak_Nev` ON `kategoriak` (`Nev`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220329175726_init', '3.1.19');

