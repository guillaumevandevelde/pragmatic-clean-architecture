using Microsoft.AspNetCore.Authorization;

namespace Bookify.Infrastructure.Authorization;

[AttributeUsage(AttributeTargets.Class)]

public sealed class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission);