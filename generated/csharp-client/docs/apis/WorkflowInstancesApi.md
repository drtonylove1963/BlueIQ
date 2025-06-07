# BlueIQ.Sdk.Client.Api.WorkflowInstancesApi

All URIs are relative to *http://localhost:5000/api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CancelWorkflowInstance**](WorkflowInstancesApi.md#cancelworkflowinstance) | **POST** /workflows/instances/{instanceId}/cancel | Cancel Workflow Instance |
| [**GetWorkflowInstanceById**](WorkflowInstancesApi.md#getworkflowinstancebyid) | **GET** /workflows/instances/{instanceId} | Get a workflow instance by ID |
| [**ListWorkflowInstances**](WorkflowInstancesApi.md#listworkflowinstances) | **GET** /workflows/instances | List all workflow instances |
| [**ResumeWorkflowInstance**](WorkflowInstancesApi.md#resumeworkflowinstance) | **POST** /workflows/instances/{instanceId}/resume | Resume Workflow Instance |
| [**RetryWorkflowInstance**](WorkflowInstancesApi.md#retryworkflowinstance) | **POST** /workflows/instances/{instanceId}/retry | Retry Workflow Instance |
| [**StartWorkflowInstance**](WorkflowInstancesApi.md#startworkflowinstance) | **POST** /workflows/instances | Start a new workflow instance |
| [**SuspendWorkflowInstance**](WorkflowInstancesApi.md#suspendworkflowinstance) | **POST** /workflows/instances/{instanceId}/suspend | Suspend Workflow Instance |

<a id="cancelworkflowinstance"></a>
# **CancelWorkflowInstance**
> void CancelWorkflowInstance (Guid instanceId)

Cancel Workflow Instance

Cancels a currently running workflow instance. The instance must be in a cancellable state.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class CancelWorkflowInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowInstancesApi(config);
            var instanceId = "instanceId_example";  // Guid | ID of the workflow instance to cancel.

            try
            {
                // Cancel Workflow Instance
                apiInstance.CancelWorkflowInstance(instanceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowInstancesApi.CancelWorkflowInstance: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CancelWorkflowInstanceWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Cancel Workflow Instance
    apiInstance.CancelWorkflowInstanceWithHttpInfo(instanceId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowInstancesApi.CancelWorkflowInstanceWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instanceId** | **Guid** | ID of the workflow instance to cancel. |  |

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
| **204** | Workflow instance cancelled successfully. |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Not Found - The requested resource could not be found. |  -  |
| **409** | Conflict - The request could not be completed due to a conflict with the current state of the resource. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getworkflowinstancebyid"></a>
# **GetWorkflowInstanceById**
> WorkflowInstance GetWorkflowInstanceById (Guid instanceId)

Get a workflow instance by ID

Retrieves the details and current state of a specific workflow instance by its unique ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class GetWorkflowInstanceByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowInstancesApi(config);
            var instanceId = "instanceId_example";  // Guid | ID of the workflow instance to retrieve

            try
            {
                // Get a workflow instance by ID
                WorkflowInstance result = apiInstance.GetWorkflowInstanceById(instanceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowInstancesApi.GetWorkflowInstanceById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetWorkflowInstanceByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a workflow instance by ID
    ApiResponse<WorkflowInstance> response = apiInstance.GetWorkflowInstanceByIdWithHttpInfo(instanceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowInstancesApi.GetWorkflowInstanceByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instanceId** | **Guid** | ID of the workflow instance to retrieve |  |

### Return type

[**WorkflowInstance**](WorkflowInstance.md)

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

<a id="listworkflowinstances"></a>
# **ListWorkflowInstances**
> WorkflowInstanceListResponse ListWorkflowInstances (int page = null, int pageSize = null)

List all workflow instances

Retrieves a paginated list of all workflow instances, regardless of their status. Supports query parameters for pagination.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class ListWorkflowInstancesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowInstancesApi(config);
            var page = 1;  // int | Page number for pagination (optional)  (default to 1)
            var pageSize = 20;  // int | Number of workflow instances per page (optional)  (default to 20)

            try
            {
                // List all workflow instances
                WorkflowInstanceListResponse result = apiInstance.ListWorkflowInstances(page, pageSize);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowInstancesApi.ListWorkflowInstances: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListWorkflowInstancesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all workflow instances
    ApiResponse<WorkflowInstanceListResponse> response = apiInstance.ListWorkflowInstancesWithHttpInfo(page, pageSize);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowInstancesApi.ListWorkflowInstancesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int** | Page number for pagination | [optional] [default to 1] |
| **pageSize** | **int** | Number of workflow instances per page | [optional] [default to 20] |

### Return type

[**WorkflowInstanceListResponse**](WorkflowInstanceListResponse.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of workflow instances |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="resumeworkflowinstance"></a>
# **ResumeWorkflowInstance**
> void ResumeWorkflowInstance (Guid instanceId)

Resume Workflow Instance

Resumes a previously suspended workflow instance.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class ResumeWorkflowInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowInstancesApi(config);
            var instanceId = "instanceId_example";  // Guid | ID of the workflow instance to resume.

            try
            {
                // Resume Workflow Instance
                apiInstance.ResumeWorkflowInstance(instanceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowInstancesApi.ResumeWorkflowInstance: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ResumeWorkflowInstanceWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Resume Workflow Instance
    apiInstance.ResumeWorkflowInstanceWithHttpInfo(instanceId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowInstancesApi.ResumeWorkflowInstanceWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instanceId** | **Guid** | ID of the workflow instance to resume. |  |

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
| **204** | Workflow instance resumed successfully. |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Not Found - The requested resource could not be found. |  -  |
| **409** | Conflict - The request could not be completed due to a conflict with the current state of the resource. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="retryworkflowinstance"></a>
# **RetryWorkflowInstance**
> void RetryWorkflowInstance (Guid instanceId)

Retry Workflow Instance

Retries a workflow instance that is in a failed or pending_retry state, typically from its last failed step.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class RetryWorkflowInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowInstancesApi(config);
            var instanceId = "instanceId_example";  // Guid | ID of the workflow instance to retry.

            try
            {
                // Retry Workflow Instance
                apiInstance.RetryWorkflowInstance(instanceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowInstancesApi.RetryWorkflowInstance: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RetryWorkflowInstanceWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Retry Workflow Instance
    apiInstance.RetryWorkflowInstanceWithHttpInfo(instanceId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowInstancesApi.RetryWorkflowInstanceWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instanceId** | **Guid** | ID of the workflow instance to retry. |  |

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
| **200** | Workflow instance retry initiated successfully. |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Not Found - The requested resource could not be found. |  -  |
| **409** | Conflict - The request could not be completed due to a conflict with the current state of the resource. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="startworkflowinstance"></a>
# **StartWorkflowInstance**
> WorkflowInstance StartWorkflowInstance (StartWorkflowInstanceRequest startWorkflowInstanceRequest)

Start a new workflow instance

Starts a new instance of a specified workflow definition. Requires the workflow definition ID and can accept initial variables.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class StartWorkflowInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowInstancesApi(config);
            var startWorkflowInstanceRequest = new StartWorkflowInstanceRequest(); // StartWorkflowInstanceRequest | Parameters to start a workflow instance

            try
            {
                // Start a new workflow instance
                WorkflowInstance result = apiInstance.StartWorkflowInstance(startWorkflowInstanceRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowInstancesApi.StartWorkflowInstance: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StartWorkflowInstanceWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Start a new workflow instance
    ApiResponse<WorkflowInstance> response = apiInstance.StartWorkflowInstanceWithHttpInfo(startWorkflowInstanceRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowInstancesApi.StartWorkflowInstanceWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **startWorkflowInstanceRequest** | [**StartWorkflowInstanceRequest**](StartWorkflowInstanceRequest.md) | Parameters to start a workflow instance |  |

### Return type

[**WorkflowInstance**](WorkflowInstance.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Workflow instance started successfully |  -  |
| **400** | Invalid input or definition not found |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Workflow definition not found |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="suspendworkflowinstance"></a>
# **SuspendWorkflowInstance**
> void SuspendWorkflowInstance (Guid instanceId)

Suspend Workflow Instance

Suspends a currently running workflow instance. A suspended instance can be resumed later.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class SuspendWorkflowInstanceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new WorkflowInstancesApi(config);
            var instanceId = "instanceId_example";  // Guid | ID of the workflow instance to suspend.

            try
            {
                // Suspend Workflow Instance
                apiInstance.SuspendWorkflowInstance(instanceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WorkflowInstancesApi.SuspendWorkflowInstance: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SuspendWorkflowInstanceWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Suspend Workflow Instance
    apiInstance.SuspendWorkflowInstanceWithHttpInfo(instanceId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WorkflowInstancesApi.SuspendWorkflowInstanceWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instanceId** | **Guid** | ID of the workflow instance to suspend. |  |

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
| **204** | Workflow instance suspended successfully. |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Not Found - The requested resource could not be found. |  -  |
| **409** | Conflict - The request could not be completed due to a conflict with the current state of the resource. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

