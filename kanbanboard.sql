-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sty 11, 2025 at 09:25 PM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kanbanboard`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `login` text NOT NULL,
  `password` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`login`, `password`) VALUES
('Dawid', '123'),
('Michał', '1234');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `zadania`
--

CREATE TABLE `zadania` (
  `task_id` int(11) NOT NULL,
  `title` text NOT NULL,
  `description` longtext NOT NULL,
  `assigned_user` text NOT NULL,
  `Status` text NOT NULL,
  `creation_date` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `zadania`
--

INSERT INTO `zadania` (`task_id`, `title`, `description`, `assigned_user`, `Status`, `creation_date`) VALUES
(1, 'zadanie 1', 'opis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\n\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\nopis zadania 1\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nopis zadania 1\r\nfsdfsdfsdf', 'Michał', 'Testowanie', '2024-12-08'),
(2, 'zadanie 2 ', 's\ns', 'Michał', 'Zaplanowane', '2024-12-08'),
(4, 'zadanie 4', 'opis zadania 4', 'Michał', 'Ukonczone', '2024-12-08'),
(5, 'zadanie 5', 'opis zadania 5', 'Michał', 'W trakcie', '2024-12-08'),
(11, 'Test zadania ', 'Jakiś opis zadani a', 'Dawid', 'Nowe', '2024-12-22'),
(13, 'Test implementacji interfejsu', 'implementacji ', 'Michał', 'Testowanie', '2025-01-11');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`login`(256));

--
-- Indeksy dla tabeli `zadania`
--
ALTER TABLE `zadania`
  ADD PRIMARY KEY (`task_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `zadania`
--
ALTER TABLE `zadania`
  MODIFY `task_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
