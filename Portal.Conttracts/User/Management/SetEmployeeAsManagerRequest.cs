namespace Portal.Conttracts.User.Management;

public record SetEmployeeAsManagerRequest
(
    Guid AdminId,
    Guid EmployeeId
);
