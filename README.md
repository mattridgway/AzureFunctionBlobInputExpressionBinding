# Blob Binding Function

[Azure Functions](https://azure.microsoft.com/en-gb/services/functions/) have both triggers and input bindings; Triggers define what causes a function to run, whereas input bindings define what data the function starts with. Using binding expressions, input bindings can reference properties from the trigger payload to dynamically create their binding. 

An example of where this would be useful would be where you have a message on an Azure service bus queue which contained the location of a blob which you needed to perform an action on. Without binding expressions you would need to write code within your function to create an Azure storage client and then download the blob. Along with making the code harder to write isolated tests for, it would also increase the execution time and therefore cost. Binding expressions remove this problem, and simply have the blob passed into the method.

## ARM Template

To create all the Azure resources necessary for this test you can use the included ARM template, this can be done using the following PowerShell:

```PowerShell
Login-AzureRmAccount
New-AzureRmResourceGroup -Name "TestResourceGroup" -Location "UK West"
New-AzureRmResourceGroupDeployment -ResourceGroupName "TestResourceGroup" -TemplateFile "build\armtemplate.json" -TemplateParameterFile "build\armtemplateparameters.json"
```

These resources can be cleaned up in one hit by removing just the resource group, rather than each individual resource. That can be done through PowerShell using:

```PowerShell
Remove-AzureRmResourceGroup -Name "TestResourceGroup"
```

## Links

* https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio
* https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings
* https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-class-library