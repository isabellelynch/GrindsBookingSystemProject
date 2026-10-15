# Grinds Booking System

**Author:** Isabelle Lynch (T00264026)
**Course:** Computing with Software Development

A Windows Forms booking system for a grinds (tuition) school. The manager can manage tutors, students and subjects, build a weekly class timetable for each room, book students into classes, and view revenue and tutor performance reports.

This repository holds the whole project, from requirements to finished system:

| Folder | What it is |
|--------|-----------|
| [`SupportingDocumentation/`](SupportingDocumentation) | The requirements specification (Requirements Engineering, submitted 05/12/2025): use cases, business rules and data files. [Read it on GitHub](SupportingDocumentation/RE_Lynch_Isabelle.md) or open the Word version. |
| [`RequirementsPrototype/`](RequirementsPrototype) | The prototype that went with the specification. It keeps its data in memory, so it runs straight away with no database. |
| [`GrindsBookingSystem/`](GrindsBookingSystem) | The full system, built on an **Oracle database**, with a unit test project and a database setup script. |

---

## Repository contents

```
README.md
.gitignore
SupportingDocumentation/
    RE_Lynch_Isabelle.docx            Requirements specification (Word)
    RE_Lynch_Isabelle.md              The same specification in Markdown, readable on GitHub
    images/                           Diagrams used by the Markdown version
RequirementsPrototype/
    GrindsBookingSystem.sln           Visual Studio solution for the prototype
    background.jpg
    GrindsBookingSystem/              C# Windows Forms project (.NET Framework 4.7.2), in-memory data
GrindsBookingSystem/
    GrindsBookingSystem.sln           Visual Studio solution for the full system (app + tests)
    background.jpg
    Database/
        GrindsBookingSystem.sql       Creates the Oracle tables with sample data
    GrindsBookingSystem/              C# Windows Forms project (.NET Framework 4.7.2) using Oracle
        secrets.example.config        Template for your Oracle login and Gmail settings
    GrindsBookingSystemTests/         MSTest unit tests
```

---

## 1. The requirements prototype

**Requirements:** Windows and Visual Studio 2019 or later, with the **.NET desktop development** workload.

1. Open `RequirementsPrototype/GrindsBookingSystem.sln`.
2. Press **F5**.

Every run starts with the same sample data (three tutors, three students, four upcoming grinds and some bookings), dated from the day you run it. Changes are lost when it closes.

| Menu | Function |
|------|----------|
| **Tutors** | Add (with Garda vetting confirmation), Remove, Update, View details |
| **Students** | Add, Remove, Update, View details |
| **Schedule** | View upcoming grinds, Add a grind, Remove a grind |
| **Bookings** | Make a booking, Cancel a booking, View a student's bookings |
| **Admin** | Yearly revenue analysis, Tutor earnings chart (click a bar for the tutor's details) |

It implements the specification's business rules: grinds run Monday to Friday, 9am to 5pm, within the next 28 days. A tutor or room can't be double-booked, and grinds can't be overbooked. Bookings cancelled more than 7 days ahead are refunded, and removing a tutor, student or grind cancels the related bookings with refunds.

---

## 2. The full system (Oracle)

### Requirements
- Windows and Visual Studio 2022 (or 2019) with the **.NET desktop development** workload
- An Oracle database account, 12c or later (for example the college's `studentoracle` server)
- **Oracle SQL Developer** (or SQL*Plus) to run the setup script
- Internet access the first time you build, so NuGet can download the Oracle driver

### Step 1: Create the database
1. Open SQL Developer and connect to your Oracle account.
2. Open `GrindsBookingSystem/Database/GrindsBookingSystem.sql` and click **Run Script** (F5).

This creates the eight tables (`TutorRates`, `Tutors`, `Students`, `Subjects`, `Tutor_Subjects`, `Rooms`, `Classes`, `Bookings`) with sample data. **Running it again deletes the tables and starts again**, which is handy for resetting test data.

### Step 2: Add your Oracle login
Your password is kept out of the code and out of Git:

1. In `GrindsBookingSystem/GrindsBookingSystem/`, copy `secrets.example.config` and name the copy **`secrets.config`**.
2. Fill in your details:

```xml
<add key="OracleDataSource" value="studentoracle:1521/orcl" />
<add key="OracleUserId" value="your Oracle username" />
<add key="OraclePassword" value="your Oracle password" />
```

`secrets.config` is listed in `.gitignore`, so it's never committed. If it's missing or the database can't be reached, the app shows a message when it starts.

### Step 3: Build and run
1. Open `GrindsBookingSystem/GrindsBookingSystem.sln`.
2. Build the solution (**Ctrl+Shift+B**). Visual Studio restores the NuGet packages (Oracle.ManagedDataAccess and its dependencies) automatically. If it doesn't, right-click the solution and choose **Restore NuGet Packages**.
3. Make sure **GrindsBookingSystem** is the start-up project and press **F5**.

### Running the unit tests
Open **Test > Test Explorer** and click **Run All**. The tests check the `Tutor` class and its validation (names, emails, phone numbers and rate codes), so they don't need the database.

### Features

| Menu | Function |
|------|----------|
| **Tutors** | Add, Remove, Update (email, phone, rate), View details, Assign subjects |
| **Students** | Add, Remove, Update, View details |
| **Subjects** | Add a subject (Leaving or Junior Cert, Higher or Ordinary level) |
| **Schedule** | Weekly timetable per room for the current semester. Pick an empty slot to **add** a class, or a class to **alter** (move day, time or room) or **remove** it. |
| **Bookings** | Book a student into a class (filter by subject), and view or cancel a student's bookings |
| **Admin** | This year's revenue and bookings, active tutors and students, best and worst performing tutor, and a tutor earnings chart (click a bar for the tutor's details) |

**Rules the system enforces**
- **Validation:**
  - Names may contain letters (including fadas), spaces, apostrophes and dashes.
  - Emails must be valid and unique.
  - Phone numbers must be `08X-XXXXXXX`.
- **Classes:**
  - A tutor can't teach two classes at the same time.
  - A room can't hold two classes at the same time.
  - A tutor can have at most 20 classes a semester.
  - A class can only be moved to a room big enough for its students.
- **Bookings:** a full class can't be booked, and a student can't book the same class twice.
- **Removing records:**
  - Removing a tutor or student marks them Inactive, so their history is kept.
  - Removing a tutor also cancels their classes and those classes' bookings.

**Semesters** are the two-digit year followed by 1 (January–June) or 2 (July–December). For example, 262 is the second half of 2026. Revenue is the tutor's hourly rate for each active booking made this year.

### Sample data

| Table | Contents |
|-------|----------|
| TutorRates | SNR €50, JNR €40, NEW €30 per hour |
| Tutors | 6 tutors (one Inactive), each assigned the subjects they teach |
| Students | 8 students (one Inactive) |
| Subjects | 8 subjects across Leaving and Junior Cert levels |
| Rooms | Room 1 (20 seats), Room 2 (12), Room 3 (3) |
| Classes | 8 in the current semester and 1 in the previous semester. The Friday 15:00 class in Room 3 is full, to show the capacity check. |
| Bookings | 12 this year and 1 from last year |

### Booking confirmation emails (optional)
`Booking.SendBookingConfirmation()` can email the student when a booking is made. It's turned off: the call in `frmAddBooking.cs` is commented out, as it was in the original, because the college network blocks Gmail. To try it:
1. Create a Gmail **App Password** (Google Account > Security > 2-Step Verification > App passwords).
2. Fill in `GmailAddress` and `GmailAppPassword` in your `secrets.config`.
3. Uncomment `//SendBookingConfirmation();` in `frmAddBooking.cs` and change it to `b.SendBookingConfirmation();`.

### Project structure

| Folder | Contents |
|--------|----------|
| `Tutors/`, `Students/`, `Subjects/`, `Classes/`, `Bookings/` | Each entity's class (database code) and its forms |
| `Schedule/` | The weekly timetable form |
| `Admin/` | Reports and the tutor earnings chart |
| `Inheritance/` | `BaseForm` (shared menu, styling and reset), `ClassBaseForm` (shared add/alter/remove class form) and the `Person` base class for tutors and students |
| `Interfaces/` | `InterfaceCRUD`, implemented by every entity class |
| `HelperClasses/` | `Database` (connection and queries), validation, combo box filters, grid views, custom message boxes, rooms, day names and `GmailSender` |

---

## Known limitations

- **The full system was not run against a live Oracle database during the October 2026 review**, because no Oracle server was available. It was compiled and its SQL was checked, as described below. Run it once against your database to confirm.
- Removing a student marks them Inactive but leaves their existing bookings in place, so they still take up seats.
- Cancelling a booking deletes it, but removing a tutor marks their bookings as cancelled (Status `C`).
- Room numbers must be single digits (1–9), because the forms read the first character of the room name.
- The schedule only shows and books the current semester.
- `SmtpClient`, used for the emails, is marked obsolete by Microsoft. It still works with Gmail App Passwords.

---

## Changes made during review (October 2026)

The two repositories were merged into this one:
- The requirements prototype moved from `Prototype/` to `RequirementsPrototype/`.
- The Oracle system moved from `Prototype/` to `GrindsBookingSystem/`.
- The 33 diagram images the Markdown specification uses were added; they were missing, so its pictures didn't show on GitHub.

The requirements prototype is unchanged from its earlier review and still passes its 54 automated checks.

### Security
- **A real Gmail App Password was written in the code** (`Booking.cs`, and in a comment in `GmailSender.cs`). It has been removed. The Oracle login and Gmail details now come from `secrets.config`, which Git ignores. **The old password is still in the Git history, so revoke it** in your Google Account (Security > App passwords).

### Fixed: features that didn't work
- **Update Student never saved.** The Find button stored the student in a new local variable, so Update saved to student ID 0 and nothing changed.
- **The student table on Remove Student never loaded.** `GetStudentList` added a `:list` parameter the SQL didn't use, so Oracle raised ORA-01036.
- **Class sizes were never counted.** Nothing updated `CurrentEnrollment`, so every class showed 0 students and no class could ever be full. Making or cancelling a booking now updates it.
- **A tutor could be given two classes at the same time.** `IsTutorFree` was passed the tutor's ID but compared it with the room number.
- **Moving a class to another room at the same time was always rejected.** The class clashed with itself, and the room size was checked against other classes' rooms. Altering a class now skips its own row and checks the new room's capacity.
- **Altering or removing a class did nothing.** `GetClass` never set the class's ID, so the update and the cancel affected ID 0.
- **Room capacity crashed the class forms.** It was read as text from a number column (`InvalidCastException`). Other number columns read in `GetClass` and `GetRoomDetails` had the same problem.
- **Invalid SQL:**
  - `Subject.Update` and `Booking.Update` joined columns with `AND` instead of commas.
  - `Booking.Update` also had no `WHERE`, so it would have changed every booking.
  - `Subject.Update` added its parameters in a different order from the SQL. Oracle matches parameters by position, so level and category would have been swapped.
- **A full class showed "System Error! The class cannot be found"** instead of saying it was full. A class that really can't be found is now checked separately.

### Fixed: wrong figures
- **Best and Worst performing tutor:**
  - They added one hourly rate per class instead of per booking, so a class with no students still counted as a booking.
  - They included removed tutors.
  - They now use the same sum as the earnings chart: bookings × rate.
- **Cancelled bookings and classes were counted:**
  - Revenue, booking totals and the chart now skip cancelled bookings.
  - The booking list skips cancelled classes.
  - A student's bookings and the "already booked" check skip cancelled ones too.
- **Hours worked** counted cancelled classes towards a tutor's 20-class limit.

### Fixed: crashes and reliability
- **Database connections leaked.** Several checks returned `dr.Read()` without closing the reader, so each one held a connection open: `DoesTutorExist`, `DoesStudentExist`, `GetRoomCapacity`, and `GetClass` when nothing was found.
- **Empty filter results produced invalid SQL.** When the filters left no tutors or students, the lists built `IN ()`.
- **Buttons crashed or carried on when nothing matched the filters,** because they used `Items[0]`: Find, Show Details, Show Bookings, Continue and Select Tutor. They now ask you to pick one person.
- **Schedule crashes:**
  - Removing or altering with an empty slot or no room selected crashed.
  - Resetting the room list fired the room-changed event with no room.
- **Forms with empty fields:**
  - Add Class crashed with no subject chosen.
  - Update Tutor crashed with no rate.
  - Assign Subject crashed with no subject selected.
- **Email validation** let an email start or end its local part with a dot, because it compared a `char` with a `string`. Names with a dash, such as Mary-Kate, were rejected.

### Project and repository
- **`Database/GrindsBookingSystem.sql` added.** The repo had no database script, so the project couldn't be set up from GitHub. It was rebuilt from the tables and columns the code uses.
- **The app checks the database connection at start-up** and shows one clear message if it fails.
- **Unit tests:**
  - The test project was added to the solution.
  - It now targets .NET Framework 4.7.2 to match the app; it targeted .NET 8, which can't reliably load a .NET Framework WinForms project.
  - The existing test expected `null`, but the constructor sets `""`, so it always failed. It's fixed, and five validation tests were added.
- **Removed:**
  - `packages/` (46 MB, which NuGet restores automatically) and the `bin/`, `obj/` and `.vs/` build folders
  - An unrelated `.github/copilot-instructions.md` and a duplicate `.gitignore`
- **Spelling:** "succesfully" in the Add Tutor and Add Student messages, and a missing space before "has been".

### How it was tested
- Both projects compile with no errors on Mono (Linux). The prototype's chart title needed a test-only patch there, because Mono lacks that method.
- The six unit tests pass.
- The requirements prototype passes its 54 scripted checks under a virtual display.
- For the Oracle system, a test build recorded the SQL text and parameters of all 56 queries the data classes build. Each was checked by an Oracle SQL parser, and each query's parameter order was compared with its placeholders, since Oracle binds by position. All 56 pass. The same check on the original code flagged the parameter bugs fixed above.
- The setup script's statements were checked with the same parser.
- The configuration loading was tested with and without a `secrets.config`.
