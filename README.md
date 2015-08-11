A complete work flow app built using Entity framework 6, MVC5 Identity 2

This application will tell you

1) How to create a work order
2) How to promote a work order
3) How to certified the work order
4) How to reject a work order
5) How to Relinquish the work worder


You can also lean how to controle the concurrency using EF6 


How to run the application:

1) Just clone the repository
2) Add your smtp detail and Twilio detail in IdentityConfig.cs
3) If you want to use google sign in then add your ClientId and ClientSecret in Startup.Auth.cs
4)Open package manager console and type update-database -verbose
5) Viola! You are good to go.
