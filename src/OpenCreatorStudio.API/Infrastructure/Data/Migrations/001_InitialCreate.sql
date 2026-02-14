-- =============================================
-- Migration Initiale - OpenCreatorStudio
-- Date: 2026-02-14
-- Description: Création des tables principales
-- =============================================

-- Table Users
CREATE TABLE IF NOT EXISTS `users` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `Username` VARCHAR(50) NOT NULL,
    `PasswordHash` VARCHAR(255) NOT NULL,
    `Email` VARCHAR(100) NULL,
    `CreatedAt` DATETIME NOT NULL,
    `LastLoginAt` DATETIME NULL,
    PRIMARY KEY (`Id`),
    UNIQUE INDEX `IX_Users_Username` (`Username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Table Projects
CREATE TABLE IF NOT EXISTS `projects` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `Name` VARCHAR(100) NOT NULL,
    `Description` VARCHAR(500) NULL,
    `UserId` INT NOT NULL,
    `CreatedAt` DATETIME NOT NULL,
    `UpdatedAt` DATETIME NOT NULL,
    PRIMARY KEY (`Id`),
    INDEX `IX_Projects_UserId` (`UserId`),
    CONSTRAINT `FK_Projects_Users` FOREIGN KEY (`UserId`) 
        REFERENCES `users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Table DecisionNodes
CREATE TABLE IF NOT EXISTS `decision_nodes` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `ProjectId` INT NOT NULL,
    `Name` VARCHAR(100) NOT NULL,
    `FrameType` VARCHAR(20) NOT NULL,
    `StoredProcedureName` VARCHAR(100) NULL,
    `BodyScript` TEXT NULL,
    `PositionX` DOUBLE NOT NULL DEFAULT 0,
    `PositionY` DOUBLE NOT NULL DEFAULT 0,
    `Width` DOUBLE NOT NULL DEFAULT 200,
    `Height` DOUBLE NOT NULL DEFAULT 100,
    `CreatedAt` DATETIME NOT NULL,
    `UpdatedAt` DATETIME NOT NULL,
    PRIMARY KEY (`Id`),
    INDEX `IX_DecisionNodes_ProjectId` (`ProjectId`),
    CONSTRAINT `FK_DecisionNodes_Projects` FOREIGN KEY (`ProjectId`) 
        REFERENCES `projects` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Table Connections
CREATE TABLE IF NOT EXISTS `connections` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `ProjectId` INT NOT NULL,
    `SourceNodeId` INT NOT NULL,
    `TargetNodeId` INT NOT NULL,
    `Label` VARCHAR(50) NULL,
    `CreatedAt` DATETIME NOT NULL,
    PRIMARY KEY (`Id`),
    INDEX `IX_Connections_ProjectId` (`ProjectId`),
    INDEX `IX_Connections_SourceNodeId` (`SourceNodeId`),
    INDEX `IX_Connections_TargetNodeId` (`TargetNodeId`),
    CONSTRAINT `FK_Connections_Projects` FOREIGN KEY (`ProjectId`) 
        REFERENCES `projects` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Connections_SourceNode` FOREIGN KEY (`SourceNodeId`) 
        REFERENCES `decision_nodes` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Connections_TargetNode` FOREIGN KEY (`TargetNodeId`) 
        REFERENCES `decision_nodes` (`Id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Données de test (utilisateur admin par défaut)
-- Mot de passe: "admin123" hashé avec BCrypt
INSERT INTO `users` (`Username`, `PasswordHash`, `Email`, `CreatedAt`)
VALUES (
    'admin',
    '$2a$11$YourBCryptHashHere',
    'admin@opencreator.local',
    NOW()
);

SELECT 'Migration 001_InitialCreate.sql terminée avec succès' AS Result;
