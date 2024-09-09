namespace BurgerToNightFunc.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class AuthorizeAttribute : Attribute
    {
        public string[] Roles { get; private set; }

        public AuthorizeAttribute(params string[] roles)
        {
            Roles = roles;
        }
    }
}
