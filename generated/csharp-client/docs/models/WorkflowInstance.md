# BlueIQ.Sdk.Client.Model.WorkflowInstance

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**WorkflowDefinitionId** | **Guid** | ID of the WorkflowDefinition this instance is based on. | 
**Status** | **string** | Current status of the workflow instance. | 
**Id** | **Guid** |  | [optional] [readonly] 
**WorkflowDefinitionVersion** | **string** | Version of the WorkflowDefinition used for this instance. | [optional] [readonly] 
**CurrentStepId** | **Guid** | ID of the current step the instance is waiting on or executing. | [optional] 
**Variables** | **Dictionary&lt;string, Object&gt;** | Key-value pairs of variables associated with this workflow instance. | [optional] 
**StartedAt** | **DateTime** |  | [optional] [readonly] 
**UpdatedAt** | **DateTime** |  | [optional] [readonly] 
**EndedAt** | **DateTime** |  | [optional] [readonly] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

