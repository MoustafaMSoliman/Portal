namespace Portal.Conttracts.User.Management;

public record SetEmployeeAsManagerResponse
(
  string AdminId,
  string ManagerId,
  string ManagerFirstName,
  string ManagerLastName
);