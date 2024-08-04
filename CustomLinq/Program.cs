
using CustomLinq;
using CustomLinq.Context;
using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
    .AddFilter("Microsoft.EntityFrameworkCore.Model.Validation", LogLevel.Error)
    .AddFilter("Microsoft.EntityFrameworkCore.Infrastructure", LogLevel.Error)
    .AddConsole();
});

var dbContext = new Context(loggerFactory);

var gmailUsers = dbContext.Users
    .Where(i => i.EmailAddress.EndsWith("gmail.com") && i.Id % 2==0)
    .ToList();
Console.WriteLine("GmailUsers count: {0}", gmailUsers.Count);


//var users = new List<UserModel>()
//{
//    new UserModel(){ Id=1, FirstName="Zozan", LastName="Y", EmailAddress="deneme@gmail.com"},
//    new UserModel(){ Id=2, FirstName="Zozan_", LastName="Y_"}
//};

//var linqUser = users
//    .Where(i => i.Id % 2 == 0)
//    .Where(i => i.EmailAddress.EndsWith("gmail.com"))
//    .ToList();

//var myLinqUser = users
//    .MyWhere_EvenId()
//    .MyWhere_GmailUsers()
//    .MyToList();


//var evenIdUsers = users.MyWhere_EvenId().MyToList().MyFirstOrDefault();

//var firstUser=users.FirstOrDefault();
//Console.WriteLine("First user name: {0}", firstUser.FirstName);
//Console.WriteLine("evenIdUsers Count: {0}", evenIdUsers.FirstName);

////var user=users.Where(x => x.FirstName == "Zozan").Select(x => x.FirstName);

Console.ReadLine();