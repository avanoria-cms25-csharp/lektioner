using Infrastructure.Services;

var menuService = new MenuService(@"c:\data\test.json");

menuService.ShowMainMenu();