Generate the async client code
----------

From the article: https://msdn.microsoft.com/en-us/library/ms730059%28v=vs.100%29.aspx

Start the server, then, type this at the Visual Studio command line:

svcutil /n:net.tcp://JohnJesus.WcfAsync.Munger net.tcp://localhost:9999/service/mex /a /tcv:Version35

