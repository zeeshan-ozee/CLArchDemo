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
