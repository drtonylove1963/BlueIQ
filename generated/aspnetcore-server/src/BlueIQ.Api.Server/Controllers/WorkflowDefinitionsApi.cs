/*
 * BlueIQ API Gateway
 *
 * This document describes the API for the BlueIQ API Gateway. It serves as the single entry point for all client interactions with the BlueIQ microservices. This specification is designed to be a reference for consumers and a template for similar gateway patterns. 
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: support@example.com
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using BlueIQ.Api.Server.Attributes;
using BlueIQ.Api.Server.Models;

namespace BlueIQ.Api.Server.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class WorkflowDefinitionsApiController : ControllerBase
    { 
        /// <summary>
        /// Create a new workflow definition
        /// </summary>
        /// <remarks>Creates a new workflow definition (template). Requires a name, version, and a list of steps.</remarks>
        /// <param name="createWorkflowDefinitionRequest">Workflow definition object to be created</param>
        /// <response code="201">Workflow definition created successfully</response>
        /// <response code="400">Invalid input</response>
        /// <response code="401">Unauthorized - Authentication token is missing or invalid.</response>
        /// <response code="403">Forbidden - User does not have permission to access this resource.</response>
        /// <response code="409">Workflow definition already exists</response>
        /// <response code="500">Internal Server Error - An unexpected error occurred on the server.</response>
        [HttpPost]
        [Route("/api/v1/workflows/definitions")]
        [Authorize]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("CreateWorkflowDefinition")]
        [SwaggerResponse(statusCode: 201, type: typeof(WorkflowDefinition), description: "Workflow definition created successfully")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Invalid input")]
        [SwaggerResponse(statusCode: 401, type: typeof(ErrorResponse), description: "Unauthorized - Authentication token is missing or invalid.")]
        [SwaggerResponse(statusCode: 403, type: typeof(ErrorResponse), description: "Forbidden - User does not have permission to access this resource.")]
        [SwaggerResponse(statusCode: 409, type: typeof(ErrorResponse), description: "Workflow definition already exists")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Internal Server Error - An unexpected error occurred on the server.")]
        public virtual IActionResult CreateWorkflowDefinition([FromBody]CreateWorkflowDefinitionRequest createWorkflowDefinitionRequest)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default);
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default);
            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default);
            //TODO: Uncomment the next line to return response 403 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(403, default);
            //TODO: Uncomment the next line to return response 409 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(409, default);
            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500, default);
            string exampleJson = null;
            exampleJson = "{\r\n  \"createdAt\" : \"2023-02-01T11:00:00Z\",\r\n  \"name\" : \"DocumentApprovalProcess\",\r\n  \"description\" : \"A standard process for document review and approval.\",\r\n  \"id\" : \"a1b2c3d4-e5f6-7890-1234-567890abcdef\",\r\n  \"isActive\" : true,\r\n  \"version\" : \"1.0.0\",\r\n  \"steps\" : [ {\r\n    \"nextSteps\" : [ \"a1b2c3d4-e5f6-7890-1234-567890abcdef\", \"123e4567-e89b-12d3-a456-426614174000\" ],\r\n    \"name\" : \"ApprovalStep\",\r\n    \"id\" : \"c1b2a3d4-e5f6-7890-1234-567890abcdef\",\r\n    \"type\" : \"manual_approval\",\r\n    \"config\" : {\r\n      \"assignee_group\" : \"editors\",\r\n      \"notification_template\" : \"approval_request_email\"\r\n    },\r\n    \"isInitialStep\" : false\r\n  }, {\r\n    \"nextSteps\" : [ \"a1b2c3d4-e5f6-7890-1234-567890abcdef\", \"123e4567-e89b-12d3-a456-426614174000\" ],\r\n    \"name\" : \"ApprovalStep\",\r\n    \"id\" : \"c1b2a3d4-e5f6-7890-1234-567890abcdef\",\r\n    \"type\" : \"manual_approval\",\r\n    \"config\" : {\r\n      \"assignee_group\" : \"editors\",\r\n      \"notification_template\" : \"approval_request_email\"\r\n    },\r\n    \"isInitialStep\" : false\r\n  } ],\r\n  \"updatedAt\" : \"2023-02-02T14:15:00Z\"\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<WorkflowDefinition>(exampleJson)
            : default;
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Delete a workflow definition by ID
        /// </summary>
        /// <remarks>Deletes a specific workflow definition by its unique ID. This may affect the ability to start new workflow instances from this definition.</remarks>
        /// <param name="definitionId">ID of the workflow definition to delete</param>
        /// <response code="204">Workflow definition deleted successfully</response>
        /// <response code="401">Unauthorized - Authentication token is missing or invalid.</response>
        /// <response code="403">Forbidden - User does not have permission to access this resource.</response>
        /// <response code="404">Not Found - The requested resource could not be found.</response>
        /// <response code="500">Internal Server Error - An unexpected error occurred on the server.</response>
        [HttpDelete]
        [Route("/api/v1/workflows/definitions/{definitionId}")]
        [Authorize]
        [ValidateModelState]
        [SwaggerOperation("DeleteWorkflowDefinition")]
        [SwaggerResponse(statusCode: 401, type: typeof(ErrorResponse), description: "Unauthorized - Authentication token is missing or invalid.")]
        [SwaggerResponse(statusCode: 403, type: typeof(ErrorResponse), description: "Forbidden - User does not have permission to access this resource.")]
        [SwaggerResponse(statusCode: 404, type: typeof(ErrorResponse), description: "Not Found - The requested resource could not be found.")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Internal Server Error - An unexpected error occurred on the server.")]
        public virtual IActionResult DeleteWorkflowDefinition([FromRoute (Name = "definitionId")][Required]Guid definitionId)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);
            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default);
            //TODO: Uncomment the next line to return response 403 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(403, default);
            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default);
            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500, default);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a workflow definition by ID
        /// </summary>
        /// <remarks>Retrieves the details of a specific workflow definition by its unique ID.</remarks>
        /// <param name="definitionId">ID of the workflow definition to retrieve</param>
        /// <response code="200">Successful operation</response>
        /// <response code="401">Unauthorized - Authentication token is missing or invalid.</response>
        /// <response code="403">Forbidden - User does not have permission to access this resource.</response>
        /// <response code="404">Not Found - The requested resource could not be found.</response>
        /// <response code="500">Internal Server Error - An unexpected error occurred on the server.</response>
        [HttpGet]
        [Route("/api/v1/workflows/definitions/{definitionId}")]
        [Authorize]
        [ValidateModelState]
        [SwaggerOperation("GetWorkflowDefinitionById")]
        [SwaggerResponse(statusCode: 200, type: typeof(WorkflowDefinition), description: "Successful operation")]
        [SwaggerResponse(statusCode: 401, type: typeof(ErrorResponse), description: "Unauthorized - Authentication token is missing or invalid.")]
        [SwaggerResponse(statusCode: 403, type: typeof(ErrorResponse), description: "Forbidden - User does not have permission to access this resource.")]
        [SwaggerResponse(statusCode: 404, type: typeof(ErrorResponse), description: "Not Found - The requested resource could not be found.")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Internal Server Error - An unexpected error occurred on the server.")]
        public virtual IActionResult GetWorkflowDefinitionById([FromRoute (Name = "definitionId")][Required]Guid definitionId)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default);
            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default);
            //TODO: Uncomment the next line to return response 403 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(403, default);
            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default);
            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500, default);
            string exampleJson = null;
            exampleJson = "{\r\n  \"createdAt\" : \"2023-02-01T11:00:00Z\",\r\n  \"name\" : \"DocumentApprovalProcess\",\r\n  \"description\" : \"A standard process for document review and approval.\",\r\n  \"id\" : \"a1b2c3d4-e5f6-7890-1234-567890abcdef\",\r\n  \"isActive\" : true,\r\n  \"version\" : \"1.0.0\",\r\n  \"steps\" : [ {\r\n    \"nextSteps\" : [ \"a1b2c3d4-e5f6-7890-1234-567890abcdef\", \"123e4567-e89b-12d3-a456-426614174000\" ],\r\n    \"name\" : \"ApprovalStep\",\r\n    \"id\" : \"c1b2a3d4-e5f6-7890-1234-567890abcdef\",\r\n    \"type\" : \"manual_approval\",\r\n    \"config\" : {\r\n      \"assignee_group\" : \"editors\",\r\n      \"notification_template\" : \"approval_request_email\"\r\n    },\r\n    \"isInitialStep\" : false\r\n  }, {\r\n    \"nextSteps\" : [ \"a1b2c3d4-e5f6-7890-1234-567890abcdef\", \"123e4567-e89b-12d3-a456-426614174000\" ],\r\n    \"name\" : \"ApprovalStep\",\r\n    \"id\" : \"c1b2a3d4-e5f6-7890-1234-567890abcdef\",\r\n    \"type\" : \"manual_approval\",\r\n    \"config\" : {\r\n      \"assignee_group\" : \"editors\",\r\n      \"notification_template\" : \"approval_request_email\"\r\n    },\r\n    \"isInitialStep\" : false\r\n  } ],\r\n  \"updatedAt\" : \"2023-02-02T14:15:00Z\"\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<WorkflowDefinition>(exampleJson)
            : default;
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// List all workflow definitions
        /// </summary>
        /// <remarks>Retrieves a paginated list of all available workflow definitions (templates). Supports query parameters for pagination.</remarks>
        /// <param name="page">Page number for pagination</param>
        /// <param name="pageSize">Number of workflow definitions per page</param>
        /// <response code="200">A list of workflow definitions</response>
        /// <response code="401">Unauthorized - Authentication token is missing or invalid.</response>
        /// <response code="403">Forbidden - User does not have permission to access this resource.</response>
        /// <response code="500">Internal Server Error - An unexpected error occurred on the server.</response>
        [HttpGet]
        [Route("/api/v1/workflows/definitions")]
        [Authorize]
        [ValidateModelState]
        [SwaggerOperation("ListWorkflowDefinitions")]
        [SwaggerResponse(statusCode: 200, type: typeof(WorkflowDefinitionListResponse), description: "A list of workflow definitions")]
        [SwaggerResponse(statusCode: 401, type: typeof(ErrorResponse), description: "Unauthorized - Authentication token is missing or invalid.")]
        [SwaggerResponse(statusCode: 403, type: typeof(ErrorResponse), description: "Forbidden - User does not have permission to access this resource.")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Internal Server Error - An unexpected error occurred on the server.")]
        public virtual IActionResult ListWorkflowDefinitions([FromQuery (Name = "page")]int? page, [FromQuery (Name = "pageSize")]int? pageSize)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default);
            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default);
            //TODO: Uncomment the next line to return response 403 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(403, default);
            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500, default);
            string exampleJson = null;
            exampleJson = "{\r\n  \"pagination\" : {\r\n    \"totalItems\" : 100,\r\n    \"totalPages\" : 5,\r\n    \"pageSize\" : 20,\r\n    \"currentPage\" : 1\r\n  },\r\n  \"workflowDefinitions\" : [ {\r\n    \"createdAt\" : \"2023-02-01T11:00:00Z\",\r\n    \"name\" : \"DocumentApprovalProcess\",\r\n    \"description\" : \"A standard process for document review and approval.\",\r\n    \"id\" : \"a1b2c3d4-e5f6-7890-1234-567890abcdef\",\r\n    \"isActive\" : true,\r\n    \"version\" : \"1.0.0\",\r\n    \"steps\" : [ {\r\n      \"nextSteps\" : [ \"a1b2c3d4-e5f6-7890-1234-567890abcdef\", \"123e4567-e89b-12d3-a456-426614174000\" ],\r\n      \"name\" : \"ApprovalStep\",\r\n      \"id\" : \"c1b2a3d4-e5f6-7890-1234-567890abcdef\",\r\n      \"type\" : \"manual_approval\",\r\n      \"config\" : {\r\n        \"assignee_group\" : \"editors\",\r\n        \"notification_template\" : \"approval_request_email\"\r\n      },\r\n      \"isInitialStep\" : false\r\n    }, {\r\n      \"nextSteps\" : [ \"a1b2c3d4-e5f6-7890-1234-567890abcdef\", \"123e4567-e89b-12d3-a456-426614174000\" ],\r\n      \"name\" : \"ApprovalStep\",\r\n      \"id\" : \"c1b2a3d4-e5f6-7890-1234-567890abcdef\",\r\n      \"type\" : \"manual_approval\",\r\n      \"config\" : {\r\n        \"assignee_group\" : \"editors\",\r\n        \"notification_template\" : \"approval_request_email\"\r\n      },\r\n      \"isInitialStep\" : false\r\n    } ],\r\n    \"updatedAt\" : \"2023-02-02T14:15:00Z\"\r\n  }, {\r\n    \"createdAt\" : \"2023-02-01T11:00:00Z\",\r\n    \"name\" : \"DocumentApprovalProcess\",\r\n    \"description\" : \"A standard process for document review and approval.\",\r\n    \"id\" : \"a1b2c3d4-e5f6-7890-1234-567890abcdef\",\r\n    \"isActive\" : true,\r\n    \"version\" : \"1.0.0\",\r\n    \"steps\" : [ {\r\n      \"nextSteps\" : [ \"a1b2c3d4-e5f6-7890-1234-567890abcdef\", \"123e4567-e89b-12d3-a456-426614174000\" ],\r\n      \"name\" : \"ApprovalStep\",\r\n      \"id\" : \"c1b2a3d4-e5f6-7890-1234-567890abcdef\",\r\n      \"type\" : \"manual_approval\",\r\n      \"config\" : {\r\n        \"assignee_group\" : \"editors\",\r\n        \"notification_template\" : \"approval_request_email\"\r\n      },\r\n      \"isInitialStep\" : false\r\n    }, {\r\n      \"nextSteps\" : [ \"a1b2c3d4-e5f6-7890-1234-567890abcdef\", \"123e4567-e89b-12d3-a456-426614174000\" ],\r\n      \"name\" : \"ApprovalStep\",\r\n      \"id\" : \"c1b2a3d4-e5f6-7890-1234-567890abcdef\",\r\n      \"type\" : \"manual_approval\",\r\n      \"config\" : {\r\n        \"assignee_group\" : \"editors\",\r\n        \"notification_template\" : \"approval_request_email\"\r\n      },\r\n      \"isInitialStep\" : false\r\n    } ],\r\n    \"updatedAt\" : \"2023-02-02T14:15:00Z\"\r\n  } ]\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<WorkflowDefinitionListResponse>(exampleJson)
            : default;
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Update an existing workflow definition
        /// </summary>
        /// <remarks>Updates an existing workflow definition. Allows modification of name, version, description, steps, and active status.</remarks>
        /// <param name="definitionId">ID of the workflow definition to update</param>
        /// <param name="updateWorkflowDefinitionRequest">Workflow definition object to be updated</param>
        /// <response code="200">Workflow definition updated successfully</response>
        /// <response code="400">Invalid input</response>
        /// <response code="401">Unauthorized - Authentication token is missing or invalid.</response>
        /// <response code="403">Forbidden - User does not have permission to access this resource.</response>
        /// <response code="404">Not Found - The requested resource could not be found.</response>
        /// <response code="500">Internal Server Error - An unexpected error occurred on the server.</response>
        [HttpPut]
        [Route("/api/v1/workflows/definitions/{definitionId}")]
        [Authorize]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("UpdateWorkflowDefinition")]
        [SwaggerResponse(statusCode: 200, type: typeof(WorkflowDefinition), description: "Workflow definition updated successfully")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Invalid input")]
        [SwaggerResponse(statusCode: 401, type: typeof(ErrorResponse), description: "Unauthorized - Authentication token is missing or invalid.")]
        [SwaggerResponse(statusCode: 403, type: typeof(ErrorResponse), description: "Forbidden - User does not have permission to access this resource.")]
        [SwaggerResponse(statusCode: 404, type: typeof(ErrorResponse), description: "Not Found - The requested resource could not be found.")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Internal Server Error - An unexpected error occurred on the server.")]
        public virtual IActionResult UpdateWorkflowDefinition([FromRoute (Name = "definitionId")][Required]Guid definitionId, [FromBody]UpdateWorkflowDefinitionRequest updateWorkflowDefinitionRequest)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default);
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default);
            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default);
            //TODO: Uncomment the next line to return response 403 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(403, default);
            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default);
            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500, default);
            string exampleJson = null;
            exampleJson = "{\r\n  \"createdAt\" : \"2023-02-01T11:00:00Z\",\r\n  \"name\" : \"DocumentApprovalProcess\",\r\n  \"description\" : \"A standard process for document review and approval.\",\r\n  \"id\" : \"a1b2c3d4-e5f6-7890-1234-567890abcdef\",\r\n  \"isActive\" : true,\r\n  \"version\" : \"1.0.0\",\r\n  \"steps\" : [ {\r\n    \"nextSteps\" : [ \"a1b2c3d4-e5f6-7890-1234-567890abcdef\", \"123e4567-e89b-12d3-a456-426614174000\" ],\r\n    \"name\" : \"ApprovalStep\",\r\n    \"id\" : \"c1b2a3d4-e5f6-7890-1234-567890abcdef\",\r\n    \"type\" : \"manual_approval\",\r\n    \"config\" : {\r\n      \"assignee_group\" : \"editors\",\r\n      \"notification_template\" : \"approval_request_email\"\r\n    },\r\n    \"isInitialStep\" : false\r\n  }, {\r\n    \"nextSteps\" : [ \"a1b2c3d4-e5f6-7890-1234-567890abcdef\", \"123e4567-e89b-12d3-a456-426614174000\" ],\r\n    \"name\" : \"ApprovalStep\",\r\n    \"id\" : \"c1b2a3d4-e5f6-7890-1234-567890abcdef\",\r\n    \"type\" : \"manual_approval\",\r\n    \"config\" : {\r\n      \"assignee_group\" : \"editors\",\r\n      \"notification_template\" : \"approval_request_email\"\r\n    },\r\n    \"isInitialStep\" : false\r\n  } ],\r\n  \"updatedAt\" : \"2023-02-02T14:15:00Z\"\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            exampleJson = "{\r\n  \"details\" : \"The 'username' field is required.\",\r\n  \"message\" : \"Invalid input provided.\",\r\n  \"statusCode\" : 400\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<WorkflowDefinition>(exampleJson)
            : default;
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
