# ClientApi

All URIs are relative to *https://server.ttexe.id.vn*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiAuthLoginPost**](#apiauthloginpost) | **POST** /api/Auth/Login | Logging in Account|
|[**apiAuthRefreshTokenPost**](#apiauthrefreshtokenpost) | **POST** /api/Auth/RefreshToken | Logging in Account|
|[**apiPatientsGet**](#apipatientsget) | **GET** /api/Patients | |
|[**apiPatientsIdGet**](#apipatientsidget) | **GET** /api/Patients/{id} | |
|[**apiPatientsIdPut**](#apipatientsidput) | **PUT** /api/Patients/{id} | |
|[**apiPatientsPost**](#apipatientspost) | **POST** /api/Patients | Create a new patient|
|[**apiVisitsPatientIdVisitsGet**](#apivisitspatientidvisitsget) | **GET** /api/Visits/{PatientId}/Visits | List visits by patient|
|[**apiVisitsPatientIdVisitsPost**](#apivisitspatientidvisitspost) | **POST** /api/Visits/{PatientId}/Visits | Create visit for a patient|

# **apiAuthLoginPost**
> LoginResponseApiResponse apiAuthLoginPost()


### Example

```typescript
import {
    ClientApi,
    Configuration,
    LoginCommand
} from './api';

const configuration = new Configuration();
const apiInstance = new ClientApi(configuration);

let loginCommand: LoginCommand; // (optional)

const { status, data } = await apiInstance.apiAuthLoginPost(
    loginCommand
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **loginCommand** | **LoginCommand**|  | |


### Return type

**LoginResponseApiResponse**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiAuthRefreshTokenPost**
> RefreshTokenResponseApiResponse apiAuthRefreshTokenPost()


### Example

```typescript
import {
    ClientApi,
    Configuration,
    RefreshTokenCommand
} from './api';

const configuration = new Configuration();
const apiInstance = new ClientApi(configuration);

let refreshTokenCommand: RefreshTokenCommand; // (optional)

const { status, data } = await apiInstance.apiAuthRefreshTokenPost(
    refreshTokenCommand
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **refreshTokenCommand** | **RefreshTokenCommand**|  | |


### Return type

**RefreshTokenResponseApiResponse**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiPatientsGet**
> ListPatientResponsePaginationResponseApiResponse apiPatientsGet()


### Example

```typescript
import {
    ClientApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new ClientApi(configuration);

let page: number; // (optional) (default to undefined)
let pageSize: number; // (optional) (default to undefined)
let keyword: string; // (optional) (default to undefined)
let targets: Array<string>; // (optional) (default to undefined)
let sort: string; // (optional) (default to undefined)
let filter: any; // (optional) (default to undefined)
let originFilters: Array<string>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiPatientsGet(
    page,
    pageSize,
    keyword,
    targets,
    sort,
    filter,
    originFilters
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **page** | [**number**] |  | (optional) defaults to undefined|
| **pageSize** | [**number**] |  | (optional) defaults to undefined|
| **keyword** | [**string**] |  | (optional) defaults to undefined|
| **targets** | **Array&lt;string&gt;** |  | (optional) defaults to undefined|
| **sort** | [**string**] |  | (optional) defaults to undefined|
| **filter** | **any** |  | (optional) defaults to undefined|
| **originFilters** | **Array&lt;string&gt;** |  | (optional) defaults to undefined|


### Return type

**ListPatientResponsePaginationResponseApiResponse**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiPatientsIdGet**
> PatientDetailResponseApiResponse apiPatientsIdGet()


### Example

```typescript
import {
    ClientApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new ClientApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiPatientsIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**PatientDetailResponseApiResponse**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiPatientsIdPut**
> ApiResponse apiPatientsIdPut()


### Example

```typescript
import {
    ClientApi,
    Configuration,
    PatientModel
} from './api';

const configuration = new Configuration();
const apiInstance = new ClientApi(configuration);

let id: string; // (default to undefined)
let patientModel: PatientModel; // (optional)

const { status, data } = await apiInstance.apiPatientsIdPut(
    id,
    patientModel
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **patientModel** | **PatientModel**|  | |
| **id** | [**string**] |  | defaults to undefined|


### Return type

**ApiResponse**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiPatientsPost**
> ApiResponse apiPatientsPost()


### Example

```typescript
import {
    ClientApi,
    Configuration,
    CreatePatientCommand
} from './api';

const configuration = new Configuration();
const apiInstance = new ClientApi(configuration);

let createPatientCommand: CreatePatientCommand; // (optional)

const { status, data } = await apiInstance.apiPatientsPost(
    createPatientCommand
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **createPatientCommand** | **CreatePatientCommand**|  | |


### Return type

**ApiResponse**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiVisitsPatientIdVisitsGet**
> ListVisitsByPatientResponsePaginationResponseApiResponse apiVisitsPatientIdVisitsGet()


### Example

```typescript
import {
    ClientApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new ClientApi(configuration);

let patientId: string; // (default to undefined)
let page: number; // (optional) (default to undefined)
let pageSize: number; // (optional) (default to undefined)
let keyword: string; // (optional) (default to undefined)
let targets: Array<string>; // (optional) (default to undefined)
let sort: string; // (optional) (default to undefined)
let filter: any; // (optional) (default to undefined)
let originFilters: Array<string>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiVisitsPatientIdVisitsGet(
    patientId,
    page,
    pageSize,
    keyword,
    targets,
    sort,
    filter,
    originFilters
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **patientId** | [**string**] |  | defaults to undefined|
| **page** | [**number**] |  | (optional) defaults to undefined|
| **pageSize** | [**number**] |  | (optional) defaults to undefined|
| **keyword** | [**string**] |  | (optional) defaults to undefined|
| **targets** | **Array&lt;string&gt;** |  | (optional) defaults to undefined|
| **sort** | [**string**] |  | (optional) defaults to undefined|
| **filter** | **any** |  | (optional) defaults to undefined|
| **originFilters** | **Array&lt;string&gt;** |  | (optional) defaults to undefined|


### Return type

**ListVisitsByPatientResponsePaginationResponseApiResponse**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiVisitsPatientIdVisitsPost**
> ApiResponse apiVisitsPatientIdVisitsPost()


### Example

```typescript
import {
    ClientApi,
    Configuration,
    VisitModel
} from './api';

const configuration = new Configuration();
const apiInstance = new ClientApi(configuration);

let patientId: string; // (default to undefined)
let visitModel: VisitModel; // (optional)

const { status, data } = await apiInstance.apiVisitsPatientIdVisitsPost(
    patientId,
    visitModel
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **visitModel** | **VisitModel**|  | |
| **patientId** | [**string**] |  | defaults to undefined|


### Return type

**ApiResponse**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

