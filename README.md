# Old MacDonald's Had a Farm

Short, console-based C# sample implementing two approaches to the same problem: a polymorphic design and a data-driven design for "Old MacDonald's" animals and their verses.

## Overview
This repository contains two small console applications demonstrating:
- Polymorphic_Approach — uses OOP polymorphism where each animal is a class implementing behavior.
- Data_Driven_Approach — loads animals from `animals.json` and drives behavior from data.

Core functionality:
- List all animals with IDs, names and sounds.
- Choose an animal to print/sing its verse.
- Add a new animal (data-driven approach persists to the JSON-backed context).
- ID generation and simple input/output abstraction to make components testable.

## Technologies
- .NET 8 (Target Framework)
- C# 12
- Console application(s)
- JSON file storage for data-driven approach (`Data_Driven_Approach/animals.json`)
- Minimal validation attributes (DataAnnotations) for entity properties

## Projects
- `Polymorphic_Approach`  
  - Each animal (Dog, Cat, Duck, Pig, Cow, ...) is a class that can sing its own verse.
  - Useful to demonstrate inheritance, abstract base classes and per-type behavior.

- `Data_Driven_Approach`  
  - Animals are represented as data objects (`Animal`) and loaded via an `IAnimalContext` implementation (`AnimalContext`) that reads and writes `animals.json`.
  - `VerseGenerator` composes verses from an animal's Name and Sound.
  - `IdGenerator` issues unique IDs for animals.
  - `IInputOutputProvider` abstracts console I/O for easier testing and separation of concerns.

## Key components (select)
- `Data_Driven_Approach/Data/Animal.cs` — data model for animals (Name, Sound, Id).
- `Data_Driven_Approach/Data/IAnimalContext.cs` — abstraction for persistence (in-memory or JSON-backed).
- `Data_Driven_Approach/Data/AnimalContext.cs` — concrete JSON-backed implementation.
- `Data_Driven_Approach/Services/AnimalServices.cs` — core operations: list, choose (sing), add animal, ID assignment.
- `Data_Driven_Approach/Services/VerseGenerator.cs` — builds the verse text from an animal instance.
- `Data_Driven_Approach/animals.json` — sample data for the data-driven app.

## How to run
From Visual Studio 2026:
- Open the solution: __File > Open > Project/Solution__
- Build the solution: __Build > Build Solution__
- Start the appropriate project (set startup project) and run: __Debug > Start Debugging__ or __Debug > Start Without Debugging__

From command line (dotnet CLI):
- To run the data-driven app:
  - `cd Data_Driven_Approach`
  - `dotnet run`
- To run the polymorphic app:
  - `cd Polymorphic_Approach`
  - `dotnet run`

Note: Running the data-driven app may modify `animals.json` when adding animals. Keep a backup if needed.

## Typical usage
- List animals -> prints ID, name and sound.
- Choose ID -> prints the verse for that animal until you choose 0 to return to menu.
- Add animal -> prompts for name and sound, prevents duplicate names (case-insensitive), assigns an ID and persists changes.

## Design notes & considerations
- Input/output is abstracted through `IInputOutputProvider` to allow unit testing or swapping console I/O for other channels.
- ID allocation is centralized in `IdGenerator` to avoid collisions and keep services thin.
- Data-driven approach stores everything in `animals.json` (suitable for demo/small apps). For production, replace `IAnimalContext` with a DB-backed implementation.
- Validation attributes exist on the `Animal` model; adding a verification step when adding animals will harden the app.
- The repository currently includes a feature branch `feature/sorting_json` — related work may add sorting/persistence improvements.

## Extending the app
- Add unit tests that mock `IInputOutputProvider` and `IAnimalContext`.
- Replace JSON persistence with EF Core or another DB for concurrency and scaling.
- Add CLI arguments to run operations non-interactively (for automation).

## Where to look in the code
- Interaction logic: `Services/AnimalServices.cs`
- Persistence abstraction: `Data/IAnimalContext.cs` and `Data/AnimalContext.cs`
- Verse composition: `Services/VerseGenerator.cs`
- Models: `Data/Animal.cs`, `Data/BaseEntity.cs`

If you want, I can generate a short quickstart script, add a CONTRIBUTING section, or produce a minimal UML/mermaid diagram of the architecture.