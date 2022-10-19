namespace CLArch.Persistance;
public class Class1
{

}


// public class MyDbContext
// {

//     void SaveChangesAsync(CancellationToken token)
//     {
//         foreach (var item in changeTracker.Entries<AudittableEntity>())
//         {
//             switch (entry.State)
//             {
//                 case EntityState.Add:
//                     item.Entity.CreatedDate = _dateTime;
//                     item.Entity.CreatedBy = _appLoggedInUser;
//                 case EntityState.Modified:
//                     item.Entity.LastModified = _dateTime;
//             }

//             return base.SaveChangesAsync(token);
//         }
//     }

//     ovierride ovide OnModelCreating()
//     {
//         builder.ApplyConfigurationFromAssembly
//     }
// }