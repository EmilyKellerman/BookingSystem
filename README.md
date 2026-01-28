# 🏢 Conference Room Booking System

This repository contains a project with the base code for a Conference Room Booking System.

This system will allow employees to search a list of available rooms and book a room for use.
There will be an administrator login portal giving them access to the administrator dashboard in the future.
There will also be functionality for a receptionist to book on behalf of another person and for facility managers to book a room for maintenance.
The code has been laid out with room for expansion for these features.

The current features are:
1) Booking a room
2) Canceling a booking
3) Exporting booking history as a json file
4) Loading history from a json file

This code will eventually be merged with existing API endpoints and documentation.

---

## Table of Contents

[How Failures are Handled](##How-Failures-are-Handled)
[Where Async is Used](#Where-Async-is-Used)
[🗂 Repository Contents](#🗂-Repository-Contents)
[⚙️ Installation](#⚙️-Installation)
[📌 Purpose of This Repository](#📌-Purpose-of-This-Repository)
[📋 System context](#📋-System-context)
[💪 Developer Onboarding Guide](#💪-Developer-Onboarding-Guide)
[🗎 Project Documentation](#🗎-Project-Documentation)
[Key Folders](#Key-Folders)
[🤝 Contributing](#🤝-Contributing)
[⏰ Upcomming Documentation](#⏰-Upcomming-Documentation)
[📄 License](#📄-License)
[✍️ Author](#✍️-Author)

---

## How Failures are Handled

- In the client code, all data that is taken from user input is validated before being passed into methods of other classes
- In methods, all data is validated before furhtering steps can be taken
- All validation follows a fail-fast approach to avoid invalid object states

---

## Where Async is Used

- This project makes use of async in creating a json file with booking history
- This project makes use of async in loading a json file with booking history

---

## 🗂 Repository Contents

- `README.md` – Basic project overview
- `src/` - Contains all the project C# code 
- `.github/` - pull_request_template.md, issue_template/ - bug_report.md, feature_request.md
- `LICENSE` – Information on the MIT licence applicable to this project

---

## ⚙️ Installation

- To install this project, you download the Zip file from GitHub and extract the project files to your selected location.
- Then you can use VS Code (make sure .NET 8 is installed on your device) to open the C# code and edit if you want to.
- Any changes will be made using the pull request template provided.
- Make sure to clone the GitHub repository should you indeed intend on creating pull requests.

---

## 📌 Purpose of This Repository

This repository is used for:
- Creating the code that will form the base of the Conference Room Booking System
- Working to eventually merge this work with existing API documentation
- Gradually improving project documentation over time
- Gradually improving project code over time

At this stage, the repository focuses on **Creating Basic Functionality Code**, not full system implementation.

---
 
## 📋 System context

The conference room booking system is intended to manage:
- Room Availability
- Booking Requests
- Conflict Prevention
- Administrator Access
- Administrator Conflict Resolution
- Receptionist Ability to Help Employees and Guests
- Facility Managers Ability to Schedule Rooms for Maintenance 

---

## 💪 Developer Onboarding Guide

 - This project is developed incrementally for a Software training program
 - The project will have additions made to it daily through assignments and will slowly build up to being a functional booking system for employees
 - Documentation is organised with a pre-determined file structure, that will have files added and/or edited according to the work that is done
 - Project artefacts can be found in the project folders. So far the artefacts available are:

    1) Pull Request Template

 - Technologies used so far:

    1) VS Code as a file editior
    2) VS Code as a git terminal
    3) GitHub for repository storage
    4) GitHub for allowance of team collaboration

 ---

 ## 🗎 Project Documentation

 This repository contains C# code and templates for pull requests, issue reports and feature requests

 ### Key Folders

 - .github/ - pull_request_template.md, issue_template/
 - src/ - ConferenceRooms.cs, Program.cs, StaffType.cs, BookingSystemCode.sln

---

## 🤝 Contributing

Changes to this repository are made using **Pull Requests**.

Contributors should:
- Create a feature or documentation branch
- Submit changes via a Pull Request
- Clearly describe the intent of the change and what was added or changed
- A clear pull request template has been provided under .github/

---

 ## ⏰ Upcomming Documentation

 The following sections will be added as the project evolves
 - API documentations (Swagger/OpenAPI)
 - Runtime instructions (Docker)
 - Developer setup and contribution workflows
 - Common issues reported by users with solutions or notification of the fix being in progress

---

## 📄 License

This project is licensed under the MIT License.

---

## ✍️ Author
Emily Kellerman : emilyckellerman@gmail.com
Created as part of professional software development training.