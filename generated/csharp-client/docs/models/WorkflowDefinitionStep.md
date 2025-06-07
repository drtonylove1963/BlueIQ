# BlueIQ.Sdk.Client.Model.WorkflowDefinitionStep

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Human-readable name for the step. | 
**Type** | **string** | Type of the step (e.g., &#39;manual_approval&#39;, &#39;automated_task&#39;, &#39;notification&#39;). | 
**Id** | **Guid** | Unique identifier for the step within the definition. | [optional] 
**Config** | **Dictionary&lt;string, Object&gt;** | Step-specific configuration parameters. | [optional] 
**NextSteps** | **List&lt;Guid&gt;** | List of IDs of the next possible steps in the workflow. | [optional] 
**IsInitialStep** | **bool** | Indicates if this is the starting step of the workflow. | [optional] [default to false]

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

