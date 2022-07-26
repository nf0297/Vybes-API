# Vybes-API (Simple C# CRUD)
This repository is containing an API for Vybes Application. Vybes API is a simple CRUD API to check Items of Vybes

## Pre-requisites
- Visual Studio 2022 (the development of this API is using VS 2022 Enterprise Edition) 
https://visualstudio.microsoft.com/vs/
- Dbeaver 
https://dbeaver.io/download/

## Setup
- Dbeaver
1) Open Dbeaver and Right Click to Under Database Navigator to Create New Connection<br/>
![image](https://user-images.githubusercontent.com/58716824/181032649-11b77db0-2544-415c-bb6b-bcf408cd792d.png)<br/><br/>
2) Choose PostgreSQL<br/>
![image](https://user-images.githubusercontent.com/58716824/181033467-4f1ae6ba-5c14-4e04-8953-90882069823d.png)<br/><br/>
3) Create Database Data > Test Connection<br/>
![image](https://user-images.githubusercontent.com/58716824/181034143-4ea389b3-1cc8-4175-b526-13ff0ad63311.png)<br/><br/>
4) Finish the Process<br/>
![image](https://user-images.githubusercontent.com/58716824/181034483-d874e063-64b9-4111-86be-e5415145bcb3.png)<br/>
*If it's your first time then Dbeaver will ask to install some data, just let it do it<br/><br/>
5) Your database is set!<br/><br/>

- VS 2022
After you got your Database inside Dbeaver, you need to do:
1) Go to VybesContext > Change Db Config 
![image](https://user-images.githubusercontent.com/58716824/181036327-c30af11d-065a-4076-aa26-c1e60804a32d.png)
2) Go to launchSettings.json > Change Db Config
![image](https://user-images.githubusercontent.com/58716824/181036636-6cc8d4ad-f63f-412e-9e19-ceeef920f9e8.png)
3) Update your Dbeaver Db using Migration<br/>
Read here to install it: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
4) Just use the "Update-Database" Command for Visual Studio Package Manager or
5) use the "dotnet ef database update" for .NET Core CLI after installing them
*Don't need to use quotation mark
6) Check your Dbeaver and make sure the Table is created!
7) Launch the API!
![image](https://user-images.githubusercontent.com/58716824/181036777-5c102c0a-937a-476c-b635-2c0df4a467aa.png)

## Using the API

### Create - Get USER
You need to create User first before creating an Item, therefore:
1) Create User using POST Endpoint (It's supposed to be a Register API)
![image](https://user-images.githubusercontent.com/58716824/181037376-738e19a0-5bfa-4e54-a4ea-4601fb90dda6.png)
2) Fill the Version with "1" (without quotation mark)
3) Ignore the User if you're using User Endpoint, Fill with your User Id (you can look it up inside Dbeaver) for Items Endpoint
![image](https://user-images.githubusercontent.com/58716824/181037891-59a8e1e9-9693-468b-9e50-3127fa8bdff1.png)
4) Fill the rest of the Body > Execute
5) Check your User using GET Endpoint (It's supposed to be a Login API)
![image](https://user-images.githubusercontent.com/58716824/181038345-5e10d379-6055-4d72-b22d-a2fb4e3cdcf3.png)
*The user is created! now you can create Items

### Create - Get ITEMS
1) Create Items using POST Endpoint
2) Fill the Version with "1" (without quotation mark)
3) Insert your User Id after you Login into the User textbox
4) Fill the rest of the Body > Execute
![image](https://user-images.githubusercontent.com/58716824/181039139-7b3eef40-ba8e-4e9f-85b2-7ac3b6a06b22.png)
5) You can check the Items with GET Endpoint (It's supposed to be a GET API for Tables)
![image](https://user-images.githubusercontent.com/58716824/181039582-bb0d4ed4-1ee6-4741-8283-a32dfecb4b25.png)
*Don't forget to add User Id
6) You can also Delete and Create another Items or User at your choice



