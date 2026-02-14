-- ==============================================
-- Script de configuration MySQL
-- OpenCreatorStudio
-- ==============================================

-- Création de la base de données
CREATE DATABASE IF NOT EXISTS opencreator 
    CHARACTER SET utf8mb4 
    COLLATE utf8mb4_unicode_ci;

-- Sélection de la base
USE opencreator;

-- Affichage de confirmation
SELECT 
    'Base de données opencreator créée avec succès!' AS Message,
    @@character_set_database AS Charset,
    @@collation_database AS Collation;

-- Instructions pour la suite
SELECT '
➡️  Prochaines étapes:
1. Exécutez le script de migration: mysql -u root -p opencreator < src/OpenCreatorStudio.API/Infrastructure/Data/Migrations/001_InitialCreate.sql
2. Configurez la chaîne de connexion dans: src/OpenCreatorStudio.API/API/appsettings.json
3. Générez un hash BCrypt pour le mot de passe admin
' AS 'Instructions';
