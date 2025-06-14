// <auto-generated>
/*
 * BlueIQ API Gateway
 *
 * This document describes the API for the BlueIQ API Gateway. It serves as the single entry point for all client interactions with the BlueIQ microservices. This specification is designed to be a reference for consumers and a template for similar gateway patterns. 
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: support@example.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using BlueIQ.Sdk.Client.Client;

namespace BlueIQ.Sdk.Client.Model
{
    /// <summary>
    /// WorkflowInstance
    /// </summary>
    public partial class WorkflowInstance : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowInstance" /> class.
        /// </summary>
        /// <param name="workflowDefinitionId">ID of the WorkflowDefinition this instance is based on.</param>
        /// <param name="status">Current status of the workflow instance.</param>
        /// <param name="id">id</param>
        /// <param name="workflowDefinitionVersion">Version of the WorkflowDefinition used for this instance.</param>
        /// <param name="currentStepId">ID of the current step the instance is waiting on or executing.</param>
        /// <param name="variables">Key-value pairs of variables associated with this workflow instance.</param>
        /// <param name="startedAt">startedAt</param>
        /// <param name="updatedAt">updatedAt</param>
        /// <param name="endedAt">endedAt</param>
        [JsonConstructor]
        public WorkflowInstance(Guid workflowDefinitionId, StatusEnum status, Option<Guid?> id = default, Option<string?> workflowDefinitionVersion = default, Option<Guid?> currentStepId = default, Option<Dictionary<string, Object>?> variables = default, Option<DateTime?> startedAt = default, Option<DateTime?> updatedAt = default, Option<DateTime?> endedAt = default)
        {
            WorkflowDefinitionId = workflowDefinitionId;
            Status = status;
            IdOption = id;
            WorkflowDefinitionVersionOption = workflowDefinitionVersion;
            CurrentStepIdOption = currentStepId;
            VariablesOption = variables;
            StartedAtOption = startedAt;
            UpdatedAtOption = updatedAt;
            EndedAtOption = endedAt;
            OnCreated();
        }

        partial void OnCreated();

        /// <summary>
        /// Current status of the workflow instance.
        /// </summary>
        /// <value>Current status of the workflow instance.</value>
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Running for value: running
            /// </summary>
            Running = 1,

            /// <summary>
            /// Enum Completed for value: completed
            /// </summary>
            Completed = 2,

            /// <summary>
            /// Enum Failed for value: failed
            /// </summary>
            Failed = 3,

            /// <summary>
            /// Enum Suspended for value: suspended
            /// </summary>
            Suspended = 4,

            /// <summary>
            /// Enum Cancelled for value: cancelled
            /// </summary>
            Cancelled = 5,

            /// <summary>
            /// Enum PendingRetry for value: pending_retry
            /// </summary>
            PendingRetry = 6
        }

        /// <summary>
        /// Returns a <see cref="StatusEnum"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static StatusEnum StatusEnumFromString(string value)
        {
            if (value.Equals("running"))
                return StatusEnum.Running;

            if (value.Equals("completed"))
                return StatusEnum.Completed;

            if (value.Equals("failed"))
                return StatusEnum.Failed;

            if (value.Equals("suspended"))
                return StatusEnum.Suspended;

            if (value.Equals("cancelled"))
                return StatusEnum.Cancelled;

            if (value.Equals("pending_retry"))
                return StatusEnum.PendingRetry;

            throw new NotImplementedException($"Could not convert value to type StatusEnum: '{value}'");
        }

        /// <summary>
        /// Returns a <see cref="StatusEnum"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static StatusEnum? StatusEnumFromStringOrDefault(string value)
        {
            if (value.Equals("running"))
                return StatusEnum.Running;

            if (value.Equals("completed"))
                return StatusEnum.Completed;

            if (value.Equals("failed"))
                return StatusEnum.Failed;

            if (value.Equals("suspended"))
                return StatusEnum.Suspended;

            if (value.Equals("cancelled"))
                return StatusEnum.Cancelled;

            if (value.Equals("pending_retry"))
                return StatusEnum.PendingRetry;

            return null;
        }

        /// <summary>
        /// Converts the <see cref="StatusEnum"/> to the json value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string StatusEnumToJsonValue(StatusEnum value)
        {
            if (value == StatusEnum.Running)
                return "running";

            if (value == StatusEnum.Completed)
                return "completed";

            if (value == StatusEnum.Failed)
                return "failed";

            if (value == StatusEnum.Suspended)
                return "suspended";

            if (value == StatusEnum.Cancelled)
                return "cancelled";

            if (value == StatusEnum.PendingRetry)
                return "pending_retry";

            throw new NotImplementedException($"Value could not be handled: '{value}'");
        }

        /// <summary>
        /// Current status of the workflow instance.
        /// </summary>
        /// <value>Current status of the workflow instance.</value>
        /* <example>running</example> */
        [JsonPropertyName("status")]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// ID of the WorkflowDefinition this instance is based on.
        /// </summary>
        /// <value>ID of the WorkflowDefinition this instance is based on.</value>
        /* <example>a1b2c3d4-e5f6-7890-1234-567890abcdef</example> */
        [JsonPropertyName("workflowDefinitionId")]
        public Guid WorkflowDefinitionId { get; set; }

        /// <summary>
        /// Used to track the state of Id
        /// </summary>
        [JsonIgnore]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public Option<Guid?> IdOption { get; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        /* <example>123e4567-e89b-12d3-a456-426614174000</example> */
        [JsonPropertyName("id")]
        public Guid? Id { get { return this.IdOption; } }

        /// <summary>
        /// Used to track the state of WorkflowDefinitionVersion
        /// </summary>
        [JsonIgnore]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public Option<string?> WorkflowDefinitionVersionOption { get; }

        /// <summary>
        /// Version of the WorkflowDefinition used for this instance.
        /// </summary>
        /// <value>Version of the WorkflowDefinition used for this instance.</value>
        /* <example>1.0.0</example> */
        [JsonPropertyName("workflowDefinitionVersion")]
        public string? WorkflowDefinitionVersion { get { return this.WorkflowDefinitionVersionOption; } }

        /// <summary>
        /// Used to track the state of CurrentStepId
        /// </summary>
        [JsonIgnore]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public Option<Guid?> CurrentStepIdOption { get; private set; }

        /// <summary>
        /// ID of the current step the instance is waiting on or executing.
        /// </summary>
        /// <value>ID of the current step the instance is waiting on or executing.</value>
        /* <example>c1b2a3d4-e5f6-7890-1234-567890abcdef</example> */
        [JsonPropertyName("currentStepId")]
        public Guid? CurrentStepId { get { return this.CurrentStepIdOption; } set { this.CurrentStepIdOption = new(value); } }

        /// <summary>
        /// Used to track the state of Variables
        /// </summary>
        [JsonIgnore]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public Option<Dictionary<string, Object>?> VariablesOption { get; private set; }

        /// <summary>
        /// Key-value pairs of variables associated with this workflow instance.
        /// </summary>
        /// <value>Key-value pairs of variables associated with this workflow instance.</value>
        /* <example>{&quot;documentId&quot;:&quot;doc-xyz-123&quot;,&quot;approvedBy&quot;:null}</example> */
        [JsonPropertyName("variables")]
        public Dictionary<string, Object>? Variables { get { return this.VariablesOption; } set { this.VariablesOption = new(value); } }

        /// <summary>
        /// Used to track the state of StartedAt
        /// </summary>
        [JsonIgnore]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public Option<DateTime?> StartedAtOption { get; }

        /// <summary>
        /// Gets or Sets StartedAt
        /// </summary>
        /* <example>2023-03-01T10:00Z</example> */
        [JsonPropertyName("startedAt")]
        public DateTime? StartedAt { get { return this.StartedAtOption; } }

        /// <summary>
        /// Used to track the state of UpdatedAt
        /// </summary>
        [JsonIgnore]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public Option<DateTime?> UpdatedAtOption { get; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        /* <example>2023-03-01T10:05Z</example> */
        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get { return this.UpdatedAtOption; } }

        /// <summary>
        /// Used to track the state of EndedAt
        /// </summary>
        [JsonIgnore]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public Option<DateTime?> EndedAtOption { get; }

        /// <summary>
        /// Gets or Sets EndedAt
        /// </summary>
        /* <example>2023-03-02T14:30Z</example> */
        [JsonPropertyName("endedAt")]
        public DateTime? EndedAt { get { return this.EndedAtOption; } }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkflowInstance {\n");
            sb.Append("  WorkflowDefinitionId: ").Append(WorkflowDefinitionId).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  WorkflowDefinitionVersion: ").Append(WorkflowDefinitionVersion).Append("\n");
            sb.Append("  CurrentStepId: ").Append(CurrentStepId).Append("\n");
            sb.Append("  Variables: ").Append(Variables).Append("\n");
            sb.Append("  StartedAt: ").Append(StartedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  EndedAt: ").Append(EndedAt).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

    /// <summary>
    /// A Json converter for type <see cref="WorkflowInstance" />
    /// </summary>
    public class WorkflowInstanceJsonConverter : JsonConverter<WorkflowInstance>
    {
        /// <summary>
        /// The format to use to serialize StartedAt
        /// </summary>
        public static string StartedAtFormat { get; set; } = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK";

        /// <summary>
        /// The format to use to serialize UpdatedAt
        /// </summary>
        public static string UpdatedAtFormat { get; set; } = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK";

        /// <summary>
        /// The format to use to serialize EndedAt
        /// </summary>
        public static string EndedAtFormat { get; set; } = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK";

        /// <summary>
        /// Deserializes json to <see cref="WorkflowInstance" />
        /// </summary>
        /// <param name="utf8JsonReader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        /// <exception cref="JsonException"></exception>
        public override WorkflowInstance Read(ref Utf8JsonReader utf8JsonReader, Type typeToConvert, JsonSerializerOptions jsonSerializerOptions)
        {
            int currentDepth = utf8JsonReader.CurrentDepth;

            if (utf8JsonReader.TokenType != JsonTokenType.StartObject && utf8JsonReader.TokenType != JsonTokenType.StartArray)
                throw new JsonException();

            JsonTokenType startingTokenType = utf8JsonReader.TokenType;

            Option<Guid?> workflowDefinitionId = default;
            Option<WorkflowInstance.StatusEnum?> status = default;
            Option<Guid?> id = default;
            Option<string?> workflowDefinitionVersion = default;
            Option<Guid?> currentStepId = default;
            Option<Dictionary<string, Object>?> variables = default;
            Option<DateTime?> startedAt = default;
            Option<DateTime?> updatedAt = default;
            Option<DateTime?> endedAt = default;

            while (utf8JsonReader.Read())
            {
                if (startingTokenType == JsonTokenType.StartObject && utf8JsonReader.TokenType == JsonTokenType.EndObject && currentDepth == utf8JsonReader.CurrentDepth)
                    break;

                if (startingTokenType == JsonTokenType.StartArray && utf8JsonReader.TokenType == JsonTokenType.EndArray && currentDepth == utf8JsonReader.CurrentDepth)
                    break;

                if (utf8JsonReader.TokenType == JsonTokenType.PropertyName && currentDepth == utf8JsonReader.CurrentDepth - 1)
                {
                    string? localVarJsonPropertyName = utf8JsonReader.GetString();
                    utf8JsonReader.Read();

                    switch (localVarJsonPropertyName)
                    {
                        case "workflowDefinitionId":
                            workflowDefinitionId = new Option<Guid?>(utf8JsonReader.TokenType == JsonTokenType.Null ? (Guid?)null : utf8JsonReader.GetGuid());
                            break;
                        case "status":
                            string? statusRawValue = utf8JsonReader.GetString();
                            if (statusRawValue != null)
                                status = new Option<WorkflowInstance.StatusEnum?>(WorkflowInstance.StatusEnumFromStringOrDefault(statusRawValue));
                            break;
                        case "id":
                            id = new Option<Guid?>(utf8JsonReader.TokenType == JsonTokenType.Null ? (Guid?)null : utf8JsonReader.GetGuid());
                            break;
                        case "workflowDefinitionVersion":
                            workflowDefinitionVersion = new Option<string?>(utf8JsonReader.GetString()!);
                            break;
                        case "currentStepId":
                            currentStepId = new Option<Guid?>(utf8JsonReader.TokenType == JsonTokenType.Null ? (Guid?)null : utf8JsonReader.GetGuid());
                            break;
                        case "variables":
                            variables = new Option<Dictionary<string, Object>?>(JsonSerializer.Deserialize<Dictionary<string, Object>>(ref utf8JsonReader, jsonSerializerOptions)!);
                            break;
                        case "startedAt":
                            startedAt = new Option<DateTime?>(JsonSerializer.Deserialize<DateTime>(ref utf8JsonReader, jsonSerializerOptions));
                            break;
                        case "updatedAt":
                            updatedAt = new Option<DateTime?>(JsonSerializer.Deserialize<DateTime>(ref utf8JsonReader, jsonSerializerOptions));
                            break;
                        case "endedAt":
                            endedAt = new Option<DateTime?>(JsonSerializer.Deserialize<DateTime?>(ref utf8JsonReader, jsonSerializerOptions));
                            break;
                        default:
                            break;
                    }
                }
            }

            if (!workflowDefinitionId.IsSet)
                throw new ArgumentException("Property is required for class WorkflowInstance.", nameof(workflowDefinitionId));

            if (!status.IsSet)
                throw new ArgumentException("Property is required for class WorkflowInstance.", nameof(status));

            if (workflowDefinitionId.IsSet && workflowDefinitionId.Value == null)
                throw new ArgumentNullException(nameof(workflowDefinitionId), "Property is not nullable for class WorkflowInstance.");

            if (status.IsSet && status.Value == null)
                throw new ArgumentNullException(nameof(status), "Property is not nullable for class WorkflowInstance.");

            if (id.IsSet && id.Value == null)
                throw new ArgumentNullException(nameof(id), "Property is not nullable for class WorkflowInstance.");

            if (workflowDefinitionVersion.IsSet && workflowDefinitionVersion.Value == null)
                throw new ArgumentNullException(nameof(workflowDefinitionVersion), "Property is not nullable for class WorkflowInstance.");

            if (variables.IsSet && variables.Value == null)
                throw new ArgumentNullException(nameof(variables), "Property is not nullable for class WorkflowInstance.");

            if (startedAt.IsSet && startedAt.Value == null)
                throw new ArgumentNullException(nameof(startedAt), "Property is not nullable for class WorkflowInstance.");

            if (updatedAt.IsSet && updatedAt.Value == null)
                throw new ArgumentNullException(nameof(updatedAt), "Property is not nullable for class WorkflowInstance.");

            return new WorkflowInstance(workflowDefinitionId.Value!.Value!, status.Value!.Value!, id, workflowDefinitionVersion, currentStepId, variables, startedAt, updatedAt, endedAt);
        }

        /// <summary>
        /// Serializes a <see cref="WorkflowInstance" />
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="workflowInstance"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Write(Utf8JsonWriter writer, WorkflowInstance workflowInstance, JsonSerializerOptions jsonSerializerOptions)
        {
            writer.WriteStartObject();

            WriteProperties(writer, workflowInstance, jsonSerializerOptions);
            writer.WriteEndObject();
        }

        /// <summary>
        /// Serializes the properties of <see cref="WorkflowInstance" />
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="workflowInstance"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void WriteProperties(Utf8JsonWriter writer, WorkflowInstance workflowInstance, JsonSerializerOptions jsonSerializerOptions)
        {
            if (workflowInstance.WorkflowDefinitionVersionOption.IsSet && workflowInstance.WorkflowDefinitionVersion == null)
                throw new ArgumentNullException(nameof(workflowInstance.WorkflowDefinitionVersion), "Property is required for class WorkflowInstance.");

            if (workflowInstance.VariablesOption.IsSet && workflowInstance.Variables == null)
                throw new ArgumentNullException(nameof(workflowInstance.Variables), "Property is required for class WorkflowInstance.");

            writer.WriteString("workflowDefinitionId", workflowInstance.WorkflowDefinitionId);

            var statusRawValue = WorkflowInstance.StatusEnumToJsonValue(workflowInstance.Status);
            writer.WriteString("status", statusRawValue);
            if (workflowInstance.IdOption.IsSet)
                writer.WriteString("id", workflowInstance.IdOption.Value!.Value);

            if (workflowInstance.WorkflowDefinitionVersionOption.IsSet)
                writer.WriteString("workflowDefinitionVersion", workflowInstance.WorkflowDefinitionVersion);

            if (workflowInstance.CurrentStepIdOption.IsSet)
                if (workflowInstance.CurrentStepIdOption.Value != null)
                    writer.WriteString("currentStepId", workflowInstance.CurrentStepIdOption.Value!.Value);
                else
                    writer.WriteNull("currentStepId");

            if (workflowInstance.VariablesOption.IsSet)
            {
                writer.WritePropertyName("variables");
                JsonSerializer.Serialize(writer, workflowInstance.Variables, jsonSerializerOptions);
            }
            if (workflowInstance.StartedAtOption.IsSet)
                writer.WriteString("startedAt", workflowInstance.StartedAtOption.Value!.Value.ToString(StartedAtFormat));

            if (workflowInstance.UpdatedAtOption.IsSet)
                writer.WriteString("updatedAt", workflowInstance.UpdatedAtOption.Value!.Value.ToString(UpdatedAtFormat));

            if (workflowInstance.EndedAtOption.IsSet)
                if (workflowInstance.EndedAtOption.Value != null)
                    writer.WriteString("endedAt", workflowInstance.EndedAtOption.Value!.Value.ToString(EndedAtFormat));
                else
                    writer.WriteNull("endedAt");
        }
    }
}
