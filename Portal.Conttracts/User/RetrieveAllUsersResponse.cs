namespace Portal.Conttracts.User;

public record RetrieveAllUsersResponse
(
  List<UserResponse> Users  
);
public record UserResponse
    (int code,
   string FirstName,
   string LastName);