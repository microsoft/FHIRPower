# Seed data for Azure API for FHIR Server

#### This repository hosts the DotNet project for uploading seed data and cleaning up the data.

## Scenario

**Enhance efficiency for developers**. The use case is an indispensable tool when it comes to loading and cleaning up FHIR datasets.



## Architecture
It a MVC DotNet application that integrates with FHIR APIs. The app also provides a simple front-end for uploading, viewing and cleaning up the seed data. 

### FHIR objects supported
1. Slots
2. Schedules
3. Patients
4. Practitioners
5. Appointments

## Steps to run the tool
1. Provision Azure FHIR API Service
2. Download the project from the repository
3. Register the application with Azure AD tenant where the Azure FHIR API Service is provisioned
4. Add the following values to Azure KeyVault provisioned in the same subscription as Azure FHIR API Service
    1. Application client ID
    2. Application secret
    3. Azure FHIR API URL
6. Deploy the DotNet project to Azure App Service.

   
