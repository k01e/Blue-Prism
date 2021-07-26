' This is an additional action to the stock actions "Utility - JSON"
' This new action exposes the JSON Path functions in Newtonsoft's JSON Library
' https://www.newtonsoft.com/json/help/html/QueryJsonSelectToken.htm

' I've also added the ability to pass in a "*" for the key array to pull back all matching values

' Inputs: json / text, jsonPath / text
' Outputs: result / collection

Dim jsonObject As JObject = JObject.Parse(json)

Dim jsonTokens As New List(Of JToken)()
jsonTokens = jsonObject.SelectTokens(jsonPath).ToList()

Dim column As String = jsonPath.Substring(jsonPath.LastIndexOf(".") + 1, jsonPath.Length - jsonPath.LastIndexOf(".") - 1)
result.Columns.Add(column, GetType(String))

For Each token As JToken In jsonTokens
	Dim row As DataRow = result.NewRow()
	row(column) = token.ToString

	result.Rows.Add(row)
Next