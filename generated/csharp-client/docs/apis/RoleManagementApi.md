# BlueIQ.Sdk.Client.Api.RoleManagementApi

All URIs are relative to *http://localhost:5000/api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateRole**](RoleManagementApi.md#createrole) | **POST** /roles | Create a new role |
| [**DeleteRole**](RoleManagementApi.md#deleterole) | **DELETE** /roles/{roleId} | Delete a role by ID |
| [**GetRoleById**](RoleManagementApi.md#getrolebyid) | **GET** /roles/{roleId} | Get a role by ID |
| [**ListRoles**](RoleManagementApi.md#listroles) | **GET** /roles | List all roles |
| [**UpdateRole**](RoleManagementApi.md#updaterole) | **PUT** /roles/{roleId} | Update an existing role |

<a id="createrole"></a>
# **CreateRole**
> Role CreateRole (CreateRoleRequest createRoleRequest)

Create a new role

Creates a new user role. Requires a role name. Optional fields include description and a list of permissions.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class CreateRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new RoleManagementApi(config);
            var createRoleRequest = new CreateRoleRequest(); // CreateRoleRequest | Role object to be created

            try
            {
                // Create a new role
                Role result = apiInstance.CreateRole(createRoleRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleManagementApi.CreateRole: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateRoleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a new role
    ApiResponse<Role> response = apiInstance.CreateRoleWithHttpInfo(createRoleRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RoleManagementApi.CreateRoleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createRoleRequest** | [**CreateRoleRequest**](CreateRoleRequest.md) | Role object to be created |  |

### Return type

[**Role**](Role.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Role created successfully |  -  |
| **400** | Invalid input |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **409** | Role already exists |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deleterole"></a>
# **DeleteRole**
> void DeleteRole (Guid roleId)

Delete a role by ID

Deletes a specific user role by its unique ID. This operation may affect users assigned to this role.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class DeleteRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new RoleManagementApi(config);
            var roleId = "roleId_example";  // Guid | ID of the role to delete

            try
            {
                // Delete a role by ID
                apiInstance.DeleteRole(roleId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleManagementApi.DeleteRole: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteRoleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a role by ID
    apiInstance.DeleteRoleWithHttpInfo(roleId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RoleManagementApi.DeleteRoleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **roleId** | **Guid** | ID of the role to delete |  |

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
| **204** | Role deleted successfully |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Not Found - The requested resource could not be found. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getrolebyid"></a>
# **GetRoleById**
> Role GetRoleById (Guid roleId)

Get a role by ID

Retrieves the details of a specific user role by its unique ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class GetRoleByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new RoleManagementApi(config);
            var roleId = "roleId_example";  // Guid | ID of the role to retrieve

            try
            {
                // Get a role by ID
                Role result = apiInstance.GetRoleById(roleId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleManagementApi.GetRoleById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetRoleByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a role by ID
    ApiResponse<Role> response = apiInstance.GetRoleByIdWithHttpInfo(roleId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RoleManagementApi.GetRoleByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **roleId** | **Guid** | ID of the role to retrieve |  |

### Return type

[**Role**](Role.md)

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

<a id="listroles"></a>
# **ListRoles**
> RoleListResponse ListRoles (int page = null, int pageSize = null)

List all roles

Retrieves a paginated list of all user roles. Supports query parameters for pagination.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class ListRolesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new RoleManagementApi(config);
            var page = 1;  // int | Page number for pagination (optional)  (default to 1)
            var pageSize = 20;  // int | Number of roles per page (optional)  (default to 20)

            try
            {
                // List all roles
                RoleListResponse result = apiInstance.ListRoles(page, pageSize);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleManagementApi.ListRoles: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListRolesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all roles
    ApiResponse<RoleListResponse> response = apiInstance.ListRolesWithHttpInfo(page, pageSize);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RoleManagementApi.ListRolesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int** | Page number for pagination | [optional] [default to 1] |
| **pageSize** | **int** | Number of roles per page | [optional] [default to 20] |

### Return type

[**RoleListResponse**](RoleListResponse.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of roles |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="updaterole"></a>
# **UpdateRole**
> Role UpdateRole (Guid roleId, UpdateRoleRequest updateRoleRequest)

Update an existing role

Updates an existing user role. Allows modification of name, description, and permissions.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class UpdateRoleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new RoleManagementApi(config);
            var roleId = "roleId_example";  // Guid | ID of the role to update
            var updateRoleRequest = new UpdateRoleRequest(); // UpdateRoleRequest | Role object to be updated

            try
            {
                // Update an existing role
                Role result = apiInstance.UpdateRole(roleId, updateRoleRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RoleManagementApi.UpdateRole: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateRoleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update an existing role
    ApiResponse<Role> response = apiInstance.UpdateRoleWithHttpInfo(roleId, updateRoleRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RoleManagementApi.UpdateRoleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **roleId** | **Guid** | ID of the role to update |  |
| **updateRoleRequest** | [**UpdateRoleRequest**](UpdateRoleRequest.md) | Role object to be updated |  |

### Return type

[**Role**](Role.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Role updated successfully |  -  |
| **400** | Invalid input |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Not Found - The requested resource could not be found. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

