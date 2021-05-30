Step 1 - Create App Registration to access the FHIR Server API

	1. Create New Azure App Registration to access FHIR Server
		a. Name: URL of FHIR Server API
		b. Select "Accounts in this organization directory  only."
		c. Create:
			i. Capture the Client ID of the newly created App Registration
	2. Configure App Registration
		a. Expose an API 
			i. Add Scope
				1) Name: user_impersonation
				2) Consent: Admins and users
				3) Configure Admin and User display name/description
				4) Save
		b. API Permissions: 
			i. Add a permission
				1) APIs in my Org 
				2) Find and Select [FHIR server API]
				3) Check permission
				4) Add permission
	
 	
Step 2 - Create App Registration for Custom Connector to access App Registration for FHIR Server API

	1. Create New Azure App Registration to access FHIR Server API App Registration
		a. Name: [recommend adding PAConnector to name]
		b. Select "Accounts in any organization directory" if you plan to access FHIR API from outside this Tenant.
		c. Create:
			i. Capture the Client ID of the newly created App Registration
	2. Configure App Registration
		a. Certificate & Secret
			i. New client secret
				1) Description: [your choice]
				2) Expires: [how long do you want the secret to last]
				3) Add
					a) Capture the Value of the Secret and store this for later use.
		b. API Permissions: 
			i. Add a permission
				1) APIs in my Org 
				2) Find and Select [FHIR server API Previously created in Step 1]
				3) Check permission

  
Step 3 - Create PowerApps Custom Connector

	1. Open https://make.powerapps.com
	2. Confirm or Select Environment
	3. Open Menu: Data->Custom Connectors
	4. Select "+ New custom connector" (From Blank)
	5. Name your connector, select Continue
	6. General Information
		a. Scheme: HTTPS
		b. Host: FHIR Server API (do not include http)
		c. Base URL: /
		d. Select "Security ->" to move to the next screen.
	7. Security
		a. Authentication Type: OAuth 2.0
		b. Identity Provider: Azure Active Directory
		c. Client id: Client id saved from step 2
		d. Client secret: Client secret saved from step 2
		e. Login URL: "https://login.windows.net"
		f. Tenant ID: Tenant Id of the App Registration created in Step 2
		g. Resource URL: URL of the FHIR Server API
		h. Scope: URL of the FHIR Server API + ".default"    ex.  http://myfhirserver.azurehealthcareapis.com/.default 
		i. Select "Create connector"
		j. Copy Redirect URL value.  This will be needed in Step 4.
		k. Select "Definition" to move to the next screen.
	8. Definition
		a. Begin to define the connector.  Be sure to click "Update connector" to save your changes.


Step 4 - Update Custom Connector App Registration

	1. Open App Registration from Step 2
	2. Authentication
		a. Add a platform
			i. Web
				1) Provide Redirect URIs from PowerApp Custom Connector Security screen (Generated Redirect URL)
				2) Implicit grant (Access tokens and ID Tokens)
				3) Configure
	





