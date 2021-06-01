# Usecase for Clinician

## Home 
When you load the clinician app you will be presented with the main page. For this use case, a clinician will click on '**Book Appointment**' 

This button click will call _**ClearCollect()**_ function. This function clears whatever is in the variable (*colAppointments, colPatients, colPractitioners*)  and load fresh collections from the datasource

> ClearCollect(colAppointments, FHIRBase.GETAppointment().entry.resource);
> ClearCollect(colPatients, FHIRBase.GETPatient().entry.resource);
> ClearCollect(colPractioners, FHIRBase.GETPractitioner().entry.resource);

After retrieving the data the same button action ('_onSelect_') will navigate the app to screen called _scrAppointments_

> Navigate(scrAppointments);

![home](images/home.PNG)

## Appointment Screen
As you see below, the above function calls allow us to retrieve all the information shown below.

![appointment](images/appointmentMainpage.PNG)

## Accept/Decline/Tentative
![statusUpdate](images/booked.png)


