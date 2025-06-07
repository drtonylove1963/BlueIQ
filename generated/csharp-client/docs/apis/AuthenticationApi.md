# BlueIQ.Sdk.Client.Api.AuthenticationApi

All URIs are relative to *http://localhost:5000/api/v1*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**LoginUser**](AuthenticationApi.md#loginuser) | **POST** /auth/login | Log in a user |
| [**LogoutUser**](AuthenticationApi.md#logoutuser) | **POST** /auth/logout | Log out a user |
| [**RefreshToken**](AuthenticationApi.md#refreshtoken) | **POST** /auth/refresh | Refresh an access token |

<a id="loginuser"></a>
# **LoginUser**
> LoginSuccessResponse LoginUser (UserLoginRequest userLoginRequest)

Log in a user

Authenticates a user with their credentials and returns JWT access and refresh tokens.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class LoginUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            var apiInstance = new AuthenticationApi(config);
            var userLoginRequest = new UserLoginRequest(); // UserLoginRequest | User credentials for login

            try
            {
                // Log in a user
                LoginSuccessResponse result = apiInstance.LoginUser(userLoginRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticationApi.LoginUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the LoginUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Log in a user
    ApiResponse<LoginSuccessResponse> response = apiInstance.LoginUserWithHttpInfo(userLoginRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthenticationApi.LoginUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userLoginRequest** | [**UserLoginRequest**](UserLoginRequest.md) | User credentials for login |  |

### Return type

[**LoginSuccessResponse**](LoginSuccessResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Login successful, returns access token |  -  |
| **400** | Invalid username or password |  -  |
| **401** | Authentication failed |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="logoutuser"></a>
# **LogoutUser**
> void LogoutUser ()

Log out a user

Invalidates the user's current session. The specifics of invalidation (e.g., token blocklisting) depend on server implementation.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class LogoutUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            // Configure Bearer token for authorization: BearerAuth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AuthenticationApi(config);

            try
            {
                // Log out a user
                apiInstance.LogoutUser();
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticationApi.LogoutUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the LogoutUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Log out a user
    apiInstance.LogoutUserWithHttpInfo();
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthenticationApi.LogoutUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
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
| **204** | Logout successful |  -  |
| **401** | Unauthorized - Authentication token is missing or invalid. |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="refreshtoken"></a>
# **RefreshToken**
> LoginSuccessResponse RefreshToken (RefreshTokenRequest refreshTokenRequest)

Refresh an access token

Obtains a new JWT access token using a valid refresh token.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Client;
using BlueIQ.Sdk.Client.Model;

namespace Example
{
    public class RefreshTokenExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost:5000/api/v1";
            var apiInstance = new AuthenticationApi(config);
            var refreshTokenRequest = new RefreshTokenRequest(); // RefreshTokenRequest | Refresh token

            try
            {
                // Refresh an access token
                LoginSuccessResponse result = apiInstance.RefreshToken(refreshTokenRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AuthenticationApi.RefreshToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the RefreshTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Refresh an access token
    ApiResponse<LoginSuccessResponse> response = apiInstance.RefreshTokenWithHttpInfo(refreshTokenRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AuthenticationApi.RefreshTokenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **refreshTokenRequest** | [**RefreshTokenRequest**](RefreshTokenRequest.md) | Refresh token |  |

### Return type

[**LoginSuccessResponse**](LoginSuccessResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Token refresh successful |  -  |
| **401** | Invalid or expired refresh token |  -  |
| **500** | Internal Server Error - An unexpected error occurred on the server. |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

