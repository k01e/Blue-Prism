// Actions for interacting with the Azure Storage service
// I've found using code (for these actions) a lot easier than using the available APIs

// Uses Microsoft.Azure.Storage and Microsoft Azure.Storage.Blob libraries

//////////
// List Container
// Inputs: AZStorageAcctKey / text, AZStorageAcctName / text, containerPrefix / text
// Outputs: containerCollection / Collection

try
{
	var dataTable = new DataTable();
	dataTable.Columns.Add("Name", typeof(string));
	
	string prefix = null;
	
	if (!string.IsNullOrWhiteSpace(containerPrefix))
	{
		prefix = containerPrefix;
	}
	
	//Build Connection String
	string connectionString = $"DefaultEndpointsProtocol=https;AccountName={AZStorageAcctName};AccountKey={AZStorageAcctKey};EndpointSuffix=core.windows.net";
	
	//Get a reference to the storage account
	CloudStorageAccount sa = CloudStorageAccount.Parse(connectionString);
	CloudBlobClient bc = sa.CreateCloudBlobClient();
	
	//Get a reference to a sample container.
	var containers = bc.ListContainers(prefix, ContainerListingDetails.Metadata, null, null);
	
	foreach (var container in containers)
	{
		dataTable.Rows.Add(container.Name);
	}
	
	containerCollection = dataTable;
}
catch (StorageException e)
{
    throw new Exception($"A new exception - HTTP Error Code {e.RequestInformation.HttpStatusCode}: {e.RequestInformation.ErrorCode}. Message: {e.Message}");
}

//////////
// Create Container
// Inputs: AZStorageAcctKey / text, AZStorageAcctName / text, containerName / text

try
{
	//Build Connection String
	string connectionString = $"DefaultEndpointsProtocol=https;AccountName={AZStorageAcctName};AccountKey={AZStorageAcctKey};EndpointSuffix=core.windows.net";
	
	//Get a reference to the storage account
	CloudStorageAccount sa = CloudStorageAccount.Parse(connectionString);
	CloudBlobClient bc = sa.CreateCloudBlobClient();
	
	//Get a reference to a sample container.
	CloudBlobContainer container = bc.GetContainerReference(containerName);
	
	container.CreateIfNotExists();
}
catch (StorageException e)
{
    throw new Exception($"A new exception - HTTP Error Code {e.RequestInformation.HttpStatusCode}: {e.RequestInformation.ErrorCode}. Message: {e.Message}");
}

//////////
// Delete Container
// Inputs: AZStorageAcctKey / text, AZStorageAcctName / text, containerName / text

try
{
	//Build Connection String
	string connectionString = $"DefaultEndpointsProtocol=https;AccountName={AZStorageAcctName};AccountKey={AZStorageAcctKey};EndpointSuffix=core.windows.net";
	
	//Get a reference to the storage account
	CloudStorageAccount sa = CloudStorageAccount.Parse(connectionString);
	CloudBlobClient bc = sa.CreateCloudBlobClient();
	
	//Get a reference to a sample container.
	CloudBlobContainer container = bc.GetContainerReference(containerName);
	
	container.DeleteIfExists();
}
catch (StorageException e)
{
    throw new Exception($"A new exception - HTTP Error Code {e.RequestInformation.HttpStatusCode}: {e.RequestInformation.ErrorCode}. Message: {e.Message}");
}

//////////
// List Container Blobs
// Inputs: AZStorageAcctKey / text, AZStorageAcctName / text, containerName / text, blobPrefix / text
// Outputs: blobCollection / Collection

try
{
	var dataTable = new DataTable();
	dataTable.Columns.Add("Name", typeof(string));
	
	string prefix = null;
	
	if (!string.IsNullOrWhiteSpace(blobPrefix))
	{
		prefix = blobPrefix;
	}
	
	//Build Connection String
	string connectionString = $"DefaultEndpointsProtocol=https;AccountName={AZStorageAcctName};AccountKey={AZStorageAcctKey};EndpointSuffix=core.windows.net";
	
	//Get a reference to the storage account
	CloudStorageAccount sa = CloudStorageAccount.Parse(connectionString);
	CloudBlobClient bc = sa.CreateCloudBlobClient();
	
	//Get a reference to a sample container.
	CloudBlobContainer container = bc.GetContainerReference(containerName);
	
	var blobItems = container.ListBlobs(prefix);
				
	foreach (var blobItem in blobItems)
	{
		var blob = (CloudBlob)blobItem;
		dataTable.Rows.Add(blob.Name);
	}
	
	blobCollection = dataTable;
}
catch (StorageException e)
{
    throw new Exception($"A new exception - HTTP Error Code {e.RequestInformation.HttpStatusCode}: {e.RequestInformation.ErrorCode}. Message: {e.Message}");
}

//////////
// Upload Blob to Container
// Inputs: AZStorageAcctKey / text, AZStorageAcctName / text, containerName / text, fileName / text, file / file

try
{
	//Build Connection String
	string connectionString = $"DefaultEndpointsProtocol=https;AccountName={AZStorageAcctName};AccountKey={AZStorageAcctKey};EndpointSuffix=core.windows.net";
	
	//Get a reference to the storage account
	CloudStorageAccount sa = CloudStorageAccount.Parse(connectionString);
	CloudBlobClient bc = sa.CreateCloudBlobClient();
	
	//Get a reference to a sample container.
	CloudBlobContainer container = bc.GetContainerReference(containerName);
	
	container.CreateIfNotExists();
	
	CloudBlockBlob b = container.GetBlockBlobReference(fileName);
	
	b.UploadFromStream(new MemoryStream(file));
}
catch (StorageException e)
{
    throw new Exception($"A new exception - HTTP Error Code {e.RequestInformation.HttpStatusCode}: {e.RequestInformation.ErrorCode}. Message: {e.Message}");
}

//////////
// Delete Blob from Container
// Inputs: AZStorageAcctKey / text, AZStorageAcctName / text, containerName / text, blobName / text

try
{ 
    //Build Connection String
    string connectionString = $"DefaultEndpointsProtocol=https;AccountName={AZStorageAcctName};AccountKey={AZStorageAcctKey};EndpointSuffix=core.windows.net";

    //Get a reference to the storage account
    CloudStorageAccount sa = CloudStorageAccount.Parse(connectionString);
    CloudBlobClient bc = sa.CreateCloudBlobClient();

    //Get a reference to a sample container.
    CloudBlobContainer container = bc.GetContainerReference(containerName);

    CloudBlob b = container.GetBlobReference(blobName);

    b.DeleteIfExists();
    
}
catch (StorageException e)
{
    throw new Exception($"A new exception - HTTP Error Code {e.RequestInformation.HttpStatusCode}: {e.RequestInformation.ErrorCode}. Message: {e.Message}");
}

//////////
// Blob Exists?
// Inputs: AZStorageAcctKey / text, AZStorageAcctName / text, containerName / text, blobName / text
// Outputs: exists / flag

try
{
    //Build Connection String
    string connectionString = $"DefaultEndpointsProtocol=https;AccountName={AZStorageAcctName};AccountKey={AZStorageAcctKey};EndpointSuffix=core.windows.net";

    //Get a reference to the storage account
    CloudStorageAccount sa = CloudStorageAccount.Parse(connectionString);
    CloudBlobClient bc = sa.CreateCloudBlobClient();

    //Get a reference to a sample container.
    CloudBlobContainer container = bc.GetContainerReference(containerName);

    CloudBlob b = container.GetBlobReference(blobName);

    exists = b.Exists();

}
catch (StorageException e)
{
    throw new Exception($"A new exception - HTTP Error Code {e.RequestInformation.HttpStatusCode}: {e.RequestInformation.ErrorCode}. Message: {e.Message}");
}
