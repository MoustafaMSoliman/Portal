namespace Portal.Conttracts.User.Management;

public record ChangeVacationStatusRequest
(
   Guid VacationId,
   Guid ManagerId,
   string NewStatus
);
