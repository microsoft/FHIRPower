# PowerApps with Azure API for FHIR

#### This repository hosts the guidance and reference architecture(s) for using PowerApps with Azure API for FHIR.

## Scenario

**Improve patient experience**. The PowerApps application with FHIR for patients ensures all their medical data is secure, while enabling patients to access to their health data using user-friendly interface. 

**Enhance physician efficiency**. The PowerApps application with FHIR for doctors is an indispensable tool when it comes to orchestrating massive patient datasets, optimizing communication, and making their job less stressful with minimum paperwork. It helps get more reliable results and insights faster that might be needed for further patient treatment.

## Azure API for FHIR
The healthcare industry is rapidly transforming health data to the emerging standard of FHIR® (Fast Healthcare Interoperability Resources). FHIR enables a robust, extensible data model with standardized semantics and data exchange that enables all systems using FHIR to work together. FHIR also enables the rapid exchange of data in applications. Backed by a managed PaaS [Azure API for FHIR](https://docs.microsoft.com/en-us/azure/healthcare-apis/overview) offering, FHIR also provides a scalable and secure environment for the management and storage of Protected Health Information (PHI) data in the native FHIR format.

## FHIR Connectors
**[FHIRBase](https://docs.microsoft.com/en-us/connectors/fhirbase/)** and **[FHIRClinical](
https://docs.microsoft.com/en-us/connectors/fhirclinical/)** are certified custom connectors that allows for building healthcare applications to enable interoperability using FHIR.

Click on detailed links on [FHIRBase Actions](https://docs.microsoft.com/en-us/connectors/fhirbase/#actions) and [FHIRClinical Actions](https://docs.microsoft.com/en-us/connectors/fhirclinical/#actions) for API calls.

Click on [FHIR Base and Clinical Resources](https://www.hl7.org/fhir/resourcelist.html) to understand which connector to use for the resources.

## Prerequisites:

### Azure API for FHIR
Azure API for FHIR is First Party Auth, when [deployed via the Azure Portal](https://docs.microsoft.com/en-us/azure/healthcare-apis/fhir-paas-portal-quickstart) supports seemless integration with Azure App Service. Users with access to Azure API for FHIR only need to login when setting up a connector to apply their RBAC's to the data connection. For instance when a user with a FHIR Data Reader role authtenticates through the Connector, the connector assumes their FHIR DATA Reader role.

### Power Platform
Custom Connectors `FHIRBase` and `FHIRClinical` needs to be added to your PowerPlatform environment by your Admin.

## Get Started:
Coming Soon...

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Trademarks

This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft trademarks or logos is subject to and must follow [Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/en-us/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos are subject to those third-party's policies.
