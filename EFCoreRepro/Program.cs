// See https://aka.ms/new-console-template for more information

using EFCoreRepro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

DbContextOptions<MMPContext> options = new DbContextOptionsBuilder<MMPContext>()
    .UseSqlServer(
        "Server=localhost,31433;Database=MMP;Encrypt=no;User Id=sa;Password=add6723e7b930c87e60add3b2aaee337f551d64c81c5a2246991bd0436e3da58!01")
    .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
    .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
    .EnableSensitiveDataLogging()
    .Options;
MMPContext context = new MMPContext(options);

Parent parentEntity = context.Parents.Add(new Parent(){Id = Guid.NewGuid()}).Entity;
context.Entry(parentEntity).State = EntityState.Added;
await context.SaveChangesAsync(CancellationToken.None);

Parent? parentEntity2 = await context.Parents.FindAsync(new object[] { parentEntity.Id }, CancellationToken.None);
parentEntity2.Children.Add(new Child(){Id = Guid.NewGuid(), ParentId = parentEntity2.Id});
await context.SaveChangesAsync(CancellationToken.None);
