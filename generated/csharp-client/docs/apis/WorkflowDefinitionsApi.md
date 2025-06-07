# BlueIQ.Sdk.Client.Api.WorkflowDefinitionsApi

All URIs are relative to *http://localhost:5000/api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateWorkflowDefinition**](WorkflowDefinitionsApi.md#createworkflowdefinition) | **POST** /workflows/definitions | Create a new workflow definition |
| [**DeleteWorkflowDefinition**](WorkflowDefinitionsApi.md#deleteworkflowdefinition) | **DELETE** /workflows/definitions/{definitionId} | Delete a workflow definition by ID |
| [**GetWorkflowDefinitionById**](WorkflowDefinitionsApi.md#getworkflowdefinitionbyid) | **GET** /workflows/definitions/{definitionId} | Get a workflow definition by ID |
| [**ListWorkflowDefinitions**](WorkflowDefinitionsApi.md#listworkflowdefinitions) | **GET** /workflows/definitions | List all workflow definitions |
| [**UpdateWorkflowDefinition**](WorkflowDefinitionsApi.md#updateworkflowdefinition) | **PUT** /workflows/definitions/{definitionId} | Update an existing workflow definition |

<a id="createworkflowdefinition"></a>
# **CreateWorkflowDefinition**
> WorkflowDefinition CreateWorkflowDefinition (CreateWorkflowDefinitionRequest createWorkflowDefinitionRequest)

Create a new workflow definition

Creates a new workflow definition (template). Requires a name, version, and a list of steps.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class CreateWorkflowDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowDefinitionsApi(config);
            var createWorkflowDefinitionRequest = new CreateWorkflowDefinitionRequest(); // CreateWorkflowDefinitionRequest | Workflow definition object to be created

            try
            {
                // Create a new workflow definition
                WorkflowDefinition result = apiInstance.CreateWorkflowDefinition(createWorkflowDefinitionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowDefinitionsApi.CreateWorkflowDefinition: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateWorkflowDefinitionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a new workflow definition
    ApiResponse<WorkflowDefinition> response = apiInstance.CreateWorkflowDefinitionWithHttpInfo(createWorkflowDefinitionRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowDefinitionsApi.CreateWorkflowDefinitionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createWorkflowDefinitionRequest** | [**CreateWorkflowDefinitionRequest**](CreateWorkflowDefinitionRequest.md) | Workflow definition object to be created |  |

### Return type

[**WorkflowDefinition**](WorkflowDefinition.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Workflow definition created successfully |  -  |
| **400** | Invalid input |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **409** | Workflow definition already exists |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deleteworkflowdefinition"></a>
# **DeleteWorkflowDefinition**
> void DeleteWorkflowDefinition (Guid definitionId)

Delete a workflow definition by ID

Deletes a specific workflow definition by its unique ID. This may affect the ability to start new workflow instances from this definition.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class DeleteWorkflowDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowDefinitionsApi(config);
            var definitionId = "definitionId_example";  // Guid | ID of the workflow definition to delete

            try
            {
                // Delete a workflow definition by ID
                apiInstance.DeleteWorkflowDefinition(definitionId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowDefinitionsApi.DeleteWorkflowDefinition: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteWorkflowDefinitionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a workflow definition by ID
    apiInstance.DeleteWorkflowDefinitionWithHttpInfo(definitionId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowDefinitionsApi.DeleteWorkflowDefinitionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **definitionId** | **Guid** | ID of the workflow definition to delete |  |

### Return type

void (empty response body)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Workflow definition deleted successfully |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Not Found - The requested resource could not be found. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getworkflowdefinitionbyid"></a>
# **GetWorkflowDefinitionById**
> WorkflowDefinition GetWorkflowDefinitionById (Guid definitionId)

Get a workflow definition by ID

Retrieves the details of a specific workflow definition by its unique ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class GetWorkflowDefinitionByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowDefinitionsApi(config);
            var definitionId = "definitionId_example";  // Guid | ID of the workflow definition to retrieve

            try
            {
                // Get a workflow definition by ID
                WorkflowDefinition result = apiInstance.GetWorkflowDefinitionById(definitionId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowDefinitionsApi.GetWorkflowDefinitionById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetWorkflowDefinitionByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a workflow definition by ID
    ApiResponse<WorkflowDefinition> response = apiInstance.GetWorkflowDefinitionByIdWithHttpInfo(definitionId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowDefinitionsApi.GetWorkflowDefinitionByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **definitionId** | **Guid** | ID of the workflow definition to retrieve |  |

### Return type

[**WorkflowDefinition**](WorkflowDefinition.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful operation |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Not Found - The requested resource could not be found. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="listworkflowdefinitions"></a>
# **ListWorkflowDefinitions**
> WorkflowDefinitionListResponse ListWorkflowDefinitions (int page = null, int pageSize = null)

List all workflow definitions

Retrieves a paginated list of all available workflow definitions (templates). Supports query parameters for pagination.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class ListWorkflowDefinitionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowDefinitionsApi(config);
            var page = 1;  // int | Page number for pagination (optional)  (default to 1)
            var pageSize = 20;  // int | Number of workflow definitions per page (optional)  (default to 20)

            try
            {
                // List all workflow definitions
                WorkflowDefinitionListResponse result = apiInstance.ListWorkflowDefinitions(page, pageSize);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowDefinitionsApi.ListWorkflowDefinitions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListWorkflowDefinitionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all workflow definitions
    ApiResponse<WorkflowDefinitionListResponse> response = apiInstance.ListWorkflowDefinitionsWithHttpInfo(page, pageSize);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowDefinitionsApi.ListWorkflowDefinitionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int** | Page number for pagination | [optional] [default to 1] |
| **pageSize** | **int** | Number of workflow definitions per page | [optional] [default to 20] |

### Return type

[**WorkflowDefinitionListResponse**](WorkflowDefinitionListResponse.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of workflow definitions |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="updateworkflowdefinition"></a>
# **UpdateWorkflowDefinition**
> WorkflowDefinition UpdateWorkflowDefinition (Guid definitionId, UpdateWorkflowDefinitionRequest updateWorkflowDefinitionRequest)

Update an existing workflow definition

Updates an existing workflow definition. Allows modification of name, version, description, steps, and active status.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class UpdateWorkflowDefinitionExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowDefinitionsApi(config);
            var definitionId = "definitionId_example";  // Guid | ID of the workflow definition to update
            var updateWorkflowDefinitionRequest = new UpdateWorkflowDefinitionRequest(); // UpdateWorkflowDefinitionRequest | Workflow definition object to be updated

            try
            {
                // Update an existing workflow definition
                WorkflowDefinition result = apiInstance.UpdateWorkflowDefinition(definitionId, updateWorkflowDefinitionRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowDefinitionsApi.UpdateWorkflowDefinition: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateWorkflowDefinitionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update an existing workflow definition
    ApiResponse<WorkflowDefinition> response = apiInstance.UpdateWorkflowDefinitionWithHttpInfo(definitionId, updateWorkflowDefinitionRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowDefinitionsApi.UpdateWorkflowDefinitionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **definitionId** | **Guid** | ID of the workflow definition to update |  |
| **updateWorkflowDefinitionRequest** | [**UpdateWorkflowDefinitionRequest**](UpdateWorkflowDefinitionRequest.md) | Workflow definition object to be updated |  |

### Return type

[**WorkflowDefinition**](WorkflowDefinition.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Workflow definition updated successfully |  -  |
| **400** | Invalid input |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Not Found - The requested resource could not be found. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

