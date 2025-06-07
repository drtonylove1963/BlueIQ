# BlueIQ.Sdk.Client.Model.WorkflowDefinition

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Human-readable name for the workflow definition. | 
**VarVersion** | **string** | Version of the workflow definition. | 
**Steps** | [**List&lt;WorkflowDefinitionStep&gt;**](WorkflowDefinitionStep.md) | The sequence of steps that define the workflow. | 
**Id** | **Guid** |  | [optional] [readonly] 
**Description** | **string** |  | [optional] 
**IsActive** | **bool** | Whether this workflow definition is currently active and can be used to start new instances. | [optional] [default to true]
**CreatedAt** | **DateTime** |  | [optional] [readonly] 
**UpdatedAt** | **DateTime** |  | [optional] [readonly] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

