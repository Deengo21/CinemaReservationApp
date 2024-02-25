CREATE TABLE dbo.Movies
(
    movie_id INT,
    title VARCHAR(50),
    director VARCHAR(40),
    length INT,
    film_genre VARCHAR(20),
    PRIMARY KEY (movie_id)
);

CREATE TABLE dbo.Screening
(
    screening_id INT,
    date DATE,
    [time] TIME,
    film_id INT,
    PRIMARY KEY (screening_id)
);

CREATE TABLE dbo.Reservations
(
    reservation_id INT,
    screening_id INT,
    movie_id INT,
    user_id INT,
    room_id INT,
    payment_id INT,
    PRIMARY KEY (reservation_id)
);

CREATE TABLE dbo.Users
(
    user_id INT,
    privilege INT,
    username VARCHAR(25),
    [password] VARCHAR(100), -- You should use a secure hashing algorithm and store hashed passwords
    PRIMARY KEY (user_id)
);

CREATE TABLE dbo.Rooms
(
    room_id INT,
    [row] INT,
    seat INT,
    PRIMARY KEY (room_id)
);

CREATE TABLE dbo.Payments
(
    payment_id INT,
    cost FLOAT,
    payment_method VARCHAR(20),
    PRIMARY KEY (payment_id)
);














