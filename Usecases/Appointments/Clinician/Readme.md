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

Clinician now is now going to response by clicking on one of the three icons (_Accept, Decline, Tentative_)

## Accept/Decline/Tentative
Once the clinician clicks on one of the three choices the app will make a call to our FHIR connector to update the status of the appointment.

> FHIRBase.PUTAppointmentID(lblApptPracIDHid.Text, 
{
    resourceType: "Appointment",
    id_1: lblApptPracIDHid.Text,
    status: "booked",
    serviceCategory: ThisItem.resource.serviceCategory,
    serviceType: ThisItem.resource.serviceType,
    specialty: ThisItem.resource.specialty,
    appointmentType: ThisItem.resource.appointmentType,
    priority: ThisItem.resource.priority,
    description: ThisItem.resource.description,
    start: ThisItem.resource.start,
    end: ThisItem.resource.end,
    created: ThisItem.resource.created,    
    participant: nestedCollectionToPatch
});

![statusUpdate](images/booked.png)


