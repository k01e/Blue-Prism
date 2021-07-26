' This is an update to the GetBody action to the stock actions "Utility - JSON"
' Instead of specifiying the finish range you can choose "0" and it'll grab the end of the range (Range.End)

' Inputs: handle / number, documentname / text, start / number, finish / number
' Outputs: result / text


Dim doc as Object = GetDocument(handle,documentname)
Dim range As Object
	
If finish = 0 Then
	finish = doc.Range.End
End If

range = doc.Range(start, finish)
   
result = range.text()