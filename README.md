# RoomAvability
This project, based on Raspberry 2 model B, Windows 10 IoT and Azure, is useful for build a box for show the avability of a room

for setup this project open the web.config (of the RoomAvabilityAPI project) and set

```
    <add key="RAusername" value=""/> <!--username of the user that can read data from excange -->
    <add key="RApassword" value=""/><!--password of the user that can read data from excange -->
    <add key="RoomName" value=""/> <!--Exchange room email address -->
```

setup the AzureAPI url in the file src\WebRuntime\RoomAvability\RoomAvabilityAPI\RoomAvabilityAPI.cs

```
	this._baseUri = new Uri(""); //TODO: Insert the API URL here
```
