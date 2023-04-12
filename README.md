# Event FHIR

## EventGridFhirFunction
When an event is triggered by FHIR server, the received **data** will be like this

```json
{ 
    "resourceType": "Task", 
    "resourceFhirAccount": "{fhir-server-id}.fhir.azurehealthcareapis.com", 
    "resourceFhirId": "01b92455-264e-4dec-8a04-54c79fa47b6f", 
    "resourceVersionId": 6 
}
```

## WebhookFhirFunction
