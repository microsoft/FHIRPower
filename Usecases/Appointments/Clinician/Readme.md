# Usecase for Clinician

## Home 
![home](images/home.PNG)


## Appointment Screen

We utilize the Fhir connector mentioned in [README](../) to connect to the FHIR database. This connection will allow us to retrieve our Appointment, Patient, and Practioner object.  

We do this by using ClearConnect(). This clears whatever is in the variable (*colAppointments, colPatients, colPractitioners*)  and load fresh collections from the datasource

> ClearCollect(colAppointments, FHIRBase.GETAppointment().entry.resource);
> ClearCollect(colPatients, FHIRBase.GETPatient().entry.resource);
> ClearCollect(colPractioners, FHIRBase.GETPractitioner().entry.resource);

As you see below, the function calls allow us to retrieve all the information shown below.

![appointment](images/appointmentMainpage.PNG)

## Accept/Decline/Tentative
![statusUpdate](images/booked.png)


