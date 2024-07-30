namespace Portal.Conttracts.Authentication;

public record LoginRequest
(
    string Email,
    string Password
);
