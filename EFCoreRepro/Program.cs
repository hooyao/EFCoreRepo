// See https://aka.ms/new-console-template for more information

using EFCoreRepro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

DbContextOptions<MMPContext> options = new DbContextOptionsBuilder<MMPContext>()
    .UseSqlServer(
        "")
    .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
    .UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
    .EnableSensitiveDataLogging()
    .Options;
MMPContext context = new MMPContext(options);

Parent parentEntity = context.Parents.Add(new Parent(){ParentId = Guid.NewGuid(), Id = null}).Entity;
context.Entry(parentEntity).State = EntityState.Added;
await context.SaveChangesAsync(CancellationToken.None);

Parent? parentEntity2 = await context.Parents.FindAsync(new object[] { parentEntity.ParentId }, CancellationToken.None);
parentEntity2.Children.Add(new Child(){ChildId = Guid.NewGuid(), ParentId = parentEntity2.ParentId, Id = null});
await context.SaveChangesAsync(CancellationToken.None);
