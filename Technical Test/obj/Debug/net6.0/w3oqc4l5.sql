CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE TABLE `Companies` (
        `companyID` int NOT NULL AUTO_INCREMENT,
        `companyName` nvarchar(255) NOT NULL,
        `companyEmail` nvarchar(255) NOT NULL,
        `companyPhone` nvarchar(255) NOT NULL,
        `approvalStatus` nvarchar(255) NOT NULL,
        `companyPhoto` varbinary NOT NULL,
        CONSTRAINT `PK_Companies` PRIMARY KEY (`companyID`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE TABLE `Vendors` (
        `VendorID` int NOT NULL AUTO_INCREMENT,
        `vendorName` nvarchar(255) NOT NULL,
        `businessType` nvarchar(255) NOT NULL,
        `companyType` nvarchar(255) NOT NULL,
        `UserID` int NOT NULL,
        CONSTRAINT `PK_Vendors` PRIMARY KEY (`VendorID`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE TABLE `Project` (
        `ProjectID` int NOT NULL AUTO_INCREMENT,
        `projectName` nvarchar(255) NOT NULL,
        `VendorID` int NOT NULL,
        CONSTRAINT `PK_Project` PRIMARY KEY (`ProjectID`),
        CONSTRAINT `FK_Project_Vendors_VendorID` FOREIGN KEY (`VendorID`) REFERENCES `Vendors` (`VendorID`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE TABLE `Users` (
        `UserID` int NOT NULL,
        `Email` nvarchar(255) NOT NULL,
        `Password` nvarchar(255) NOT NULL,
        `UserType` int NOT NULL,
        `CompanyID` int NOT NULL,
        `ManagerID` int NOT NULL,
        CONSTRAINT `PK_Users` PRIMARY KEY (`UserID`),
        CONSTRAINT `FK_Users_Companies_CompanyID` FOREIGN KEY (`CompanyID`) REFERENCES `Companies` (`companyID`),
        CONSTRAINT `FK_Users_Vendors_UserID` FOREIGN KEY (`UserID`) REFERENCES `Vendors` (`VendorID`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE TABLE `Managers` (
        `ManagerID` int NOT NULL,
        `managerName` nvarchar(255) NOT NULL,
        `managerEmail` nvarchar(255) NOT NULL,
        `managerPhone` nvarchar(255) NOT NULL,
        CONSTRAINT `PK_Managers` PRIMARY KEY (`ManagerID`),
        CONSTRAINT `FK_Managers_Users_ManagerID` FOREIGN KEY (`ManagerID`) REFERENCES `Users` (`UserID`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_Companies_companyID_companyEmail` ON `Companies` (`companyID`, `companyEmail`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_Managers_ManagerID_managerEmail` ON `Managers` (`ManagerID`, `managerEmail`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_Project_ProjectID` ON `Project` (`ProjectID`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE INDEX `IX_Project_VendorID` ON `Project` (`VendorID`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_Users_CompanyID` ON `Users` (`CompanyID`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_Users_UserID_Email` ON `Users` (`UserID`, `Email`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_Vendors_VendorID` ON `Vendors` (`VendorID`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20231229162124_InitialCreate') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20231229162124_InitialCreate', '7.0.2');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

