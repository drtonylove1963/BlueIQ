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
    /// WorkflowDefinitionStep
    /// </summary>
    public partial class WorkflowDefinitionStep : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowDefinitionStep" /> class.
        /// </summary>
        /// <param name="name">Human-readable name for the step.</param>
        /// <param name="type">Type of the step (e.g., &#39;manual_approval&#39;, &#39;automated_task&#39;, &#39;notification&#39;).</param>
        /// <param name="id">Unique identifier for the step within the definition.</param>
        /// <param name="config">Step-specific configuration parameters.</param>
        /// <param name="nextSteps">List of IDs of the next possible steps in the workflow.</param>
        /// <param name="isInitialStep">Indicates if this is the starting step of the workflow. (default to false)</param>
        [JsonConstructor]
        public WorkflowDefinitionStep(string name, string type, Option<Guid?> id = default, Option<Dictionary<string, Object>?> config = default, Option<List<Guid>?> nextSteps = default, Option<bool?> isInitialStep = default)
        {
            Name = name;
            Type = type;
            IdOption = id;
            ConfigOption = config;
            NextStepsOption = nextSteps;
            IsInitialStepOption = isInitialStep;
            OnCreated();
        }

        partial void OnCreated();

        /// <summary>
        /// Human-readable name for the step.
        /// </summary>
        /// <value>Human-readable name for the step.</value>
        /* <example>ApprovalStep</example> */
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of the step (e.g., &#39;manual_approval&#39;, &#39;automated_task&#39;, &#39;notification&#39;).
        /// </summary>
        /// <value>Type of the step (e.g., &#39;manual_approval&#39;, &#39;automated_task&#39;, &#39;notification&#39;).</value>
        /* <example>manual_approval</example> */
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Used to track the state of Id
        /// </summary>
        [JsonIgnore]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public Option<Guid?> IdOption { get; private set; }

        /// <summary>
        /// Unique identifier for the step within the definition.
        /// </summary>
        /// <value>Unique identifier for the step within the definition.</value>
        /* <example>c1b2a3d4-e5f6-7890-1234-567890abcdef</example> */
        [JsonPropertyName("id")]
        public Guid? Id { get { return this.IdOption; } set { this.IdOption = new(value); } }

        /// <summary>
        /// Used to track the state of Config
        /// </summary>
        [JsonIgnore]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public Option<Dictionary<string, Object>?> ConfigOption { get; private set; }

        /// <summary>
        /// Step-specific configuration parameters.
        /// </summary>
        /// <value>Step-specific configuration parameters.</value>
        /* <example>{&quot;assignee_group&quot;:&quot;editors&quot;,&quot;notification_template&quot;:&quot;approval_request_email&quot;}</example> */
        [JsonPropertyName("config")]
        public Dictionary<string, Object>? Config { get { return this.ConfigOption; } set { this.ConfigOption = new(value); } }

        /// <summary>
        /// Used to track the state of NextSteps
        /// </summary>
        [JsonIgnore]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public Option<List<Guid>?> NextStepsOption { get; private set; }

        /// <summary>
        /// List of IDs of the next possible steps in the workflow.
        /// </summary>
        /// <value>List of IDs of the next possible steps in the workflow.</value>
        /* <example>[&quot;a1b2c3d4-e5f6-7890-1234-567890abcdef&quot;,&quot;123e4567-e89b-12d3-a456-426614174000&quot;]</example> */
        [JsonPropertyName("nextSteps")]
        public List<Guid>? NextSteps { get { return this.NextStepsOption; } set { this.NextStepsOption = new(value); } }

        /// <summary>
        /// Used to track the state of IsInitialStep
        /// </summary>
        [JsonIgnore]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public Option<bool?> IsInitialStepOption { get; private set; }

        /// <summary>
        /// Indicates if this is the starting step of the workflow.
        /// </summary>
        /// <value>Indicates if this is the starting step of the workflow.</value>
        [JsonPropertyName("isInitialStep")]
        public bool? IsInitialStep { get { return this.IsInitialStepOption; } set { this.IsInitialStepOption = new(value); } }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WorkflowDefinitionStep {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Config: ").Append(Config).Append("\n");
            sb.Append("  NextSteps: ").Append(NextSteps).Append("\n");
            sb.Append("  IsInitialStep: ").Append(IsInitialStep).Append("\n");
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
    /// A Json converter for type <see cref="WorkflowDefinitionStep" />
    /// </summary>
    public class WorkflowDefinitionStepJsonConverter : JsonConverter<WorkflowDefinitionStep>
    {
        /// <summary>
        /// Deserializes json to <see cref="WorkflowDefinitionStep" />
        /// </summary>
        /// <param name="utf8JsonReader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        /// <exception cref="JsonException"></exception>
        public override WorkflowDefinitionStep Read(ref Utf8JsonReader utf8JsonReader, Type typeToConvert, JsonSerializerOptions jsonSerializerOptions)
        {
            int currentDepth = utf8JsonReader.CurrentDepth;

            if (utf8JsonReader.TokenType != JsonTokenType.StartObject && utf8JsonReader.TokenType != JsonTokenType.StartArray)
                throw new JsonException();

            JsonTokenType startingTokenType = utf8JsonReader.TokenType;

            Option<string?> name = default;
            Option<string?> type = default;
            Option<Guid?> id = default;
            Option<Dictionary<string, Object>?> config = default;
            Option<List<Guid>?> nextSteps = default;
            Option<bool?> isInitialStep = default;

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
                        case "name":
                            name = new Option<string?>(utf8JsonReader.GetString()!);
                            break;
                        case "type":
                            type = new Option<string?>(utf8JsonReader.GetString()!);
                            break;
                        case "id":
                            id = new Option<Guid?>(utf8JsonReader.TokenType == JsonTokenType.Null ? (Guid?)null : utf8JsonReader.GetGuid());
                            break;
                        case "config":
                            config = new Option<Dictionary<string, Object>?>(JsonSerializer.Deserialize<Dictionary<string, Object>>(ref utf8JsonReader, jsonSerializerOptions)!);
                            break;
                        case "nextSteps":
                            nextSteps = new Option<List<Guid>?>(JsonSerializer.Deserialize<List<Guid>>(ref utf8JsonReader, jsonSerializerOptions)!);
                            break;
                        case "isInitialStep":
                            isInitialStep = new Option<bool?>(utf8JsonReader.TokenType == JsonTokenType.Null ? (bool?)null : utf8JsonReader.GetBoolean());
                            break;
                        default:
                            break;
                    }
                }
            }

            if (!name.IsSet)
                throw new ArgumentException("Property is required for class WorkflowDefinitionStep.", nameof(name));

            if (!type.IsSet)
                throw new ArgumentException("Property is required for class WorkflowDefinitionStep.", nameof(type));

            if (name.IsSet && name.Value == null)
                throw new ArgumentNullException(nameof(name), "Property is not nullable for class WorkflowDefinitionStep.");

            if (type.IsSet && type.Value == null)
                throw new ArgumentNullException(nameof(type), "Property is not nullable for class WorkflowDefinitionStep.");

            if (id.IsSet && id.Value == null)
                throw new ArgumentNullException(nameof(id), "Property is not nullable for class WorkflowDefinitionStep.");

            if (config.IsSet && config.Value == null)
                throw new ArgumentNullException(nameof(config), "Property is not nullable for class WorkflowDefinitionStep.");

            if (nextSteps.IsSet && nextSteps.Value == null)
                throw new ArgumentNullException(nameof(nextSteps), "Property is not nullable for class WorkflowDefinitionStep.");

            if (isInitialStep.IsSet && isInitialStep.Value == null)
                throw new ArgumentNullException(nameof(isInitialStep), "Property is not nullable for class WorkflowDefinitionStep.");

            return new WorkflowDefinitionStep(name.Value!, type.Value!, id, config, nextSteps, isInitialStep);
        }

        /// <summary>
        /// Serializes a <see cref="WorkflowDefinitionStep" />
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="workflowDefinitionStep"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Write(Utf8JsonWriter writer, WorkflowDefinitionStep workflowDefinitionStep, JsonSerializerOptions jsonSerializerOptions)
        {
            writer.WriteStartObject();

            WriteProperties(writer, workflowDefinitionStep, jsonSerializerOptions);
            writer.WriteEndObject();
        }

        /// <summary>
        /// Serializes the properties of <see cref="WorkflowDefinitionStep" />
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="workflowDefinitionStep"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void WriteProperties(Utf8JsonWriter writer, WorkflowDefinitionStep workflowDefinitionStep, JsonSerializerOptions jsonSerializerOptions)
        {
            if (workflowDefinitionStep.Name == null)
                throw new ArgumentNullException(nameof(workflowDefinitionStep.Name), "Property is required for class WorkflowDefinitionStep.");

            if (workflowDefinitionStep.Type == null)
                throw new ArgumentNullException(nameof(workflowDefinitionStep.Type), "Property is required for class WorkflowDefinitionStep.");

            if (workflowDefinitionStep.ConfigOption.IsSet && workflowDefinitionStep.Config == null)
                throw new ArgumentNullException(nameof(workflowDefinitionStep.Config), "Property is required for class WorkflowDefinitionStep.");

            if (workflowDefinitionStep.NextStepsOption.IsSet && workflowDefinitionStep.NextSteps == null)
                throw new ArgumentNullException(nameof(workflowDefinitionStep.NextSteps), "Property is required for class WorkflowDefinitionStep.");

            writer.WriteString("name", workflowDefinitionStep.Name);

            writer.WriteString("type", workflowDefinitionStep.Type);

            if (workflowDefinitionStep.IdOption.IsSet)
                writer.WriteString("id", workflowDefinitionStep.IdOption.Value!.Value);

            if (workflowDefinitionStep.ConfigOption.IsSet)
            {
                writer.WritePropertyName("config");
                JsonSerializer.Serialize(writer, workflowDefinitionStep.Config, jsonSerializerOptions);
            }
            if (workflowDefinitionStep.NextStepsOption.IsSet)
            {
                writer.WritePropertyName("nextSteps");
                JsonSerializer.Serialize(writer, workflowDefinitionStep.NextSteps, jsonSerializerOptions);
            }
            if (workflowDefinitionStep.IsInitialStepOption.IsSet)
                writer.WriteBoolean("isInitialStep", workflowDefinitionStep.IsInitialStepOption.Value!.Value);
        }
    }
}
