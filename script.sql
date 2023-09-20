CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `customers` (
    `id` char(36) COLLATE ascii_general_ci NOT NULL,
    `first_name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `last_name` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
    `date_Of_birth` date NOT NULL,
    `phone_number` varchar(15) CHARACTER SET utf8mb4 NOT NULL,
    `email` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `bank_account_number` longtext CHARACTER SET utf8mb4 NOT NULL,
    `created_at` datetime(6) NOT NULL,
    `modified_at` datetime(6) NULL,
    CONSTRAINT `PRIMARY` PRIMARY KEY (`id`)
) CHARACTER SET=utf8mb4;

CREATE UNIQUE INDEX `IX_customers_email` ON `customers` (`email`);

CREATE UNIQUE INDEX `IX_customers_first_name_last_name_date_Of_birth` ON `customers` (`first_name`, `last_name`, `date_Of_birth`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230916000010_Initial', '7.0.10');

COMMIT;

