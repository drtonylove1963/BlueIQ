/*
 * BlueIQ API Gateway
 *
 * This document describes the API for the BlueIQ API Gateway. It serves as the single entry point for all client interactions with the BlueIQ microservices. This specification is designed to be a reference for consumers and a template for similar gateway patterns. 
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: support@example.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using BlueIQ.Sdk.Client.Api;
using BlueIQ.Sdk.Client.Model;


/* *********************************************************************************
*              Follow these manual steps to construct tests.
*              This file will not be overwritten.
*  *********************************************************************************
* 1. Navigate to ApiTests.Base.cs and ensure any tokens are being created correctly.
*    Take care not to commit credentials to any repository.
*
* 2. Mocking is coordinated by ApiTestsBase#AddApiHttpClients.
*    To mock the client, use the generic AddApiHttpClients.
*    To mock the server, change the client's BaseAddress.
*
* 3. Locate the test you want below
*      - remove the skip property from the Fact attribute
*      - set the value of any variables if necessary
*
* 4. Run the tests and ensure they work.
*
*/


namespace BlueIQ.Sdk.Client.Test.Api
{
    /// <summary>
    ///  Class for testing UserManagementApi
    /// </summary>
    public sealed class UserManagementApiTests : ApiTestsBase
    {
        private readonly IUserManagementApi _instance;

        public UserManagementApiTests(): base(Array.Empty<string>())
        {
            _instance = _host.Services.GetRequiredService<IUserManagementApi>();
        }

        /// <summary>
        /// Test CreateUser
        /// </summary>
        [Fact (Skip = "not implemented")]
        public async Task CreateUserAsyncTest()
        {
            CreateUserRequest createUserRequest = default!;
            var response = await _instance.CreateUserAsync(createUserRequest);
            var model = response.Created();
            Assert.IsType<User>(model);
        }

        /// <summary>
        /// Test DeleteUser
        /// </summary>
        [Fact (Skip = "not implemented")]
        public async Task DeleteUserAsyncTest()
        {
            Guid userId = default!;
            await _instance.DeleteUserAsync(userId);
        }

        /// <summary>
        /// Test GetUserById
        /// </summary>
        [Fact (Skip = "not implemented")]
        public async Task GetUserByIdAsyncTest()
        {
            Guid userId = default!;
            var response = await _instance.GetUserByIdAsync(userId);
            var model = response.Ok();
            Assert.IsType<User>(model);
        }

        /// <summary>
        /// Test ListUsers
        /// </summary>
        [Fact (Skip = "not implemented")]
        public async Task ListUsersAsyncTest()
        {
            Client.Option<int> page = default!;
            Client.Option<int> pageSize = default!;
            var response = await _instance.ListUsersAsync(page, pageSize);
            var model = response.Ok();
            Assert.IsType<UserListResponse>(model);
        }

        /// <summary>
        /// Test UpdateUser
        /// </summary>
        [Fact (Skip = "not implemented")]
        public async Task UpdateUserAsyncTest()
        {
            Guid userId = default!;
            UpdateUserRequest updateUserRequest = default!;
            var response = await _instance.UpdateUserAsync(userId, updateUserRequest);
            var model = response.Ok();
            Assert.IsType<User>(model);
        }
    }
}
