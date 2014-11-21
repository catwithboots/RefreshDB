# Standard function for running queries to SQL Server, it will return a datatable object

Param
(
	[parameter(Position=1,mandatory=$true)] [string]$SqlServer,
	[parameter(Position=2,mandatory=$true)] [string]$SqlCatalog,
	[parameter(Position=3,mandatory=$true)] [string]$SqlQuery
)

TRY
{
	$SqlConnection = New-Object System.Data.SqlClient.SqlConnection
	$SqlConnection.ConnectionString = "Server = $SqlServer; Database = $SqlCatalog; Integrated Security = True; Application Name = .NET SQLClient Data Provider - RefreshDB Deployment"
	$SqlConnection.Open()

	$SqlCmd = New-Object System.Data.SqlClient.SqlCommand
	$SqlCmd.CommandText = $SqlQuery
	$SqlCmd.CommandTimeout = 120
	$SqlCmd.Connection = $SqlConnection

	$SqlAdapter = New-Object System.Data.SqlClient.SqlDataAdapter
	$SqlAdapter.SelectCommand = $SqlCmd

	$DataSet = New-Object System.Data.DataSet
	$SqlAdapter.Fill($DataSet) | Out-Null

	$SqlConnection.Close()

	$ResultSet=$DataSet.Tables[0]
}
CATCH
{
	$ErrorMessage=$Error[0].Exception ;
	Write-Host "Error in SQL connection:" $ErrorMessage.Message ;	
	exit (1)
}

return $ResultSet