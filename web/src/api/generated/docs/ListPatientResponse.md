# ListPatientResponse


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | [**Ulid**](Ulid.md) |  | [optional] [default to undefined]
**createdAt** | **string** |  | [optional] [default to undefined]
**createdBy** | **string** |  | [optional] [default to undefined]
**updatedBy** | **string** |  | [optional] [default to undefined]
**updatedAt** | **string** |  | [optional] [default to undefined]
**fullName** | **string** |  | [optional] [default to undefined]
**age** | **number** |  | [optional] [default to undefined]
**gender** | [**Gender**](Gender.md) |  | [optional] [default to undefined]
**numberVisits** | **number** |  | [optional] [default to undefined]

## Example

```typescript
import { ListPatientResponse } from './api';

const instance: ListPatientResponse = {
    id,
    createdAt,
    createdBy,
    updatedBy,
    updatedAt,
    fullName,
    age,
    gender,
    numberVisits,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
