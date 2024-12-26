﻿namespace Bookify.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(Domain.Users.Entities.Email recipient, string subject, string body);
}