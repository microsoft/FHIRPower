# Usecase for Clinician

## Home 
![home](images/home.PNG)


## Appointment Screen
![appointment](images/appointmentMainpage.PNG)

>> ClearCollect(colAppointments, FHIRBase.GETAppointment().entry.resource);

ClearCollect(colPatients, FHIRBase.GETPatient().entry.resource);

ClearCollect(colPractioners, FHIRBase.GETPractitioner().entry.resource);

## Accept/Decline/Tentative
![statusUpdate](images/booked.png)


