# JR22051936
This is a web Project (built in .net, opens in VS Code) that consumes a public API to provide facts about numbers. Customer may enter a number which could be a year or date. It could also be a random trivia fact!

Project structure (2 sub projects):
  1. Manulife.Demo.Web- Blazor server app (Blazor client is not suitable for small demo due to initial load time). Uses DI to load model to views. No direct API calls are made here. appsettings.json will hold configurable values. 
  2. Manulife.Demo.Library- Class library. All API calls are made here. Models and Services are available here and injected into the view (Demo.Web). 
  
  Please note some warnings are suppressed for this demo. Placeholders (eg. exception logging) and comments are used where applicable. Project does not include unit testing. 
