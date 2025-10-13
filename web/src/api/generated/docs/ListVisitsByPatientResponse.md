# ListVisitsByPatientResponse


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | [**Ulid**](Ulid.md) |  | [optional] [default to undefined]
**createdAt** | **string** |  | [optional] [default to undefined]
**createdBy** | **string** |  | [optional] [default to undefined]
**updatedBy** | **string** |  | [optional] [default to undefined]
**updatedAt** | **string** |  | [optional] [default to undefined]
**patientId** | [**Ulid**](Ulid.md) |  | [optional] [default to undefined]
**visitDate** | **string** |  | [optional] [default to undefined]
**symptoms** | **string** |  | [optional] [default to undefined]
**diagnosis** | **string** |  | [optional] [default to undefined]
**note** | **string** |  | [optional] [default to undefined]

## Example

```typescript
import { ListVisitsByPatientResponse } from './api';

const instance: ListVisitsByPatientResponse = {
    id,
    createdAt,
    createdBy,
    updatedBy,
    updatedAt,
    patientId,
    visitDate,
    symptoms,
    diagnosis,
    note,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
