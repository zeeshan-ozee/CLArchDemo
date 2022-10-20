public class GetTodoItemsListQuery : IRequest<TodoItemsListVm>
    public class GetTodoItemsListQueryHandler : IRequestHandler<GetTodoItemsListQuery, TodoItemsListVm> => handler return TodoItemsListVm
    {}

User
    UserId guid
    Name
    DOB
    Address
        guid
        userid 
        Postalcode
        Phone1
        Phone2
        CellPhone
        Fax
        Emai
        Address1
        Address2
        City
        State
        Zip
        Country

for generic repo use this => https://dev.to/moe23/step-by-step-repository-pattern-and-unit-of-work-with-asp-net-core-5-3l92


more ./abc.sln
dotnet sln add(ls -r **\*.csproj)


----
links used
https://www.youtube.com/watch?v=fhM0V2N1GpY&list=PLzYkqgWkHPKC-n4ehnzcgkHJxd7bC-8gW&index=2&ab_channel=AmichaiMantinband