using Microsoft.AspNetCore.Authorization;

namespace Bookify.Infrastructure.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission);
