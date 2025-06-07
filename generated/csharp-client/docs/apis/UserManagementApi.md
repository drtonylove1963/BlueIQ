# BlueIQ.Sdk.Client.Api.UserManagementApi

All URIs are relative to *http://localhost:5000/api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateUser**](UserManagementApi.md#createuser) | **POST** /users | Create a new user |
| [**DeleteUser**](UserManagementApi.md#deleteuser) | **DELETE** /users/{userId} | Delete a user by ID |
| [**GetUserById**](UserManagementApi.md#getuserbyid) | **GET** /users/{userId} | Get a user by ID |
| [**ListUsers**](UserManagementApi.md#listusers) | **GET** /users | List all users |
| [**UpdateUser**](UserManagementApi.md#updateuser) | **PUT** /users/{userId} | Update an existing user |

<a id="createuser"></a>
# **CreateUser**
> User CreateUser (CreateUserRequest createUserRequest)

Create a new user

Creates a new user account. Requires username, email, and password. Optional fields include first name, last name, and role assignments.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class CreateUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new UserManagementApi(config);
            var createUserRequest = new CreateUserRequest(); // CreateUserRequest | User object to be created

            try
            {
                // Create a new user
                User result = apiInstance.CreateUser(createUserRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.CreateUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a new user
    ApiResponse<User> response = apiInstance.CreateUserWithHttpInfo(createUserRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.CreateUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createUserRequest** | [**CreateUserRequest**](CreateUserRequest.md) | User object to be created |  |

### Return type

[**User**](User.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | User created successfully |  -  |
| **400** | Invalid input |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **409** | User already exists |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deleteuser"></a>
# **DeleteUser**
> void DeleteUser (Guid userId)

Delete a user by ID

Deletes a specific user account by their unique ID. This operation is typically irreversible.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class DeleteUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new UserManagementApi(config);
            var userId = "userId_example";  // Guid | ID of the user to delete

            try
            {
                // Delete a user by ID
                apiInstance.DeleteUser(userId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.DeleteUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a user by ID
    apiInstance.DeleteUserWithHttpInfo(userId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.DeleteUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userId** | **Guid** | ID of the user to delete |  |

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
| **204** | User deleted successfully |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Not Found - The requested resource could not be found. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getuserbyid"></a>
# **GetUserById**
> User GetUserById (Guid userId)

Get a user by ID

Retrieves the details of a specific user account by their unique ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class GetUserByIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new UserManagementApi(config);
            var userId = "userId_example";  // Guid | ID of the user to retrieve

            try
            {
                // Get a user by ID
                User result = apiInstance.GetUserById(userId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.GetUserById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetUserByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a user by ID
    ApiResponse<User> response = apiInstance.GetUserByIdWithHttpInfo(userId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.GetUserByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userId** | **Guid** | ID of the user to retrieve |  |

### Return type

[**User**](User.md)

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

<a id="listusers"></a>
# **ListUsers**
> UserListResponse ListUsers (int page = null, int pageSize = null)

List all users

Retrieves a paginated list of all user accounts. Supports query parameters for pagination.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class ListUsersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new UserManagementApi(config);
            var page = 1;  // int | Page number for pagination (optional)  (default to 1)
            var pageSize = 20;  // int | Number of users per page (optional)  (default to 20)

            try
            {
                // List all users
                UserListResponse result = apiInstance.ListUsers(page, pageSize);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.ListUsers: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListUsersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all users
    ApiResponse<UserListResponse> response = apiInstance.ListUsersWithHttpInfo(page, pageSize);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.ListUsersWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int** | Page number for pagination | [optional] [default to 1] |
| **pageSize** | **int** | Number of users per page | [optional] [default to 20] |

### Return type

[**UserListResponse**](UserListResponse.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of users |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="updateuser"></a>
# **UpdateUser**
> User UpdateUser (Guid userId, UpdateUserRequest updateUserRequest)

Update an existing user

Updates an existing user's account details. Allows modification of email, names, active status, and role assignments.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class UpdateUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new UserManagementApi(config);
            var userId = "userId_example";  // Guid | ID of the user to update
            var updateUserRequest = new UpdateUserRequest(); // UpdateUserRequest | User object to be updated

            try
            {
                // Update an existing user
                User result = apiInstance.UpdateUser(userId, updateUserRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.UpdateUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update an existing user
    ApiResponse<User> response = apiInstance.UpdateUserWithHttpInfo(userId, updateUserRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.UpdateUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userId** | **Guid** | ID of the user to update |  |
| **updateUserRequest** | [**UpdateUserRequest**](UpdateUserRequest.md) | User object to be updated |  |

### Return type

[**User**](User.md)

### Authorization

[BearerAuth](../README.md#BearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | User updated successfully |  -  |
| **400** | Invalid input |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **403** | Forbidden - User does not have permission to access this resource. |  -  |
| **404** | Not Found - The requested resource could not be found. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

