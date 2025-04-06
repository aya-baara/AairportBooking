# Airport Ticket Booking System

A console-based application built with .NET that enables passengers to book flights and allows a manager to manage bookings. This system uses a simple file-based storage mechanism, making it easy to use and ideal for learning purposes.

---

## Objective

Develop a .NET console application that:
- Lets passengers search for and book flights.
- Provides managers with tools to manage and monitor bookings.
- Uses the file system to store flight and booking information.

---

## Data Storage

- Data is saved locally using text or CSV files.
- No database required.

---

## Features

### For Passengers

**Book a Flight**
- Select a flight based on various search parameters.
- Choose from Economy, Business, or First Class.
- Pricing adjusts based on selected class.

**Search Available Flights**
- Filter by:
  - Price
  - Departure Country
  - Destination Country
  - Departure Date
  - Departure Airport
  - Arrival Airport
  - Class

**Manage Bookings**
- Cancel a booking.
- Modify an existing booking.
- View personal bookings.

---

### For the Manager

**Filter Bookings**
- Search using:
  - Flight
  - Price
  - Departure/Destination Countries
  - Departure/Arrival Airports
  - Passenger
  - Class
  - Date

**Batch Flight Upload**
- Import flights from a CSV file.

**Validate Flight Data**
- Check correctness of flight entries.
- Return error reports to help correct issues.

**Dynamic Model Validation**
- Automatically generate validation rules for each field during import.

---

