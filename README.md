# git-event-tracking-hmo

There are two parts of the application, 
1. API
2. Web application.

Web application will call the API to perform the relevant actions. All the assumption about the solution is submitted in the answer where I gave provided the Git Repo Url.

To run the application, you need to do following steps:

1. Install visual studio 2019 (Community version will be fine) on your machine using link: https://visualstudio.microsoft.com/downloads/
2. After downloading the code from GitHub, go to the folder
3. Double click on file "GitEventTracking.sln" and open it with Visual Studio which you installed in Step 1
4. Once solution is open, right click on the project "GitEventTrackingApi" and click on option "Set as StartUp Project"
5. Using run (play) button, run the application.
6. It will open a swagger page in your browser. Url will look like https://localhost:5001/index.html
7. Now copy the domain part of your url (in my case, it will be https://localhost:5001/). We need to do this step because web application will call the API using this url.
8. Repeat the Step 4 again (Open solution file)
9. Expand projct "GitEventTracking.Web" and open appsettings.json file
10. In this file, **replace** the value of "APIUrl" domain with your domain. i.e. value of my APIUrl will look like: "APIUrl": "https://localhost:5001/api/"
11. Now right click on the "GitEventTracking.Web" and run it.
12. You will see the Git Event creation page.
13. You can fill in the information and click on submit, it will call the api and save the data in InMemoryDatabase.
14. To test the API toke authentication, stop the "GitEventTracking.Web" and in appsettings.json file of "GitEventTracking.Web", add some random text to the **ApiKey** value. 
15. Run the "GitEventTracking.Web" again, fill the form or click on "Find" button, you will see 401 Unauthorised access exception.
16. Once you test the token authentication, **revert** the key value to the correct one and run the application again.

**Run Unit and Integration Tests**
1. To run the Unit and Integration tests of the application, keep the above both solutions open.
2. Once again double click on file GitEventTracking.sln and open it again.
3. Expand projct "GitEventTracking.Web.IntegrationTest" and open appsettings.json file
4. Change the domain value to your web domain. (It must be your web domain not API). i.e. in my case, value is like "domain": "https://localhost:44333/". We need to do this step because integration tests are Behaviour Driven Development tests which are implement using selenium and SpecFlow. So, these tests need to open the website in Google Chrome browser and run the tests.
6. Open "Test Explorer" using Test menu option.
7. There is Fast play button which will run all the integration and unit tests for the application. All tests must be green like shown in picture below
8. ![image](https://user-images.githubusercontent.com/81446695/112899477-17b5e900-90da-11eb-98cc-9af763dbcf8a.png)
 
