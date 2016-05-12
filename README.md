# Construction equipment rental (shorthand : cer)   
## Short overview
* MVC 4 
* EF 6.1.3 (code first)

## What is required to run this project
* Visual Studio 2015 with update 1.

## How to run tests
0. Press F6 *(to build project), tests are set to run after build. 
1. Use "Test - Windows - Test Expolorer" select feature "Run Tests after build" and F6 (to build).

## How to initialize database
Open nugget package manager console, with `src\Cer.Infrastructure` and type `Update-Database`. 

Like shown on image.
![alt tag](http://i.imgur.com/SdJzhFU.png?1)

This assumes you have admin rights in the server, if you do not, acquire them or change connection string.

## Progress
### v. 0.0.1 
- [x] Create core project
- [x] Create infrastructure project
- [x] Create web ui
- [x] Create web link projects
- [x] Add IoC to web ui project
- [x] Add abstractions, dtos, interfaces and models to core project
- [x] Initial commits to GitHub

### v. 0.0.2 
- [x] Add ReadMe.md
- [x] Fix some naming issues
- [x] Move abstraction interfaces to separate files

### v. 0.0.3
- [x] Fixed ReadMe.md

### v. 0.0.4
- [x] Add EF to infrastructure
- [x] Add connection string
- [x] Add Code first migration
- [x] Create some seed data
- [x] Deploy to database 
- [x] Add unit test project
- [x] Add integration test project 
- [x] Add todo section in readme

### v. 0.0.5
- [x] Add folder structure
- [x] Remove inadequate localisation support 
- [x] Add support for returning subset items
- [x] Add support for rent item loan state
- [x] Add WebApi project and add IoC
- [x] Add WebApi consumer project
- [x] Add WebApi consumer primitive service implementation in DI friendly manner
- [x] Update seed data

### v. 0.1.0
- [x] Remake core
- [x] Fix structuremap references
- [x] Update seed data
- [x] WebApi returns returns list of equipment

## Todo
- [ ] Add localization 
- [ ] Utf8 or alternative support in database 
- [ ] Logging
- [ ] Decent-looking UI
- [ ] Caching
- [ ] Class and interaction diagrams
