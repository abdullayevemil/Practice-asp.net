create database VehiclesDb;

use VehiclesDb;

create table Vehicles 
(
    [Id] int primary key identity,
    [BrandName] nvarchar(100),
    [ModelName] nvarchar(100),
    [Price] money,
    [EngineVolume] int,
    [ImageUrl] nvarchar(max),
    [ManufactureDate] Date,
    [Mileage] int, 
    [HorsePower] int,
    [Description] nvarchar(max)
)

create table Users 
(
    [Id] int primary key identity,
    [Login] nvarchar(100),
    [Password] nvarchar(100),
)