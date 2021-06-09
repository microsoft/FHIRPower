# Why?
Why would I ever create a Power Platform Custom Connector? Well, you don't have to. You could instead 
ask your Power Apps developers to call your custom APIs by creating a Flow action that calls your REST 
APIs (assuming you are still using REST). Maybe you'll give them a Swagger/Open API file to help them 
understand the available operations and schema too. They can then add an HTTP Request activity to 
their Flow and whatever number of Initialize Variable parameters needed to be passed from the Power 
Apps call to Flow. OR, you can give them a Power Platform Custom Connector that they simply add to the 
Power App and they can start to use like any other Power App function! Since the point of the 
FHIRPower project isn't to be a finished product, but rather a "starter kit", we wanted to use a 
Custom Connector to help others that might want to do something similar.

#Prerequisites
- These steps assume you have a running FHIR endpoint (like the Azure API for FHIR).

# Register your application in Azure Active Directory
WARNING: This can be the most complicated and fragile part of this process. Azure AD App registrations are poorly documented and we recommend working with someone who's done these before.
1. __Login to the Azure portal (https://portal.azure.com).__
2. __Click Azure Active Directory.__
3. __In the left-hand pane, click App registrations.__
4. __At the top of the main pane, click New registration.__
5. __Enter a display name for this application.__
It's probably a good practice to create an app registration for each Custom Connector you create so you may want to think about that when you name this app registration.
6. __Choose your supported account types.__
If you aren't sure, we recommend you start with the default option of single tenant.
7. __Add a Redirect URI.__
Select Web for your platform type and add https://global.consent.azure-apim.net/redirect.
9. __Click the Register button.__
10. __In the left-hand pane, Click Certificates & secrets.__
11. __Under Cllient secrets section, click the New client secret button.__
12. __Enter a description, choose an expires timeframe and click the Add button.__
13. __In the Value column of the Client secrets table, click the Copy to clipboard button.__
IMPORTANT: This is the only time you'll see the client secret so copy it to Notepad or some other location right now!
15. __In the left-hand pane, click API permissions.__
16. __Click the Add a permission button.__
17. __At the top of the main pane, click the APIs my organization uses tab and search for Azure Healthcare APIs.__
18. __Select the Azure Healthcare APIs option.__
19. __On the Azure Healthcare APIs page, check the box next to user_impersonation and click the Add permissions button.__
20. __In the left-hand pane, click Overview and capture the information here.__
In Notepad or some other location, you'll want to capture your Application (client) ID and Directory (tenant) ID.

# Creating a Power Platform Custom Connector for your FHIR API
1. __Log in to your Power Apps environment.__
2. __In the left-hand pane, click Data and select Custom Connectors.__
3. __In the upper-right corner, click New custom connector and select Create from blank.__
There are several options here, but since we are working with the FHIR API and it's Swagger file will exceed the 1MB limit imposed by the Power Platform, I'd recommend choosing Create from blank.
4. __Enter a name for your new custom connector.__
We are fans of purpose-built connectors so we recommend names that describe one or few scenarios that might be useful to your Power App developers. For example, we created a Custom Connector that had everything we thought it would be useful to the FHIR Appointment workflow - no more and no less.
5. __In the Host textbox enter your FHIR server's host name.__
Since the default selection on this page is to use HTTPS, only enter the FHIR server here. E.g. hlsfhirpower.azurehealthcareapis.com
6. __Click Security -> button.__
7. __In Authentication type drop down, select OAuth 2.0.__
8. __In the Identity Provider drop down, select Azure Active Directory.__
9. __In the Client id text box, paste the Application (client) ID you captured above.__
10. __In the Client secret text box, paste the value from the Client secret you captured above.__
11. __In the Tenant ID text box, paste the Directory (tenant) ID you captured above.__
12. __In the Resource URL text box, paste the URL to your FHIR endpoint.__
Now, you'll use the entire URL including the https://. E.g. https://hlsfhirpower.azurehealthcareapis.com/
13. __In the Scope text box, enter the API permission you set up above.__
This will be your FHIR endpoint URL again followed by /.default. E.g. https://hlsfhirpower.azurehealthcareapis.com/.default
14. __Click the Definition -> button.__
15. __Click the Swagger Editor toggle.__
16. __Use the YAML file in this repository as a reference to help you define the operations you want to expose through your Custom Connector.__
17. __At the top of the page, click the Update connector button.__
